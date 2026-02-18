using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Tests.Models.V1.Events.Plans;

public class PlanCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PricingType.Free,
            Status = Status.Draft,
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        string expectedProductID = "productId";
        string expectedBillingID = "billingId";
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, PricingType> expectedPricingType = PricingType.Free;
        ApiEnum<string, Status> expectedStatus = Status.Draft;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentPlanID, parameters.ParentPlanID);
        Assert.Equal(expectedPricingType, parameters.PricingType);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            Description = "description",
            ParentPlanID = "parentPlanId",
            PricingType = PricingType.Free,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            Description = "description",
            ParentPlanID = "parentPlanId",
            PricingType = PricingType.Free,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Status = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Status.Draft,
        };

        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("parentPlanId"));
        Assert.Null(parameters.PricingType);
        Assert.False(parameters.RawBodyData.ContainsKey("pricingType"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Status.Draft,

            BillingID = null,
            Description = null,
            ParentPlanID = null,
            PricingType = null,
        };

        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentPlanID);
        Assert.True(parameters.RawBodyData.ContainsKey("parentPlanId"));
        Assert.Null(parameters.PricingType);
        Assert.True(parameters.RawBodyData.ContainsKey("pricingType"));
    }

    [Fact]
    public void Url_Works()
    {
        PlanCreateParams parameters = new()
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PricingType.Free,
            Status = Status.Draft,
        };

        PlanCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PricingTypeTest : TestBase
{
    [Theory]
    [InlineData(PricingType.Free)]
    [InlineData(PricingType.Paid)]
    [InlineData(PricingType.Custom)]
    public void Validation_Works(PricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingType.Free)]
    [InlineData(PricingType.Paid)]
    [InlineData(PricingType.Custom)]
    public void SerializationRoundtrip_Works(PricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Draft)]
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
    [InlineData(Status.Draft)]
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
