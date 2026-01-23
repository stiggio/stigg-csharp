using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Subscriptions = Stigg.Models.V1.Subscriptions;

namespace Stigg.Tests.Models.V1.Subscriptions;

public class SubscriptionPreviewParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Subscriptions::SubscriptionPreviewParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            Addons = [new() { AddonID = "addonId", Quantity = 1 }],
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
            BillableFeatures = [new() { FeatureID = "featureId", Quantity = 1 }],
            BillingCountryCode = "billingCountryCode",
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
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Subscriptions::SubscriptionPreviewParamsBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior =
                    Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 1,
        };

        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        List<Subscriptions::Addon> expectedAddons = [new() { AddonID = "addonId", Quantity = 1 }];
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
        List<Subscriptions::BillableFeature> expectedBillableFeatures =
        [
            new() { FeatureID = "featureId", Quantity = 1 },
        ];
        string expectedBillingCountryCode = "billingCountryCode";
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
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
            ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };
        ApiEnum<
            string,
            Subscriptions::SubscriptionPreviewParamsBillingPeriod
        > expectedBillingPeriod = Subscriptions::SubscriptionPreviewParamsBillingPeriod.Monthly;
        List<Subscriptions::Charge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 1,
                Type = Subscriptions::Type.Feature,
            },
        ];
        string expectedPayingCustomerID = "payingCustomerId";
        string expectedResourceID = "resourceId";
        ApiEnum<string, Subscriptions::ScheduleStrategy> expectedScheduleStrategy =
            Subscriptions::ScheduleStrategy.EndOfBillingPeriod;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration expectedTrialOverrideConfiguration =
            new()
            {
                IsTrial = true,
                TrialEndBehavior =
                    Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            };
        double expectedUnitQuantity = 1;

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.NotNull(parameters.Addons);
        Assert.Equal(expectedAddons.Count, parameters.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], parameters.Addons[i]);
        }
        Assert.Equal(expectedAppliedCoupon, parameters.AppliedCoupon);
        Assert.NotNull(parameters.BillableFeatures);
        Assert.Equal(expectedBillableFeatures.Count, parameters.BillableFeatures.Count);
        for (int i = 0; i < expectedBillableFeatures.Count; i++)
        {
            Assert.Equal(expectedBillableFeatures[i], parameters.BillableFeatures[i]);
        }
        Assert.Equal(expectedBillingCountryCode, parameters.BillingCountryCode);
        Assert.Equal(expectedBillingInformation, parameters.BillingInformation);
        Assert.Equal(expectedBillingPeriod, parameters.BillingPeriod);
        Assert.NotNull(parameters.Charges);
        Assert.Equal(expectedCharges.Count, parameters.Charges.Count);
        for (int i = 0; i < expectedCharges.Count; i++)
        {
            Assert.Equal(expectedCharges[i], parameters.Charges[i]);
        }
        Assert.Equal(expectedPayingCustomerID, parameters.PayingCustomerID);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedScheduleStrategy, parameters.ScheduleStrategy);
        Assert.Equal(expectedStartDate, parameters.StartDate);
        Assert.Equal(expectedTrialOverrideConfiguration, parameters.TrialOverrideConfiguration);
        Assert.Equal(expectedUnitQuantity, parameters.UnitQuantity);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionPreviewParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
        };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.AppliedCoupon);
        Assert.False(parameters.RawBodyData.ContainsKey("appliedCoupon"));
        Assert.Null(parameters.BillableFeatures);
        Assert.False(parameters.RawBodyData.ContainsKey("billableFeatures"));
        Assert.Null(parameters.BillingCountryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("billingCountryCode"));
        Assert.Null(parameters.BillingInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("billingInformation"));
        Assert.Null(parameters.BillingPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("billingPeriod"));
        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.PayingCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("payingCustomerId"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.ScheduleStrategy);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduleStrategy"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startDate"));
        Assert.Null(parameters.TrialOverrideConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("trialOverrideConfiguration"));
        Assert.Null(parameters.UnitQuantity);
        Assert.False(parameters.RawBodyData.ContainsKey("unitQuantity"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Subscriptions::SubscriptionPreviewParams
        {
            CustomerID = "customerId",
            PlanID = "planId",

            // Null should be interpreted as omitted for these properties
            Addons = null,
            AppliedCoupon = null,
            BillableFeatures = null,
            BillingCountryCode = null,
            BillingInformation = null,
            BillingPeriod = null,
            Charges = null,
            PayingCustomerID = null,
            ResourceID = null,
            ScheduleStrategy = null,
            StartDate = null,
            TrialOverrideConfiguration = null,
            UnitQuantity = null,
        };

        Assert.Null(parameters.Addons);
        Assert.False(parameters.RawBodyData.ContainsKey("addons"));
        Assert.Null(parameters.AppliedCoupon);
        Assert.False(parameters.RawBodyData.ContainsKey("appliedCoupon"));
        Assert.Null(parameters.BillableFeatures);
        Assert.False(parameters.RawBodyData.ContainsKey("billableFeatures"));
        Assert.Null(parameters.BillingCountryCode);
        Assert.False(parameters.RawBodyData.ContainsKey("billingCountryCode"));
        Assert.Null(parameters.BillingInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("billingInformation"));
        Assert.Null(parameters.BillingPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("billingPeriod"));
        Assert.Null(parameters.Charges);
        Assert.False(parameters.RawBodyData.ContainsKey("charges"));
        Assert.Null(parameters.PayingCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("payingCustomerId"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.ScheduleStrategy);
        Assert.False(parameters.RawBodyData.ContainsKey("scheduleStrategy"));
        Assert.Null(parameters.StartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("startDate"));
        Assert.Null(parameters.TrialOverrideConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("trialOverrideConfiguration"));
        Assert.Null(parameters.UnitQuantity);
        Assert.False(parameters.RawBodyData.ContainsKey("unitQuantity"));
    }

    [Fact]
    public void Url_Works()
    {
        Subscriptions::SubscriptionPreviewParams parameters = new()
        {
            CustomerID = "customerId",
            PlanID = "planId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/subscriptions/preview"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Subscriptions::SubscriptionPreviewParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            Addons = [new() { AddonID = "addonId", Quantity = 1 }],
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
            BillableFeatures = [new() { FeatureID = "featureId", Quantity = 1 }],
            BillingCountryCode = "billingCountryCode",
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
                Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
                ProrationBehavior = Subscriptions::ProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = Subscriptions::SubscriptionPreviewParamsBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = Subscriptions::Type.Feature,
                },
            ],
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            ScheduleStrategy = Subscriptions::ScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior =
                    Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 1,
        };

        Subscriptions::SubscriptionPreviewParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

        string expectedAddonID = "addonId";
        long expectedQuantity = 1;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

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
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::Addon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedAddonID = "addonId";
        long expectedQuantity = 1;

        Assert.Equal(expectedAddonID, deserialized.AddonID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId" };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::Addon
        {
            AddonID = "addonId",

            // Null should be interpreted as omitted for these properties
            Quantity = null,
        };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::Addon
        {
            AddonID = "addonId",

            // Null should be interpreted as omitted for these properties
            Quantity = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::Addon { AddonID = "addonId", Quantity = 1 };

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
        var model = new Subscriptions::AppliedCoupon { };

        Assert.Null(model.BillingCouponID);
        Assert.False(model.RawData.ContainsKey("billingCouponId"));
        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.PromotionCode);
        Assert.False(model.RawData.ContainsKey("promotionCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::AppliedCoupon { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            // Null should be interpreted as omitted for these properties
            BillingCouponID = null,
            Configuration = null,
            CouponID = null,
            Discount = null,
            PromotionCode = null,
        };

        Assert.Null(model.BillingCouponID);
        Assert.False(model.RawData.ContainsKey("billingCouponId"));
        Assert.Null(model.Configuration);
        Assert.False(model.RawData.ContainsKey("configuration"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.Discount);
        Assert.False(model.RawData.ContainsKey("discount"));
        Assert.Null(model.PromotionCode);
        Assert.False(model.RawData.ContainsKey("promotionCode"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::AppliedCoupon
        {
            // Null should be interpreted as omitted for these properties
            BillingCouponID = null,
            Configuration = null,
            CouponID = null,
            Discount = null,
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

public class BillableFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::BillableFeature { FeatureID = "featureId", Quantity = 1 };

        string expectedFeatureID = "featureId";
        double expectedQuantity = 1;

        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::BillableFeature { FeatureID = "featureId", Quantity = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BillableFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::BillableFeature { FeatureID = "featureId", Quantity = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscriptions::BillableFeature>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFeatureID = "featureId";
        double expectedQuantity = 1;

        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::BillableFeature { FeatureID = "featureId", Quantity = 1 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::BillableFeature { FeatureID = "featureId", Quantity = 1 };

        Subscriptions::BillableFeature copied = new(model);

        Assert.Equal(model, copied);
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
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        string expectedIntegrationID = "integrationId";
        double expectedInvoiceDaysUntilDue = 0;
        bool expectedIsBackdated = true;
        bool expectedIsInvoicePaid = true;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, Subscriptions::ProrationBehavior> expectedProrationBehavior =
            Subscriptions::ProrationBehavior.InvoiceImmediately;
        List<Subscriptions::TaxID> expectedTaxIds = [new() { Type = "type", Value = "value" }];
        double expectedTaxPercentage = 0;
        List<string> expectedTaxRateIds = ["string"];

        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedChargeOnBehalfOfAccount, model.ChargeOnBehalfOfAccount);
        Assert.Equal(expectedIntegrationID, model.IntegrationID);
        Assert.Equal(expectedInvoiceDaysUntilDue, model.InvoiceDaysUntilDue);
        Assert.Equal(expectedIsBackdated, model.IsBackdated);
        Assert.Equal(expectedIsInvoicePaid, model.IsInvoicePaid);
        Assert.NotNull(model.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, model.Metadata.Value));
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
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
        string expectedIntegrationID = "integrationId";
        double expectedInvoiceDaysUntilDue = 0;
        bool expectedIsBackdated = true;
        bool expectedIsInvoicePaid = true;
        JsonElement expectedMetadata = JsonSerializer.Deserialize<JsonElement>("{}");
        ApiEnum<string, Subscriptions::ProrationBehavior> expectedProrationBehavior =
            Subscriptions::ProrationBehavior.InvoiceImmediately;
        List<Subscriptions::TaxID> expectedTaxIds = [new() { Type = "type", Value = "value" }];
        double expectedTaxPercentage = 0;
        List<string> expectedTaxRateIds = ["string"];

        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedChargeOnBehalfOfAccount, deserialized.ChargeOnBehalfOfAccount);
        Assert.Equal(expectedIntegrationID, deserialized.IntegrationID);
        Assert.Equal(expectedInvoiceDaysUntilDue, deserialized.InvoiceDaysUntilDue);
        Assert.Equal(expectedIsBackdated, deserialized.IsBackdated);
        Assert.Equal(expectedIsInvoicePaid, deserialized.IsInvoicePaid);
        Assert.NotNull(deserialized.Metadata);
        Assert.True(JsonElement.DeepEquals(expectedMetadata, deserialized.Metadata.Value));
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
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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
            IntegrationID = "integrationId",
            InvoiceDaysUntilDue = 0,
            IsBackdated = true,
            IsInvoicePaid = true,
            Metadata = JsonSerializer.Deserialize<JsonElement>("{}"),
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

public class SubscriptionPreviewParamsBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(Subscriptions::SubscriptionPreviewParamsBillingPeriod.Monthly)]
    [InlineData(Subscriptions::SubscriptionPreviewParamsBillingPeriod.Annually)]
    public void Validation_Works(Subscriptions::SubscriptionPreviewParamsBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::SubscriptionPreviewParamsBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::SubscriptionPreviewParamsBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Subscriptions::SubscriptionPreviewParamsBillingPeriod.Monthly)]
    [InlineData(Subscriptions::SubscriptionPreviewParamsBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionPreviewParamsBillingPeriod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Subscriptions::SubscriptionPreviewParamsBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::SubscriptionPreviewParamsBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::SubscriptionPreviewParamsBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Subscriptions::SubscriptionPreviewParamsBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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

public class SubscriptionPreviewParamsTrialOverrideConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedIsTrial = true;
        ApiEnum<
            string,
            Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
        > expectedTrialEndBehavior =
            Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, model.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        bool expectedIsTrial = true;
        ApiEnum<
            string,
            Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
        > expectedTrialEndBehavior =
            Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, deserialized.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,
        };

        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,

            // Null should be interpreted as omitted for these properties
            TrialEndBehavior = null,
            TrialEndDate = null,
        };

        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,

            // Null should be interpreted as omitted for these properties
            TrialEndBehavior = null,
            TrialEndDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior =
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscriptions::SubscriptionPreviewParamsTrialOverrideConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(
        Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid
    )]
    [InlineData(
        Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.CancelSubscription
    )]
    public void Validation_Works(
        Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.ConvertToPaid
    )]
    [InlineData(
        Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior.CancelSubscription
    )]
    public void SerializationRoundtrip_Works(
        Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
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
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                Subscriptions::SubscriptionPreviewParamsTrialOverrideConfigurationTrialEndBehavior
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
