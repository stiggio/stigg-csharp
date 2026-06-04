using System;
using Stigg.Client.Models.V1.Events.DataExport;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport;

public class DataExportTriggerSyncParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataExportTriggerSyncParams { DestinationID = "destinationId" };

        string expectedDestinationID = "destinationId";

        Assert.Equal(expectedDestinationID, parameters.DestinationID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataExportTriggerSyncParams { };

        Assert.Null(parameters.DestinationID);
        Assert.False(parameters.RawBodyData.ContainsKey("destinationId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DataExportTriggerSyncParams
        {
            // Null should be interpreted as omitted for these properties
            DestinationID = null,
        };

        Assert.Null(parameters.DestinationID);
        Assert.False(parameters.RawBodyData.ContainsKey("destinationId"));
    }

    [Fact]
    public void Url_Works()
    {
        DataExportTriggerSyncParams parameters = new();

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/data-export/sync"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DataExportTriggerSyncParams { DestinationID = "destinationId" };

        DataExportTriggerSyncParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
