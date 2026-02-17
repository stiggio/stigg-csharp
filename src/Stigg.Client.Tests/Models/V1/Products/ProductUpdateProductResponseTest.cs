using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductUpdateProductResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUpdateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUpdateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductUpdateProductResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUpdateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUpdateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductUpdateProductResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductUpdateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUpdateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductUpdateProductResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ProductUpdateProductResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUpdateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUpdateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUpdateProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUpdateProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductUpdateProductResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductUpdateProductResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        ApiEnum<string, ProductUpdateProductResponseDataStatus> expectedStatus =
            ProductUpdateProductResponseDataStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductUpdateProductResponseDataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductUpdateProductResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductUpdateProductResponseData>(
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
        ApiEnum<string, ProductUpdateProductResponseDataStatus> expectedStatus =
            ProductUpdateProductResponseDataStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductUpdateProductResponseDataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ProductSettings);
        Assert.False(model.RawData.ContainsKey("productSettings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
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
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ProductSettings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductUpdateProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUpdateProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        ProductUpdateProductResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductUpdateProductResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(ProductUpdateProductResponseDataStatus.Published)]
    [InlineData(ProductUpdateProductResponseDataStatus.Archived)]
    public void Validation_Works(ProductUpdateProductResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductUpdateProductResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductUpdateProductResponseDataStatus.Published)]
    [InlineData(ProductUpdateProductResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(ProductUpdateProductResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductUpdateProductResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductUpdateProductResponseDataProductSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductUpdateProductResponseDataProductSettings>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductUpdateProductResponseDataProductSettings>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,

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
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,

            DowngradePlanID = null,
            ProrateAtEndOfBillingPeriod = null,
            SubscriptionStartPlanID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductUpdateProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ProductUpdateProductResponseDataProductSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTimeTest
    : TestBase
{
    [Theory]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate
    )]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void Validation_Works(
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate
    )]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void SerializationRoundtrip_Works(
        ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
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
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUpdateProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetupTest : TestBase
{
    [Theory]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree
    )]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription
    )]
    public void Validation_Works(
        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree
    )]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription
    )]
    public void SerializationRoundtrip_Works(
        ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetupTest : TestBase
{
    [Theory]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection
    )]
    [InlineData(ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod)]
    [InlineData(ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void Validation_Works(
        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection
    )]
    [InlineData(ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod)]
    [InlineData(ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void SerializationRoundtrip_Works(
        ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUpdateProductResponseDataProductSettingsSubscriptionStartSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
