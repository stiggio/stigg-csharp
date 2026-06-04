using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.DataExport.Destinations;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport.Destinations;

public class DestinationCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DestinationCreateResponse
        {
            Data = new(
                [
                    new()
                    {
                        ConnectedAt = "connectedAt",
                        DestinationID = "destinationId",
                        Type = "type",
                    },
                ]
            ),
        };

        Data expectedData = new(
            [
                new()
                {
                    ConnectedAt = "connectedAt",
                    DestinationID = "destinationId",
                    Type = "type",
                },
            ]
        );

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DestinationCreateResponse
        {
            Data = new(
                [
                    new()
                    {
                        ConnectedAt = "connectedAt",
                        DestinationID = "destinationId",
                        Type = "type",
                    },
                ]
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DestinationCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DestinationCreateResponse
        {
            Data = new(
                [
                    new()
                    {
                        ConnectedAt = "connectedAt",
                        DestinationID = "destinationId",
                        Type = "type",
                    },
                ]
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DestinationCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new(
            [
                new()
                {
                    ConnectedAt = "connectedAt",
                    DestinationID = "destinationId",
                    Type = "type",
                },
            ]
        );

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DestinationCreateResponse
        {
            Data = new(
                [
                    new()
                    {
                        ConnectedAt = "connectedAt",
                        DestinationID = "destinationId",
                        Type = "type",
                    },
                ]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DestinationCreateResponse
        {
            Data = new(
                [
                    new()
                    {
                        ConnectedAt = "connectedAt",
                        DestinationID = "destinationId",
                        Type = "type",
                    },
                ]
            ),
        };

        DestinationCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            Destinations =
            [
                new()
                {
                    ConnectedAt = "connectedAt",
                    DestinationID = "destinationId",
                    Type = "type",
                },
            ],
        };

        List<Destination> expectedDestinations =
        [
            new()
            {
                ConnectedAt = "connectedAt",
                DestinationID = "destinationId",
                Type = "type",
            },
        ];

        Assert.Equal(expectedDestinations.Count, model.Destinations.Count);
        for (int i = 0; i < expectedDestinations.Count; i++)
        {
            Assert.Equal(expectedDestinations[i], model.Destinations[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Destinations =
            [
                new()
                {
                    ConnectedAt = "connectedAt",
                    DestinationID = "destinationId",
                    Type = "type",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            Destinations =
            [
                new()
                {
                    ConnectedAt = "connectedAt",
                    DestinationID = "destinationId",
                    Type = "type",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        List<Destination> expectedDestinations =
        [
            new()
            {
                ConnectedAt = "connectedAt",
                DestinationID = "destinationId",
                Type = "type",
            },
        ];

        Assert.Equal(expectedDestinations.Count, deserialized.Destinations.Count);
        for (int i = 0; i < expectedDestinations.Count; i++)
        {
            Assert.Equal(expectedDestinations[i], deserialized.Destinations[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Destinations =
            [
                new()
                {
                    ConnectedAt = "connectedAt",
                    DestinationID = "destinationId",
                    Type = "type",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Destinations =
            [
                new()
                {
                    ConnectedAt = "connectedAt",
                    DestinationID = "destinationId",
                    Type = "type",
                },
            ],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DestinationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Destination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        string expectedConnectedAt = "connectedAt";
        string expectedDestinationID = "destinationId";
        string expectedType = "type";

        Assert.Equal(expectedConnectedAt, model.ConnectedAt);
        Assert.Equal(expectedDestinationID, model.DestinationID);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Destination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Destination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Destination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Destination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedConnectedAt = "connectedAt";
        string expectedDestinationID = "destinationId";
        string expectedType = "type";

        Assert.Equal(expectedConnectedAt, deserialized.ConnectedAt);
        Assert.Equal(expectedDestinationID, deserialized.DestinationID);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Destination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Destination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        Destination copied = new(model);

        Assert.Equal(model, copied);
    }
}
