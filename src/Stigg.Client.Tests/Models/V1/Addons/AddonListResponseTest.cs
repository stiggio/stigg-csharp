using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class AddonListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = AddonListResponseEntitlementType.Feature }],
            IsLatest = true,
            MaxQuantity = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListResponsePricingType.Free,
            ProductID = "productId",
            Status = AddonListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedDependencies = ["string"];
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<AddonListResponseEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 1;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, AddonListResponsePricingType> expectedPricingType =
            AddonListResponsePricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, AddonListResponseStatus> expectedStatus = AddonListResponseStatus.Draft;
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
        var model = new AddonListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = AddonListResponseEntitlementType.Feature }],
            IsLatest = true,
            MaxQuantity = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListResponsePricingType.Free,
            ProductID = "productId",
            Status = AddonListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = AddonListResponseEntitlementType.Feature }],
            IsLatest = true,
            MaxQuantity = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListResponsePricingType.Free,
            ProductID = "productId",
            Status = AddonListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListResponse>(
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
        List<AddonListResponseEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = AddonListResponseEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 1;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, AddonListResponsePricingType> expectedPricingType =
            AddonListResponsePricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, AddonListResponseStatus> expectedStatus = AddonListResponseStatus.Draft;
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
        var model = new AddonListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = AddonListResponseEntitlementType.Feature }],
            IsLatest = true,
            MaxQuantity = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListResponsePricingType.Free,
            ProductID = "productId",
            Status = AddonListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = AddonListResponseEntitlementType.Feature }],
            IsLatest = true,
            MaxQuantity = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListResponsePricingType.Free,
            ProductID = "productId",
            Status = AddonListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        AddonListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListResponseEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListResponseEntitlement
        {
            ID = "id",
            Type = AddonListResponseEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<string, AddonListResponseEntitlementType> expectedType =
            AddonListResponseEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonListResponseEntitlement
        {
            ID = "id",
            Type = AddonListResponseEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListResponseEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListResponseEntitlement
        {
            ID = "id",
            Type = AddonListResponseEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListResponseEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, AddonListResponseEntitlementType> expectedType =
            AddonListResponseEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonListResponseEntitlement
        {
            ID = "id",
            Type = AddonListResponseEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListResponseEntitlement
        {
            ID = "id",
            Type = AddonListResponseEntitlementType.Feature,
        };

        AddonListResponseEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListResponseEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(AddonListResponseEntitlementType.Feature)]
    [InlineData(AddonListResponseEntitlementType.Credit)]
    public void Validation_Works(AddonListResponseEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListResponseEntitlementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListResponseEntitlementType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListResponseEntitlementType.Feature)]
    [InlineData(AddonListResponseEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(AddonListResponseEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListResponseEntitlementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListResponseEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListResponseEntitlementType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListResponseEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListResponsePricingTypeTest : TestBase
{
    [Theory]
    [InlineData(AddonListResponsePricingType.Free)]
    [InlineData(AddonListResponsePricingType.Paid)]
    [InlineData(AddonListResponsePricingType.Custom)]
    public void Validation_Works(AddonListResponsePricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListResponsePricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListResponsePricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListResponsePricingType.Free)]
    [InlineData(AddonListResponsePricingType.Paid)]
    [InlineData(AddonListResponsePricingType.Custom)]
    public void SerializationRoundtrip_Works(AddonListResponsePricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListResponsePricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListResponsePricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListResponsePricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListResponsePricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(AddonListResponseStatus.Draft)]
    [InlineData(AddonListResponseStatus.Published)]
    [InlineData(AddonListResponseStatus.Archived)]
    public void Validation_Works(AddonListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListResponseStatus.Draft)]
    [InlineData(AddonListResponseStatus.Published)]
    [InlineData(AddonListResponseStatus.Archived)]
    public void SerializationRoundtrip_Works(AddonListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AddonListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AddonListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
