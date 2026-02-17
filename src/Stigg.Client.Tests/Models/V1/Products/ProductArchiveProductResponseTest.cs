using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductArchiveProductResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ProductArchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = Status.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        DataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        Data expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductArchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = Status.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        DataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductArchiveProductResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ProductArchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = Status.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        DataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ProductArchiveProductResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductArchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = Status.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        DataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new ProductArchiveProductResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                MultipleSubscriptions = true,
                Status = Status.Published,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ProductSettings = new()
                {
                    SubscriptionCancellationTime =
                        DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                    SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                    SubscriptionStartSetup =
                        DataProductSettingsSubscriptionStartSetup.PlanSelection,
                    DowngradePlanID = "downgradePlanId",
                    ProrateAtEndOfBillingPeriod = true,
                    SubscriptionStartPlanID = "subscriptionStartPlanId",
                },
            },
        };

        ProductArchiveProductResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        ApiEnum<string, Status> expectedStatus = Status.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        bool expectedMultipleSubscriptions = true;
        ApiEnum<string, Status> expectedStatus = Status.Published;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DataProductSettings expectedProductSettings = new()
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ProductSettings);
        Assert.False(model.RawData.ContainsKey("productSettings"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
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
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            ProductSettings = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            MultipleSubscriptions = true,
            Status = Status.Published,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ProductSettings = new()
            {
                SubscriptionCancellationTime =
                    DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
                SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
                SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
                DowngradePlanID = "downgradePlanId",
                ProrateAtEndOfBillingPeriod = true,
                SubscriptionStartPlanID = "subscriptionStartPlanId",
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Published)]
    [InlineData(Status.Archived)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Published)]
    [InlineData(Status.Archived)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataProductSettingsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        ApiEnum<
            string,
            DataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<string, DataProductSettingsSubscriptionEndSetup> expectedSubscriptionEndSetup =
            DataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<string, DataProductSettingsSubscriptionStartSetup> expectedSubscriptionStartSetup =
            DataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataProductSettings>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataProductSettings>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<
            string,
            DataProductSettingsSubscriptionCancellationTime
        > expectedSubscriptionCancellationTime =
            DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod;
        ApiEnum<string, DataProductSettingsSubscriptionEndSetup> expectedSubscriptionEndSetup =
            DataProductSettingsSubscriptionEndSetup.DowngradeToFree;
        ApiEnum<string, DataProductSettingsSubscriptionStartSetup> expectedSubscriptionStartSetup =
            DataProductSettingsSubscriptionStartSetup.PlanSelection;
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
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
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
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,

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
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,

            DowngradePlanID = null,
            ProrateAtEndOfBillingPeriod = null,
            SubscriptionStartPlanID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataProductSettings
        {
            SubscriptionCancellationTime =
                DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod,
            SubscriptionEndSetup = DataProductSettingsSubscriptionEndSetup.DowngradeToFree,
            SubscriptionStartSetup = DataProductSettingsSubscriptionStartSetup.PlanSelection,
            DowngradePlanID = "downgradePlanId",
            ProrateAtEndOfBillingPeriod = true,
            SubscriptionStartPlanID = "subscriptionStartPlanId",
        };

        DataProductSettings copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataProductSettingsSubscriptionCancellationTimeTest : TestBase
{
    [Theory]
    [InlineData(DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod)]
    [InlineData(DataProductSettingsSubscriptionCancellationTime.Immediate)]
    [InlineData(DataProductSettingsSubscriptionCancellationTime.SpecificDate)]
    public void Validation_Works(DataProductSettingsSubscriptionCancellationTime rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataProductSettingsSubscriptionCancellationTime> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionCancellationTime>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataProductSettingsSubscriptionCancellationTime.EndOfBillingPeriod)]
    [InlineData(DataProductSettingsSubscriptionCancellationTime.Immediate)]
    [InlineData(DataProductSettingsSubscriptionCancellationTime.SpecificDate)]
    public void SerializationRoundtrip_Works(
        DataProductSettingsSubscriptionCancellationTime rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataProductSettingsSubscriptionCancellationTime> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionCancellationTime>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionCancellationTime>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionCancellationTime>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataProductSettingsSubscriptionEndSetupTest : TestBase
{
    [Theory]
    [InlineData(DataProductSettingsSubscriptionEndSetup.DowngradeToFree)]
    [InlineData(DataProductSettingsSubscriptionEndSetup.CancelSubscription)]
    public void Validation_Works(DataProductSettingsSubscriptionEndSetup rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataProductSettingsSubscriptionEndSetup> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataProductSettingsSubscriptionEndSetup.DowngradeToFree)]
    [InlineData(DataProductSettingsSubscriptionEndSetup.CancelSubscription)]
    public void SerializationRoundtrip_Works(DataProductSettingsSubscriptionEndSetup rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataProductSettingsSubscriptionEndSetup> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionEndSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionEndSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataProductSettingsSubscriptionStartSetupTest : TestBase
{
    [Theory]
    [InlineData(DataProductSettingsSubscriptionStartSetup.PlanSelection)]
    [InlineData(DataProductSettingsSubscriptionStartSetup.TrialPeriod)]
    [InlineData(DataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void Validation_Works(DataProductSettingsSubscriptionStartSetup rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataProductSettingsSubscriptionStartSetup> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionStartSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataProductSettingsSubscriptionStartSetup.PlanSelection)]
    [InlineData(DataProductSettingsSubscriptionStartSetup.TrialPeriod)]
    [InlineData(DataProductSettingsSubscriptionStartSetup.FreePlan)]
    public void SerializationRoundtrip_Works(DataProductSettingsSubscriptionStartSetup rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataProductSettingsSubscriptionStartSetup> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionStartSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionStartSetup>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataProductSettingsSubscriptionStartSetup>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
