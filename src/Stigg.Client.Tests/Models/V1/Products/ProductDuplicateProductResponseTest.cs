using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductDuplicateProductResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductDuplicateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductDuplicateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductDuplicateProductResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductDuplicateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductDuplicateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductDuplicateProductResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductDuplicateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductDuplicateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductDuplicateProductResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ProductDuplicateProductResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductDuplicateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductDuplicateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductDuplicateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductDuplicateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductDuplicateProductResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductDuplicateProductResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        ApiEnum<string, ProductDuplicateProductResponseDataStatus> expectedStatus =
            ProductDuplicateProductResponseDataStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductDuplicateProductResponseDataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductDuplicateProductResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductDuplicateProductResponseData>(
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
        ApiEnum<string, ProductDuplicateProductResponseDataStatus> expectedStatus =
            ProductDuplicateProductResponseDataStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductDuplicateProductResponseDataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ProductSettings);
        Assert.False(model.RawData.ContainsKey("productSettings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
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
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ProductSettings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductDuplicateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductDuplicateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        ProductDuplicateProductResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductDuplicateProductResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(ProductDuplicateProductResponseDataStatus.Published)]
    [InlineData(ProductDuplicateProductResponseDataStatus.Archived)]
    public void Validation_Works(ProductDuplicateProductResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductDuplicateProductResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductDuplicateProductResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductDuplicateProductResponseDataStatus.Published)]
    [InlineData(ProductDuplicateProductResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(ProductDuplicateProductResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductDuplicateProductResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductDuplicateProductResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductDuplicateProductResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductDuplicateProductResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductDuplicateProductResponseDataProductSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductDuplicateProductResponseDataProductSettings>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductDuplicateProductResponseDataProductSettings>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,

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
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,

            DowngradePlanID = null,
            ProrateAtEndOfBillingPeriod = null,
            SubscriptionStartPlanID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductDuplicateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ProductDuplicateProductResponseDataProductSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTimeTest
    : TestBase
{
    [Theory]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate
    )]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void Validation_Works(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate
    )]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void SerializationRoundtrip_Works(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
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
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductDuplicateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetupTest : TestBase
{
    [Theory]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree
    )]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription
    )]
    public void Validation_Works(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree
    )]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription
    )]
    public void SerializationRoundtrip_Works(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductDuplicateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetupTest : TestBase
{
    [Theory]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection
    )]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod
    )]
    [InlineData(ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void Validation_Works(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection
    )]
    [InlineData(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod
    )]
    [InlineData(ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void SerializationRoundtrip_Works(
        ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
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
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductDuplicateProductResponseDataProductSettingsSubscriptionStartSetup
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
