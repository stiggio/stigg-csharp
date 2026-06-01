using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanListOverageChargesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponse
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
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, PlanListOverageChargesResponseBillingCadence> expectedBillingCadence =
            PlanListOverageChargesResponseBillingCadence.Recurring;
        ApiEnum<string, PlanListOverageChargesResponseBillingModel> expectedBillingModel =
            PlanListOverageChargesResponseBillingModel.FlatFee;
        ApiEnum<string, PlanListOverageChargesResponseBillingPeriod> expectedBillingPeriod =
            PlanListOverageChargesResponseBillingPeriod.Monthly;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        double expectedBlockSize = 0;
        ApiEnum<
            string,
            PlanListOverageChargesResponseCreditGrantCadence
        > expectedCreditGrantCadence =
            PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod;
        PlanListOverageChargesResponseCreditRate expectedCreditRate = new()
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
        PlanListOverageChargesResponsePrice expectedPrice = new()
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
        };
        List<PlanListOverageChargesResponseTier> expectedTiers =
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
        ];
        ApiEnum<string, PlanListOverageChargesResponseTiersMode> expectedTiersMode =
            PlanListOverageChargesResponseTiersMode.Volume;
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
        var model = new PlanListOverageChargesResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListOverageChargesResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, PlanListOverageChargesResponseBillingCadence> expectedBillingCadence =
            PlanListOverageChargesResponseBillingCadence.Recurring;
        ApiEnum<string, PlanListOverageChargesResponseBillingModel> expectedBillingModel =
            PlanListOverageChargesResponseBillingModel.FlatFee;
        ApiEnum<string, PlanListOverageChargesResponseBillingPeriod> expectedBillingPeriod =
            PlanListOverageChargesResponseBillingPeriod.Monthly;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        double expectedBlockSize = 0;
        ApiEnum<
            string,
            PlanListOverageChargesResponseCreditGrantCadence
        > expectedCreditGrantCadence =
            PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod;
        PlanListOverageChargesResponseCreditRate expectedCreditRate = new()
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
        PlanListOverageChargesResponsePrice expectedPrice = new()
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
        };
        List<PlanListOverageChargesResponseTier> expectedTiers =
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
        ];
        ApiEnum<string, PlanListOverageChargesResponseTiersMode> expectedTiersMode =
            PlanListOverageChargesResponseTiersMode.Volume;
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
        var model = new PlanListOverageChargesResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlanListOverageChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
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
        var model = new PlanListOverageChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanListOverageChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
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
        var model = new PlanListOverageChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListOverageChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListOverageChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListOverageChargesResponseBillingPeriod.Monthly,
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
        var model = new PlanListOverageChargesResponse
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
        };

        PlanListOverageChargesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListOverageChargesResponseBillingCadenceTest : TestBase
{
    [Theory]
    [InlineData(PlanListOverageChargesResponseBillingCadence.Recurring)]
    [InlineData(PlanListOverageChargesResponseBillingCadence.OneOff)]
    public void Validation_Works(PlanListOverageChargesResponseBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseBillingCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListOverageChargesResponseBillingCadence.Recurring)]
    [InlineData(PlanListOverageChargesResponseBillingCadence.OneOff)]
    public void SerializationRoundtrip_Works(PlanListOverageChargesResponseBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseBillingCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListOverageChargesResponseBillingModelTest : TestBase
{
    [Theory]
    [InlineData(PlanListOverageChargesResponseBillingModel.FlatFee)]
    [InlineData(PlanListOverageChargesResponseBillingModel.MinimumSpend)]
    [InlineData(PlanListOverageChargesResponseBillingModel.PerUnit)]
    [InlineData(PlanListOverageChargesResponseBillingModel.UsageBased)]
    [InlineData(PlanListOverageChargesResponseBillingModel.CreditBased)]
    public void Validation_Works(PlanListOverageChargesResponseBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseBillingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListOverageChargesResponseBillingModel.FlatFee)]
    [InlineData(PlanListOverageChargesResponseBillingModel.MinimumSpend)]
    [InlineData(PlanListOverageChargesResponseBillingModel.PerUnit)]
    [InlineData(PlanListOverageChargesResponseBillingModel.UsageBased)]
    [InlineData(PlanListOverageChargesResponseBillingModel.CreditBased)]
    public void SerializationRoundtrip_Works(PlanListOverageChargesResponseBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseBillingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListOverageChargesResponseBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(PlanListOverageChargesResponseBillingPeriod.Monthly)]
    [InlineData(PlanListOverageChargesResponseBillingPeriod.Annually)]
    public void Validation_Works(PlanListOverageChargesResponseBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListOverageChargesResponseBillingPeriod.Monthly)]
    [InlineData(PlanListOverageChargesResponseBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(PlanListOverageChargesResponseBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListOverageChargesResponseCreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(PlanListOverageChargesResponseCreditGrantCadence.Monthly)]
    public void Validation_Works(PlanListOverageChargesResponseCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseCreditGrantCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListOverageChargesResponseCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(PlanListOverageChargesResponseCreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(
        PlanListOverageChargesResponseCreditGrantCadence rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseCreditGrantCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListOverageChargesResponseCreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponseCreditRate
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
        var model = new PlanListOverageChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponseCreditRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListOverageChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponseCreditRate>(
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
        var model = new PlanListOverageChargesResponseCreditRate
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
        var model = new PlanListOverageChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
        };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlanListOverageChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanListOverageChargesResponseCreditRate
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
        var model = new PlanListOverageChargesResponseCreditRate
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
        var model = new PlanListOverageChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        PlanListOverageChargesResponseCreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListOverageChargesResponsePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PlanListOverageChargesResponsePriceCurrency> expectedCurrency =
            PlanListOverageChargesResponsePriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponsePrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListOverageChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponsePrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PlanListOverageChargesResponsePriceCurrency> expectedCurrency =
            PlanListOverageChargesResponsePriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListOverageChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListOverageChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponsePriceCurrency.Usd,
        };

        PlanListOverageChargesResponsePrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListOverageChargesResponsePriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Usd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Aed)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.All)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Amd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ang)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Aud)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Awg)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Azn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bam)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bbd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bdt)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bgn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bif)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bmd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bnd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bsd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bwp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Byn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bzd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Brl)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Cad)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Cdf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Chf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Cny)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Czk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Dkk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Dop)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Dzd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Egp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Etb)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Eur)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Fjd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gbp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gel)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gip)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gmd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gyd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Hkd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Hrk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Htg)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Idr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ils)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Inr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Isk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Jmd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Jpy)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kes)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kgs)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Khr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kmf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Krw)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kyd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kzt)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Lbp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Lkr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Lrd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Lsl)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mad)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mdl)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mga)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mkd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mmk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mnt)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mop)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mro)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mvr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mwk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mxn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Myr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mzn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Nad)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ngn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Nok)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Npr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Nzd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Pgk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Php)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Pkr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Pln)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Qar)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ron)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Rsd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Rub)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Rwf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sar)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sbd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Scr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sek)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sgd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sle)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sll)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sos)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Szl)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Thb)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Tjs)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Top)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Try)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ttd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Tzs)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Uah)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Uzs)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Vnd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Vuv)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Wst)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Xaf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Xcd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Yer)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Zar)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Zmw)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Clp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Djf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gnf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ugx)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Pyg)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Xof)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Xpf)]
    public void Validation_Works(PlanListOverageChargesResponsePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponsePriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponsePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Usd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Aed)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.All)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Amd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ang)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Aud)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Awg)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Azn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bam)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bbd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bdt)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bgn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bif)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bmd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bnd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bsd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bwp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Byn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Bzd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Brl)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Cad)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Cdf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Chf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Cny)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Czk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Dkk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Dop)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Dzd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Egp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Etb)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Eur)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Fjd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gbp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gel)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gip)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gmd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gyd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Hkd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Hrk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Htg)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Idr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ils)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Inr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Isk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Jmd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Jpy)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kes)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kgs)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Khr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kmf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Krw)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kyd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Kzt)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Lbp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Lkr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Lrd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Lsl)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mad)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mdl)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mga)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mkd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mmk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mnt)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mop)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mro)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mvr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mwk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mxn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Myr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Mzn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Nad)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ngn)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Nok)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Npr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Nzd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Pgk)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Php)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Pkr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Pln)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Qar)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ron)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Rsd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Rub)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Rwf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sar)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sbd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Scr)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sek)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sgd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sle)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sll)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Sos)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Szl)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Thb)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Tjs)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Top)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Try)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ttd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Tzs)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Uah)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Uzs)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Vnd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Vuv)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Wst)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Xaf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Xcd)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Yer)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Zar)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Zmw)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Clp)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Djf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Gnf)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Ugx)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Pyg)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Xof)]
    [InlineData(PlanListOverageChargesResponsePriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PlanListOverageChargesResponsePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponsePriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponsePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponsePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponsePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListOverageChargesResponseTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponseTier
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
        };

        PlanListOverageChargesResponseTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
        };
        PlanListOverageChargesResponseTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponseTier
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponseTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListOverageChargesResponseTier
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponseTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PlanListOverageChargesResponseTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
        };
        PlanListOverageChargesResponseTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListOverageChargesResponseTier
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlanListOverageChargesResponseTier { };

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
        var model = new PlanListOverageChargesResponseTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanListOverageChargesResponseTier
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
        var model = new PlanListOverageChargesResponseTier
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
        var model = new PlanListOverageChargesResponseTier
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
        };

        PlanListOverageChargesResponseTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListOverageChargesResponseTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency> expectedCurrency =
            PlanListOverageChargesResponseTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponseTierFlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListOverageChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponseTierFlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency> expectedCurrency =
            PlanListOverageChargesResponseTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListOverageChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListOverageChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierFlatPriceCurrency.Usd,
        };

        PlanListOverageChargesResponseTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListOverageChargesResponseTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Usd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Aed)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.All)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Amd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ang)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Aud)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Awg)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Azn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bam)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bbd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bdt)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bgn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bif)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bmd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bnd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bsd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bwp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Byn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bzd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Brl)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Cad)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Cdf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Chf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Cny)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Czk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Dkk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Dop)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Dzd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Egp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Etb)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Eur)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Fjd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gbp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gel)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gip)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gmd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gyd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Hkd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Hrk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Htg)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Idr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ils)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Inr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Isk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Jmd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Jpy)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kes)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kgs)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Khr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kmf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Krw)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kyd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kzt)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Lbp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Lkr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Lrd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Lsl)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mad)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mdl)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mga)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mkd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mmk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mnt)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mop)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mro)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mvr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mwk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mxn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Myr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mzn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Nad)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ngn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Nok)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Npr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Nzd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Pgk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Php)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Pkr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Pln)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Qar)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ron)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Rsd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Rub)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Rwf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sar)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sbd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Scr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sek)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sgd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sle)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sll)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sos)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Szl)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Thb)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Tjs)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Top)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Try)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ttd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Tzs)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Uah)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Uzs)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Vnd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Vuv)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Wst)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Xaf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Xcd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Yer)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Zar)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Zmw)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Clp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Djf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gnf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ugx)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Pyg)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Xof)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(PlanListOverageChargesResponseTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Usd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Aed)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.All)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Amd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ang)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Aud)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Awg)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Azn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bam)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bbd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bdt)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bgn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bif)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bmd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bnd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bsd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bwp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Byn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Bzd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Brl)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Cad)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Cdf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Chf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Cny)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Czk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Dkk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Dop)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Dzd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Egp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Etb)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Eur)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Fjd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gbp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gel)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gip)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gmd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gyd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Hkd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Hrk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Htg)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Idr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ils)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Inr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Isk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Jmd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Jpy)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kes)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kgs)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Khr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kmf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Krw)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kyd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Kzt)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Lbp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Lkr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Lrd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Lsl)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mad)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mdl)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mga)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mkd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mmk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mnt)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mop)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mro)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mvr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mwk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mxn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Myr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Mzn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Nad)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ngn)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Nok)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Npr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Nzd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Pgk)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Php)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Pkr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Pln)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Qar)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ron)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Rsd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Rub)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Rwf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sar)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sbd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Scr)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sek)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sgd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sle)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sll)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Sos)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Szl)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Thb)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Tjs)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Top)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Try)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ttd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Tzs)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Uah)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Uzs)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Vnd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Vuv)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Wst)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Xaf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Xcd)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Yer)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Zar)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Zmw)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Clp)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Djf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Gnf)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Ugx)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Pyg)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Xof)]
    [InlineData(PlanListOverageChargesResponseTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        PlanListOverageChargesResponseTierFlatPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListOverageChargesResponseTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency> expectedCurrency =
            PlanListOverageChargesResponseTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListOverageChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponseTierUnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListOverageChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListOverageChargesResponseTierUnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency> expectedCurrency =
            PlanListOverageChargesResponseTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListOverageChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListOverageChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListOverageChargesResponseTierUnitPriceCurrency.Usd,
        };

        PlanListOverageChargesResponseTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListOverageChargesResponseTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Usd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Aed)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.All)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Amd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ang)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Aud)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Awg)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Azn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bam)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bbd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bdt)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bgn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bif)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bmd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bnd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bsd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bwp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Byn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bzd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Brl)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Cad)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Cdf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Chf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Cny)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Czk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Dkk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Dop)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Dzd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Egp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Etb)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Eur)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Fjd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gbp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gel)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gip)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gmd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gyd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Hkd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Hrk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Htg)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Idr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ils)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Inr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Isk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Jmd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Jpy)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kes)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kgs)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Khr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kmf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Krw)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kyd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kzt)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Lbp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Lkr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Lrd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Lsl)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mad)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mdl)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mga)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mkd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mmk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mnt)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mop)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mro)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mvr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mwk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mxn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Myr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mzn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Nad)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ngn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Nok)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Npr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Nzd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Pgk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Php)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Pkr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Pln)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Qar)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ron)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Rsd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Rub)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Rwf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sar)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sbd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Scr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sek)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sgd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sle)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sll)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sos)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Szl)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Thb)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Tjs)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Top)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Try)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ttd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Tzs)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Uah)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Uzs)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Vnd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Vuv)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Wst)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Xaf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Xcd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Yer)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Zar)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Zmw)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Clp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Djf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gnf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ugx)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Pyg)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Xof)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(PlanListOverageChargesResponseTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Usd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Aed)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.All)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Amd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ang)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Aud)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Awg)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Azn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bam)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bbd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bdt)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bgn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bif)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bmd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bnd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bsd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bwp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Byn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Bzd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Brl)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Cad)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Cdf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Chf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Cny)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Czk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Dkk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Dop)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Dzd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Egp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Etb)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Eur)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Fjd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gbp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gel)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gip)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gmd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gyd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Hkd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Hrk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Htg)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Idr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ils)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Inr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Isk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Jmd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Jpy)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kes)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kgs)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Khr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kmf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Krw)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kyd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Kzt)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Lbp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Lkr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Lrd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Lsl)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mad)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mdl)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mga)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mkd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mmk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mnt)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mop)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mro)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mvr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mwk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mxn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Myr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Mzn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Nad)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ngn)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Nok)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Npr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Nzd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Pgk)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Php)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Pkr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Pln)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Qar)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ron)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Rsd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Rub)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Rwf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sar)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sbd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Scr)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sek)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sgd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sle)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sll)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Sos)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Szl)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Thb)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Tjs)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Top)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Try)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ttd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Tzs)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Uah)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Uzs)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Vnd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Vuv)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Wst)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Xaf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Xcd)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Yer)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Zar)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Zmw)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Clp)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Djf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Gnf)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Ugx)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Pyg)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Xof)]
    [InlineData(PlanListOverageChargesResponseTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        PlanListOverageChargesResponseTierUnitPriceCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListOverageChargesResponseTiersModeTest : TestBase
{
    [Theory]
    [InlineData(PlanListOverageChargesResponseTiersMode.Volume)]
    [InlineData(PlanListOverageChargesResponseTiersMode.Graduated)]
    public void Validation_Works(PlanListOverageChargesResponseTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseTiersMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTiersMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListOverageChargesResponseTiersMode.Volume)]
    [InlineData(PlanListOverageChargesResponseTiersMode.Graduated)]
    public void SerializationRoundtrip_Works(PlanListOverageChargesResponseTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListOverageChargesResponseTiersMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTiersMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTiersMode>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListOverageChargesResponseTiersMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
