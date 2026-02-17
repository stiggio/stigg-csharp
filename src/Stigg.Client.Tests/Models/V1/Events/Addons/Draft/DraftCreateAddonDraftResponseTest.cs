using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Draft = Stigg.Client.Models.V1.Events.Addons.Draft;

namespace Stigg.Client.Tests.Models.V1.Events.Addons.Draft;

public class DraftCreateAddonDraftResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Draft::DraftCreateAddonDraftResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = Draft::PricingType.Free,
                Status = Draft::Status.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        Draft::Data expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = Draft::PricingType.Free,
            Status = Draft::Status.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Draft::DraftCreateAddonDraftResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = Draft::PricingType.Free,
                Status = Draft::Status.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draft::DraftCreateAddonDraftResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Draft::DraftCreateAddonDraftResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = Draft::PricingType.Free,
                Status = Draft::Status.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draft::DraftCreateAddonDraftResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Draft::Data expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = Draft::PricingType.Free,
            Status = Draft::Status.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Draft::DraftCreateAddonDraftResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = Draft::PricingType.Free,
                Status = Draft::Status.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Draft::DraftCreateAddonDraftResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dependencies = ["string"],
                Description = "description",
                DisplayName = "displayName",
                Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
                IsLatest = true,
                MaxQuantity = 0,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PricingType = Draft::PricingType.Free,
                Status = Draft::Status.Draft,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VersionNumber = 0,
            },
        };

        Draft::DraftCreateAddonDraftResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Draft::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = Draft::PricingType.Free,
            Status = Draft::Status.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<string> expectedDependencies = ["string"];
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        List<Draft::Entitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = Draft::Type.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Draft::PricingType> expectedPricingType = Draft::PricingType.Free;
        ApiEnum<string, Draft::Status> expectedStatus = Draft::Status.Draft;
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
        var model = new Draft::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = Draft::PricingType.Free,
            Status = Draft::Status.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draft::Data>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Draft::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = Draft::PricingType.Free,
            Status = Draft::Status.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draft::Data>(
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
        List<Draft::Entitlement> expectedEntitlements =
        [
            new() { ID = "id", Type = Draft::Type.Feature },
        ];
        bool expectedIsLatest = true;
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, Draft::PricingType> expectedPricingType = Draft::PricingType.Free;
        ApiEnum<string, Draft::Status> expectedStatus = Draft::Status.Draft;
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
        var model = new Draft::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = Draft::PricingType.Free,
            Status = Draft::Status.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Draft::Data
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dependencies = ["string"],
            Description = "description",
            DisplayName = "displayName",
            Entitlements = [new() { ID = "id", Type = Draft::Type.Feature }],
            IsLatest = true,
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = Draft::PricingType.Free,
            Status = Draft::Status.Draft,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VersionNumber = 0,
        };

        Draft::Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class EntitlementTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Draft::Entitlement { ID = "id", Type = Draft::Type.Feature };

        string expectedID = "id";
        ApiEnum<string, Draft::Type> expectedType = Draft::Type.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Draft::Entitlement { ID = "id", Type = Draft::Type.Feature };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draft::Entitlement>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Draft::Entitlement { ID = "id", Type = Draft::Type.Feature };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Draft::Entitlement>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Draft::Type> expectedType = Draft::Type.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Draft::Entitlement { ID = "id", Type = Draft::Type.Feature };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Draft::Entitlement { ID = "id", Type = Draft::Type.Feature };

        Draft::Entitlement copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Draft::Type.Feature)]
    [InlineData(Draft::Type.Credit)]
    public void Validation_Works(Draft::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draft::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draft::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Draft::Type.Feature)]
    [InlineData(Draft::Type.Credit)]
    public void SerializationRoundtrip_Works(Draft::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draft::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draft::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draft::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draft::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricingTypeTest : TestBase
{
    [Theory]
    [InlineData(Draft::PricingType.Free)]
    [InlineData(Draft::PricingType.Paid)]
    [InlineData(Draft::PricingType.Custom)]
    public void Validation_Works(Draft::PricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draft::PricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draft::PricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Draft::PricingType.Free)]
    [InlineData(Draft::PricingType.Paid)]
    [InlineData(Draft::PricingType.Custom)]
    public void SerializationRoundtrip_Works(Draft::PricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draft::PricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draft::PricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draft::PricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draft::PricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Draft::Status.Draft)]
    [InlineData(Draft::Status.Published)]
    [InlineData(Draft::Status.Archived)]
    public void Validation_Works(Draft::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draft::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draft::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Draft::Status.Draft)]
    [InlineData(Draft::Status.Published)]
    [InlineData(Draft::Status.Archived)]
    public void SerializationRoundtrip_Works(Draft::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Draft::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draft::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Draft::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Draft::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
