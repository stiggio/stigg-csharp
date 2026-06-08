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
                        ConnectionStatus = "connectionStatus",
                        LastSyncStatus = new()
                        {
                            FinishedAt = "finishedAt",
                            Status = "status",
                            TransferID = "transferId",
                            BlamedParty = "blamedParty",
                            FailureMessage = "failureMessage",
                            RowsTransferred = 0,
                        },
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
                    ConnectionStatus = "connectionStatus",
                    LastSyncStatus = new()
                    {
                        FinishedAt = "finishedAt",
                        Status = "status",
                        TransferID = "transferId",
                        BlamedParty = "blamedParty",
                        FailureMessage = "failureMessage",
                        RowsTransferred = 0,
                    },
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
                        ConnectionStatus = "connectionStatus",
                        LastSyncStatus = new()
                        {
                            FinishedAt = "finishedAt",
                            Status = "status",
                            TransferID = "transferId",
                            BlamedParty = "blamedParty",
                            FailureMessage = "failureMessage",
                            RowsTransferred = 0,
                        },
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
                        ConnectionStatus = "connectionStatus",
                        LastSyncStatus = new()
                        {
                            FinishedAt = "finishedAt",
                            Status = "status",
                            TransferID = "transferId",
                            BlamedParty = "blamedParty",
                            FailureMessage = "failureMessage",
                            RowsTransferred = 0,
                        },
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
                    ConnectionStatus = "connectionStatus",
                    LastSyncStatus = new()
                    {
                        FinishedAt = "finishedAt",
                        Status = "status",
                        TransferID = "transferId",
                        BlamedParty = "blamedParty",
                        FailureMessage = "failureMessage",
                        RowsTransferred = 0,
                    },
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
                        ConnectionStatus = "connectionStatus",
                        LastSyncStatus = new()
                        {
                            FinishedAt = "finishedAt",
                            Status = "status",
                            TransferID = "transferId",
                            BlamedParty = "blamedParty",
                            FailureMessage = "failureMessage",
                            RowsTransferred = 0,
                        },
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
                        ConnectionStatus = "connectionStatus",
                        LastSyncStatus = new()
                        {
                            FinishedAt = "finishedAt",
                            Status = "status",
                            TransferID = "transferId",
                            BlamedParty = "blamedParty",
                            FailureMessage = "failureMessage",
                            RowsTransferred = 0,
                        },
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
                    ConnectionStatus = "connectionStatus",
                    LastSyncStatus = new()
                    {
                        FinishedAt = "finishedAt",
                        Status = "status",
                        TransferID = "transferId",
                        BlamedParty = "blamedParty",
                        FailureMessage = "failureMessage",
                        RowsTransferred = 0,
                    },
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
                ConnectionStatus = "connectionStatus",
                LastSyncStatus = new()
                {
                    FinishedAt = "finishedAt",
                    Status = "status",
                    TransferID = "transferId",
                    BlamedParty = "blamedParty",
                    FailureMessage = "failureMessage",
                    RowsTransferred = 0,
                },
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
                    ConnectionStatus = "connectionStatus",
                    LastSyncStatus = new()
                    {
                        FinishedAt = "finishedAt",
                        Status = "status",
                        TransferID = "transferId",
                        BlamedParty = "blamedParty",
                        FailureMessage = "failureMessage",
                        RowsTransferred = 0,
                    },
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
                    ConnectionStatus = "connectionStatus",
                    LastSyncStatus = new()
                    {
                        FinishedAt = "finishedAt",
                        Status = "status",
                        TransferID = "transferId",
                        BlamedParty = "blamedParty",
                        FailureMessage = "failureMessage",
                        RowsTransferred = 0,
                    },
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
                ConnectionStatus = "connectionStatus",
                LastSyncStatus = new()
                {
                    FinishedAt = "finishedAt",
                    Status = "status",
                    TransferID = "transferId",
                    BlamedParty = "blamedParty",
                    FailureMessage = "failureMessage",
                    RowsTransferred = 0,
                },
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
                    ConnectionStatus = "connectionStatus",
                    LastSyncStatus = new()
                    {
                        FinishedAt = "finishedAt",
                        Status = "status",
                        TransferID = "transferId",
                        BlamedParty = "blamedParty",
                        FailureMessage = "failureMessage",
                        RowsTransferred = 0,
                    },
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
                    ConnectionStatus = "connectionStatus",
                    LastSyncStatus = new()
                    {
                        FinishedAt = "finishedAt",
                        Status = "status",
                        TransferID = "transferId",
                        BlamedParty = "blamedParty",
                        FailureMessage = "failureMessage",
                        RowsTransferred = 0,
                    },
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
            ConnectionStatus = "connectionStatus",
            LastSyncStatus = new()
            {
                FinishedAt = "finishedAt",
                Status = "status",
                TransferID = "transferId",
                BlamedParty = "blamedParty",
                FailureMessage = "failureMessage",
                RowsTransferred = 0,
            },
        };

        string expectedConnectedAt = "connectedAt";
        string expectedDestinationID = "destinationId";
        string expectedType = "type";
        string expectedConnectionStatus = "connectionStatus";
        DestinationDeleteResponseDataDestinationLastSyncStatus expectedLastSyncStatus = new()
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
            BlamedParty = "blamedParty",
            FailureMessage = "failureMessage",
            RowsTransferred = 0,
        };

        Assert.Equal(expectedConnectedAt, model.ConnectedAt);
        Assert.Equal(expectedDestinationID, model.DestinationID);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedConnectionStatus, model.ConnectionStatus);
        Assert.Equal(expectedLastSyncStatus, model.LastSyncStatus);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DestinationDeleteResponseDataDestination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
            ConnectionStatus = "connectionStatus",
            LastSyncStatus = new()
            {
                FinishedAt = "finishedAt",
                Status = "status",
                TransferID = "transferId",
                BlamedParty = "blamedParty",
                FailureMessage = "failureMessage",
                RowsTransferred = 0,
            },
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
            ConnectionStatus = "connectionStatus",
            LastSyncStatus = new()
            {
                FinishedAt = "finishedAt",
                Status = "status",
                TransferID = "transferId",
                BlamedParty = "blamedParty",
                FailureMessage = "failureMessage",
                RowsTransferred = 0,
            },
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
        string expectedConnectionStatus = "connectionStatus";
        DestinationDeleteResponseDataDestinationLastSyncStatus expectedLastSyncStatus = new()
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
            BlamedParty = "blamedParty",
            FailureMessage = "failureMessage",
            RowsTransferred = 0,
        };

        Assert.Equal(expectedConnectedAt, deserialized.ConnectedAt);
        Assert.Equal(expectedDestinationID, deserialized.DestinationID);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedConnectionStatus, deserialized.ConnectionStatus);
        Assert.Equal(expectedLastSyncStatus, deserialized.LastSyncStatus);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DestinationDeleteResponseDataDestination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
            ConnectionStatus = "connectionStatus",
            LastSyncStatus = new()
            {
                FinishedAt = "finishedAt",
                Status = "status",
                TransferID = "transferId",
                BlamedParty = "blamedParty",
                FailureMessage = "failureMessage",
                RowsTransferred = 0,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DestinationDeleteResponseDataDestination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",
        };

        Assert.Null(model.ConnectionStatus);
        Assert.False(model.RawData.ContainsKey("connectionStatus"));
        Assert.Null(model.LastSyncStatus);
        Assert.False(model.RawData.ContainsKey("lastSyncStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
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
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DestinationDeleteResponseDataDestination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",

            // Null should be interpreted as omitted for these properties
            ConnectionStatus = null,
            LastSyncStatus = null,
        };

        Assert.Null(model.ConnectionStatus);
        Assert.False(model.RawData.ContainsKey("connectionStatus"));
        Assert.Null(model.LastSyncStatus);
        Assert.False(model.RawData.ContainsKey("lastSyncStatus"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DestinationDeleteResponseDataDestination
        {
            ConnectedAt = "connectedAt",
            DestinationID = "destinationId",
            Type = "type",

            // Null should be interpreted as omitted for these properties
            ConnectionStatus = null,
            LastSyncStatus = null,
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
            ConnectionStatus = "connectionStatus",
            LastSyncStatus = new()
            {
                FinishedAt = "finishedAt",
                Status = "status",
                TransferID = "transferId",
                BlamedParty = "blamedParty",
                FailureMessage = "failureMessage",
                RowsTransferred = 0,
            },
        };

        DestinationDeleteResponseDataDestination copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DestinationDeleteResponseDataDestinationLastSyncStatusTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
            BlamedParty = "blamedParty",
            FailureMessage = "failureMessage",
            RowsTransferred = 0,
        };

        string expectedFinishedAt = "finishedAt";
        string expectedStatus = "status";
        string expectedTransferID = "transferId";
        string expectedBlamedParty = "blamedParty";
        string expectedFailureMessage = "failureMessage";
        double expectedRowsTransferred = 0;

        Assert.Equal(expectedFinishedAt, model.FinishedAt);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedTransferID, model.TransferID);
        Assert.Equal(expectedBlamedParty, model.BlamedParty);
        Assert.Equal(expectedFailureMessage, model.FailureMessage);
        Assert.Equal(expectedRowsTransferred, model.RowsTransferred);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
            BlamedParty = "blamedParty",
            FailureMessage = "failureMessage",
            RowsTransferred = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DestinationDeleteResponseDataDestinationLastSyncStatus>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
            BlamedParty = "blamedParty",
            FailureMessage = "failureMessage",
            RowsTransferred = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<DestinationDeleteResponseDataDestinationLastSyncStatus>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedFinishedAt = "finishedAt";
        string expectedStatus = "status";
        string expectedTransferID = "transferId";
        string expectedBlamedParty = "blamedParty";
        string expectedFailureMessage = "failureMessage";
        double expectedRowsTransferred = 0;

        Assert.Equal(expectedFinishedAt, deserialized.FinishedAt);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
        Assert.Equal(expectedBlamedParty, deserialized.BlamedParty);
        Assert.Equal(expectedFailureMessage, deserialized.FailureMessage);
        Assert.Equal(expectedRowsTransferred, deserialized.RowsTransferred);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
            BlamedParty = "blamedParty",
            FailureMessage = "failureMessage",
            RowsTransferred = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
        };

        Assert.Null(model.BlamedParty);
        Assert.False(model.RawData.ContainsKey("blamedParty"));
        Assert.Null(model.FailureMessage);
        Assert.False(model.RawData.ContainsKey("failureMessage"));
        Assert.Null(model.RowsTransferred);
        Assert.False(model.RawData.ContainsKey("rowsTransferred"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",

            // Null should be interpreted as omitted for these properties
            BlamedParty = null,
            FailureMessage = null,
            RowsTransferred = null,
        };

        Assert.Null(model.BlamedParty);
        Assert.False(model.RawData.ContainsKey("blamedParty"));
        Assert.Null(model.FailureMessage);
        Assert.False(model.RawData.ContainsKey("failureMessage"));
        Assert.Null(model.RowsTransferred);
        Assert.False(model.RawData.ContainsKey("rowsTransferred"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",

            // Null should be interpreted as omitted for these properties
            BlamedParty = null,
            FailureMessage = null,
            RowsTransferred = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DestinationDeleteResponseDataDestinationLastSyncStatus
        {
            FinishedAt = "finishedAt",
            Status = "status",
            TransferID = "transferId",
            BlamedParty = "blamedParty",
            FailureMessage = "failureMessage",
            RowsTransferred = 0,
        };

        DestinationDeleteResponseDataDestinationLastSyncStatus copied = new(model);

        Assert.Equal(model, copied);
    }
}
