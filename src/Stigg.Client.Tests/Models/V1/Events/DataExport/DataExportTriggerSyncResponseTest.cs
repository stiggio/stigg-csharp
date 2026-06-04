using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.DataExport;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport;

public class DataExportTriggerSyncResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataExportTriggerSyncResponse
        {
            Data = new(
                [
                    new()
                    {
                        DestinationID = "destinationId",
                        Triggered = true,
                        ErrorMessage = "errorMessage",
                        TransferID = "transferId",
                    },
                ]
            ),
        };

        DataExportTriggerSyncResponseData expectedData = new(
            [
                new()
                {
                    DestinationID = "destinationId",
                    Triggered = true,
                    ErrorMessage = "errorMessage",
                    TransferID = "transferId",
                },
            ]
        );

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataExportTriggerSyncResponse
        {
            Data = new(
                [
                    new()
                    {
                        DestinationID = "destinationId",
                        Triggered = true,
                        ErrorMessage = "errorMessage",
                        TransferID = "transferId",
                    },
                ]
            ),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataExportTriggerSyncResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataExportTriggerSyncResponse
        {
            Data = new(
                [
                    new()
                    {
                        DestinationID = "destinationId",
                        Triggered = true,
                        ErrorMessage = "errorMessage",
                        TransferID = "transferId",
                    },
                ]
            ),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataExportTriggerSyncResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DataExportTriggerSyncResponseData expectedData = new(
            [
                new()
                {
                    DestinationID = "destinationId",
                    Triggered = true,
                    ErrorMessage = "errorMessage",
                    TransferID = "transferId",
                },
            ]
        );

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataExportTriggerSyncResponse
        {
            Data = new(
                [
                    new()
                    {
                        DestinationID = "destinationId",
                        Triggered = true,
                        ErrorMessage = "errorMessage",
                        TransferID = "transferId",
                    },
                ]
            ),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataExportTriggerSyncResponse
        {
            Data = new(
                [
                    new()
                    {
                        DestinationID = "destinationId",
                        Triggered = true,
                        ErrorMessage = "errorMessage",
                        TransferID = "transferId",
                    },
                ]
            ),
        };

        DataExportTriggerSyncResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataExportTriggerSyncResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataExportTriggerSyncResponseData
        {
            Results =
            [
                new()
                {
                    DestinationID = "destinationId",
                    Triggered = true,
                    ErrorMessage = "errorMessage",
                    TransferID = "transferId",
                },
            ],
        };

        List<Result> expectedResults =
        [
            new()
            {
                DestinationID = "destinationId",
                Triggered = true,
                ErrorMessage = "errorMessage",
                TransferID = "transferId",
            },
        ];

        Assert.Equal(expectedResults.Count, model.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], model.Results[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataExportTriggerSyncResponseData
        {
            Results =
            [
                new()
                {
                    DestinationID = "destinationId",
                    Triggered = true,
                    ErrorMessage = "errorMessage",
                    TransferID = "transferId",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataExportTriggerSyncResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataExportTriggerSyncResponseData
        {
            Results =
            [
                new()
                {
                    DestinationID = "destinationId",
                    Triggered = true,
                    ErrorMessage = "errorMessage",
                    TransferID = "transferId",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataExportTriggerSyncResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<Result> expectedResults =
        [
            new()
            {
                DestinationID = "destinationId",
                Triggered = true,
                ErrorMessage = "errorMessage",
                TransferID = "transferId",
            },
        ];

        Assert.Equal(expectedResults.Count, deserialized.Results.Count);
        for (int i = 0; i < expectedResults.Count; i++)
        {
            Assert.Equal(expectedResults[i], deserialized.Results[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataExportTriggerSyncResponseData
        {
            Results =
            [
                new()
                {
                    DestinationID = "destinationId",
                    Triggered = true,
                    ErrorMessage = "errorMessage",
                    TransferID = "transferId",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataExportTriggerSyncResponseData
        {
            Results =
            [
                new()
                {
                    DestinationID = "destinationId",
                    Triggered = true,
                    ErrorMessage = "errorMessage",
                    TransferID = "transferId",
                },
            ],
        };

        DataExportTriggerSyncResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ResultTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Result
        {
            DestinationID = "destinationId",
            Triggered = true,
            ErrorMessage = "errorMessage",
            TransferID = "transferId",
        };

        string expectedDestinationID = "destinationId";
        bool expectedTriggered = true;
        string expectedErrorMessage = "errorMessage";
        string expectedTransferID = "transferId";

        Assert.Equal(expectedDestinationID, model.DestinationID);
        Assert.Equal(expectedTriggered, model.Triggered);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedTransferID, model.TransferID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Result
        {
            DestinationID = "destinationId",
            Triggered = true,
            ErrorMessage = "errorMessage",
            TransferID = "transferId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Result
        {
            DestinationID = "destinationId",
            Triggered = true,
            ErrorMessage = "errorMessage",
            TransferID = "transferId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Result>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedDestinationID = "destinationId";
        bool expectedTriggered = true;
        string expectedErrorMessage = "errorMessage";
        string expectedTransferID = "transferId";

        Assert.Equal(expectedDestinationID, deserialized.DestinationID);
        Assert.Equal(expectedTriggered, deserialized.Triggered);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedTransferID, deserialized.TransferID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Result
        {
            DestinationID = "destinationId",
            Triggered = true,
            ErrorMessage = "errorMessage",
            TransferID = "transferId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Result { DestinationID = "destinationId", Triggered = true };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.TransferID);
        Assert.False(model.RawData.ContainsKey("transferId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Result { DestinationID = "destinationId", Triggered = true };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Result
        {
            DestinationID = "destinationId",
            Triggered = true,

            // Null should be interpreted as omitted for these properties
            ErrorMessage = null,
            TransferID = null,
        };

        Assert.Null(model.ErrorMessage);
        Assert.False(model.RawData.ContainsKey("errorMessage"));
        Assert.Null(model.TransferID);
        Assert.False(model.RawData.ContainsKey("transferId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Result
        {
            DestinationID = "destinationId",
            Triggered = true,

            // Null should be interpreted as omitted for these properties
            ErrorMessage = null,
            TransferID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Result
        {
            DestinationID = "destinationId",
            Triggered = true,
            ErrorMessage = "errorMessage",
            TransferID = "transferId",
        };

        Result copied = new(model);

        Assert.Equal(model, copied);
    }
}
