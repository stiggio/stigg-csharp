using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Models.V1.Events.Addons;

public class AddonCreateAddonResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonCreateAddonResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonCreateAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonCreateAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        AddonCreateAddonResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonCreateAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonCreateAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonCreateAddonResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonCreateAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonCreateAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonCreateAddonResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonCreateAddonResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonCreateAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonCreateAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonCreateAddonResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AddonCreateAddonResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonCreateAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonCreateAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonCreateAddonResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonCreateAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonCreateAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonCreateAddonResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements =
                [
                    new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonCreateAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonCreateAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        AddonCreateAddonResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonCreateAddonResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonCreateAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonCreateAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonCreateAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedDependencies = ["string"];
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<AddonCreateAddonResponseDataEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, AddonCreateAddonResponseDataPricingType> expectedPricingType =
            AddonCreateAddonResponseDataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, AddonCreateAddonResponseDataStatus> expectedStatus =
            AddonCreateAddonResponseDataStatus.Draft;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNumber = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Dependencies);
        Assert.Equal(expectedDependencies.Count, model.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], model.Dependencies[i]);
        }
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
        Assert.Equal(expectedIsLatest, model.IsLatest);
        Assert.Equal(expectedMaxQuantity, model.MaxQuantity);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPricingType, model.PricingType);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersionNumber, model.VersionNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonCreateAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonCreateAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonCreateAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonCreateAddonResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonCreateAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonCreateAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonCreateAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonCreateAddonResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedDependencies = ["string"];
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<AddonCreateAddonResponseDataEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, AddonCreateAddonResponseDataPricingType> expectedPricingType =
            AddonCreateAddonResponseDataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, AddonCreateAddonResponseDataStatus> expectedStatus =
            AddonCreateAddonResponseDataStatus.Draft;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNumber = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Dependencies);
        Assert.Equal(expectedDependencies.Count, deserialized.Dependencies.Count);
        for (int i = 0; i < expectedDependencies.Count; i++)
        {
            Assert.Equal(expectedDependencies[i], deserialized.Dependencies[i]);
        }
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
        Assert.Equal(expectedIsLatest, deserialized.IsLatest);
        Assert.Equal(expectedMaxQuantity, deserialized.MaxQuantity);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPricingType, deserialized.PricingType);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersionNumber, deserialized.VersionNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonCreateAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonCreateAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonCreateAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonCreateAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonCreateAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonCreateAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonCreateAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        AddonCreateAddonResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonCreateAddonResponseDataEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonCreateAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonCreateAddonResponseDataEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<string, AddonCreateAddonResponseDataEntitlementType> expectedType =
            AddonCreateAddonResponseDataEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonCreateAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonCreateAddonResponseDataEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonCreateAddonResponseDataEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonCreateAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonCreateAddonResponseDataEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonCreateAddonResponseDataEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, AddonCreateAddonResponseDataEntitlementType> expectedType =
            AddonCreateAddonResponseDataEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonCreateAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonCreateAddonResponseDataEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonCreateAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonCreateAddonResponseDataEntitlementType.Feature,
        };

        AddonCreateAddonResponseDataEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonCreateAddonResponseDataEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(AddonCreateAddonResponseDataEntitlementType.Feature)]
    [InlineData(AddonCreateAddonResponseDataEntitlementType.Credit)]
    public void Validation_Works(AddonCreateAddonResponseDataEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonCreateAddonResponseDataEntitlementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonCreateAddonResponseDataEntitlementType.Feature)]
    [InlineData(AddonCreateAddonResponseDataEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(AddonCreateAddonResponseDataEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonCreateAddonResponseDataEntitlementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonCreateAddonResponseDataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(AddonCreateAddonResponseDataPricingType.Free)]
    [InlineData(AddonCreateAddonResponseDataPricingType.Paid)]
    [InlineData(AddonCreateAddonResponseDataPricingType.Custom)]
    public void Validation_Works(AddonCreateAddonResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonCreateAddonResponseDataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonCreateAddonResponseDataPricingType.Free)]
    [InlineData(AddonCreateAddonResponseDataPricingType.Paid)]
    [InlineData(AddonCreateAddonResponseDataPricingType.Custom)]
    public void SerializationRoundtrip_Works(AddonCreateAddonResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonCreateAddonResponseDataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonCreateAddonResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(AddonCreateAddonResponseDataStatus.Draft)]
    [InlineData(AddonCreateAddonResponseDataStatus.Published)]
    [InlineData(AddonCreateAddonResponseDataStatus.Archived)]
    public void Validation_Works(AddonCreateAddonResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonCreateAddonResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonCreateAddonResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonCreateAddonResponseDataStatus.Draft)]
    [InlineData(AddonCreateAddonResponseDataStatus.Published)]
    [InlineData(AddonCreateAddonResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(AddonCreateAddonResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonCreateAddonResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonCreateAddonResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonCreateAddonResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
