using System;
using System.Collections.Generic;
using System.Net.Http;
using Stigg.Client.Models.V1.Events.DataExport.Destinations;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport.Destinations;

public class DestinationUpdateSelectionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DestinationUpdateSelectionParams
        {
            DestinationID = "x",
            EnabledModels = ["x"],
            IntegrationID = "x",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedDestinationID = "x";
        List<string> expectedEnabledModels = ["x"];
        string expectedIntegrationID = "x";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedDestinationID, parameters.DestinationID);
        Assert.Equal(expectedEnabledModels.Count, parameters.EnabledModels.Count);
        for (int i = 0; i < expectedEnabledModels.Count; i++)
        {
            Assert.Equal(expectedEnabledModels[i], parameters.EnabledModels[i]);
        }
        Assert.Equal(expectedIntegrationID, parameters.IntegrationID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DestinationUpdateSelectionParams
        {
            DestinationID = "x",
            EnabledModels = ["x"],
            IntegrationID = "x",
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DestinationUpdateSelectionParams
        {
            DestinationID = "x",
            EnabledModels = ["x"],
            IntegrationID = "x",

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
        DestinationUpdateSelectionParams parameters = new()
        {
            DestinationID = "x",
            EnabledModels = ["x"],
            IntegrationID = "x",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/data-export/destinations/x"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        DestinationUpdateSelectionParams parameters = new()
        {
            DestinationID = "x",
            EnabledModels = ["x"],
            IntegrationID = "x",
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
        var parameters = new DestinationUpdateSelectionParams
        {
            DestinationID = "x",
            EnabledModels = ["x"],
            IntegrationID = "x",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        DestinationUpdateSelectionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
