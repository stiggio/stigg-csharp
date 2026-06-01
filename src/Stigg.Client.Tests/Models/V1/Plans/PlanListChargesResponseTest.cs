using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanListChargesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
            Price = new() { Amount = 0, Currency = PlanListChargesResponsePriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = PlanListChargesResponseTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, PlanListChargesResponseBillingCadence> expectedBillingCadence =
            PlanListChargesResponseBillingCadence.Recurring;
        ApiEnum<string, PlanListChargesResponseBillingModel> expectedBillingModel =
            PlanListChargesResponseBillingModel.FlatFee;
        ApiEnum<string, PlanListChargesResponseBillingPeriod> expectedBillingPeriod =
            PlanListChargesResponseBillingPeriod.Monthly;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        double expectedBlockSize = 0;
        ApiEnum<string, PlanListChargesResponseCreditGrantCadence> expectedCreditGrantCadence =
            PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod;
        PlanListChargesResponseCreditRate expectedCreditRate = new()
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
        PlanListChargesResponsePrice expectedPrice = new()
        {
            Amount = 0,
            Currency = PlanListChargesResponsePriceCurrency.Usd,
        };
        List<PlanListChargesResponseTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];
        ApiEnum<string, PlanListChargesResponseTiersMode> expectedTiersMode =
            PlanListChargesResponseTiersMode.Volume;
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
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
            Price = new() { Amount = 0, Currency = PlanListChargesResponsePriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = PlanListChargesResponseTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
            Price = new() { Amount = 0, Currency = PlanListChargesResponsePriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = PlanListChargesResponseTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, PlanListChargesResponseBillingCadence> expectedBillingCadence =
            PlanListChargesResponseBillingCadence.Recurring;
        ApiEnum<string, PlanListChargesResponseBillingModel> expectedBillingModel =
            PlanListChargesResponseBillingModel.FlatFee;
        ApiEnum<string, PlanListChargesResponseBillingPeriod> expectedBillingPeriod =
            PlanListChargesResponseBillingPeriod.Monthly;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        double expectedBlockSize = 0;
        ApiEnum<string, PlanListChargesResponseCreditGrantCadence> expectedCreditGrantCadence =
            PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod;
        PlanListChargesResponseCreditRate expectedCreditRate = new()
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
        PlanListChargesResponsePrice expectedPrice = new()
        {
            Amount = 0,
            Currency = PlanListChargesResponsePriceCurrency.Usd,
        };
        List<PlanListChargesResponseTier> expectedTiers =
        [
            new()
            {
                FlatPrice = new()
                {
                    Amount = 0,
                    Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
                },
                UnitPrice = new()
                {
                    Amount = 0,
                    Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
                },
                UpTo = 0,
            },
        ];
        ApiEnum<string, PlanListChargesResponseTiersMode> expectedTiersMode =
            PlanListChargesResponseTiersMode.Volume;
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
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
            Price = new() { Amount = 0, Currency = PlanListChargesResponsePriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = PlanListChargesResponseTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
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
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
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
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
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
        var model = new PlanListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = PlanListChargesResponseBillingCadence.Recurring,
            BillingModel = PlanListChargesResponseBillingModel.FlatFee,
            BillingPeriod = PlanListChargesResponseBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCountryCode = "billingCountryCode",
            BillingID = "billingId",
            BlockSize = 0,
            CreditGrantCadence = PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod,
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
            Price = new() { Amount = 0, Currency = PlanListChargesResponsePriceCurrency.Usd },
            Tiers =
            [
                new()
                {
                    FlatPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
                    },
                    UnitPrice = new()
                    {
                        Amount = 0,
                        Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
                    },
                    UpTo = 0,
                },
            ],
            TiersMode = PlanListChargesResponseTiersMode.Volume,
            TopUpCustomCurrencyID = "topUpCustomCurrencyId",
            UsedInSubscriptions = true,
        };

        PlanListChargesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListChargesResponseBillingCadenceTest : TestBase
{
    [Theory]
    [InlineData(PlanListChargesResponseBillingCadence.Recurring)]
    [InlineData(PlanListChargesResponseBillingCadence.OneOff)]
    public void Validation_Works(PlanListChargesResponseBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseBillingCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListChargesResponseBillingCadence.Recurring)]
    [InlineData(PlanListChargesResponseBillingCadence.OneOff)]
    public void SerializationRoundtrip_Works(PlanListChargesResponseBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseBillingCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListChargesResponseBillingModelTest : TestBase
{
    [Theory]
    [InlineData(PlanListChargesResponseBillingModel.FlatFee)]
    [InlineData(PlanListChargesResponseBillingModel.MinimumSpend)]
    [InlineData(PlanListChargesResponseBillingModel.PerUnit)]
    [InlineData(PlanListChargesResponseBillingModel.UsageBased)]
    [InlineData(PlanListChargesResponseBillingModel.CreditBased)]
    public void Validation_Works(PlanListChargesResponseBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseBillingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListChargesResponseBillingModel.FlatFee)]
    [InlineData(PlanListChargesResponseBillingModel.MinimumSpend)]
    [InlineData(PlanListChargesResponseBillingModel.PerUnit)]
    [InlineData(PlanListChargesResponseBillingModel.UsageBased)]
    [InlineData(PlanListChargesResponseBillingModel.CreditBased)]
    public void SerializationRoundtrip_Works(PlanListChargesResponseBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseBillingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListChargesResponseBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(PlanListChargesResponseBillingPeriod.Monthly)]
    [InlineData(PlanListChargesResponseBillingPeriod.Annually)]
    public void Validation_Works(PlanListChargesResponseBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListChargesResponseBillingPeriod.Monthly)]
    [InlineData(PlanListChargesResponseBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(PlanListChargesResponseBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListChargesResponseCreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(PlanListChargesResponseCreditGrantCadence.Monthly)]
    public void Validation_Works(PlanListChargesResponseCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseCreditGrantCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(PlanListChargesResponseCreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(PlanListChargesResponseCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseCreditGrantCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListChargesResponseCreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListChargesResponseCreditRate
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
        var model = new PlanListChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponseCreditRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponseCreditRate>(
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
        var model = new PlanListChargesResponseCreditRate
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
        var model = new PlanListChargesResponseCreditRate { Amount = 0, CurrencyID = "currencyId" };

        Assert.Null(model.CostFormula);
        Assert.False(model.RawData.ContainsKey("costFormula"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlanListChargesResponseCreditRate { Amount = 0, CurrencyID = "currencyId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanListChargesResponseCreditRate
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
        var model = new PlanListChargesResponseCreditRate
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
        var model = new PlanListChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        PlanListChargesResponseCreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListChargesResponsePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListChargesResponsePriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PlanListChargesResponsePriceCurrency> expectedCurrency =
            PlanListChargesResponsePriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListChargesResponsePriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponsePrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListChargesResponsePriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponsePrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PlanListChargesResponsePriceCurrency> expectedCurrency =
            PlanListChargesResponsePriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListChargesResponsePriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListChargesResponsePrice
        {
            Amount = 0,
            Currency = PlanListChargesResponsePriceCurrency.Usd,
        };

        PlanListChargesResponsePrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListChargesResponsePriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PlanListChargesResponsePriceCurrency.Usd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Aed)]
    [InlineData(PlanListChargesResponsePriceCurrency.All)]
    [InlineData(PlanListChargesResponsePriceCurrency.Amd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ang)]
    [InlineData(PlanListChargesResponsePriceCurrency.Aud)]
    [InlineData(PlanListChargesResponsePriceCurrency.Awg)]
    [InlineData(PlanListChargesResponsePriceCurrency.Azn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bam)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bbd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bdt)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bgn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bif)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bmd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bnd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bsd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bwp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Byn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bzd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Brl)]
    [InlineData(PlanListChargesResponsePriceCurrency.Cad)]
    [InlineData(PlanListChargesResponsePriceCurrency.Cdf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Chf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Cny)]
    [InlineData(PlanListChargesResponsePriceCurrency.Czk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Dkk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Dop)]
    [InlineData(PlanListChargesResponsePriceCurrency.Dzd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Egp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Etb)]
    [InlineData(PlanListChargesResponsePriceCurrency.Eur)]
    [InlineData(PlanListChargesResponsePriceCurrency.Fjd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gbp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gel)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gip)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gmd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gyd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Hkd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Hrk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Htg)]
    [InlineData(PlanListChargesResponsePriceCurrency.Idr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ils)]
    [InlineData(PlanListChargesResponsePriceCurrency.Inr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Isk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Jmd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Jpy)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kes)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kgs)]
    [InlineData(PlanListChargesResponsePriceCurrency.Khr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kmf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Krw)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kyd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kzt)]
    [InlineData(PlanListChargesResponsePriceCurrency.Lbp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Lkr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Lrd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Lsl)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mad)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mdl)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mga)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mkd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mmk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mnt)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mop)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mro)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mvr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mwk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mxn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Myr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mzn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Nad)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ngn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Nok)]
    [InlineData(PlanListChargesResponsePriceCurrency.Npr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Nzd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Pgk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Php)]
    [InlineData(PlanListChargesResponsePriceCurrency.Pkr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Pln)]
    [InlineData(PlanListChargesResponsePriceCurrency.Qar)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ron)]
    [InlineData(PlanListChargesResponsePriceCurrency.Rsd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Rub)]
    [InlineData(PlanListChargesResponsePriceCurrency.Rwf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sar)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sbd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Scr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sek)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sgd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sle)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sll)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sos)]
    [InlineData(PlanListChargesResponsePriceCurrency.Szl)]
    [InlineData(PlanListChargesResponsePriceCurrency.Thb)]
    [InlineData(PlanListChargesResponsePriceCurrency.Tjs)]
    [InlineData(PlanListChargesResponsePriceCurrency.Top)]
    [InlineData(PlanListChargesResponsePriceCurrency.Try)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ttd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Tzs)]
    [InlineData(PlanListChargesResponsePriceCurrency.Uah)]
    [InlineData(PlanListChargesResponsePriceCurrency.Uzs)]
    [InlineData(PlanListChargesResponsePriceCurrency.Vnd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Vuv)]
    [InlineData(PlanListChargesResponsePriceCurrency.Wst)]
    [InlineData(PlanListChargesResponsePriceCurrency.Xaf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Xcd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Yer)]
    [InlineData(PlanListChargesResponsePriceCurrency.Zar)]
    [InlineData(PlanListChargesResponsePriceCurrency.Zmw)]
    [InlineData(PlanListChargesResponsePriceCurrency.Clp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Djf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gnf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ugx)]
    [InlineData(PlanListChargesResponsePriceCurrency.Pyg)]
    [InlineData(PlanListChargesResponsePriceCurrency.Xof)]
    [InlineData(PlanListChargesResponsePriceCurrency.Xpf)]
    public void Validation_Works(PlanListChargesResponsePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponsePriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponsePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListChargesResponsePriceCurrency.Usd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Aed)]
    [InlineData(PlanListChargesResponsePriceCurrency.All)]
    [InlineData(PlanListChargesResponsePriceCurrency.Amd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ang)]
    [InlineData(PlanListChargesResponsePriceCurrency.Aud)]
    [InlineData(PlanListChargesResponsePriceCurrency.Awg)]
    [InlineData(PlanListChargesResponsePriceCurrency.Azn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bam)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bbd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bdt)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bgn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bif)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bmd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bnd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bsd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bwp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Byn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Bzd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Brl)]
    [InlineData(PlanListChargesResponsePriceCurrency.Cad)]
    [InlineData(PlanListChargesResponsePriceCurrency.Cdf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Chf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Cny)]
    [InlineData(PlanListChargesResponsePriceCurrency.Czk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Dkk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Dop)]
    [InlineData(PlanListChargesResponsePriceCurrency.Dzd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Egp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Etb)]
    [InlineData(PlanListChargesResponsePriceCurrency.Eur)]
    [InlineData(PlanListChargesResponsePriceCurrency.Fjd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gbp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gel)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gip)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gmd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gyd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Hkd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Hrk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Htg)]
    [InlineData(PlanListChargesResponsePriceCurrency.Idr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ils)]
    [InlineData(PlanListChargesResponsePriceCurrency.Inr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Isk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Jmd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Jpy)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kes)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kgs)]
    [InlineData(PlanListChargesResponsePriceCurrency.Khr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kmf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Krw)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kyd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Kzt)]
    [InlineData(PlanListChargesResponsePriceCurrency.Lbp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Lkr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Lrd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Lsl)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mad)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mdl)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mga)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mkd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mmk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mnt)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mop)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mro)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mvr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mwk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mxn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Myr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Mzn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Nad)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ngn)]
    [InlineData(PlanListChargesResponsePriceCurrency.Nok)]
    [InlineData(PlanListChargesResponsePriceCurrency.Npr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Nzd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Pgk)]
    [InlineData(PlanListChargesResponsePriceCurrency.Php)]
    [InlineData(PlanListChargesResponsePriceCurrency.Pkr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Pln)]
    [InlineData(PlanListChargesResponsePriceCurrency.Qar)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ron)]
    [InlineData(PlanListChargesResponsePriceCurrency.Rsd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Rub)]
    [InlineData(PlanListChargesResponsePriceCurrency.Rwf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sar)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sbd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Scr)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sek)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sgd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sle)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sll)]
    [InlineData(PlanListChargesResponsePriceCurrency.Sos)]
    [InlineData(PlanListChargesResponsePriceCurrency.Szl)]
    [InlineData(PlanListChargesResponsePriceCurrency.Thb)]
    [InlineData(PlanListChargesResponsePriceCurrency.Tjs)]
    [InlineData(PlanListChargesResponsePriceCurrency.Top)]
    [InlineData(PlanListChargesResponsePriceCurrency.Try)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ttd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Tzs)]
    [InlineData(PlanListChargesResponsePriceCurrency.Uah)]
    [InlineData(PlanListChargesResponsePriceCurrency.Uzs)]
    [InlineData(PlanListChargesResponsePriceCurrency.Vnd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Vuv)]
    [InlineData(PlanListChargesResponsePriceCurrency.Wst)]
    [InlineData(PlanListChargesResponsePriceCurrency.Xaf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Xcd)]
    [InlineData(PlanListChargesResponsePriceCurrency.Yer)]
    [InlineData(PlanListChargesResponsePriceCurrency.Zar)]
    [InlineData(PlanListChargesResponsePriceCurrency.Zmw)]
    [InlineData(PlanListChargesResponsePriceCurrency.Clp)]
    [InlineData(PlanListChargesResponsePriceCurrency.Djf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Gnf)]
    [InlineData(PlanListChargesResponsePriceCurrency.Ugx)]
    [InlineData(PlanListChargesResponsePriceCurrency.Pyg)]
    [InlineData(PlanListChargesResponsePriceCurrency.Xof)]
    [InlineData(PlanListChargesResponsePriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PlanListChargesResponsePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponsePriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponsePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponsePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponsePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListChargesResponseTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListChargesResponseTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        PlanListChargesResponseTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
        };
        PlanListChargesResponseTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListChargesResponseTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponseTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListChargesResponseTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponseTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        PlanListChargesResponseTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
        };
        PlanListChargesResponseTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListChargesResponseTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlanListChargesResponseTier { };

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
        var model = new PlanListChargesResponseTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanListChargesResponseTier
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
        var model = new PlanListChargesResponseTier
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
        var model = new PlanListChargesResponseTier
        {
            FlatPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
            },
            UnitPrice = new()
            {
                Amount = 0,
                Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
            },
            UpTo = 0,
        };

        PlanListChargesResponseTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListChargesResponseTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency> expectedCurrency =
            PlanListChargesResponseTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponseTierFlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponseTierFlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency> expectedCurrency =
            PlanListChargesResponseTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierFlatPriceCurrency.Usd,
        };

        PlanListChargesResponseTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListChargesResponseTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Usd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Aed)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.All)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Amd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ang)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Aud)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Awg)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Azn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bam)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bbd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bdt)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bgn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bif)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bmd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bnd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bsd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bwp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Byn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bzd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Brl)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Cad)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Cdf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Chf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Cny)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Czk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Dkk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Dop)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Dzd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Egp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Etb)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Eur)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Fjd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gbp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gel)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gip)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gmd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gyd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Hkd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Hrk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Htg)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Idr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ils)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Inr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Isk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Jmd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Jpy)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kes)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kgs)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Khr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kmf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Krw)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kyd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kzt)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Lbp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Lkr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Lrd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Lsl)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mad)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mdl)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mga)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mkd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mmk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mnt)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mop)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mro)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mvr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mwk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mxn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Myr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mzn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Nad)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ngn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Nok)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Npr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Nzd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Pgk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Php)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Pkr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Pln)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Qar)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ron)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Rsd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Rub)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Rwf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sar)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sbd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Scr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sek)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sgd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sle)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sll)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sos)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Szl)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Thb)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Tjs)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Top)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Try)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ttd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Tzs)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Uah)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Uzs)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Vnd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Vuv)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Wst)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Xaf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Xcd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Yer)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Zar)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Zmw)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Clp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Djf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gnf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ugx)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Pyg)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Xof)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(PlanListChargesResponseTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Usd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Aed)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.All)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Amd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ang)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Aud)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Awg)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Azn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bam)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bbd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bdt)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bgn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bif)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bmd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bnd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bsd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bwp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Byn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Bzd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Brl)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Cad)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Cdf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Chf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Cny)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Czk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Dkk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Dop)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Dzd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Egp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Etb)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Eur)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Fjd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gbp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gel)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gip)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gmd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gyd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Hkd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Hrk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Htg)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Idr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ils)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Inr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Isk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Jmd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Jpy)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kes)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kgs)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Khr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kmf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Krw)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kyd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Kzt)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Lbp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Lkr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Lrd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Lsl)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mad)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mdl)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mga)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mkd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mmk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mnt)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mop)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mro)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mvr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mwk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mxn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Myr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Mzn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Nad)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ngn)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Nok)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Npr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Nzd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Pgk)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Php)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Pkr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Pln)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Qar)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ron)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Rsd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Rub)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Rwf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sar)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sbd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Scr)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sek)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sgd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sle)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sll)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Sos)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Szl)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Thb)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Tjs)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Top)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Try)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ttd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Tzs)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Uah)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Uzs)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Vnd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Vuv)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Wst)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Xaf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Xcd)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Yer)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Zar)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Zmw)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Clp)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Djf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Gnf)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Ugx)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Pyg)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Xof)]
    [InlineData(PlanListChargesResponseTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PlanListChargesResponseTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListChargesResponseTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency> expectedCurrency =
            PlanListChargesResponseTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponseTierUnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListChargesResponseTierUnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency> expectedCurrency =
            PlanListChargesResponseTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = PlanListChargesResponseTierUnitPriceCurrency.Usd,
        };

        PlanListChargesResponseTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListChargesResponseTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Usd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Aed)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.All)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Amd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ang)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Aud)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Awg)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Azn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bam)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bbd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bdt)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bgn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bif)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bmd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bnd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bsd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bwp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Byn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bzd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Brl)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Cad)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Cdf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Chf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Cny)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Czk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Dkk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Dop)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Dzd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Egp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Etb)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Eur)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Fjd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gbp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gel)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gip)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gmd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gyd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Hkd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Hrk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Htg)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Idr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ils)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Inr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Isk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Jmd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Jpy)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kes)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kgs)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Khr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kmf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Krw)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kyd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kzt)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Lbp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Lkr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Lrd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Lsl)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mad)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mdl)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mga)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mkd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mmk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mnt)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mop)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mro)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mvr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mwk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mxn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Myr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mzn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Nad)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ngn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Nok)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Npr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Nzd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Pgk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Php)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Pkr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Pln)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Qar)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ron)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Rsd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Rub)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Rwf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sar)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sbd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Scr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sek)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sgd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sle)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sll)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sos)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Szl)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Thb)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Tjs)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Top)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Try)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ttd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Tzs)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Uah)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Uzs)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Vnd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Vuv)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Wst)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Xaf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Xcd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Yer)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Zar)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Zmw)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Clp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Djf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gnf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ugx)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Pyg)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Xof)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(PlanListChargesResponseTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Usd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Aed)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.All)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Amd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ang)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Aud)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Awg)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Azn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bam)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bbd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bdt)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bgn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bif)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bmd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bnd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bsd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bwp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Byn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Bzd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Brl)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Cad)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Cdf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Chf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Cny)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Czk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Dkk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Dop)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Dzd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Egp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Etb)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Eur)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Fjd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gbp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gel)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gip)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gmd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gyd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Hkd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Hrk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Htg)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Idr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ils)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Inr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Isk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Jmd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Jpy)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kes)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kgs)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Khr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kmf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Krw)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kyd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Kzt)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Lbp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Lkr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Lrd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Lsl)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mad)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mdl)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mga)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mkd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mmk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mnt)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mop)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mro)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mvr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mwk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mxn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Myr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Mzn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Nad)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ngn)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Nok)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Npr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Nzd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Pgk)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Php)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Pkr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Pln)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Qar)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ron)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Rsd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Rub)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Rwf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sar)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sbd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Scr)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sek)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sgd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sle)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sll)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Sos)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Szl)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Thb)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Tjs)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Top)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Try)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ttd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Tzs)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Uah)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Uzs)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Vnd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Vuv)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Wst)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Xaf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Xcd)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Yer)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Zar)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Zmw)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Clp)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Djf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Gnf)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Ugx)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Pyg)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Xof)]
    [InlineData(PlanListChargesResponseTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(PlanListChargesResponseTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListChargesResponseTiersModeTest : TestBase
{
    [Theory]
    [InlineData(PlanListChargesResponseTiersMode.Volume)]
    [InlineData(PlanListChargesResponseTiersMode.Graduated)]
    public void Validation_Works(PlanListChargesResponseTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseTiersMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListChargesResponseTiersMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListChargesResponseTiersMode.Volume)]
    [InlineData(PlanListChargesResponseTiersMode.Graduated)]
    public void SerializationRoundtrip_Works(PlanListChargesResponseTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListChargesResponseTiersMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTiersMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListChargesResponseTiersMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListChargesResponseTiersMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
