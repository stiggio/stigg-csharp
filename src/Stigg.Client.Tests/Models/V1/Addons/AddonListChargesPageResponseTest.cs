using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class AddonListChargesPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
                    BillingModel = AddonListChargesResponseBillingModel.FlatFee,
                    BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                    Price = new()
                    {
                        Amount = 0,
                        Currency = AddonListChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = AddonListChargesResponseTiersMode.Volume,
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

        List<AddonListChargesResponse> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
                BillingModel = AddonListChargesResponseBillingModel.FlatFee,
                BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCountryCode = "billingCountryCode",
                BillingID = "billingId",
                BlockSize = 0,
                CreditGrantCadence =
                    AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                Price = new() { Amount = 0, Currency = AddonListChargesResponsePriceCurrency.Usd },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
                TiersMode = AddonListChargesResponseTiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                UsedInSubscriptions = true,
            },
        ];
        AddonListChargesPageResponsePagination expectedPagination = new()
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
        var model = new AddonListChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
                    BillingModel = AddonListChargesResponseBillingModel.FlatFee,
                    BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                    Price = new()
                    {
                        Amount = 0,
                        Currency = AddonListChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = AddonListChargesResponseTiersMode.Volume,
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
        var deserialized = JsonSerializer.Deserialize<AddonListChargesPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
                    BillingModel = AddonListChargesResponseBillingModel.FlatFee,
                    BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                    Price = new()
                    {
                        Amount = 0,
                        Currency = AddonListChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = AddonListChargesResponseTiersMode.Volume,
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
        var deserialized = JsonSerializer.Deserialize<AddonListChargesPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<AddonListChargesResponse> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
                BillingModel = AddonListChargesResponseBillingModel.FlatFee,
                BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCountryCode = "billingCountryCode",
                BillingID = "billingId",
                BlockSize = 0,
                CreditGrantCadence =
                    AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                Price = new() { Amount = 0, Currency = AddonListChargesResponsePriceCurrency.Usd },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
                TiersMode = AddonListChargesResponseTiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                UsedInSubscriptions = true,
            },
        ];
        AddonListChargesPageResponsePagination expectedPagination = new()
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
        var model = new AddonListChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
                    BillingModel = AddonListChargesResponseBillingModel.FlatFee,
                    BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                    Price = new()
                    {
                        Amount = 0,
                        Currency = AddonListChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = AddonListChargesResponseTiersMode.Volume,
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
        var model = new AddonListChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
                    BillingModel = AddonListChargesResponseBillingModel.FlatFee,
                    BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                    Price = new()
                    {
                        Amount = 0,
                        Currency = AddonListChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = AddonListChargesResponseTiersMode.Volume,
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

        AddonListChargesPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListChargesPageResponsePaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListChargesPageResponsePagination
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
        var model = new AddonListChargesPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesPageResponsePagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListChargesPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesPageResponsePagination>(
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
        var model = new AddonListChargesPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListChargesPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        AddonListChargesPageResponsePagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
