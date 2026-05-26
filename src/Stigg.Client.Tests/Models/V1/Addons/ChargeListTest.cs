using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class ChargeListTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargeList
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = ChargeListDataBillingCadence.Recurring,
                    BillingModel = ChargeListDataBillingModel.FlatFee,
                    BillingPeriod = ChargeListDataBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 0,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    CrmID = "crmId",
                    CrmLinkUrl = "crmLinkUrl",
                    FeatureID = "featureId",
                    MaxUnitQuantity = 0,
                    MinUnitQuantity = 0,
                    Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = ChargeListDataTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    UsedInSubscriptions = true,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        List<ChargeListData> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BillingCadence = ChargeListDataBillingCadence.Recurring,
                BillingModel = ChargeListDataBillingModel.FlatFee,
                BillingPeriod = ChargeListDataBillingPeriod.Monthly,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCountryCode = "billingCountryCode",
                BillingID = "billingId",
                BlockSize = 0,
                CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 0,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                CrmID = "crmId",
                CrmLinkUrl = "crmLinkUrl",
                FeatureID = "featureId",
                MaxUnitQuantity = 0,
                MinUnitQuantity = 0,
                Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
                TiersMode = ChargeListDataTiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                UsedInSubscriptions = true,
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargeList
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = ChargeListDataBillingCadence.Recurring,
                    BillingModel = ChargeListDataBillingModel.FlatFee,
                    BillingPeriod = ChargeListDataBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 0,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    CrmID = "crmId",
                    CrmLinkUrl = "crmLinkUrl",
                    FeatureID = "featureId",
                    MaxUnitQuantity = 0,
                    MinUnitQuantity = 0,
                    Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = ChargeListDataTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    UsedInSubscriptions = true,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeList>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargeList
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = ChargeListDataBillingCadence.Recurring,
                    BillingModel = ChargeListDataBillingModel.FlatFee,
                    BillingPeriod = ChargeListDataBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 0,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    CrmID = "crmId",
                    CrmLinkUrl = "crmLinkUrl",
                    FeatureID = "featureId",
                    MaxUnitQuantity = 0,
                    MinUnitQuantity = 0,
                    Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = ChargeListDataTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    UsedInSubscriptions = true,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeList>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ChargeListData> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BillingCadence = ChargeListDataBillingCadence.Recurring,
                BillingModel = ChargeListDataBillingModel.FlatFee,
                BillingPeriod = ChargeListDataBillingPeriod.Monthly,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCountryCode = "billingCountryCode",
                BillingID = "billingId",
                BlockSize = 0,
                CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
                CreditRate = new()
                {
                    Amount = 0,
                    CurrencyID = "currencyId",
                    CostFormula = "costFormula",
                },
                CrmID = "crmId",
                CrmLinkUrl = "crmLinkUrl",
                FeatureID = "featureId",
                MaxUnitQuantity = 0,
                MinUnitQuantity = 0,
                Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
                TiersMode = ChargeListDataTiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                UsedInSubscriptions = true,
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargeList
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = ChargeListDataBillingCadence.Recurring,
                    BillingModel = ChargeListDataBillingModel.FlatFee,
                    BillingPeriod = ChargeListDataBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 0,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    CrmID = "crmId",
                    CrmLinkUrl = "crmLinkUrl",
                    FeatureID = "featureId",
                    MaxUnitQuantity = 0,
                    MinUnitQuantity = 0,
                    Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = ChargeListDataTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    UsedInSubscriptions = true,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargeList
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = ChargeListDataBillingCadence.Recurring,
                    BillingModel = ChargeListDataBillingModel.FlatFee,
                    BillingPeriod = ChargeListDataBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
                    CreditRate = new()
                    {
                        Amount = 0,
                        CurrencyID = "currencyId",
                        CostFormula = "costFormula",
                    },
                    CrmID = "crmId",
                    CrmLinkUrl = "crmLinkUrl",
                    FeatureID = "featureId",
                    MaxUnitQuantity = 0,
                    MinUnitQuantity = 0,
                    Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = ChargeListDataTiersMode.Volume,
                    TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                    UsedInSubscriptions = true,
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        ChargeList copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeListDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            CrmID = "crmId",
            CrmLinkUrl = "crmLinkUrl",
            FeatureID = "featureId",
            MaxUnitQuantity = 0,
            MinUnitQuantity = 0,
            Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = ChargeListDataTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, ChargeListDataBillingCadence> expectedBillingCadence =
            ChargeListDataBillingCadence.Recurring;
        ApiEnum<string, ChargeListDataBillingModel> expectedBillingModel =
            ChargeListDataBillingModel.FlatFee;
        ApiEnum<string, ChargeListDataBillingPeriod> expectedBillingPeriod =
            ChargeListDataBillingPeriod.Monthly;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        double expectedBlockSize = 0;
        ApiEnum<string, ChargeListDataCreditGrantCadence> expectedCreditGrantCadence =
            ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod;
        ChargeListDataCreditRate expectedCreditRate = new()
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        string expectedCrmID = "crmId";
        string expectedCrmLinkUrl = "crmLinkUrl";
        string expectedFeatureID = "featureId";
        double expectedMaxUnitQuantity = 0;
        double expectedMinUnitQuantity = 0;
        ChargeListDataPrice expectedPrice = new()
        {
            Amount = 0,
            Currency = ChargeListDataPriceCurrency.Usd,
        };
        List<ChargeListDataTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];
        ApiEnum<string, ChargeListDataTiersMode> expectedTiersMode = ChargeListDataTiersMode.Volume;
        string expectedTopUpCustomCurrencyID = "topUpCustomCurrencyId";
        bool expectedUsedInSubscriptions = true;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillingCadence, model.BillingCadence);
        Assert.Equal(expectedBillingModel, model.BillingModel);
        Assert.Equal(expectedBillingPeriod, model.BillingPeriod);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedBillingCountryCode, model.BillingCountryCode);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedBlockSize, model.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, model.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, model.CreditRate);
        Assert.Equal(expectedCrmID, model.CrmID);
        Assert.Equal(expectedCrmLinkUrl, model.CrmLinkUrl);
        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedMaxUnitQuantity, model.MaxUnitQuantity);
        Assert.Equal(expectedMinUnitQuantity, model.MinUnitQuantity);
        Assert.Equal(expectedPrice, model.Price);
        Assert.NotNull(model.Tiers);
        Assert.Equal(expectedTiers.Count, model.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], model.Tiers[i]);
        }
        Assert.Equal(expectedTiersMode, model.TiersMode);
        Assert.Equal(expectedTopUpCustomCurrencyID, model.TopUpCustomCurrencyID);
        Assert.Equal(expectedUsedInSubscriptions, model.UsedInSubscriptions);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            CrmID = "crmId",
            CrmLinkUrl = "crmLinkUrl",
            FeatureID = "featureId",
            MaxUnitQuantity = 0,
            MinUnitQuantity = 0,
            Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = ChargeListDataTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            CrmID = "crmId",
            CrmLinkUrl = "crmLinkUrl",
            FeatureID = "featureId",
            MaxUnitQuantity = 0,
            MinUnitQuantity = 0,
            Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = ChargeListDataTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, ChargeListDataBillingCadence> expectedBillingCadence =
            ChargeListDataBillingCadence.Recurring;
        ApiEnum<string, ChargeListDataBillingModel> expectedBillingModel =
            ChargeListDataBillingModel.FlatFee;
        ApiEnum<string, ChargeListDataBillingPeriod> expectedBillingPeriod =
            ChargeListDataBillingPeriod.Monthly;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        double expectedBlockSize = 0;
        ApiEnum<string, ChargeListDataCreditGrantCadence> expectedCreditGrantCadence =
            ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod;
        ChargeListDataCreditRate expectedCreditRate = new()
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };
        string expectedCrmID = "crmId";
        string expectedCrmLinkUrl = "crmLinkUrl";
        string expectedFeatureID = "featureId";
        double expectedMaxUnitQuantity = 0;
        double expectedMinUnitQuantity = 0;
        ChargeListDataPrice expectedPrice = new()
        {
            Amount = 0,
            Currency = ChargeListDataPriceCurrency.Usd,
        };
        List<ChargeListDataTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];
        ApiEnum<string, ChargeListDataTiersMode> expectedTiersMode = ChargeListDataTiersMode.Volume;
        string expectedTopUpCustomCurrencyID = "topUpCustomCurrencyId";
        bool expectedUsedInSubscriptions = true;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBillingCadence, deserialized.BillingCadence);
        Assert.Equal(expectedBillingModel, deserialized.BillingModel);
        Assert.Equal(expectedBillingPeriod, deserialized.BillingPeriod);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedBillingCountryCode, deserialized.BillingCountryCode);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedBlockSize, deserialized.BlockSize);
        Assert.Equal(expectedCreditGrantCadence, deserialized.CreditGrantCadence);
        Assert.Equal(expectedCreditRate, deserialized.CreditRate);
        Assert.Equal(expectedCrmID, deserialized.CrmID);
        Assert.Equal(expectedCrmLinkUrl, deserialized.CrmLinkUrl);
        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedMaxUnitQuantity, deserialized.MaxUnitQuantity);
        Assert.Equal(expectedMinUnitQuantity, deserialized.MinUnitQuantity);
        Assert.Equal(expectedPrice, deserialized.Price);
        Assert.NotNull(deserialized.Tiers);
        Assert.Equal(expectedTiers.Count, deserialized.Tiers.Count);
        for (int i = 0; i < expectedTiers.Count; i++)
        {
            Assert.Equal(expectedTiers[i], deserialized.Tiers[i]);
        }
        Assert.Equal(expectedTiersMode, deserialized.TiersMode);
        Assert.Equal(expectedTopUpCustomCurrencyID, deserialized.TopUpCustomCurrencyID);
        Assert.Equal(expectedUsedInSubscriptions, deserialized.UsedInSubscriptions);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            CrmID = "crmId",
            CrmLinkUrl = "crmLinkUrl",
            FeatureID = "featureId",
            MaxUnitQuantity = 0,
            MinUnitQuantity = 0,
            Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = ChargeListDataTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.BillingCountryCode);
        Assert.False(model.RawData.ContainsKey("billingCountryCode"));
        Assert.Null(model.BillingID);
        Assert.False(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.BlockSize);
        Assert.False(model.RawData.ContainsKey("blockSize"));
        Assert.Null(model.CreditGrantCadence);
        Assert.False(model.RawData.ContainsKey("creditGrantCadence"));
        Assert.Null(model.CreditRate);
        Assert.False(model.RawData.ContainsKey("creditRate"));
        Assert.Null(model.CrmID);
        Assert.False(model.RawData.ContainsKey("crmId"));
        Assert.Null(model.CrmLinkUrl);
        Assert.False(model.RawData.ContainsKey("crmLinkUrl"));
        Assert.Null(model.FeatureID);
        Assert.False(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.MaxUnitQuantity);
        Assert.False(model.RawData.ContainsKey("maxUnitQuantity"));
        Assert.Null(model.MinUnitQuantity);
        Assert.False(model.RawData.ContainsKey("minUnitQuantity"));
        Assert.Null(model.Price);
        Assert.False(model.RawData.ContainsKey("price"));
        Assert.Null(model.Tiers);
        Assert.False(model.RawData.ContainsKey("tiers"));
        Assert.Null(model.TiersMode);
        Assert.False(model.RawData.ContainsKey("tiersMode"));
        Assert.Null(model.TopUpCustomCurrencyID);
        Assert.False(model.RawData.ContainsKey("topUpCustomCurrencyId"));
        Assert.Null(model.UsedInSubscriptions);
        Assert.False(model.RawData.ContainsKey("usedInSubscriptions"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            BillingCountryCode = null,
            BillingID = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            CrmID = null,
            CrmLinkUrl = null,
            FeatureID = null,
            MaxUnitQuantity = null,
            MinUnitQuantity = null,
            Price = null,
            Tiers = null,
            TiersMode = null,
            TopUpCustomCurrencyID = null,
            UsedInSubscriptions = null,
        };

        Assert.Null(model.BillingCountryCode);
        Assert.True(model.RawData.ContainsKey("billingCountryCode"));
        Assert.Null(model.BillingID);
        Assert.True(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.BlockSize);
        Assert.True(model.RawData.ContainsKey("blockSize"));
        Assert.Null(model.CreditGrantCadence);
        Assert.True(model.RawData.ContainsKey("creditGrantCadence"));
        Assert.Null(model.CreditRate);
        Assert.True(model.RawData.ContainsKey("creditRate"));
        Assert.Null(model.CrmID);
        Assert.True(model.RawData.ContainsKey("crmId"));
        Assert.Null(model.CrmLinkUrl);
        Assert.True(model.RawData.ContainsKey("crmLinkUrl"));
        Assert.Null(model.FeatureID);
        Assert.True(model.RawData.ContainsKey("featureId"));
        Assert.Null(model.MaxUnitQuantity);
        Assert.True(model.RawData.ContainsKey("maxUnitQuantity"));
        Assert.Null(model.MinUnitQuantity);
        Assert.True(model.RawData.ContainsKey("minUnitQuantity"));
        Assert.Null(model.Price);
        Assert.True(model.RawData.ContainsKey("price"));
        Assert.Null(model.Tiers);
        Assert.True(model.RawData.ContainsKey("tiers"));
        Assert.Null(model.TiersMode);
        Assert.True(model.RawData.ContainsKey("tiersMode"));
        Assert.Null(model.TopUpCustomCurrencyID);
        Assert.True(model.RawData.ContainsKey("topUpCustomCurrencyId"));
        Assert.Null(model.UsedInSubscriptions);
        Assert.True(model.RawData.ContainsKey("usedInSubscriptions"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            BillingCountryCode = null,
            BillingID = null,
            BlockSize = null,
            CreditGrantCadence = null,
            CreditRate = null,
            CrmID = null,
            CrmLinkUrl = null,
            FeatureID = null,
            MaxUnitQuantity = null,
            MinUnitQuantity = null,
            Price = null,
            Tiers = null,
            TiersMode = null,
            TopUpCustomCurrencyID = null,
            UsedInSubscriptions = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargeListData
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = ChargeListDataBillingCadence.Recurring,
            BillingModel = ChargeListDataBillingModel.FlatFee,
            BillingPeriod = ChargeListDataBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod,
            CreditRate = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CostFormula = "costFormula",
            },
            CrmID = "crmId",
            CrmLinkUrl = "crmLinkUrl",
            FeatureID = "featureId",
            MaxUnitQuantity = 0,
            MinUnitQuantity = 0,
            Price = new() { Amount = 0, Currency = ChargeListDataPriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = ChargeListDataTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = ChargeListDataTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        ChargeListData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeListDataBillingCadenceTest : TestBase
{
    [Theory]
    [InlineData(ChargeListDataBillingCadence.Recurring)]
    [InlineData(ChargeListDataBillingCadence.OneOff)]
    public void Validation_Works(ChargeListDataBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataBillingCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeListDataBillingCadence.Recurring)]
    [InlineData(ChargeListDataBillingCadence.OneOff)]
    public void SerializationRoundtrip_Works(ChargeListDataBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataBillingCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargeListDataBillingModelTest : TestBase
{
    [Theory]
    [InlineData(ChargeListDataBillingModel.FlatFee)]
    [InlineData(ChargeListDataBillingModel.MinimumSpend)]
    [InlineData(ChargeListDataBillingModel.PerUnit)]
    [InlineData(ChargeListDataBillingModel.UsageBased)]
    [InlineData(ChargeListDataBillingModel.CreditBased)]
    public void Validation_Works(ChargeListDataBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataBillingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeListDataBillingModel.FlatFee)]
    [InlineData(ChargeListDataBillingModel.MinimumSpend)]
    [InlineData(ChargeListDataBillingModel.PerUnit)]
    [InlineData(ChargeListDataBillingModel.UsageBased)]
    [InlineData(ChargeListDataBillingModel.CreditBased)]
    public void SerializationRoundtrip_Works(ChargeListDataBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataBillingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingModel>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingModel>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChargeListDataBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(ChargeListDataBillingPeriod.Monthly)]
    [InlineData(ChargeListDataBillingPeriod.Annually)]
    public void Validation_Works(ChargeListDataBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeListDataBillingPeriod.Monthly)]
    [InlineData(ChargeListDataBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(ChargeListDataBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataBillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChargeListDataCreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(ChargeListDataCreditGrantCadence.Monthly)]
    public void Validation_Works(ChargeListDataCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataCreditGrantCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataCreditGrantCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeListDataCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(ChargeListDataCreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(ChargeListDataCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataCreditGrantCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataCreditGrantCadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargeListDataCreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargeListDataCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        double expectedAmount = 0;
        string expectedCurrencyID = "currencyId";
        string expectedCostFormula = "costFormula";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCostFormula, model.CostFormula);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargeListDataCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataCreditRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargeListDataCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataCreditRate>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedCurrencyID = "currencyId";
        string expectedCostFormula = "costFormula";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCostFormula, deserialized.CostFormula);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargeListDataCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargeListDataCreditRate { Amount = 0, CurrencyID = "currencyId" };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargeListDataCreditRate { Amount = 0, CurrencyID = "currencyId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChargeListDataCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",

            CostFormula = null,
        };

        Assert.Null(model.CostFormula);
        Assert.True(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargeListDataCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",

            CostFormula = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargeListDataCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        ChargeListDataCreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeListDataPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargeListDataPrice
        {
            Amount = 0,
            Currency = ChargeListDataPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, ChargeListDataPriceCurrency> expectedCurrency =
            ChargeListDataPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargeListDataPrice
        {
            Amount = 0,
            Currency = ChargeListDataPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargeListDataPrice
        {
            Amount = 0,
            Currency = ChargeListDataPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, ChargeListDataPriceCurrency> expectedCurrency =
            ChargeListDataPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargeListDataPrice
        {
            Amount = 0,
            Currency = ChargeListDataPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargeListDataPrice
        {
            Amount = 0,
            Currency = ChargeListDataPriceCurrency.Usd,
        };

        ChargeListDataPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeListDataPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(ChargeListDataPriceCurrency.Usd)]
    [InlineData(ChargeListDataPriceCurrency.Aed)]
    [InlineData(ChargeListDataPriceCurrency.All)]
    [InlineData(ChargeListDataPriceCurrency.Amd)]
    [InlineData(ChargeListDataPriceCurrency.Ang)]
    [InlineData(ChargeListDataPriceCurrency.Aud)]
    [InlineData(ChargeListDataPriceCurrency.Awg)]
    [InlineData(ChargeListDataPriceCurrency.Azn)]
    [InlineData(ChargeListDataPriceCurrency.Bam)]
    [InlineData(ChargeListDataPriceCurrency.Bbd)]
    [InlineData(ChargeListDataPriceCurrency.Bdt)]
    [InlineData(ChargeListDataPriceCurrency.Bgn)]
    [InlineData(ChargeListDataPriceCurrency.Bif)]
    [InlineData(ChargeListDataPriceCurrency.Bmd)]
    [InlineData(ChargeListDataPriceCurrency.Bnd)]
    [InlineData(ChargeListDataPriceCurrency.Bsd)]
    [InlineData(ChargeListDataPriceCurrency.Bwp)]
    [InlineData(ChargeListDataPriceCurrency.Byn)]
    [InlineData(ChargeListDataPriceCurrency.Bzd)]
    [InlineData(ChargeListDataPriceCurrency.Brl)]
    [InlineData(ChargeListDataPriceCurrency.Cad)]
    [InlineData(ChargeListDataPriceCurrency.Cdf)]
    [InlineData(ChargeListDataPriceCurrency.Chf)]
    [InlineData(ChargeListDataPriceCurrency.Cny)]
    [InlineData(ChargeListDataPriceCurrency.Czk)]
    [InlineData(ChargeListDataPriceCurrency.Dkk)]
    [InlineData(ChargeListDataPriceCurrency.Dop)]
    [InlineData(ChargeListDataPriceCurrency.Dzd)]
    [InlineData(ChargeListDataPriceCurrency.Egp)]
    [InlineData(ChargeListDataPriceCurrency.Etb)]
    [InlineData(ChargeListDataPriceCurrency.Eur)]
    [InlineData(ChargeListDataPriceCurrency.Fjd)]
    [InlineData(ChargeListDataPriceCurrency.Gbp)]
    [InlineData(ChargeListDataPriceCurrency.Gel)]
    [InlineData(ChargeListDataPriceCurrency.Gip)]
    [InlineData(ChargeListDataPriceCurrency.Gmd)]
    [InlineData(ChargeListDataPriceCurrency.Gyd)]
    [InlineData(ChargeListDataPriceCurrency.Hkd)]
    [InlineData(ChargeListDataPriceCurrency.Hrk)]
    [InlineData(ChargeListDataPriceCurrency.Htg)]
    [InlineData(ChargeListDataPriceCurrency.Idr)]
    [InlineData(ChargeListDataPriceCurrency.Ils)]
    [InlineData(ChargeListDataPriceCurrency.Inr)]
    [InlineData(ChargeListDataPriceCurrency.Isk)]
    [InlineData(ChargeListDataPriceCurrency.Jmd)]
    [InlineData(ChargeListDataPriceCurrency.Jpy)]
    [InlineData(ChargeListDataPriceCurrency.Kes)]
    [InlineData(ChargeListDataPriceCurrency.Kgs)]
    [InlineData(ChargeListDataPriceCurrency.Khr)]
    [InlineData(ChargeListDataPriceCurrency.Kmf)]
    [InlineData(ChargeListDataPriceCurrency.Krw)]
    [InlineData(ChargeListDataPriceCurrency.Kyd)]
    [InlineData(ChargeListDataPriceCurrency.Kzt)]
    [InlineData(ChargeListDataPriceCurrency.Lbp)]
    [InlineData(ChargeListDataPriceCurrency.Lkr)]
    [InlineData(ChargeListDataPriceCurrency.Lrd)]
    [InlineData(ChargeListDataPriceCurrency.Lsl)]
    [InlineData(ChargeListDataPriceCurrency.Mad)]
    [InlineData(ChargeListDataPriceCurrency.Mdl)]
    [InlineData(ChargeListDataPriceCurrency.Mga)]
    [InlineData(ChargeListDataPriceCurrency.Mkd)]
    [InlineData(ChargeListDataPriceCurrency.Mmk)]
    [InlineData(ChargeListDataPriceCurrency.Mnt)]
    [InlineData(ChargeListDataPriceCurrency.Mop)]
    [InlineData(ChargeListDataPriceCurrency.Mro)]
    [InlineData(ChargeListDataPriceCurrency.Mvr)]
    [InlineData(ChargeListDataPriceCurrency.Mwk)]
    [InlineData(ChargeListDataPriceCurrency.Mxn)]
    [InlineData(ChargeListDataPriceCurrency.Myr)]
    [InlineData(ChargeListDataPriceCurrency.Mzn)]
    [InlineData(ChargeListDataPriceCurrency.Nad)]
    [InlineData(ChargeListDataPriceCurrency.Ngn)]
    [InlineData(ChargeListDataPriceCurrency.Nok)]
    [InlineData(ChargeListDataPriceCurrency.Npr)]
    [InlineData(ChargeListDataPriceCurrency.Nzd)]
    [InlineData(ChargeListDataPriceCurrency.Pgk)]
    [InlineData(ChargeListDataPriceCurrency.Php)]
    [InlineData(ChargeListDataPriceCurrency.Pkr)]
    [InlineData(ChargeListDataPriceCurrency.Pln)]
    [InlineData(ChargeListDataPriceCurrency.Qar)]
    [InlineData(ChargeListDataPriceCurrency.Ron)]
    [InlineData(ChargeListDataPriceCurrency.Rsd)]
    [InlineData(ChargeListDataPriceCurrency.Rub)]
    [InlineData(ChargeListDataPriceCurrency.Rwf)]
    [InlineData(ChargeListDataPriceCurrency.Sar)]
    [InlineData(ChargeListDataPriceCurrency.Sbd)]
    [InlineData(ChargeListDataPriceCurrency.Scr)]
    [InlineData(ChargeListDataPriceCurrency.Sek)]
    [InlineData(ChargeListDataPriceCurrency.Sgd)]
    [InlineData(ChargeListDataPriceCurrency.Sle)]
    [InlineData(ChargeListDataPriceCurrency.Sll)]
    [InlineData(ChargeListDataPriceCurrency.Sos)]
    [InlineData(ChargeListDataPriceCurrency.Szl)]
    [InlineData(ChargeListDataPriceCurrency.Thb)]
    [InlineData(ChargeListDataPriceCurrency.Tjs)]
    [InlineData(ChargeListDataPriceCurrency.Top)]
    [InlineData(ChargeListDataPriceCurrency.Try)]
    [InlineData(ChargeListDataPriceCurrency.Ttd)]
    [InlineData(ChargeListDataPriceCurrency.Tzs)]
    [InlineData(ChargeListDataPriceCurrency.Uah)]
    [InlineData(ChargeListDataPriceCurrency.Uzs)]
    [InlineData(ChargeListDataPriceCurrency.Vnd)]
    [InlineData(ChargeListDataPriceCurrency.Vuv)]
    [InlineData(ChargeListDataPriceCurrency.Wst)]
    [InlineData(ChargeListDataPriceCurrency.Xaf)]
    [InlineData(ChargeListDataPriceCurrency.Xcd)]
    [InlineData(ChargeListDataPriceCurrency.Yer)]
    [InlineData(ChargeListDataPriceCurrency.Zar)]
    [InlineData(ChargeListDataPriceCurrency.Zmw)]
    [InlineData(ChargeListDataPriceCurrency.Clp)]
    [InlineData(ChargeListDataPriceCurrency.Djf)]
    [InlineData(ChargeListDataPriceCurrency.Gnf)]
    [InlineData(ChargeListDataPriceCurrency.Ugx)]
    [InlineData(ChargeListDataPriceCurrency.Pyg)]
    [InlineData(ChargeListDataPriceCurrency.Xof)]
    [InlineData(ChargeListDataPriceCurrency.Xpf)]
    public void Validation_Works(ChargeListDataPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeListDataPriceCurrency.Usd)]
    [InlineData(ChargeListDataPriceCurrency.Aed)]
    [InlineData(ChargeListDataPriceCurrency.All)]
    [InlineData(ChargeListDataPriceCurrency.Amd)]
    [InlineData(ChargeListDataPriceCurrency.Ang)]
    [InlineData(ChargeListDataPriceCurrency.Aud)]
    [InlineData(ChargeListDataPriceCurrency.Awg)]
    [InlineData(ChargeListDataPriceCurrency.Azn)]
    [InlineData(ChargeListDataPriceCurrency.Bam)]
    [InlineData(ChargeListDataPriceCurrency.Bbd)]
    [InlineData(ChargeListDataPriceCurrency.Bdt)]
    [InlineData(ChargeListDataPriceCurrency.Bgn)]
    [InlineData(ChargeListDataPriceCurrency.Bif)]
    [InlineData(ChargeListDataPriceCurrency.Bmd)]
    [InlineData(ChargeListDataPriceCurrency.Bnd)]
    [InlineData(ChargeListDataPriceCurrency.Bsd)]
    [InlineData(ChargeListDataPriceCurrency.Bwp)]
    [InlineData(ChargeListDataPriceCurrency.Byn)]
    [InlineData(ChargeListDataPriceCurrency.Bzd)]
    [InlineData(ChargeListDataPriceCurrency.Brl)]
    [InlineData(ChargeListDataPriceCurrency.Cad)]
    [InlineData(ChargeListDataPriceCurrency.Cdf)]
    [InlineData(ChargeListDataPriceCurrency.Chf)]
    [InlineData(ChargeListDataPriceCurrency.Cny)]
    [InlineData(ChargeListDataPriceCurrency.Czk)]
    [InlineData(ChargeListDataPriceCurrency.Dkk)]
    [InlineData(ChargeListDataPriceCurrency.Dop)]
    [InlineData(ChargeListDataPriceCurrency.Dzd)]
    [InlineData(ChargeListDataPriceCurrency.Egp)]
    [InlineData(ChargeListDataPriceCurrency.Etb)]
    [InlineData(ChargeListDataPriceCurrency.Eur)]
    [InlineData(ChargeListDataPriceCurrency.Fjd)]
    [InlineData(ChargeListDataPriceCurrency.Gbp)]
    [InlineData(ChargeListDataPriceCurrency.Gel)]
    [InlineData(ChargeListDataPriceCurrency.Gip)]
    [InlineData(ChargeListDataPriceCurrency.Gmd)]
    [InlineData(ChargeListDataPriceCurrency.Gyd)]
    [InlineData(ChargeListDataPriceCurrency.Hkd)]
    [InlineData(ChargeListDataPriceCurrency.Hrk)]
    [InlineData(ChargeListDataPriceCurrency.Htg)]
    [InlineData(ChargeListDataPriceCurrency.Idr)]
    [InlineData(ChargeListDataPriceCurrency.Ils)]
    [InlineData(ChargeListDataPriceCurrency.Inr)]
    [InlineData(ChargeListDataPriceCurrency.Isk)]
    [InlineData(ChargeListDataPriceCurrency.Jmd)]
    [InlineData(ChargeListDataPriceCurrency.Jpy)]
    [InlineData(ChargeListDataPriceCurrency.Kes)]
    [InlineData(ChargeListDataPriceCurrency.Kgs)]
    [InlineData(ChargeListDataPriceCurrency.Khr)]
    [InlineData(ChargeListDataPriceCurrency.Kmf)]
    [InlineData(ChargeListDataPriceCurrency.Krw)]
    [InlineData(ChargeListDataPriceCurrency.Kyd)]
    [InlineData(ChargeListDataPriceCurrency.Kzt)]
    [InlineData(ChargeListDataPriceCurrency.Lbp)]
    [InlineData(ChargeListDataPriceCurrency.Lkr)]
    [InlineData(ChargeListDataPriceCurrency.Lrd)]
    [InlineData(ChargeListDataPriceCurrency.Lsl)]
    [InlineData(ChargeListDataPriceCurrency.Mad)]
    [InlineData(ChargeListDataPriceCurrency.Mdl)]
    [InlineData(ChargeListDataPriceCurrency.Mga)]
    [InlineData(ChargeListDataPriceCurrency.Mkd)]
    [InlineData(ChargeListDataPriceCurrency.Mmk)]
    [InlineData(ChargeListDataPriceCurrency.Mnt)]
    [InlineData(ChargeListDataPriceCurrency.Mop)]
    [InlineData(ChargeListDataPriceCurrency.Mro)]
    [InlineData(ChargeListDataPriceCurrency.Mvr)]
    [InlineData(ChargeListDataPriceCurrency.Mwk)]
    [InlineData(ChargeListDataPriceCurrency.Mxn)]
    [InlineData(ChargeListDataPriceCurrency.Myr)]
    [InlineData(ChargeListDataPriceCurrency.Mzn)]
    [InlineData(ChargeListDataPriceCurrency.Nad)]
    [InlineData(ChargeListDataPriceCurrency.Ngn)]
    [InlineData(ChargeListDataPriceCurrency.Nok)]
    [InlineData(ChargeListDataPriceCurrency.Npr)]
    [InlineData(ChargeListDataPriceCurrency.Nzd)]
    [InlineData(ChargeListDataPriceCurrency.Pgk)]
    [InlineData(ChargeListDataPriceCurrency.Php)]
    [InlineData(ChargeListDataPriceCurrency.Pkr)]
    [InlineData(ChargeListDataPriceCurrency.Pln)]
    [InlineData(ChargeListDataPriceCurrency.Qar)]
    [InlineData(ChargeListDataPriceCurrency.Ron)]
    [InlineData(ChargeListDataPriceCurrency.Rsd)]
    [InlineData(ChargeListDataPriceCurrency.Rub)]
    [InlineData(ChargeListDataPriceCurrency.Rwf)]
    [InlineData(ChargeListDataPriceCurrency.Sar)]
    [InlineData(ChargeListDataPriceCurrency.Sbd)]
    [InlineData(ChargeListDataPriceCurrency.Scr)]
    [InlineData(ChargeListDataPriceCurrency.Sek)]
    [InlineData(ChargeListDataPriceCurrency.Sgd)]
    [InlineData(ChargeListDataPriceCurrency.Sle)]
    [InlineData(ChargeListDataPriceCurrency.Sll)]
    [InlineData(ChargeListDataPriceCurrency.Sos)]
    [InlineData(ChargeListDataPriceCurrency.Szl)]
    [InlineData(ChargeListDataPriceCurrency.Thb)]
    [InlineData(ChargeListDataPriceCurrency.Tjs)]
    [InlineData(ChargeListDataPriceCurrency.Top)]
    [InlineData(ChargeListDataPriceCurrency.Try)]
    [InlineData(ChargeListDataPriceCurrency.Ttd)]
    [InlineData(ChargeListDataPriceCurrency.Tzs)]
    [InlineData(ChargeListDataPriceCurrency.Uah)]
    [InlineData(ChargeListDataPriceCurrency.Uzs)]
    [InlineData(ChargeListDataPriceCurrency.Vnd)]
    [InlineData(ChargeListDataPriceCurrency.Vuv)]
    [InlineData(ChargeListDataPriceCurrency.Wst)]
    [InlineData(ChargeListDataPriceCurrency.Xaf)]
    [InlineData(ChargeListDataPriceCurrency.Xcd)]
    [InlineData(ChargeListDataPriceCurrency.Yer)]
    [InlineData(ChargeListDataPriceCurrency.Zar)]
    [InlineData(ChargeListDataPriceCurrency.Zmw)]
    [InlineData(ChargeListDataPriceCurrency.Clp)]
    [InlineData(ChargeListDataPriceCurrency.Djf)]
    [InlineData(ChargeListDataPriceCurrency.Gnf)]
    [InlineData(ChargeListDataPriceCurrency.Ugx)]
    [InlineData(ChargeListDataPriceCurrency.Pyg)]
    [InlineData(ChargeListDataPriceCurrency.Xof)]
    [InlineData(ChargeListDataPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(ChargeListDataPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataPriceCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataPriceCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ChargeListDataTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargeListDataTier
        {
            FlatPrice = new() { Amount = 0, Currency = ChargeListDataTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = ChargeListDataTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        ChargeListDataTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
        };
        ChargeListDataTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargeListDataTier
        {
            FlatPrice = new() { Amount = 0, Currency = ChargeListDataTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = ChargeListDataTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargeListDataTier
        {
            FlatPrice = new() { Amount = 0, Currency = ChargeListDataTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = ChargeListDataTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ChargeListDataTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
        };
        ChargeListDataTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargeListDataTier
        {
            FlatPrice = new() { Amount = 0, Currency = ChargeListDataTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = ChargeListDataTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ChargeListDataTier { };

        Assert.Null(model.FlatPrice);
        Assert.False(model.RawData.ContainsKey("flatPrice"));
        Assert.Null(model.UnitPrice);
        Assert.False(model.RawData.ContainsKey("unitPrice"));
        Assert.Null(model.UpTo);
        Assert.False(model.RawData.ContainsKey("upTo"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ChargeListDataTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ChargeListDataTier
        {
            FlatPrice = null,
            UnitPrice = null,
            UpTo = null,
        };

        Assert.Null(model.FlatPrice);
        Assert.True(model.RawData.ContainsKey("flatPrice"));
        Assert.Null(model.UnitPrice);
        Assert.True(model.RawData.ContainsKey("unitPrice"));
        Assert.Null(model.UpTo);
        Assert.True(model.RawData.ContainsKey("upTo"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ChargeListDataTier
        {
            FlatPrice = null,
            UnitPrice = null,
            UpTo = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargeListDataTier
        {
            FlatPrice = new() { Amount = 0, Currency = ChargeListDataTierFlatPriceCurrency.Usd },
            UnitPrice = new() { Amount = 0, Currency = ChargeListDataTierUnitPriceCurrency.Usd },
            UpTo = 0,
        };

        ChargeListDataTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeListDataTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargeListDataTierFlatPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, ChargeListDataTierFlatPriceCurrency> expectedCurrency =
            ChargeListDataTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargeListDataTierFlatPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataTierFlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargeListDataTierFlatPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataTierFlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, ChargeListDataTierFlatPriceCurrency> expectedCurrency =
            ChargeListDataTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargeListDataTierFlatPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargeListDataTierFlatPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierFlatPriceCurrency.Usd,
        };

        ChargeListDataTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeListDataTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Usd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Aed)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.All)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Amd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ang)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Aud)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Awg)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Azn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bam)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bbd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bdt)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bgn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bif)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bmd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bnd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bsd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bwp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Byn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bzd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Brl)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Cad)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Cdf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Chf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Cny)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Czk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Dkk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Dop)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Dzd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Egp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Etb)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Eur)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Fjd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gbp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gel)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gip)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gmd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gyd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Hkd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Hrk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Htg)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Idr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ils)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Inr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Isk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Jmd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Jpy)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kes)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kgs)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Khr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kmf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Krw)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kyd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kzt)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Lbp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Lkr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Lrd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Lsl)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mad)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mdl)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mga)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mkd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mmk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mnt)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mop)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mro)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mvr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mwk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mxn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Myr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mzn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Nad)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ngn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Nok)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Npr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Nzd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Pgk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Php)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Pkr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Pln)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Qar)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ron)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Rsd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Rub)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Rwf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sar)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sbd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Scr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sek)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sgd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sle)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sll)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sos)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Szl)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Thb)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Tjs)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Top)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Try)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ttd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Tzs)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Uah)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Uzs)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Vnd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Vuv)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Wst)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Xaf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Xcd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Yer)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Zar)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Zmw)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Clp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Djf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gnf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ugx)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Pyg)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Xof)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(ChargeListDataTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataTierFlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Usd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Aed)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.All)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Amd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ang)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Aud)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Awg)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Azn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bam)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bbd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bdt)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bgn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bif)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bmd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bnd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bsd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bwp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Byn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Bzd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Brl)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Cad)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Cdf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Chf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Cny)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Czk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Dkk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Dop)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Dzd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Egp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Etb)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Eur)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Fjd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gbp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gel)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gip)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gmd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gyd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Hkd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Hrk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Htg)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Idr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ils)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Inr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Isk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Jmd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Jpy)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kes)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kgs)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Khr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kmf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Krw)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kyd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Kzt)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Lbp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Lkr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Lrd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Lsl)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mad)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mdl)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mga)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mkd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mmk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mnt)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mop)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mro)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mvr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mwk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mxn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Myr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Mzn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Nad)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ngn)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Nok)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Npr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Nzd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Pgk)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Php)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Pkr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Pln)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Qar)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ron)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Rsd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Rub)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Rwf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sar)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sbd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Scr)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sek)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sgd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sle)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sll)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Sos)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Szl)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Thb)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Tjs)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Top)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Try)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ttd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Tzs)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Uah)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Uzs)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Vnd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Vuv)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Wst)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Xaf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Xcd)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Yer)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Zar)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Zmw)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Clp)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Djf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Gnf)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Ugx)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Pyg)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Xof)]
    [InlineData(ChargeListDataTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(ChargeListDataTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataTierFlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargeListDataTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ChargeListDataTierUnitPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, ChargeListDataTierUnitPriceCurrency> expectedCurrency =
            ChargeListDataTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ChargeListDataTierUnitPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataTierUnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ChargeListDataTierUnitPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ChargeListDataTierUnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, ChargeListDataTierUnitPriceCurrency> expectedCurrency =
            ChargeListDataTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ChargeListDataTierUnitPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ChargeListDataTierUnitPrice
        {
            Amount = 0,
            Currency = ChargeListDataTierUnitPriceCurrency.Usd,
        };

        ChargeListDataTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ChargeListDataTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Usd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Aed)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.All)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Amd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ang)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Aud)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Awg)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Azn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bam)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bbd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bdt)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bgn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bif)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bmd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bnd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bsd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bwp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Byn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bzd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Brl)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Cad)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Cdf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Chf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Cny)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Czk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Dkk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Dop)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Dzd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Egp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Etb)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Eur)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Fjd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gbp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gel)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gip)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gmd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gyd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Hkd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Hrk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Htg)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Idr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ils)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Inr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Isk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Jmd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Jpy)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kes)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kgs)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Khr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kmf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Krw)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kyd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kzt)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Lbp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Lkr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Lrd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Lsl)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mad)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mdl)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mga)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mkd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mmk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mnt)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mop)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mro)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mvr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mwk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mxn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Myr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mzn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Nad)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ngn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Nok)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Npr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Nzd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Pgk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Php)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Pkr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Pln)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Qar)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ron)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Rsd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Rub)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Rwf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sar)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sbd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Scr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sek)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sgd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sle)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sll)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sos)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Szl)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Thb)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Tjs)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Top)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Try)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ttd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Tzs)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Uah)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Uzs)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Vnd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Vuv)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Wst)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Xaf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Xcd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Yer)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Zar)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Zmw)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Clp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Djf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gnf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ugx)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Pyg)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Xof)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(ChargeListDataTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataTierUnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Usd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Aed)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.All)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Amd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ang)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Aud)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Awg)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Azn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bam)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bbd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bdt)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bgn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bif)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bmd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bnd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bsd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bwp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Byn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Bzd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Brl)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Cad)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Cdf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Chf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Cny)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Czk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Dkk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Dop)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Dzd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Egp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Etb)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Eur)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Fjd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gbp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gel)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gip)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gmd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gyd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Hkd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Hrk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Htg)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Idr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ils)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Inr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Isk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Jmd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Jpy)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kes)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kgs)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Khr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kmf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Krw)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kyd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Kzt)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Lbp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Lkr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Lrd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Lsl)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mad)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mdl)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mga)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mkd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mmk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mnt)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mop)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mro)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mvr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mwk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mxn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Myr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Mzn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Nad)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ngn)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Nok)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Npr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Nzd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Pgk)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Php)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Pkr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Pln)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Qar)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ron)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Rsd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Rub)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Rwf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sar)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sbd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Scr)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sek)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sgd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sle)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sll)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Sos)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Szl)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Thb)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Tjs)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Top)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Try)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ttd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Tzs)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Uah)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Uzs)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Vnd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Vuv)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Wst)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Xaf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Xcd)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Yer)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Zar)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Zmw)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Clp)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Djf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Gnf)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Ugx)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Pyg)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Xof)]
    [InlineData(ChargeListDataTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(ChargeListDataTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataTierUnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ChargeListDataTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ChargeListDataTiersModeTest : TestBase
{
    [Theory]
    [InlineData(ChargeListDataTiersMode.Volume)]
    [InlineData(ChargeListDataTiersMode.Graduated)]
    public void Validation_Works(ChargeListDataTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataTiersMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataTiersMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ChargeListDataTiersMode.Volume)]
    [InlineData(ChargeListDataTiersMode.Graduated)]
    public void SerializationRoundtrip_Works(ChargeListDataTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ChargeListDataTiersMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataTiersMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataTiersMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ChargeListDataTiersMode>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
