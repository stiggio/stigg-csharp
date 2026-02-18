using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Models.V1.Events.Addons;

public class AddonRetrieveAddonResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonRetrieveAddonResponse
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
                    new()
                    {
                        ID = "id",
                        Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
                    },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonRetrieveAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        AddonRetrieveAddonResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonRetrieveAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonRetrieveAddonResponse
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
                    new()
                    {
                        ID = "id",
                        Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
                    },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonRetrieveAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonRetrieveAddonResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonRetrieveAddonResponse
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
                    new()
                    {
                        ID = "id",
                        Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
                    },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonRetrieveAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonRetrieveAddonResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        AddonRetrieveAddonResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonRetrieveAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonRetrieveAddonResponse
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
                    new()
                    {
                        ID = "id",
                        Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
                    },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonRetrieveAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonRetrieveAddonResponse
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
                    new()
                    {
                        ID = "id",
                        Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
                    },
                ],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
                ProductID = "productId",
                Status = AddonRetrieveAddonResponseDataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        AddonRetrieveAddonResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonRetrieveAddonResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonRetrieveAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonRetrieveAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedDependencies = ["string"];
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<AddonRetrieveAddonResponseDataEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, AddonRetrieveAddonResponseDataPricingType> expectedPricingType =
            AddonRetrieveAddonResponseDataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, AddonRetrieveAddonResponseDataStatus> expectedStatus =
            AddonRetrieveAddonResponseDataStatus.Draft;
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
        var model = new AddonRetrieveAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonRetrieveAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonRetrieveAddonResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonRetrieveAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonRetrieveAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonRetrieveAddonResponseData>(
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
        List<AddonRetrieveAddonResponseDataEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, AddonRetrieveAddonResponseDataPricingType> expectedPricingType =
            AddonRetrieveAddonResponseDataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, AddonRetrieveAddonResponseDataStatus> expectedStatus =
            AddonRetrieveAddonResponseDataStatus.Draft;
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
        var model = new AddonRetrieveAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonRetrieveAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonRetrieveAddonResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonRetrieveAddonResponseDataEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonRetrieveAddonResponseDataPricingType.Free,
            ProductID = "productId",
            Status = AddonRetrieveAddonResponseDataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        AddonRetrieveAddonResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonRetrieveAddonResponseDataEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonRetrieveAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType> expectedType =
            AddonRetrieveAddonResponseDataEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonRetrieveAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonRetrieveAddonResponseDataEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonRetrieveAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonRetrieveAddonResponseDataEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType> expectedType =
            AddonRetrieveAddonResponseDataEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonRetrieveAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonRetrieveAddonResponseDataEntitlement
        {
            ID = "id",
            Type = AddonRetrieveAddonResponseDataEntitlementType.Feature,
        };

        AddonRetrieveAddonResponseDataEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonRetrieveAddonResponseDataEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(AddonRetrieveAddonResponseDataEntitlementType.Feature)]
    [InlineData(AddonRetrieveAddonResponseDataEntitlementType.Credit)]
    public void Validation_Works(AddonRetrieveAddonResponseDataEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonRetrieveAddonResponseDataEntitlementType.Feature)]
    [InlineData(AddonRetrieveAddonResponseDataEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(AddonRetrieveAddonResponseDataEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonRetrieveAddonResponseDataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(AddonRetrieveAddonResponseDataPricingType.Free)]
    [InlineData(AddonRetrieveAddonResponseDataPricingType.Paid)]
    [InlineData(AddonRetrieveAddonResponseDataPricingType.Custom)]
    public void Validation_Works(AddonRetrieveAddonResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonRetrieveAddonResponseDataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonRetrieveAddonResponseDataPricingType.Free)]
    [InlineData(AddonRetrieveAddonResponseDataPricingType.Paid)]
    [InlineData(AddonRetrieveAddonResponseDataPricingType.Custom)]
    public void SerializationRoundtrip_Works(AddonRetrieveAddonResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonRetrieveAddonResponseDataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonRetrieveAddonResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(AddonRetrieveAddonResponseDataStatus.Draft)]
    [InlineData(AddonRetrieveAddonResponseDataStatus.Published)]
    [InlineData(AddonRetrieveAddonResponseDataStatus.Archived)]
    public void Validation_Works(AddonRetrieveAddonResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonRetrieveAddonResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonRetrieveAddonResponseDataStatus.Draft)]
    [InlineData(AddonRetrieveAddonResponseDataStatus.Published)]
    [InlineData(AddonRetrieveAddonResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(AddonRetrieveAddonResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonRetrieveAddonResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonRetrieveAddonResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
