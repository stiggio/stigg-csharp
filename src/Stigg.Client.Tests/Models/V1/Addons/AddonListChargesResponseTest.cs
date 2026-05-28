using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class AddonListChargesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListChargesResponse
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
        };

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AddonListChargesResponseBillingCadence> expectedBillingCadence =
            AddonListChargesResponseBillingCadence.Recurring;
        ApiEnum<string, AddonListChargesResponseBillingModel> expectedBillingModel =
            AddonListChargesResponseBillingModel.FlatFee;
        ApiEnum<string, AddonListChargesResponseBillingPeriod> expectedBillingPeriod =
            AddonListChargesResponseBillingPeriod.Monthly;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        double expectedBlockSize = 0;
        ApiEnum<string, AddonListChargesResponseCreditGrantCadence> expectedCreditGrantCadence =
            AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod;
        AddonListChargesResponseCreditRate expectedCreditRate = new()
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
        AddonListChargesResponsePrice expectedPrice = new()
        {
            Amount = 0,
            Currency = AddonListChargesResponsePriceCurrency.Usd,
        };
        List<AddonListChargesResponseTier> expectedTiers =
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
        ];
        ApiEnum<string, AddonListChargesResponseTiersMode> expectedTiersMode =
            AddonListChargesResponseTiersMode.Volume;
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
        var model = new AddonListChargesResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListChargesResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        ApiEnum<string, AddonListChargesResponseBillingCadence> expectedBillingCadence =
            AddonListChargesResponseBillingCadence.Recurring;
        ApiEnum<string, AddonListChargesResponseBillingModel> expectedBillingModel =
            AddonListChargesResponseBillingModel.FlatFee;
        ApiEnum<string, AddonListChargesResponseBillingPeriod> expectedBillingPeriod =
            AddonListChargesResponseBillingPeriod.Monthly;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedBillingCountryCode = "billingCountryCode";
        string expectedBillingID = "billingId";
        double expectedBlockSize = 0;
        ApiEnum<string, AddonListChargesResponseCreditGrantCadence> expectedCreditGrantCadence =
            AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod;
        AddonListChargesResponseCreditRate expectedCreditRate = new()
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
        AddonListChargesResponsePrice expectedPrice = new()
        {
            Amount = 0,
            Currency = AddonListChargesResponsePriceCurrency.Usd,
        };
        List<AddonListChargesResponseTier> expectedTiers =
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
        ];
        ApiEnum<string, AddonListChargesResponseTiersMode> expectedTiersMode =
            AddonListChargesResponseTiersMode.Volume;
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
        var model = new AddonListChargesResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AddonListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
            BillingModel = AddonListChargesResponseBillingModel.FlatFee,
            BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
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
        var model = new AddonListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
            BillingModel = AddonListChargesResponseBillingModel.FlatFee,
            BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddonListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
            BillingModel = AddonListChargesResponseBillingModel.FlatFee,
            BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
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
        var model = new AddonListChargesResponse
        {
            ID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            BillingCadence = AddonListChargesResponseBillingCadence.Recurring,
            BillingModel = AddonListChargesResponseBillingModel.FlatFee,
            BillingPeriod = AddonListChargesResponseBillingPeriod.Monthly,
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
        var model = new AddonListChargesResponse
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
        };

        AddonListChargesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListChargesResponseBillingCadenceTest : TestBase
{
    [Theory]
    [InlineData(AddonListChargesResponseBillingCadence.Recurring)]
    [InlineData(AddonListChargesResponseBillingCadence.OneOff)]
    public void Validation_Works(AddonListChargesResponseBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseBillingCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListChargesResponseBillingCadence.Recurring)]
    [InlineData(AddonListChargesResponseBillingCadence.OneOff)]
    public void SerializationRoundtrip_Works(AddonListChargesResponseBillingCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseBillingCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListChargesResponseBillingModelTest : TestBase
{
    [Theory]
    [InlineData(AddonListChargesResponseBillingModel.FlatFee)]
    [InlineData(AddonListChargesResponseBillingModel.MinimumSpend)]
    [InlineData(AddonListChargesResponseBillingModel.PerUnit)]
    [InlineData(AddonListChargesResponseBillingModel.UsageBased)]
    [InlineData(AddonListChargesResponseBillingModel.CreditBased)]
    public void Validation_Works(AddonListChargesResponseBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseBillingModel> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListChargesResponseBillingModel.FlatFee)]
    [InlineData(AddonListChargesResponseBillingModel.MinimumSpend)]
    [InlineData(AddonListChargesResponseBillingModel.PerUnit)]
    [InlineData(AddonListChargesResponseBillingModel.UsageBased)]
    [InlineData(AddonListChargesResponseBillingModel.CreditBased)]
    public void SerializationRoundtrip_Works(AddonListChargesResponseBillingModel rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseBillingModel> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingModel>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingModel>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListChargesResponseBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(AddonListChargesResponseBillingPeriod.Monthly)]
    [InlineData(AddonListChargesResponseBillingPeriod.Annually)]
    public void Validation_Works(AddonListChargesResponseBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListChargesResponseBillingPeriod.Monthly)]
    [InlineData(AddonListChargesResponseBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(AddonListChargesResponseBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListChargesResponseCreditGrantCadenceTest : TestBase
{
    [Theory]
    [InlineData(AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(AddonListChargesResponseCreditGrantCadence.Monthly)]
    public void Validation_Works(AddonListChargesResponseCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseCreditGrantCadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListChargesResponseCreditGrantCadence.BeginningOfBillingPeriod)]
    [InlineData(AddonListChargesResponseCreditGrantCadence.Monthly)]
    public void SerializationRoundtrip_Works(AddonListChargesResponseCreditGrantCadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseCreditGrantCadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseCreditGrantCadence>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseCreditGrantCadence>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListChargesResponseCreditRateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListChargesResponseCreditRate
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
        var model = new AddonListChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponseCreditRate>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponseCreditRate>(
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
        var model = new AddonListChargesResponseCreditRate
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
        var model = new AddonListChargesResponseCreditRate
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
        var model = new AddonListChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddonListChargesResponseCreditRate
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
        var model = new AddonListChargesResponseCreditRate
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
        var model = new AddonListChargesResponseCreditRate
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CostFormula = "costFormula",
        };

        AddonListChargesResponseCreditRate copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListChargesResponsePriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListChargesResponsePrice
        {
            Amount = 0,
            Currency = AddonListChargesResponsePriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, AddonListChargesResponsePriceCurrency> expectedCurrency =
            AddonListChargesResponsePriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonListChargesResponsePrice
        {
            Amount = 0,
            Currency = AddonListChargesResponsePriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponsePrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListChargesResponsePrice
        {
            Amount = 0,
            Currency = AddonListChargesResponsePriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponsePrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, AddonListChargesResponsePriceCurrency> expectedCurrency =
            AddonListChargesResponsePriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonListChargesResponsePrice
        {
            Amount = 0,
            Currency = AddonListChargesResponsePriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListChargesResponsePrice
        {
            Amount = 0,
            Currency = AddonListChargesResponsePriceCurrency.Usd,
        };

        AddonListChargesResponsePrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListChargesResponsePriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(AddonListChargesResponsePriceCurrency.Usd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Aed)]
    [InlineData(AddonListChargesResponsePriceCurrency.All)]
    [InlineData(AddonListChargesResponsePriceCurrency.Amd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ang)]
    [InlineData(AddonListChargesResponsePriceCurrency.Aud)]
    [InlineData(AddonListChargesResponsePriceCurrency.Awg)]
    [InlineData(AddonListChargesResponsePriceCurrency.Azn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bam)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bbd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bdt)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bgn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bif)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bmd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bnd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bsd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bwp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Byn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bzd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Brl)]
    [InlineData(AddonListChargesResponsePriceCurrency.Cad)]
    [InlineData(AddonListChargesResponsePriceCurrency.Cdf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Chf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Cny)]
    [InlineData(AddonListChargesResponsePriceCurrency.Czk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Dkk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Dop)]
    [InlineData(AddonListChargesResponsePriceCurrency.Dzd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Egp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Etb)]
    [InlineData(AddonListChargesResponsePriceCurrency.Eur)]
    [InlineData(AddonListChargesResponsePriceCurrency.Fjd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gbp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gel)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gip)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gmd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gyd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Hkd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Hrk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Htg)]
    [InlineData(AddonListChargesResponsePriceCurrency.Idr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ils)]
    [InlineData(AddonListChargesResponsePriceCurrency.Inr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Isk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Jmd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Jpy)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kes)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kgs)]
    [InlineData(AddonListChargesResponsePriceCurrency.Khr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kmf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Krw)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kyd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kzt)]
    [InlineData(AddonListChargesResponsePriceCurrency.Lbp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Lkr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Lrd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Lsl)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mad)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mdl)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mga)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mkd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mmk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mnt)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mop)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mro)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mvr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mwk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mxn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Myr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mzn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Nad)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ngn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Nok)]
    [InlineData(AddonListChargesResponsePriceCurrency.Npr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Nzd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Pgk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Php)]
    [InlineData(AddonListChargesResponsePriceCurrency.Pkr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Pln)]
    [InlineData(AddonListChargesResponsePriceCurrency.Qar)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ron)]
    [InlineData(AddonListChargesResponsePriceCurrency.Rsd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Rub)]
    [InlineData(AddonListChargesResponsePriceCurrency.Rwf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sar)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sbd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Scr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sek)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sgd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sle)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sll)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sos)]
    [InlineData(AddonListChargesResponsePriceCurrency.Szl)]
    [InlineData(AddonListChargesResponsePriceCurrency.Thb)]
    [InlineData(AddonListChargesResponsePriceCurrency.Tjs)]
    [InlineData(AddonListChargesResponsePriceCurrency.Top)]
    [InlineData(AddonListChargesResponsePriceCurrency.Try)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ttd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Tzs)]
    [InlineData(AddonListChargesResponsePriceCurrency.Uah)]
    [InlineData(AddonListChargesResponsePriceCurrency.Uzs)]
    [InlineData(AddonListChargesResponsePriceCurrency.Vnd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Vuv)]
    [InlineData(AddonListChargesResponsePriceCurrency.Wst)]
    [InlineData(AddonListChargesResponsePriceCurrency.Xaf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Xcd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Yer)]
    [InlineData(AddonListChargesResponsePriceCurrency.Zar)]
    [InlineData(AddonListChargesResponsePriceCurrency.Zmw)]
    [InlineData(AddonListChargesResponsePriceCurrency.Clp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Djf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gnf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ugx)]
    [InlineData(AddonListChargesResponsePriceCurrency.Pyg)]
    [InlineData(AddonListChargesResponsePriceCurrency.Xof)]
    [InlineData(AddonListChargesResponsePriceCurrency.Xpf)]
    public void Validation_Works(AddonListChargesResponsePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponsePriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponsePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListChargesResponsePriceCurrency.Usd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Aed)]
    [InlineData(AddonListChargesResponsePriceCurrency.All)]
    [InlineData(AddonListChargesResponsePriceCurrency.Amd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ang)]
    [InlineData(AddonListChargesResponsePriceCurrency.Aud)]
    [InlineData(AddonListChargesResponsePriceCurrency.Awg)]
    [InlineData(AddonListChargesResponsePriceCurrency.Azn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bam)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bbd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bdt)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bgn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bif)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bmd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bnd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bsd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bwp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Byn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Bzd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Brl)]
    [InlineData(AddonListChargesResponsePriceCurrency.Cad)]
    [InlineData(AddonListChargesResponsePriceCurrency.Cdf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Chf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Cny)]
    [InlineData(AddonListChargesResponsePriceCurrency.Czk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Dkk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Dop)]
    [InlineData(AddonListChargesResponsePriceCurrency.Dzd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Egp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Etb)]
    [InlineData(AddonListChargesResponsePriceCurrency.Eur)]
    [InlineData(AddonListChargesResponsePriceCurrency.Fjd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gbp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gel)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gip)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gmd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gyd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Hkd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Hrk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Htg)]
    [InlineData(AddonListChargesResponsePriceCurrency.Idr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ils)]
    [InlineData(AddonListChargesResponsePriceCurrency.Inr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Isk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Jmd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Jpy)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kes)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kgs)]
    [InlineData(AddonListChargesResponsePriceCurrency.Khr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kmf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Krw)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kyd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Kzt)]
    [InlineData(AddonListChargesResponsePriceCurrency.Lbp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Lkr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Lrd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Lsl)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mad)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mdl)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mga)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mkd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mmk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mnt)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mop)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mro)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mvr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mwk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mxn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Myr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Mzn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Nad)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ngn)]
    [InlineData(AddonListChargesResponsePriceCurrency.Nok)]
    [InlineData(AddonListChargesResponsePriceCurrency.Npr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Nzd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Pgk)]
    [InlineData(AddonListChargesResponsePriceCurrency.Php)]
    [InlineData(AddonListChargesResponsePriceCurrency.Pkr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Pln)]
    [InlineData(AddonListChargesResponsePriceCurrency.Qar)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ron)]
    [InlineData(AddonListChargesResponsePriceCurrency.Rsd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Rub)]
    [InlineData(AddonListChargesResponsePriceCurrency.Rwf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sar)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sbd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Scr)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sek)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sgd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sle)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sll)]
    [InlineData(AddonListChargesResponsePriceCurrency.Sos)]
    [InlineData(AddonListChargesResponsePriceCurrency.Szl)]
    [InlineData(AddonListChargesResponsePriceCurrency.Thb)]
    [InlineData(AddonListChargesResponsePriceCurrency.Tjs)]
    [InlineData(AddonListChargesResponsePriceCurrency.Top)]
    [InlineData(AddonListChargesResponsePriceCurrency.Try)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ttd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Tzs)]
    [InlineData(AddonListChargesResponsePriceCurrency.Uah)]
    [InlineData(AddonListChargesResponsePriceCurrency.Uzs)]
    [InlineData(AddonListChargesResponsePriceCurrency.Vnd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Vuv)]
    [InlineData(AddonListChargesResponsePriceCurrency.Wst)]
    [InlineData(AddonListChargesResponsePriceCurrency.Xaf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Xcd)]
    [InlineData(AddonListChargesResponsePriceCurrency.Yer)]
    [InlineData(AddonListChargesResponsePriceCurrency.Zar)]
    [InlineData(AddonListChargesResponsePriceCurrency.Zmw)]
    [InlineData(AddonListChargesResponsePriceCurrency.Clp)]
    [InlineData(AddonListChargesResponsePriceCurrency.Djf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Gnf)]
    [InlineData(AddonListChargesResponsePriceCurrency.Ugx)]
    [InlineData(AddonListChargesResponsePriceCurrency.Pyg)]
    [InlineData(AddonListChargesResponsePriceCurrency.Xof)]
    [InlineData(AddonListChargesResponsePriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(AddonListChargesResponsePriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponsePriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponsePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponsePriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponsePriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListChargesResponseTierTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListChargesResponseTier
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
        };

        AddonListChargesResponseTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
        };
        AddonListChargesResponseTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, model.FlatPrice);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
        Assert.Equal(expectedUpTo, model.UpTo);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonListChargesResponseTier
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponseTier>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListChargesResponseTier
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponseTier>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AddonListChargesResponseTierFlatPrice expectedFlatPrice = new()
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
        };
        AddonListChargesResponseTierUnitPrice expectedUnitPrice = new()
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
        };
        double expectedUpTo = 0;

        Assert.Equal(expectedFlatPrice, deserialized.FlatPrice);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
        Assert.Equal(expectedUpTo, deserialized.UpTo);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonListChargesResponseTier
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new AddonListChargesResponseTier { };

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
        var model = new AddonListChargesResponseTier { };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new AddonListChargesResponseTier
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
        var model = new AddonListChargesResponseTier
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
        var model = new AddonListChargesResponseTier
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
        };

        AddonListChargesResponseTier copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListChargesResponseTierFlatPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency> expectedCurrency =
            AddonListChargesResponseTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponseTierFlatPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponseTierFlatPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency> expectedCurrency =
            AddonListChargesResponseTierFlatPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListChargesResponseTierFlatPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierFlatPriceCurrency.Usd,
        };

        AddonListChargesResponseTierFlatPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListChargesResponseTierFlatPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Usd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Aed)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.All)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Amd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ang)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Aud)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Awg)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Azn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bam)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bbd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bdt)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bgn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bif)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bmd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bnd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bsd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bwp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Byn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bzd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Brl)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Cad)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Cdf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Chf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Cny)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Czk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Dkk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Dop)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Dzd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Egp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Etb)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Eur)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Fjd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gbp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gel)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gip)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gmd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gyd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Hkd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Hrk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Htg)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Idr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ils)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Inr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Isk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Jmd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Jpy)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kes)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kgs)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Khr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kmf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Krw)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kyd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kzt)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Lbp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Lkr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Lrd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Lsl)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mad)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mdl)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mga)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mkd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mmk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mnt)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mop)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mro)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mvr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mwk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mxn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Myr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mzn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Nad)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ngn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Nok)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Npr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Nzd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Pgk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Php)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Pkr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Pln)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Qar)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ron)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Rsd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Rub)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Rwf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sar)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sbd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Scr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sek)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sgd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sle)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sll)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sos)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Szl)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Thb)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Tjs)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Top)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Try)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ttd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Tzs)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Uah)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Uzs)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Vnd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Vuv)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Wst)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Xaf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Xcd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Yer)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Zar)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Zmw)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Clp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Djf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gnf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ugx)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Pyg)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Xof)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Xpf)]
    public void Validation_Works(AddonListChargesResponseTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Usd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Aed)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.All)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Amd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ang)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Aud)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Awg)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Azn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bam)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bbd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bdt)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bgn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bif)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bmd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bnd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bsd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bwp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Byn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Bzd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Brl)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Cad)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Cdf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Chf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Cny)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Czk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Dkk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Dop)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Dzd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Egp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Etb)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Eur)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Fjd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gbp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gel)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gip)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gmd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gyd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Hkd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Hrk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Htg)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Idr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ils)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Inr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Isk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Jmd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Jpy)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kes)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kgs)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Khr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kmf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Krw)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kyd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Kzt)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Lbp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Lkr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Lrd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Lsl)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mad)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mdl)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mga)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mkd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mmk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mnt)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mop)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mro)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mvr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mwk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mxn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Myr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Mzn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Nad)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ngn)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Nok)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Npr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Nzd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Pgk)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Php)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Pkr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Pln)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Qar)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ron)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Rsd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Rub)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Rwf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sar)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sbd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Scr)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sek)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sgd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sle)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sll)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Sos)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Szl)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Thb)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Tjs)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Top)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Try)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ttd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Tzs)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Uah)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Uzs)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Vnd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Vuv)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Wst)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Xaf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Xcd)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Yer)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Zar)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Zmw)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Clp)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Djf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Gnf)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Ugx)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Pyg)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Xof)]
    [InlineData(AddonListChargesResponseTierFlatPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(AddonListChargesResponseTierFlatPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTierFlatPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListChargesResponseTierUnitPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency> expectedCurrency =
            AddonListChargesResponseTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponseTierUnitPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListChargesResponseTierUnitPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency> expectedCurrency =
            AddonListChargesResponseTierUnitPriceCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListChargesResponseTierUnitPrice
        {
            Amount = 0,
            Currency = AddonListChargesResponseTierUnitPriceCurrency.Usd,
        };

        AddonListChargesResponseTierUnitPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListChargesResponseTierUnitPriceCurrencyTest : TestBase
{
    [Theory]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Usd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Aed)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.All)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Amd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ang)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Aud)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Awg)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Azn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bam)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bbd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bdt)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bgn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bif)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bmd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bnd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bsd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bwp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Byn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bzd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Brl)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Cad)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Cdf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Chf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Cny)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Czk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Dkk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Dop)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Dzd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Egp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Etb)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Eur)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Fjd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gbp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gel)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gip)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gmd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gyd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Hkd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Hrk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Htg)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Idr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ils)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Inr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Isk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Jmd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Jpy)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kes)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kgs)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Khr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kmf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Krw)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kyd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kzt)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Lbp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Lkr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Lrd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Lsl)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mad)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mdl)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mga)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mkd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mmk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mnt)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mop)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mro)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mvr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mwk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mxn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Myr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mzn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Nad)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ngn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Nok)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Npr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Nzd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Pgk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Php)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Pkr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Pln)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Qar)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ron)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Rsd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Rub)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Rwf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sar)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sbd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Scr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sek)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sgd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sle)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sll)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sos)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Szl)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Thb)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Tjs)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Top)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Try)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ttd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Tzs)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Uah)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Uzs)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Vnd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Vuv)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Wst)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Xaf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Xcd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Yer)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Zar)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Zmw)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Clp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Djf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gnf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ugx)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Pyg)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Xof)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Xpf)]
    public void Validation_Works(AddonListChargesResponseTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Usd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Aed)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.All)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Amd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ang)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Aud)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Awg)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Azn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bam)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bbd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bdt)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bgn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bif)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bmd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bnd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bsd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bwp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Byn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Bzd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Brl)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Cad)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Cdf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Chf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Cny)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Czk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Dkk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Dop)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Dzd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Egp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Etb)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Eur)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Fjd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gbp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gel)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gip)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gmd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gyd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Hkd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Hrk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Htg)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Idr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ils)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Inr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Isk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Jmd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Jpy)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kes)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kgs)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Khr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kmf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Krw)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kyd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Kzt)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Lbp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Lkr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Lrd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Lsl)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mad)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mdl)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mga)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mkd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mmk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mnt)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mop)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mro)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mvr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mwk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mxn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Myr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Mzn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Nad)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ngn)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Nok)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Npr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Nzd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Pgk)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Php)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Pkr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Pln)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Qar)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ron)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Rsd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Rub)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Rwf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sar)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sbd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Scr)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sek)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sgd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sle)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sll)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Sos)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Szl)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Thb)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Tjs)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Top)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Try)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ttd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Tzs)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Uah)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Uzs)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Vnd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Vuv)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Wst)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Xaf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Xcd)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Yer)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Zar)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Zmw)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Clp)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Djf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Gnf)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Ugx)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Pyg)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Xof)]
    [InlineData(AddonListChargesResponseTierUnitPriceCurrency.Xpf)]
    public void SerializationRoundtrip_Works(AddonListChargesResponseTierUnitPriceCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTierUnitPriceCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListChargesResponseTiersModeTest : TestBase
{
    [Theory]
    [InlineData(AddonListChargesResponseTiersMode.Volume)]
    [InlineData(AddonListChargesResponseTiersMode.Graduated)]
    public void Validation_Works(AddonListChargesResponseTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseTiersMode> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListChargesResponseTiersMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListChargesResponseTiersMode.Volume)]
    [InlineData(AddonListChargesResponseTiersMode.Graduated)]
    public void SerializationRoundtrip_Works(AddonListChargesResponseTiersMode rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListChargesResponseTiersMode> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTiersMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListChargesResponseTiersMode>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListChargesResponseTiersMode>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
