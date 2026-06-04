using System;
using Stigg.Client.Models.V1.Events.DataExport.Destinations;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport.Destinations;

public class DestinationCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DestinationCreateParams { DestinationID = "x", DestinationType = "x" };

        string expectedDestinationID = "x";
        string expectedDestinationType = "x";

        Assert.Equal(expectedDestinationID, parameters.DestinationID);
        Assert.Equal(expectedDestinationType, parameters.DestinationType);
    }

    [Fact]
    public void Url_Works()
    {
        DestinationCreateParams parameters = new() { DestinationID = "x", DestinationType = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/data-export/destinations"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DestinationCreateParams { DestinationID = "x", DestinationType = "x" };

        DestinationCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
