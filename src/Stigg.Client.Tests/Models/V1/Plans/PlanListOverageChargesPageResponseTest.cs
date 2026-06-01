using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanListOverageChargesPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListOverageChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
                    BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
                    BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                        Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = PlanListOverageChargesResponseTiersMode.Volume,
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

        List<PlanListOverageChargesResponse> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
                BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
                BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCountryCode = "billingCountryCode",
                BillingID = "billingId",
                BlockSize = 0,
                CreditGrantCadence =
                    PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                    Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
                TiersMode = PlanListOverageChargesResponseTiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                UsedInSubscriptions = true,
            },
        ];
        PlanListOverageChargesPageResponsePagination expectedPagination = new()
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
        var model = new PlanListOverageChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
                    BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
                    BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                        Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = PlanListOverageChargesResponseTiersMode.Volume,
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
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListOverageChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
                    BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
                    BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                        Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = PlanListOverageChargesResponseTiersMode.Volume,
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
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<PlanListOverageChargesResponse> expectedData =
        [
            new()
            {
                ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
                BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
                BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCountryCode = "billingCountryCode",
                BillingID = "billingId",
                BlockSize = 0,
                CreditGrantCadence =
                    PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                    Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
                },
                Tiers =
                [
                    new()
                    {
                        FlatPrice = new()
                        {
                            Amount = 0,
                            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
                        },
                        UnitPrice = new()
                        {
                            Amount = 0,
                            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
                        },
                        UpTo = 0,
                    },
                ],
                TiersMode = PlanListOverageChargesResponseTiersMode.Volume,
                TopUpCustomCurrencyID = "topUpCustomCurrencyId",
                UsedInSubscriptions = true,
            },
        ];
        PlanListOverageChargesPageResponsePagination expectedPagination = new()
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
        var model = new PlanListOverageChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
                    BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
                    BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                        Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = PlanListOverageChargesResponseTiersMode.Volume,
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
        var model = new PlanListOverageChargesPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
                    BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
                    BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingCountryCode = "billingCountryCode",
                    BillingID = "billingId",
                    BlockSize = 0,
                    CreditGrantCadence =
                        PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
                        Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
                    },
                    Tiers =
                    [
                        new()
                        {
                            FlatPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
                            },
                            UnitPrice = new()
                            {
                                Amount = 0,
                                Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
                            },
                            UpTo = 0,
                        },
                    ],
                    TiersMode = PlanListOverageChargesResponseTiersMode.Volume,
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

        PlanListOverageChargesPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListOverageChargesPageResponsePaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListOverageChargesPageResponsePagination
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
        var model = new PlanListOverageChargesPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesPageResponsePagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListOverageChargesPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesPageResponsePagination>(
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
        var model = new PlanListOverageChargesPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListOverageChargesPageResponsePagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        PlanListOverageChargesPageResponsePagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
