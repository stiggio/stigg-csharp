using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductUnarchiveProductResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUnarchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUnarchiveProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductUnarchiveProductResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUnarchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUnarchiveProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductUnarchiveProductResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductUnarchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUnarchiveProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductUnarchiveProductResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ProductUnarchiveProductResponseData expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUnarchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUnarchiveProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUnarchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = ProductUnarchiveProductResponseDataStatus.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductUnarchiveProductResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductUnarchiveProductResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        ApiEnum<string, ProductUnarchiveProductResponseDataStatus> expectedStatus =
            ProductUnarchiveProductResponseDataStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductUnarchiveProductResponseDataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductUnarchiveProductResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductUnarchiveProductResponseData>(
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
        ApiEnum<string, ProductUnarchiveProductResponseDataStatus> expectedStatus =
            ProductUnarchiveProductResponseDataStatus.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ProductUnarchiveProductResponseDataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ProductSettings);
        Assert.False(model.RawData.ContainsKey("productSettings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
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
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ProductSettings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductUnarchiveProductResponseData
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = ProductUnarchiveProductResponseDataStatus.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup =
                    ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        ProductUnarchiveProductResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductUnarchiveProductResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(ProductUnarchiveProductResponseDataStatus.Published)]
    [InlineData(ProductUnarchiveProductResponseDataStatus.Archived)]
    public void Validation_Works(ProductUnarchiveProductResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductUnarchiveProductResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUnarchiveProductResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ProductUnarchiveProductResponseDataStatus.Published)]
    [InlineData(ProductUnarchiveProductResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(ProductUnarchiveProductResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ProductUnarchiveProductResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUnarchiveProductResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUnarchiveProductResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUnarchiveProductResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductUnarchiveProductResponseDataProductSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductUnarchiveProductResponseDataProductSettings>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ProductUnarchiveProductResponseDataProductSettings>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup
        > expectedSubscriptionEndSetup =
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
        > expectedSubscriptionStartSetup =
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,

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
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,

            DowngradePlanID = null,
            ProrateAtEndOfBillingPeriod = null,
            SubscriptionStartPlanID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ProductUnarchiveProductResponseDataProductSettings
        {
            SubscriptionCancellationTime =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup =
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ProductUnarchiveProductResponseDataProductSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTimeTest
    : TestBase
{
    [Theory]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate
    )]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void Validation_Works(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod
    )]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.Immediate
    )]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime.SpecificDate
    )]
    public void SerializationRoundtrip_Works(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
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
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionCancellationTime
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetupTest : TestBase
{
    [Theory]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree
    )]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription
    )]
    public void Validation_Works(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.DowngradeToFree
    )]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup.CancelSubscription
    )]
    public void SerializationRoundtrip_Works(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ProductUnarchiveProductResponseDataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetupTest : TestBase
{
    [Theory]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection
    )]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod
    )]
    [InlineData(ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void Validation_Works(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
        > value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.PlanSelection
    )]
    [InlineData(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.TrialPeriod
    )]
    [InlineData(ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void SerializationRoundtrip_Works(
        ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<
            string,
            ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
        > value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
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
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
            >
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<
                string,
                ProductUnarchiveProductResponseDataProductSettingsSubscriptionStartSetup
            >
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
