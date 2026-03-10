using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionPreviewParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionPreviewParams
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
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                        },
                    ],
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
                ProrationBehavior =
                    SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = SubscriptionPreviewParamsBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionPreviewParamsChargeType.Feature,
                },
            ],
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            ScheduleStrategy = SubscriptionPreviewParamsScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 1,
        };

        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        List<SubscriptionPreviewParamsAddon> expectedAddons =
        [
            new() { AddonID = "addonId", Quantity = 1 },
        ];
        SubscriptionPreviewParamsAppliedCoupon expectedAppliedCoupon = new()
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };
        List<BillableFeature> expectedBillableFeatures =
        [
            new() { FeatureID = "featureId", Quantity = 1 },
        ];
        string expectedBillingCountryCode = "billingCountryCode";
        SubscriptionPreviewParamsBillingInformation expectedBillingInformation = new()
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
            ProrationBehavior =
                SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };
        ApiEnum<string, SubscriptionPreviewParamsBillingPeriod> expectedBillingPeriod =
            SubscriptionPreviewParamsBillingPeriod.Monthly;
        List<SubscriptionPreviewParamsCharge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 1,
                Type = SubscriptionPreviewParamsChargeType.Feature,
            },
        ];
        string expectedPayingCustomerID = "payingCustomerId";
        string expectedResourceID = "resourceId";
        ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy> expectedScheduleStrategy =
            SubscriptionPreviewParamsScheduleStrategy.EndOfBillingPeriod;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        TrialOverrideConfiguration expectedTrialOverrideConfiguration = new()
        {
            IsTrial = true,
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
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
        var parameters = new SubscriptionPreviewParams
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
        var parameters = new SubscriptionPreviewParams
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
        SubscriptionPreviewParams parameters = new()
        {
            CustomerID = "customerId",
            PlanID = "planId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/subscriptions/preview"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionPreviewParams
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
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency =
                                SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                        },
                    ],
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
                ProrationBehavior =
                    SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
                TaxIds = [new() { Type = "type", Value = "value" }],
                TaxPercentage = 0,
                TaxRateIds = ["string"],
            },
            BillingPeriod = SubscriptionPreviewParamsBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionPreviewParamsChargeType.Feature,
                },
            ],
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            ScheduleStrategy = SubscriptionPreviewParamsScheduleStrategy.EndOfBillingPeriod,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            UnitQuantity = 1,
        };

        SubscriptionPreviewParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class SubscriptionPreviewParamsAddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsAddon { AddonID = "addonId", Quantity = 1 };

        string expectedAddonID = "addonId";
        long expectedQuantity = 1;

        Assert.Equal(expectedAddonID, model.AddonID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsAddon { AddonID = "addonId", Quantity = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewParamsAddon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsAddon { AddonID = "addonId", Quantity = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewParamsAddon>(
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
        var model = new SubscriptionPreviewParamsAddon { AddonID = "addonId", Quantity = 1 };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsAddon { AddonID = "addonId" };

        Assert.Null(model.Quantity);
        Assert.False(model.RawData.ContainsKey("quantity"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPreviewParamsAddon { AddonID = "addonId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsAddon
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
        var model = new SubscriptionPreviewParamsAddon
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
        var model = new SubscriptionPreviewParamsAddon { AddonID = "addonId", Quantity = 1 };

        SubscriptionPreviewParamsAddon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsAppliedCouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string expectedBillingCouponID = "billingCouponId";
        SubscriptionPreviewParamsAppliedCouponConfiguration expectedConfiguration = new()
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCouponID = "couponId";
        SubscriptionPreviewParamsAppliedCouponDiscount expectedDiscount = new()
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
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
        var model = new SubscriptionPreviewParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewParamsAppliedCoupon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewParamsAppliedCoupon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingCouponID = "billingCouponId";
        SubscriptionPreviewParamsAppliedCouponConfiguration expectedConfiguration = new()
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCouponID = "couponId";
        SubscriptionPreviewParamsAppliedCouponDiscount expectedDiscount = new()
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
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
        var model = new SubscriptionPreviewParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
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
        var model = new SubscriptionPreviewParamsAppliedCoupon { };

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
        var model = new SubscriptionPreviewParamsAppliedCoupon { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCoupon
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
        var model = new SubscriptionPreviewParamsAppliedCoupon
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
        var model = new SubscriptionPreviewParamsAppliedCoupon
        {
            BillingCouponID = "billingCouponId",
            Configuration = new() { StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z") },
            CouponID = "couponId",
            Discount = new()
            {
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency =
                            SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                    },
                ],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            PromotionCode = "promotionCode",
        };

        SubscriptionPreviewParamsAppliedCoupon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsAppliedCouponConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsAppliedCouponConfiguration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsAppliedCouponConfiguration>(
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
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration { };

        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration
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
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration
        {
            // Null should be interpreted as omitted for these properties
            StartDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponConfiguration
        {
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionPreviewParamsAppliedCouponConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsAppliedCouponDiscountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        List<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff> expectedAmountsOff =
        [
            new()
            {
                Amount = 0,
                Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
            },
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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsAppliedCouponDiscount>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsAppliedCouponDiscount>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        List<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff> expectedAmountsOff =
        [
            new()
            {
                Amount = 0,
                Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
            },
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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],

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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],

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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
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
        var model = new SubscriptionPreviewParamsAppliedCouponDiscount
        {
            AmountsOff =
            [
                new()
                {
                    Amount = 0,
                    Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
                },
            ],
            Description = "description",
            DurationInMonths = 1,
            Name = "name",
            PercentOff = 1,
        };

        SubscriptionPreviewParamsAppliedCouponDiscount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency
        > expectedCurrency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<
            string,
            SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency
        > expectedCurrency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff
        {
            Amount = 0,
            Currency = SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd,
        };

        SubscriptionPreviewParamsAppliedCouponDiscountAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Aed)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.All)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Amd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ang)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Aud)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Awg)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Azn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bam)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bbd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bdt)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bgn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bif)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bmd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bnd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bsd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bwp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Byn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bzd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Brl)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cad)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cdf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Chf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cny)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Czk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dkk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dop)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dzd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Egp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Etb)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Eur)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Fjd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gbp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gel)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gip)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gmd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gyd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Hkd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Hrk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Htg)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Idr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ils)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Inr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Isk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Jmd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Jpy)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kes)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kgs)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Khr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kmf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Krw)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kyd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kzt)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lbp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lkr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lrd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lsl)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mad)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mdl)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mga)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mkd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mmk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mnt)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mop)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mro)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mvr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mwk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mxn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Myr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mzn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nad)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ngn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nok)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Npr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nzd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pgk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Php)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pkr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pln)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Qar)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ron)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rsd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rub)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rwf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sar)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sbd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Scr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sek)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sgd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sle)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sll)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sos)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Szl)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Thb)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Tjs)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Top)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Try)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ttd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Tzs)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Uah)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Uzs)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Vnd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Vuv)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Wst)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xaf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xcd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Yer)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Zar)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Zmw)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Clp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Djf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gnf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ugx)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pyg)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xof)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xpf)]
    public void Validation_Works(
        SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Usd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Aed)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.All)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Amd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ang)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Aud)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Awg)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Azn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bam)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bbd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bdt)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bgn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bif)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bmd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bnd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bsd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bwp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Byn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Bzd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Brl)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cad)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cdf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Chf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Cny)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Czk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dkk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dop)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Dzd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Egp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Etb)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Eur)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Fjd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gbp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gel)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gip)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gmd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gyd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Hkd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Hrk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Htg)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Idr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ils)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Inr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Isk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Jmd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Jpy)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kes)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kgs)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Khr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kmf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Krw)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kyd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Kzt)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lbp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lkr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lrd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Lsl)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mad)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mdl)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mga)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mkd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mmk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mnt)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mop)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mro)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mvr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mwk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mxn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Myr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Mzn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nad)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ngn)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nok)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Npr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Nzd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pgk)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Php)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pkr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pln)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Qar)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ron)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rsd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rub)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Rwf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sar)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sbd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Scr)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sek)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sgd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sle)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sll)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Sos)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Szl)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Thb)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Tjs)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Top)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Try)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ttd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Tzs)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Uah)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Uzs)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Vnd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Vuv)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Wst)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xaf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xcd)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Yer)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Zar)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Zmw)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Clp)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Djf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Gnf)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Ugx)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Pyg)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xof)]
    [InlineData(SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsAppliedCouponDiscountAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class BillableFeatureTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillableFeature { FeatureID = "featureId", Quantity = 1 };

        string expectedFeatureID = "featureId";
        double expectedQuantity = 1;

        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillableFeature { FeatureID = "featureId", Quantity = 1 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillableFeature>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillableFeature { FeatureID = "featureId", Quantity = 1 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillableFeature>(
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
        var model = new BillableFeature { FeatureID = "featureId", Quantity = 1 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillableFeature { FeatureID = "featureId", Quantity = 1 };

        BillableFeature copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsBillingInformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        SubscriptionPreviewParamsBillingInformationBillingAddress expectedBillingAddress = new()
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
        ApiEnum<
            string,
            SubscriptionPreviewParamsBillingInformationProrationBehavior
        > expectedProrationBehavior =
            SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately;
        List<SubscriptionPreviewParamsBillingInformationTaxID> expectedTaxIds =
        [
            new() { Type = "type", Value = "value" },
        ];
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
        var model = new SubscriptionPreviewParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewParamsBillingInformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewParamsBillingInformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionPreviewParamsBillingInformationBillingAddress expectedBillingAddress = new()
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
        ApiEnum<
            string,
            SubscriptionPreviewParamsBillingInformationProrationBehavior
        > expectedProrationBehavior =
            SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately;
        List<SubscriptionPreviewParamsBillingInformationTaxID> expectedTaxIds =
        [
            new() { Type = "type", Value = "value" },
        ];
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
        var model = new SubscriptionPreviewParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformation { };

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
        var model = new SubscriptionPreviewParamsBillingInformation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformation
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
        var model = new SubscriptionPreviewParamsBillingInformation
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
        var model = new SubscriptionPreviewParamsBillingInformation
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
            ProrationBehavior =
                SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately,
            TaxIds = [new() { Type = "type", Value = "value" }],
            TaxPercentage = 0,
            TaxRateIds = ["string"],
        };

        SubscriptionPreviewParamsBillingInformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsBillingInformationBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress
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
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsBillingInformationBillingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsBillingInformationBillingAddress>(
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
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress
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
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress { };

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
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress
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
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress
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
        var model = new SubscriptionPreviewParamsBillingInformationBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        SubscriptionPreviewParamsBillingInformationBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsBillingInformationProrationBehaviorTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately)]
    [InlineData(SubscriptionPreviewParamsBillingInformationProrationBehavior.CreateProrations)]
    [InlineData(SubscriptionPreviewParamsBillingInformationProrationBehavior.None)]
    public void Validation_Works(
        SubscriptionPreviewParamsBillingInformationProrationBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsBillingInformationProrationBehavior> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsBillingInformationProrationBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewParamsBillingInformationProrationBehavior.InvoiceImmediately)]
    [InlineData(SubscriptionPreviewParamsBillingInformationProrationBehavior.CreateProrations)]
    [InlineData(SubscriptionPreviewParamsBillingInformationProrationBehavior.None)]
    public void SerializationRoundtrip_Works(
        SubscriptionPreviewParamsBillingInformationProrationBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsBillingInformationProrationBehavior> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsBillingInformationProrationBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsBillingInformationProrationBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsBillingInformationProrationBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPreviewParamsBillingInformationTaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsBillingInformationTaxID>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<SubscriptionPreviewParamsBillingInformationTaxID>(
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
        var model = new SubscriptionPreviewParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewParamsBillingInformationTaxID
        {
            Type = "type",
            Value = "value",
        };

        SubscriptionPreviewParamsBillingInformationTaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewParamsBillingPeriod.Monthly)]
    [InlineData(SubscriptionPreviewParamsBillingPeriod.Annually)]
    public void Validation_Works(SubscriptionPreviewParamsBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewParamsBillingPeriod.Monthly)]
    [InlineData(SubscriptionPreviewParamsBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(SubscriptionPreviewParamsBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsBillingPeriod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsBillingPeriod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPreviewParamsChargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionPreviewParamsChargeType.Feature,
        };

        string expectedID = "id";
        double expectedQuantity = 1;
        ApiEnum<string, SubscriptionPreviewParamsChargeType> expectedType =
            SubscriptionPreviewParamsChargeType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionPreviewParamsCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionPreviewParamsChargeType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewParamsCharge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionPreviewParamsCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionPreviewParamsChargeType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionPreviewParamsCharge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedQuantity = 1;
        ApiEnum<string, SubscriptionPreviewParamsChargeType> expectedType =
            SubscriptionPreviewParamsChargeType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionPreviewParamsCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionPreviewParamsChargeType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionPreviewParamsCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionPreviewParamsChargeType.Feature,
        };

        SubscriptionPreviewParamsCharge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionPreviewParamsChargeTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewParamsChargeType.Feature)]
    [InlineData(SubscriptionPreviewParamsChargeType.Credit)]
    public void Validation_Works(SubscriptionPreviewParamsChargeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsChargeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsChargeType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewParamsChargeType.Feature)]
    [InlineData(SubscriptionPreviewParamsChargeType.Credit)]
    public void SerializationRoundtrip_Works(SubscriptionPreviewParamsChargeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsChargeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsChargeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsChargeType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsChargeType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionPreviewParamsScheduleStrategyTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionPreviewParamsScheduleStrategy.EndOfBillingPeriod)]
    [InlineData(SubscriptionPreviewParamsScheduleStrategy.EndOfBillingMonth)]
    [InlineData(SubscriptionPreviewParamsScheduleStrategy.Immediate)]
    public void Validation_Works(SubscriptionPreviewParamsScheduleStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionPreviewParamsScheduleStrategy.EndOfBillingPeriod)]
    [InlineData(SubscriptionPreviewParamsScheduleStrategy.EndOfBillingMonth)]
    [InlineData(SubscriptionPreviewParamsScheduleStrategy.Immediate)]
    public void SerializationRoundtrip_Works(SubscriptionPreviewParamsScheduleStrategy rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionPreviewParamsScheduleStrategy>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class TrialOverrideConfigurationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        bool expectedIsTrial = true;
        ApiEnum<string, TrialEndBehavior> expectedTrialEndBehavior = TrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, model.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrialOverrideConfiguration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TrialOverrideConfiguration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedIsTrial = true;
        ApiEnum<string, TrialEndBehavior> expectedTrialEndBehavior = TrialEndBehavior.ConvertToPaid;
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedIsTrial, deserialized.IsTrial);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new TrialOverrideConfiguration { IsTrial = true };

        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new TrialOverrideConfiguration { IsTrial = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new TrialOverrideConfiguration
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
        var model = new TrialOverrideConfiguration
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
        var model = new TrialOverrideConfiguration
        {
            IsTrial = true,
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        TrialOverrideConfiguration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(TrialEndBehavior.ConvertToPaid)]
    [InlineData(TrialEndBehavior.CancelSubscription)]
    public void Validation_Works(TrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrialEndBehavior.ConvertToPaid)]
    [InlineData(TrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(TrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialEndBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialEndBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
