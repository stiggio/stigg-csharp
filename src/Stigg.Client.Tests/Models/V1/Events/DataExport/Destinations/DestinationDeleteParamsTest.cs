using System;
using Stigg.Client.Models.V1.Events.DataExport.Destinations;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport.Destinations;

public class DestinationDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DestinationDeleteParams { DestinationID = "x" };

        string expectedDestinationID = "x";

        Assert.Equal(expectedDestinationID, parameters.DestinationID);
    }

    [Fact]
    public void Url_Works()
    {
        DestinationDeleteParams parameters = new() { DestinationID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/data-export/destinations/x"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DestinationDeleteParams { DestinationID = "x" };

        DestinationDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
