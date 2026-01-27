using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            AwaitPaymentConfirmation = true,
            BillingPeriod = BillingPeriod.Monthly,
            CheckoutOptions = new()
            {
                CancelUrl = "https://example.com",
                SuccessUrl = "https://example.com",
                AllowPromoCodes = true,
                AllowTaxIDCollection = true,
                CollectBillingAddress = true,
                CollectPhoneNumber = true,
                ReferenceID = "referenceId",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        string expectedID = "id";
        bool expectedAwaitPaymentConfirmation = true;
        ApiEnum<string, BillingPeriod> expectedBillingPeriod = BillingPeriod.Monthly;
        CheckoutOptions expectedCheckoutOptions = new()
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPayingCustomerID = "payingCustomerId";
        string expectedResourceID = "resourceId";
        TrialOverrideConfiguration expectedTrialOverrideConfiguration = new()
        {
            IsTrial = true,
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAwaitPaymentConfirmation, parameters.AwaitPaymentConfirmation);
        Assert.Equal(expectedBillingPeriod, parameters.BillingPeriod);
        Assert.Equal(expectedCheckoutOptions, parameters.CheckoutOptions);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedPayingCustomerID, parameters.PayingCustomerID);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedTrialOverrideConfiguration, parameters.TrialOverrideConfiguration);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
        };

        Assert.Null(parameters.AwaitPaymentConfirmation);
        Assert.False(parameters.RawBodyData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(parameters.BillingPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("billingPeriod"));
        Assert.Null(parameters.CheckoutOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("checkoutOptions"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.TrialOverrideConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("trialOverrideConfiguration"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            AwaitPaymentConfirmation = null,
            BillingPeriod = null,
            CheckoutOptions = null,
            Metadata = null,
            TrialOverrideConfiguration = null,
        };

        Assert.Null(parameters.AwaitPaymentConfirmation);
        Assert.False(parameters.RawBodyData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(parameters.BillingPeriod);
        Assert.False(parameters.RawBodyData.ContainsKey("billingPeriod"));
        Assert.Null(parameters.CheckoutOptions);
        Assert.False(parameters.RawBodyData.ContainsKey("checkoutOptions"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.TrialOverrideConfiguration);
        Assert.False(parameters.RawBodyData.ContainsKey("trialOverrideConfiguration"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            AwaitPaymentConfirmation = true,
            BillingPeriod = BillingPeriod.Monthly,
            CheckoutOptions = new()
            {
                CancelUrl = "https://example.com",
                SuccessUrl = "https://example.com",
                AllowPromoCodes = true,
                AllowTaxIDCollection = true,
                CollectBillingAddress = true,
                CollectPhoneNumber = true,
                ReferenceID = "referenceId",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Null(parameters.ID);
        Assert.False(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.PayingCustomerID);
        Assert.False(parameters.RawBodyData.ContainsKey("payingCustomerId"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            AwaitPaymentConfirmation = true,
            BillingPeriod = BillingPeriod.Monthly,
            CheckoutOptions = new()
            {
                CancelUrl = "https://example.com",
                SuccessUrl = "https://example.com",
                AllowPromoCodes = true,
                AllowTaxIDCollection = true,
                CollectBillingAddress = true,
                CollectPhoneNumber = true,
                ReferenceID = "referenceId",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            ID = null,
            PayingCustomerID = null,
            ResourceID = null,
        };

        Assert.Null(parameters.ID);
        Assert.True(parameters.RawBodyData.ContainsKey("id"));
        Assert.Null(parameters.PayingCustomerID);
        Assert.True(parameters.RawBodyData.ContainsKey("payingCustomerId"));
        Assert.Null(parameters.ResourceID);
        Assert.True(parameters.RawBodyData.ContainsKey("resourceId"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionCreateParams parameters = new()
        {
            CustomerID = "customerId",
            PlanID = "planId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/subscriptions"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionCreateParams
        {
            CustomerID = "customerId",
            PlanID = "planId",
            ID = "id",
            AwaitPaymentConfirmation = true,
            BillingPeriod = BillingPeriod.Monthly,
            CheckoutOptions = new()
            {
                CancelUrl = "https://example.com",
                SuccessUrl = "https://example.com",
                AllowPromoCodes = true,
                AllowTaxIDCollection = true,
                CollectBillingAddress = true,
                CollectPhoneNumber = true,
                ReferenceID = "referenceId",
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            ResourceID = "resourceId",
            TrialOverrideConfiguration = new()
            {
                IsTrial = true,
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        SubscriptionCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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

public class CheckoutOptionsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        string expectedCancelUrl = "https://example.com";
        string expectedSuccessUrl = "https://example.com";
        bool expectedAllowPromoCodes = true;
        bool expectedAllowTaxIDCollection = true;
        bool expectedCollectBillingAddress = true;
        bool expectedCollectPhoneNumber = true;
        string expectedReferenceID = "referenceId";

        Assert.Equal(expectedCancelUrl, model.CancelUrl);
        Assert.Equal(expectedSuccessUrl, model.SuccessUrl);
        Assert.Equal(expectedAllowPromoCodes, model.AllowPromoCodes);
        Assert.Equal(expectedAllowTaxIDCollection, model.AllowTaxIDCollection);
        Assert.Equal(expectedCollectBillingAddress, model.CollectBillingAddress);
        Assert.Equal(expectedCollectPhoneNumber, model.CollectPhoneNumber);
        Assert.Equal(expectedReferenceID, model.ReferenceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutOptions>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CheckoutOptions>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCancelUrl = "https://example.com";
        string expectedSuccessUrl = "https://example.com";
        bool expectedAllowPromoCodes = true;
        bool expectedAllowTaxIDCollection = true;
        bool expectedCollectBillingAddress = true;
        bool expectedCollectPhoneNumber = true;
        string expectedReferenceID = "referenceId";

        Assert.Equal(expectedCancelUrl, deserialized.CancelUrl);
        Assert.Equal(expectedSuccessUrl, deserialized.SuccessUrl);
        Assert.Equal(expectedAllowPromoCodes, deserialized.AllowPromoCodes);
        Assert.Equal(expectedAllowTaxIDCollection, deserialized.AllowTaxIDCollection);
        Assert.Equal(expectedCollectBillingAddress, deserialized.CollectBillingAddress);
        Assert.Equal(expectedCollectPhoneNumber, deserialized.CollectPhoneNumber);
        Assert.Equal(expectedReferenceID, deserialized.ReferenceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            ReferenceID = "referenceId",
        };

        Assert.Null(model.AllowPromoCodes);
        Assert.False(model.RawData.ContainsKey("allowPromoCodes"));
        Assert.Null(model.AllowTaxIDCollection);
        Assert.False(model.RawData.ContainsKey("allowTaxIdCollection"));
        Assert.Null(model.CollectBillingAddress);
        Assert.False(model.RawData.ContainsKey("collectBillingAddress"));
        Assert.Null(model.CollectPhoneNumber);
        Assert.False(model.RawData.ContainsKey("collectPhoneNumber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            ReferenceID = "referenceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            ReferenceID = "referenceId",

            // Null should be interpreted as omitted for these properties
            AllowPromoCodes = null,
            AllowTaxIDCollection = null,
            CollectBillingAddress = null,
            CollectPhoneNumber = null,
        };

        Assert.Null(model.AllowPromoCodes);
        Assert.False(model.RawData.ContainsKey("allowPromoCodes"));
        Assert.Null(model.AllowTaxIDCollection);
        Assert.False(model.RawData.ContainsKey("allowTaxIdCollection"));
        Assert.Null(model.CollectBillingAddress);
        Assert.False(model.RawData.ContainsKey("collectBillingAddress"));
        Assert.Null(model.CollectPhoneNumber);
        Assert.False(model.RawData.ContainsKey("collectPhoneNumber"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            ReferenceID = "referenceId",

            // Null should be interpreted as omitted for these properties
            AllowPromoCodes = null,
            AllowTaxIDCollection = null,
            CollectBillingAddress = null,
            CollectPhoneNumber = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
        };

        Assert.Null(model.ReferenceID);
        Assert.False(model.RawData.ContainsKey("referenceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,

            ReferenceID = null,
        };

        Assert.Null(model.ReferenceID);
        Assert.True(model.RawData.ContainsKey("referenceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,

            ReferenceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CheckoutOptions
        {
            CancelUrl = "https://example.com",
            SuccessUrl = "https://example.com",
            AllowPromoCodes = true,
            AllowTaxIDCollection = true,
            CollectBillingAddress = true,
            CollectPhoneNumber = true,
            ReferenceID = "referenceId",
        };

        CheckoutOptions copied = new(model);

        Assert.Equal(model, copied);
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
