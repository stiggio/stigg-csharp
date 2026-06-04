using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.DataExport.Destinations;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport.Destinations;

public class DestinationDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DestinationDeleteResponse
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

        DestinationDeleteResponseData expectedData = new(
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
        var model = new DestinationDeleteResponse
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
        var deserialized = JsonSerializer.Deserialize<DestinationDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DestinationDeleteResponse
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
        var deserialized = JsonSerializer.Deserialize<DestinationDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DestinationDeleteResponseData expectedData = new(
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
        var model = new DestinationDeleteResponse
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
        var model = new DestinationDeleteResponse
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

        DestinationDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DestinationDeleteResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DestinationDeleteResponseData
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

        List<DestinationDeleteResponseDataDestination> expectedDestinations =
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
        var model = new DestinationDeleteResponseData
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
        var deserialized = JsonSerializer.Deserialize<DestinationDeleteResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DestinationDeleteResponseData
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
        var deserialized = JsonSerializer.Deserialize<DestinationDeleteResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<DestinationDeleteResponseDataDestination> expectedDestinations =
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
        var model = new DestinationDeleteResponseData
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
        var model = new DestinationDeleteResponseData
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

        DestinationDeleteResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DestinationDeleteResponseDataDestinationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DestinationDeleteResponseDataDestination
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
        var model = new DestinationDeleteResponseDataDestination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DestinationDeleteResponseDataDestination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DestinationDeleteResponseDataDestination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DestinationDeleteResponseDataDestination>(
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
        var model = new DestinationDeleteResponseDataDestination
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
        var model = new DestinationDeleteResponseDataDestination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        DestinationDeleteResponseDataDestination copied = new(model);

        Assert.Equal(model, copied);
    }
}
