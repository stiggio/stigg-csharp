using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events;

namespace Stigg.Client.Tests.Models.V1.Events;

public class EventEstimateCostParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EventEstimateCostParams
        {
            CustomerID = "customerId",
            EventName = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedCustomerID = "customerId";
        string expectedEventName = "x";
        Dictionary<string, Dimension> expectedDimensions = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedEventName, parameters.EventName);
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
        var parameters = new EventEstimateCostParams
        {
            CustomerID = "customerId",
            EventName = "x",
            ResourceID = "resourceId",
        };

        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawBodyData.ContainsKey("dimensions"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new EventEstimateCostParams
        {
            CustomerID = "customerId",
            EventName = "x",
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.Dimensions);
        Assert.False(parameters.RawBodyData.ContainsKey("dimensions"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new EventEstimateCostParams
        {
            CustomerID = "customerId",
            EventName = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new EventEstimateCostParams
        {
            CustomerID = "customerId",
            EventName = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            ResourceID = null,
        };

        Assert.Null(parameters.ResourceID);
        Assert.True(parameters.RawBodyData.ContainsKey("resourceId"));
    }

    [Fact]
    public void Url_Works()
    {
        EventEstimateCostParams parameters = new() { CustomerID = "customerId", EventName = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://edge.api.stigg.io/api/v1/events/estimate"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        EventEstimateCostParams parameters = new()
        {
            CustomerID = "customerId",
            EventName = "x",
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
        var parameters = new EventEstimateCostParams
        {
            CustomerID = "customerId",
            EventName = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        EventEstimateCostParams copied = new(parameters);

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
