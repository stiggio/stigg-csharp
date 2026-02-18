using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Tests.Models.V1.Events.Plans;

public class PlanListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = PlanListResponseEntitlementType.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanListResponsePricingType.Free,
            ProductID = "productId",
            Status = PlanListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<PlanListResponseEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = PlanListResponseEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, PlanListResponsePricingType> expectedPricingType =
            PlanListResponsePricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, PlanListResponseStatus> expectedStatus = PlanListResponseStatus.Draft;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNumber = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEntitlements.Count, model.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], model.Entitlements[i]);
        }
        Assert.Equal(expectedIsLatest, model.IsLatest);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentPlanID, model.ParentPlanID);
        Assert.Equal(expectedPricingType, model.PricingType);
        Assert.Equal(expectedProductID, model.ProductID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVersionNumber, model.VersionNumber);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = PlanListResponseEntitlementType.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanListResponsePricingType.Free,
            ProductID = "productId",
            Status = PlanListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = PlanListResponseEntitlementType.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanListResponsePricingType.Free,
            ProductID = "productId",
            Status = PlanListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<PlanListResponseEntitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = PlanListResponseEntitlementType.Feature },
        ];
        bool expectedIsLatest = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, PlanListResponsePricingType> expectedPricingType =
            PlanListResponsePricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, PlanListResponseStatus> expectedStatus = PlanListResponseStatus.Draft;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        long expectedVersionNumber = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEntitlements.Count, deserialized.Entitlements.Count);
        for (int i = 0; i < expectedEntitlements.Count; i++)
        {
            Assert.Equal(expectedEntitlements[i], deserialized.Entitlements[i]);
        }
        Assert.Equal(expectedIsLatest, deserialized.IsLatest);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentPlanID, deserialized.ParentPlanID);
        Assert.Equal(expectedPricingType, deserialized.PricingType);
        Assert.Equal(expectedProductID, deserialized.ProductID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVersionNumber, deserialized.VersionNumber);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = PlanListResponseEntitlementType.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanListResponsePricingType.Free,
            ProductID = "productId",
            Status = PlanListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListResponse
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = PlanListResponseEntitlementType.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PlanListResponsePricingType.Free,
            ProductID = "productId",
            Status = PlanListResponseStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        PlanListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListResponseEntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanListResponseEntitlement
        {
            ID = "id",
            Type = PlanListResponseEntitlementType.Feature,
        };

        string expectedID = "id";
        ApiEnum<string, PlanListResponseEntitlementType> expectedType =
            PlanListResponseEntitlementType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanListResponseEntitlement
        {
            ID = "id",
            Type = PlanListResponseEntitlementType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListResponseEntitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanListResponseEntitlement
        {
            ID = "id",
            Type = PlanListResponseEntitlementType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanListResponseEntitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, PlanListResponseEntitlementType> expectedType =
            PlanListResponseEntitlementType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanListResponseEntitlement
        {
            ID = "id",
            Type = PlanListResponseEntitlementType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanListResponseEntitlement
        {
            ID = "id",
            Type = PlanListResponseEntitlementType.Feature,
        };

        PlanListResponseEntitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanListResponseEntitlementTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanListResponseEntitlementType.Feature)]
    [InlineData(PlanListResponseEntitlementType.Credit)]
    public void Validation_Works(PlanListResponseEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListResponseEntitlementType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponseEntitlementType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListResponseEntitlementType.Feature)]
    [InlineData(PlanListResponseEntitlementType.Credit)]
    public void SerializationRoundtrip_Works(PlanListResponseEntitlementType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListResponseEntitlementType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListResponseEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponseEntitlementType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanListResponseEntitlementType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanListResponsePricingTypeTest : TestBase
{
    [Theory]
    [InlineData(PlanListResponsePricingType.Free)]
    [InlineData(PlanListResponsePricingType.Paid)]
    [InlineData(PlanListResponsePricingType.Custom)]
    public void Validation_Works(PlanListResponsePricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListResponsePricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponsePricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListResponsePricingType.Free)]
    [InlineData(PlanListResponsePricingType.Paid)]
    [InlineData(PlanListResponsePricingType.Custom)]
    public void SerializationRoundtrip_Works(PlanListResponsePricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListResponsePricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponsePricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponsePricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponsePricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PlanListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(PlanListResponseStatus.Draft)]
    [InlineData(PlanListResponseStatus.Published)]
    [InlineData(PlanListResponseStatus.Archived)]
    public void Validation_Works(PlanListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanListResponseStatus.Draft)]
    [InlineData(PlanListResponseStatus.Published)]
    [InlineData(PlanListResponseStatus.Archived)]
    public void SerializationRoundtrip_Works(PlanListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PlanListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
