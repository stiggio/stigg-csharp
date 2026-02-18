using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Plans = Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Tests.Models.V1.Events.Plans;

public class PlanCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plans::PlanCreateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        Plans::Data expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plans::PlanCreateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::PlanCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plans::PlanCreateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::PlanCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Plans::Data expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plans::PlanCreateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plans::PlanCreateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
                IsLatest = true,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ParentPlanID = "parentPlanId",
                PricingType = Plans::DataPricingType.Free,
                ProductID = "productId",
                Status = Plans::DataStatus.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        Plans::PlanCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<Plans::Entitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = Plans::Type.Feature },
        ];
        bool expectedIsLatest = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, Plans::DataPricingType> expectedPricingType = Plans::DataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, Plans::DataStatus> expectedStatus = Plans::DataStatus.Draft;
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
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::Data>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::Data>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<Plans::Entitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = Plans::Type.Feature },
        ];
        bool expectedIsLatest = true;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, Plans::DataPricingType> expectedPricingType = Plans::DataPricingType.Free;
        string expectedProductID = "productId";
        ApiEnum<string, Plans::DataStatus> expectedStatus = Plans::DataStatus.Draft;
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
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plans::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Plans::Type.Feature }],
            IsLatest = true,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = Plans::DataPricingType.Free,
            ProductID = "productId",
            Status = Plans::DataStatus.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Plans::Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Plans::Entitlement { ID = "id", Type = Plans::Type.Feature };

        string expectedID = "id";
        ApiEnum<string, Plans::Type> expectedType = Plans::Type.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Plans::Entitlement { ID = "id", Type = Plans::Type.Feature };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::Entitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Plans::Entitlement { ID = "id", Type = Plans::Type.Feature };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Plans::Entitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Plans::Type> expectedType = Plans::Type.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Plans::Entitlement { ID = "id", Type = Plans::Type.Feature };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Plans::Entitlement { ID = "id", Type = Plans::Type.Feature };

        Plans::Entitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Plans::Type.Feature)]
    [InlineData(Plans::Type.Credit)]
    public void Validation_Works(Plans::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plans::Type.Feature)]
    [InlineData(Plans::Type.Credit)]
    public void SerializationRoundtrip_Works(Plans::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(Plans::DataPricingType.Free)]
    [InlineData(Plans::DataPricingType.Paid)]
    [InlineData(Plans::DataPricingType.Custom)]
    public void Validation_Works(Plans::DataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataPricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plans::DataPricingType.Free)]
    [InlineData(Plans::DataPricingType.Paid)]
    [InlineData(Plans::DataPricingType.Custom)]
    public void SerializationRoundtrip_Works(Plans::DataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataPricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataPricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataPricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataStatusTest : TestBase
{
    [Theory]
    [InlineData(Plans::DataStatus.Draft)]
    [InlineData(Plans::DataStatus.Published)]
    [InlineData(Plans::DataStatus.Archived)]
    public void Validation_Works(Plans::DataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Plans::DataStatus.Draft)]
    [InlineData(Plans::DataStatus.Published)]
    [InlineData(Plans::DataStatus.Archived)]
    public void SerializationRoundtrip_Works(Plans::DataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Plans::DataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Plans::DataStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
