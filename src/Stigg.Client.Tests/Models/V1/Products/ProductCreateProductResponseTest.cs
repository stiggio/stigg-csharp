using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductCreateProductResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCreateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductCreateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductCreateProductResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ProductCreateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductCreateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCreateProductResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCreateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductCreateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCreateProductResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ProductCreateProductResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ProductCreateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductCreateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCreateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductCreateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductCreateProductResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductCreateProductResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        ApiEnum<string, ProductCreateProductResponseDataStatus> expectedStatus =
            ProductCreateProductResponseDataStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductCreateProductResponseDataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCreateProductResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductCreateProductResponseData>(
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
        ApiEnum<string, ProductCreateProductResponseDataStatus> expectedStatus =
            ProductCreateProductResponseDataStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductCreateProductResponseDataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ProductSettings);
        Assert.False(model.RawData.ContainsKey("productSettings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
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
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ProductSettings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCreateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductCreateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        ProductCreateProductResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductCreateProductResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(ProductCreateProductResponseDataStatus.Published)]
    [InlineData(ProductCreateProductResponseDataStatus.Archived)]
    public void Validation_Works(ProductCreateProductResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCreateProductResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductCreateProductResponseDataStatus.Published)]
    [InlineData(ProductCreateProductResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(ProductCreateProductResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCreateProductResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCreateProductResponseDataProductSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductCreateProductResponseDataProductSettings>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductCreateProductResponseDataProductSettings>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,

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
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,

            DowngradePlanID = null,
            ProrateAtEndOfBillingPeriod = null,
            SubscriptionStartPlanID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductCreateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ProductCreateProductResponseDataProductSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTimeTest
    : TestBase
{
    [Theory]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate
    )]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void Validation_Works(
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate
    )]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void SerializationRoundtrip_Works(
        ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
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
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductCreateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCreateProductResponseDataProductSettingsSubscriptionEndSetupTest : TestBase
{
    [Theory]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree
    )]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription
    )]
    public void Validation_Works(
        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree
    )]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription
    )]
    public void SerializationRoundtrip_Works(
        ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductCreateProductResponseDataProductSettingsSubscriptionStartSetupTest : TestBase
{
    [Theory]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection
    )]
    [InlineData(ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod)]
    [InlineData(ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void Validation_Works(
        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection
    )]
    [InlineData(ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod)]
    [InlineData(ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void SerializationRoundtrip_Works(
        ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductCreateProductResponseDataProductSettingsSubscriptionStartSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
