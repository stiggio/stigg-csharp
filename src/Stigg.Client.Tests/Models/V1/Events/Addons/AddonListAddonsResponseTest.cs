using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Models.V1.Events.Addons;

public class AddonListAddonsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListAddonsResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonListAddonsResponseEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListAddonsResponsePricingType.Free,
            Status = AddonListAddonsResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedDependencies = ["string"];
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<AddonListAddonsResponseEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = AddonListAddonsResponseEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, AddonListAddonsResponsePricingType> expectedPricingType =
            AddonListAddonsResponsePricingType.Free;
        ApiEnum<string, AddonListAddonsResponseStatus> expectedStatus =
            AddonListAddonsResponseStatus.Draft;
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
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersionNumber, model.VersionNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonListAddonsResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonListAddonsResponseEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListAddonsResponsePricingType.Free,
            Status = AddonListAddonsResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListAddonsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListAddonsResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonListAddonsResponseEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListAddonsResponsePricingType.Free,
            Status = AddonListAddonsResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListAddonsResponse>(
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
        List<AddonListAddonsResponseEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = AddonListAddonsResponseEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, AddonListAddonsResponsePricingType> expectedPricingType =
            AddonListAddonsResponsePricingType.Free;
        ApiEnum<string, AddonListAddonsResponseStatus> expectedStatus =
            AddonListAddonsResponseStatus.Draft;
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
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersionNumber, deserialized.VersionNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonListAddonsResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonListAddonsResponseEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListAddonsResponsePricingType.Free,
            Status = AddonListAddonsResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListAddonsResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements =
            [
                new() { ID = "id", Type = AddonListAddonsResponseEntitlementType.Feature },
            ],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = AddonListAddonsResponsePricingType.Free,
            Status = AddonListAddonsResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        AddonListAddonsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListAddonsResponseEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AddonListAddonsResponseEntitlement
        {
            ID = "id",
            Type = AddonListAddonsResponseEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<string, AddonListAddonsResponseEntitlementType> expectedType =
            AddonListAddonsResponseEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AddonListAddonsResponseEntitlement
        {
            ID = "id",
            Type = AddonListAddonsResponseEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListAddonsResponseEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AddonListAddonsResponseEntitlement
        {
            ID = "id",
            Type = AddonListAddonsResponseEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AddonListAddonsResponseEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, AddonListAddonsResponseEntitlementType> expectedType =
            AddonListAddonsResponseEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AddonListAddonsResponseEntitlement
        {
            ID = "id",
            Type = AddonListAddonsResponseEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AddonListAddonsResponseEntitlement
        {
            ID = "id",
            Type = AddonListAddonsResponseEntitlementType.Feature,
        };

        AddonListAddonsResponseEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AddonListAddonsResponseEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(AddonListAddonsResponseEntitlementType.Feature)]
    [InlineData(AddonListAddonsResponseEntitlementType.Credit)]
    public void Validation_Works(AddonListAddonsResponseEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListAddonsResponseEntitlementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListAddonsResponseEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListAddonsResponseEntitlementType.Feature)]
    [InlineData(AddonListAddonsResponseEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(AddonListAddonsResponseEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListAddonsResponseEntitlementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListAddonsResponseEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListAddonsResponseEntitlementType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListAddonsResponseEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListAddonsResponsePricingTypeTest : TestBase
{
    [Theory]
    [InlineData(AddonListAddonsResponsePricingType.Free)]
    [InlineData(AddonListAddonsResponsePricingType.Paid)]
    [InlineData(AddonListAddonsResponsePricingType.Custom)]
    public void Validation_Works(AddonListAddonsResponsePricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListAddonsResponsePricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListAddonsResponsePricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListAddonsResponsePricingType.Free)]
    [InlineData(AddonListAddonsResponsePricingType.Paid)]
    [InlineData(AddonListAddonsResponsePricingType.Custom)]
    public void SerializationRoundtrip_Works(AddonListAddonsResponsePricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListAddonsResponsePricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListAddonsResponsePricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListAddonsResponsePricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListAddonsResponsePricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class AddonListAddonsResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(AddonListAddonsResponseStatus.Draft)]
    [InlineData(AddonListAddonsResponseStatus.Published)]
    [InlineData(AddonListAddonsResponseStatus.Archived)]
    public void Validation_Works(AddonListAddonsResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListAddonsResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListAddonsResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AddonListAddonsResponseStatus.Draft)]
    [InlineData(AddonListAddonsResponseStatus.Published)]
    [InlineData(AddonListAddonsResponseStatus.Archived)]
    public void SerializationRoundtrip_Works(AddonListAddonsResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AddonListAddonsResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListAddonsResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AddonListAddonsResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, AddonListAddonsResponseStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
