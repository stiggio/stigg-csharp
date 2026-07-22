using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.Consumption;

namespace Stigg.Client.Tests.Models.V1.Credits.Consumption;

public class ConsumptionConsumeAsyncParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ConsumptionConsumeAsyncParams
        {
            Consumptions =
            [
                new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    IdempotencyKey = "x",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<
                        string,
                        ConsumptionConsumeAsyncParamsConsumptionDimension
                    >()
                    {
                        { "foo", "string" },
                    },
                    ResourceID = "resourceId",
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        List<ConsumptionConsumeAsyncParamsConsumption> expectedConsumptions =
        [
            new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                IdempotencyKey = "x",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Dimensions = new Dictionary<
                    string,
                    ConsumptionConsumeAsyncParamsConsumptionDimension
                >()
                {
                    { "foo", "string" },
                },
                ResourceID = "resourceId",
            },
        ];
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedConsumptions.Count, parameters.Consumptions.Count);
        for (int i = 0; i < expectedConsumptions.Count; i++)
        {
            Assert.Equal(expectedConsumptions[i], parameters.Consumptions[i]);
        }
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ConsumptionConsumeAsyncParams
        {
            Consumptions =
            [
                new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    IdempotencyKey = "x",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<
                        string,
                        ConsumptionConsumeAsyncParamsConsumptionDimension
                    >()
                    {
                        { "foo", "string" },
                    },
                    ResourceID = "resourceId",
                },
            ],
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ConsumptionConsumeAsyncParams
        {
            Consumptions =
            [
                new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    IdempotencyKey = "x",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<
                        string,
                        ConsumptionConsumeAsyncParamsConsumptionDimension
                    >()
                    {
                        { "foo", "string" },
                    },
                    ResourceID = "resourceId",
                },
            ],

            // Null should be interpreted as omitted for these properties
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        ConsumptionConsumeAsyncParams parameters = new()
        {
            Consumptions =
            [
                new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    IdempotencyKey = "x",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<
                        string,
                        ConsumptionConsumeAsyncParamsConsumptionDimension
                    >()
                    {
                        { "foo", "string" },
                    },
                    ResourceID = "resourceId",
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://edge.api.stigg.io/api/v1/credits/consumption/async"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ConsumptionConsumeAsyncParams parameters = new()
        {
            Consumptions =
            [
                new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    IdempotencyKey = "x",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<
                        string,
                        ConsumptionConsumeAsyncParamsConsumptionDimension
                    >()
                    {
                        { "foo", "string" },
                    },
                    ResourceID = "resourceId",
                },
            ],
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
        var parameters = new ConsumptionConsumeAsyncParams
        {
            Consumptions =
            [
                new()
                {
                    Amount = 1,
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    IdempotencyKey = "x",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Dimensions = new Dictionary<
                        string,
                        ConsumptionConsumeAsyncParamsConsumptionDimension
                    >()
                    {
                        { "foo", "string" },
                    },
                    ResourceID = "resourceId",
                },
            ],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        ConsumptionConsumeAsyncParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class ConsumptionConsumeAsyncParamsConsumptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, ConsumptionConsumeAsyncParamsConsumptionDimension>()
            {
                { "foo", "string" },
            },
            ResourceID = "resourceId",
        };

        double expectedAmount = 1;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedIdempotencyKey = "x";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, ConsumptionConsumeAsyncParamsConsumptionDimension> expectedDimensions =
            new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedIdempotencyKey, model.IdempotencyKey);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.NotNull(model.Dimensions);
        Assert.Equal(expectedDimensions.Count, model.Dimensions.Count);
        foreach (var item in expectedDimensions)
        {
            Assert.True(model.Dimensions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Dimensions[item.Key]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, ConsumptionConsumeAsyncParamsConsumptionDimension>()
            {
                { "foo", "string" },
            },
            ResourceID = "resourceId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumptionConsumeAsyncParamsConsumption>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, ConsumptionConsumeAsyncParamsConsumptionDimension>()
            {
                { "foo", "string" },
            },
            ResourceID = "resourceId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumptionConsumeAsyncParamsConsumption>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 1;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedIdempotencyKey = "x";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, ConsumptionConsumeAsyncParamsConsumptionDimension> expectedDimensions =
            new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedIdempotencyKey, deserialized.IdempotencyKey);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.NotNull(deserialized.Dimensions);
        Assert.Equal(expectedDimensions.Count, deserialized.Dimensions.Count);
        foreach (var item in expectedDimensions)
        {
            Assert.True(deserialized.Dimensions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Dimensions[item.Key]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, ConsumptionConsumeAsyncParamsConsumptionDimension>()
            {
                { "foo", "string" },
            },
            ResourceID = "resourceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Dimensions = null,
            ResourceID = null,
        };

        Assert.Null(model.CreatedAt);
        Assert.False(model.RawData.ContainsKey("createdAt"));
        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",

            // Null should be interpreted as omitted for these properties
            CreatedAt = null,
            Dimensions = null,
            ResourceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumptionConsumeAsyncParamsConsumption
        {
            Amount = 1,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            IdempotencyKey = "x",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Dimensions = new Dictionary<string, ConsumptionConsumeAsyncParamsConsumptionDimension>()
            {
                { "foo", "string" },
            },
            ResourceID = "resourceId",
        };

        ConsumptionConsumeAsyncParamsConsumption copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ConsumptionConsumeAsyncParamsConsumptionDimensionTest : TestBase
{
    [Fact]
    public void StringValidationWorks()
    {
        ConsumptionConsumeAsyncParamsConsumptionDimension value = "string";
        value.Validate();
    }

    [Fact]
    public void DoubleValidationWorks()
    {
        ConsumptionConsumeAsyncParamsConsumptionDimension value = 0;
        value.Validate();
    }

    [Fact]
    public void BoolValidationWorks()
    {
        ConsumptionConsumeAsyncParamsConsumptionDimension value = true;
        value.Validate();
    }

    [Fact]
    public void StringSerializationRoundtripWorks()
    {
        ConsumptionConsumeAsyncParamsConsumptionDimension value = "string";
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumptionConsumeAsyncParamsConsumptionDimension>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void DoubleSerializationRoundtripWorks()
    {
        ConsumptionConsumeAsyncParamsConsumptionDimension value = 0;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumptionConsumeAsyncParamsConsumptionDimension>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void BoolSerializationRoundtripWorks()
    {
        ConsumptionConsumeAsyncParamsConsumptionDimension value = true;
        string element = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ConsumptionConsumeAsyncParamsConsumptionDimension>(
                element,
                ModelBase.SerializerOptions
            );

        Assert.Equal(value, deserialized);
    }
}
