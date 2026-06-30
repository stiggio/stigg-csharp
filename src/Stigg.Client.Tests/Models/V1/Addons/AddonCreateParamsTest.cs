using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Addons;

namespace Stigg.Client.Tests.Models.V1.Addons;

public class AddonCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AddonCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            Description = "description",
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = PricingType.Free,
            Status = Status.Draft,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        string expectedProductID = "productId";
        string expectedBillingID = "billingId";
        string expectedDescription = "description";
        long expectedMaxQuantity = 0;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, PricingType> expectedPricingType = PricingType.Free;
        ApiEnum<string, Status> expectedStatus = Status.Draft;
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedMaxQuantity, parameters.MaxQuantity);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedPricingType, parameters.PricingType);
        Assert.Equal(expectedStatus, parameters.Status);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddonCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            Description = "description",
            MaxQuantity = 0,
            PricingType = PricingType.Free,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AddonCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            Description = "description",
            MaxQuantity = 0,
            PricingType = PricingType.Free,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Status = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AddonCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Status.Draft,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MaxQuantity);
        Assert.False(parameters.RawBodyData.ContainsKey("maxQuantity"));
        Assert.Null(parameters.PricingType);
        Assert.False(parameters.RawBodyData.ContainsKey("pricingType"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new AddonCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Status.Draft,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            BillingID = null,
            Description = null,
            MaxQuantity = null,
            PricingType = null,
        };

        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.MaxQuantity);
        Assert.True(parameters.RawBodyData.ContainsKey("maxQuantity"));
        Assert.Null(parameters.PricingType);
        Assert.True(parameters.RawBodyData.ContainsKey("pricingType"));
    }

    [Fact]
    public void Url_Works()
    {
        AddonCreateParams parameters = new()
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/addons"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AddonCreateParams parameters = new()
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["X-ACCOUNT-ID"], requestMessage.Headers.GetValues("X-ACCOUNT-ID"));
        Assert.Equal(["X-ENVIRONMENT-ID"], requestMessage.Headers.GetValues("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AddonCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            Description = "description",
            MaxQuantity = 0,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PricingType = PricingType.Free,
            Status = Status.Draft,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        AddonCreateParams copied = new(parameters);

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
