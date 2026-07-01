using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.Consumption;

namespace Stigg.Client.Tests.Models.V1.Credits.Consumption;

public class ConsumptionConsumeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConsumptionConsumeParams
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        double expectedAmount = 1;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedIdempotencyKey = "x";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, Dimension> expectedDimensions = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedIdempotencyKey, parameters.IdempotencyKey);
        Assert.Equal(expectedCreatedAt, parameters.CreatedAt);
        Assert.NotNull(parameters.Dimensions);
        Assert.Equal(expectedDimensions.Count, parameters.Dimensions.Count);
        foreach (var item in expectedDimensions)
        {
            Assert.True(parameters.Dimensions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Dimensions[item.Key]);
        }
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConsumptionConsumeParams
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
        };

        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("createdAt"));
        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawBodyData.ContainsKey("dimensions"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConsumptionConsumeParams
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Dimensions = null,
            ResourceID = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawBodyData.ContainsKey("createdAt"));
        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawBodyData.ContainsKey("dimensions"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        ConsumptionConsumeParams parameters = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/credits/consumption"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ConsumptionConsumeParams parameters = new()
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
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
        var parameters = new ConsumptionConsumeParams
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        ConsumptionConsumeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DimensionTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        Dimension value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        Dimension value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        Dimension value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        Dimension value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dimension>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        Dimension value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dimension>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        Dimension value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Dimension>(
            element,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
