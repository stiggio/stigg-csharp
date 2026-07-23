using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductUpdateProductParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductUpdateProductParams
        {
            ID = "x",
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            ProductSettings = new()
            {
                SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
            UsageResetCutoffRule = new(Behavior.NeverReset),
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedMultipleSubscriptions = true;
        ProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };
        UsageResetCutoffRule expectedUsageResetCutoffRule = new(Behavior.NeverReset);
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedMultipleSubscriptions, parameters.MultipleSubscriptions);
        Assert.Equal(expectedProductSettings, parameters.ProductSettings);
        Assert.Equal(expectedUsageResetCutoffRule, parameters.UsageResetCutoffRule);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductUpdateProductParams
        {
            ID = "x",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.MultipleSubscriptions);
        Assert.False(parameters.RawBodyData.ContainsKey("multipleSubscriptions"));
        Assert.Null(parameters.ProductSettings);
        Assert.False(parameters.RawBodyData.ContainsKey("productSettings"));
        Assert.Null(parameters.UsageResetCutoffRule);
        Assert.False(parameters.RawBodyData.ContainsKey("usageResetCutoffRule"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ProductUpdateProductParams
        {
            ID = "x",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            MultipleSubscriptions = null,
            ProductSettings = null,
            UsageResetCutoffRule = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.MultipleSubscriptions);
        Assert.False(parameters.RawBodyData.ContainsKey("multipleSubscriptions"));
        Assert.Null(parameters.ProductSettings);
        Assert.False(parameters.RawBodyData.ContainsKey("productSettings"));
        Assert.Null(parameters.UsageResetCutoffRule);
        Assert.False(parameters.RawBodyData.ContainsKey("usageResetCutoffRule"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ProductUpdateProductParams
        {
            ID = "x",
            DisplayName = "displayName",
            MultipleSubscriptions = true,
            ProductSettings = new()
            {
                SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
            UsageResetCutoffRule = new(Behavior.NeverReset),
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ProductUpdateProductParams
        {
            ID = "x",
            DisplayName = "displayName",
            MultipleSubscriptions = true,
            ProductSettings = new()
            {
                SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
            UsageResetCutoffRule = new(Behavior.NeverReset),
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            Description = null,
            Metadata = null,
        };

        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.Metadata);
        Assert.True(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void Url_Works()
    {
        ProductUpdateProductParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/products/x"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ProductUpdateProductParams parameters = new()
        {
            ID = "x",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["X-ACCOUNT-ID"], requestMessage.Headers.GetValues("X-ACCOUNT-ID"));
        Assert.Equal(["X-ENVIRONMENT-ID"], requestMessage.Headers.GetValues("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductUpdateProductParams
        {
            ID = "x",
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            ProductSettings = new()
            {
                SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
            UsageResetCutoffRule = new(Behavior.NeverReset),
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        ProductUpdateProductParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ProductSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ApiEnum<string, SubscriptionCancellationTime> expectedSubscriptionCancellationTime =
            SubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<string, SubscriptionEndSetup> expectedSubscriptionEndSetup =
            SubscriptionEndSetup.DowngradeToFree;
        ApiEnum<string, SubscriptionStartSetup> expectedSubscriptionStartSetup =
            SubscriptionStartSetup.PlanSelection;
        string expectedDowngradePlanID = "downgradePlanId";
        bool expectedProrateAtEndOfBillingPeriod = true;
        string expectedSubscriptionStartPlanID = "subscriptionStartPlanId";

        Assert.Equal(expectedSubscriptionCancellationTime, model.SubscriptionCancellationTime);
        Assert.Equal(expectedSubscriptionEndSetup, model.SubscriptionEndSetup);
        Assert.Equal(expectedSubscriptionStartSetup, model.SubscriptionStartSetup);
        Assert.Equal(expectedDowngradePlanID, model.DowngradePlanID);
        Assert.Equal(expectedProrateAtEndOfBillingPeriod, model.ProrateAtEndOfBillingPeriod);
        Assert.Equal(expectedSubscriptionStartPlanID, model.SubscriptionStartPlanID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SubscriptionCancellationTime> expectedSubscriptionCancellationTime =
            SubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<string, SubscriptionEndSetup> expectedSubscriptionEndSetup =
            SubscriptionEndSetup.DowngradeToFree;
        ApiEnum<string, SubscriptionStartSetup> expectedSubscriptionStartSetup =
            SubscriptionStartSetup.PlanSelection;
        string expectedDowngradePlanID = "downgradePlanId";
        bool expectedProrateAtEndOfBillingPeriod = true;
        string expectedSubscriptionStartPlanID = "subscriptionStartPlanId";

        Assert.Equal(
            expectedSubscriptionCancellationTime,
            deserialized.SubscriptionCancellationTime
        );
        Assert.Equal(expectedSubscriptionEndSetup, deserialized.SubscriptionEndSetup);
        Assert.Equal(expectedSubscriptionStartSetup, deserialized.SubscriptionStartSetup);
        Assert.Equal(expectedDowngradePlanID, deserialized.DowngradePlanID);
        Assert.Equal(expectedProrateAtEndOfBillingPeriod, deserialized.ProrateAtEndOfBillingPeriod);
        Assert.Equal(expectedSubscriptionStartPlanID, deserialized.SubscriptionStartPlanID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
        };

        Assert.Null(model.DowngradePlanID);
        Assert.False(model.RawData.ContainsKey("downgradePlanId"));
        Assert.Null(model.ProrateAtEndOfBillingPeriod);
        Assert.False(model.RawData.ContainsKey("prorateAtEndOfBillingPeriod"));
        Assert.Null(model.SubscriptionStartPlanID);
        Assert.False(model.RawData.ContainsKey("subscriptionStartPlanId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,

            DowngradePlanID = null,
            ProrateAtEndOfBillingPeriod = null,
            SubscriptionStartPlanID = null,
        };

        Assert.Null(model.DowngradePlanID);
        Assert.True(model.RawData.ContainsKey("downgradePlanId"));
        Assert.Null(model.ProrateAtEndOfBillingPeriod);
        Assert.True(model.RawData.ContainsKey("prorateAtEndOfBillingPeriod"));
        Assert.Null(model.SubscriptionStartPlanID);
        Assert.True(model.RawData.ContainsKey("subscriptionStartPlanId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,

            DowngradePlanID = null,
            ProrateAtEndOfBillingPeriod = null,
            SubscriptionStartPlanID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductSettings
        {
            SubscriptionCancellationTime = SubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = SubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = SubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ProductSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionCancellationTimeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionCancellationTime.EndOfBillingPeriod)]
    [InlineData(SubscriptionCancellationTime.Immediate)]
    [InlineData(SubscriptionCancellationTime.SpecificDate)]
    public void Validation_Works(SubscriptionCancellationTime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionCancellationTime> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionCancellationTime>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionCancellationTime.EndOfBillingPeriod)]
    [InlineData(SubscriptionCancellationTime.Immediate)]
    [InlineData(SubscriptionCancellationTime.SpecificDate)]
    public void SerializationRoundtrip_Works(SubscriptionCancellationTime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionCancellationTime> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionCancellationTime>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionCancellationTime>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionCancellationTime>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionEndSetupTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionEndSetup.DowngradeToFree)]
    [InlineData(SubscriptionEndSetup.CancelSubscription)]
    public void Validation_Works(SubscriptionEndSetup rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionEndSetup> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionEndSetup>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionEndSetup.DowngradeToFree)]
    [InlineData(SubscriptionEndSetup.CancelSubscription)]
    public void SerializationRoundtrip_Works(SubscriptionEndSetup rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionEndSetup> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionEndSetup>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionEndSetup>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionEndSetup>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionStartSetupTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionStartSetup.PlanSelection)]
    [InlineData(SubscriptionStartSetup.TrialPeriod)]
    [InlineData(SubscriptionStartSetup.FreePlan)]
    public void Validation_Works(SubscriptionStartSetup rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStartSetup> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStartSetup>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionStartSetup.PlanSelection)]
    [InlineData(SubscriptionStartSetup.TrialPeriod)]
    [InlineData(SubscriptionStartSetup.FreePlan)]
    public void SerializationRoundtrip_Works(SubscriptionStartSetup rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStartSetup> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStartSetup>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStartSetup>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStartSetup>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class UsageResetCutoffRuleTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageResetCutoffRule { Behavior = Behavior.NeverReset };

        ApiEnum<string, Behavior> expectedBehavior = Behavior.NeverReset;

        Assert.Equal(expectedBehavior, model.Behavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageResetCutoffRule { Behavior = Behavior.NeverReset };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageResetCutoffRule>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageResetCutoffRule { Behavior = Behavior.NeverReset };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageResetCutoffRule>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, Behavior> expectedBehavior = Behavior.NeverReset;

        Assert.Equal(expectedBehavior, deserialized.Behavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageResetCutoffRule { Behavior = Behavior.NeverReset };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageResetCutoffRule { Behavior = Behavior.NeverReset };

        UsageResetCutoffRule copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BehaviorTest : TestBase
{
    [Theory]
    [InlineData(Behavior.NeverReset)]
    [InlineData(Behavior.AlwaysReset)]
    [InlineData(Behavior.BillingPeriodChange)]
    public void Validation_Works(Behavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Behavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Behavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Behavior.NeverReset)]
    [InlineData(Behavior.AlwaysReset)]
    [InlineData(Behavior.BillingPeriodChange)]
    public void SerializationRoundtrip_Works(Behavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Behavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Behavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Behavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Behavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
