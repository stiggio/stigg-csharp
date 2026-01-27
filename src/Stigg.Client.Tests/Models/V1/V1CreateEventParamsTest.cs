using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1;

namespace Stigg.Client.Tests.Models.V1;

public class V1CreateEventParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new V1CreateEventParams
        {
            Events =
            [
                new()
                {
                    CustomerID = "customerId",
                    EventName = "x",
                    IdempotencyKey = "x",
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<Event> expectedEvents =
        [
            new()
            {
                CustomerID = "customerId",
                EventName = "x",
                IdempotencyKey = "x",
                Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                ResourceID = "resourceId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedEvents.Count, parameters.Events.Count);
        for (int i = 0; i < expectedEvents.Count; i++)
        {
            Assert.Equal(expectedEvents[i], parameters.Events[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        V1CreateEventParams parameters = new()
        {
            Events =
            [
                new()
                {
                    CustomerID = "customerId",
                    EventName = "x",
                    IdempotencyKey = "x",
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/events"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new V1CreateEventParams
        {
            Events =
            [
                new()
                {
                    CustomerID = "customerId",
                    EventName = "x",
                    IdempotencyKey = "x",
                    Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        V1CreateEventParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class EventTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCustomerID = "customerId";
        string expectedEventName = "x";
        string expectedIdempotencyKey = "x";
        Dictionary<string, Dimension> expectedDimensions = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedEventName, model.EventName);
        Assert.Equal(expectedIdempotencyKey, model.IdempotencyKey);
        Assert.NotNull(model.Dimensions);
        Assert.Equal(expectedDimensions.Count, model.Dimensions.Count);
        foreach (var item in expectedDimensions)
        {
            Assert.True(model.Dimensions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Dimensions[item.Key]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Event>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCustomerID = "customerId";
        string expectedEventName = "x";
        string expectedIdempotencyKey = "x";
        Dictionary<string, Dimension> expectedDimensions = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedEventName, deserialized.EventName);
        Assert.Equal(expectedIdempotencyKey, deserialized.IdempotencyKey);
        Assert.NotNull(deserialized.Dimensions);
        Assert.Equal(expectedDimensions.Count, deserialized.Dimensions.Count);
        foreach (var item in expectedDimensions)
        {
            Assert.True(deserialized.Dimensions.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Dimensions[item.Key]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            ResourceID = "resourceId",
        };

        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            ResourceID = "resourceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            Timestamp = null,
        };

        Assert.Null(model.Dimensions);
        Assert.False(model.RawData.ContainsKey("dimensions"));
        Assert.Null(model.Timestamp);
        Assert.False(model.RawData.ContainsKey("timestamp"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            Dimensions = null,
            Timestamp = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ResourceID = null,
        };

        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            ResourceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Event
        {
            CustomerID = "customerId",
            EventName = "x",
            IdempotencyKey = "x",
            Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
            ResourceID = "resourceId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Event copied = new(model);

        Assert.Equal(model, copied);
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
