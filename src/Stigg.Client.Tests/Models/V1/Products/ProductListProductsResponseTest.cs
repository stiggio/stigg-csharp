using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductListProductsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedMultipleSubscriptions = true;
        ApiEnum<string, ProductListProductsResponseStatus> expectedStatus =
            ProductListProductsResponseStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductListProductsResponseProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedMultipleSubscriptions, model.MultipleSubscriptions);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedProductSettings, model.ProductSettings);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductListProductsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductListProductsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedMultipleSubscriptions = true;
        ApiEnum<string, ProductListProductsResponseStatus> expectedStatus =
            ProductListProductsResponseStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductListProductsResponseProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedMultipleSubscriptions, deserialized.MultipleSubscriptions);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedProductSettings, deserialized.ProductSettings);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ProductSettings);
        Assert.False(model.RawData.ContainsKey("productSettings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ProductSettings = null,
        };

        Assert.Null(model.ProductSettings);
        Assert.False(model.RawData.ContainsKey("productSettings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ProductSettings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductListProductsResponse
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductListProductsResponseStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        ProductListProductsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListProductsResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(ProductListProductsResponseStatus.Published)]
    [InlineData(ProductListProductsResponseStatus.Archived)]
    public void Validation_Works(ProductListProductsResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductListProductsResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProductListProductsResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductListProductsResponseStatus.Published)]
    [InlineData(ProductListProductsResponseStatus.Archived)]
    public void SerializationRoundtrip_Works(ProductListProductsResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductListProductsResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ProductListProductsResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductListProductsResponseProductSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ApiEnum<
            string,
            ProductListProductsResponseProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductListProductsResponseProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductListProductsResponseProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductListProductsResponseProductSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductListProductsResponseProductSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ProductListProductsResponseProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductListProductsResponseProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductListProductsResponseProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,

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
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,

            DowngradePlanID = null,
            ProrateAtEndOfBillingPeriod = null,
            SubscriptionStartPlanID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductListProductsResponseProductSettings
        {
            SubscriptionCancellationTime =
                ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ProductListProductsResponseProductSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductListProductsResponseProductSettingsSubscriptionCancellationTimeTest : TestBase
{
    [Theory]
    [InlineData(
        ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionCancellationTime.Immediate)]
    [InlineData(
        ProductListProductsResponseProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void Validation_Works(
        ProductListProductsResponseProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductListProductsResponseProductSettingsSubscriptionCancellationTime
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionCancellationTime>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductListProductsResponseProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionCancellationTime.Immediate)]
    [InlineData(
        ProductListProductsResponseProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void SerializationRoundtrip_Works(
        ProductListProductsResponseProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductListProductsResponseProductSettingsSubscriptionCancellationTime
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionCancellationTime>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionCancellationTime>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionCancellationTime>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductListProductsResponseProductSettingsSubscriptionEndSetupTest : TestBase
{
    [Theory]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree)]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionEndSetup.CancelSubscription)]
    public void Validation_Works(
        ProductListProductsResponseProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionEndSetup> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionEndSetup.DowngradeToFree)]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionEndSetup.CancelSubscription)]
    public void SerializationRoundtrip_Works(
        ProductListProductsResponseProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionEndSetup> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductListProductsResponseProductSettingsSubscriptionStartSetupTest : TestBase
{
    [Theory]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection)]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionStartSetup.TrialPeriod)]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionStartSetup.FreePlan)]
    public void Validation_Works(
        ProductListProductsResponseProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionStartSetup> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionStartSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionStartSetup.PlanSelection)]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionStartSetup.TrialPeriod)]
    [InlineData(ProductListProductsResponseProductSettingsSubscriptionStartSetup.FreePlan)]
    public void SerializationRoundtrip_Works(
        ProductListProductsResponseProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionStartSetup> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionStartSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionStartSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductListProductsResponseProductSettingsSubscriptionStartSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
