using System;
using System.Net.Http;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationUnlinkParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationUnlinkParams
        {
            ID = "id",
            IntegrationID = "integrationId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        string expectedIntegrationID = "integrationId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIntegrationID, parameters.IntegrationID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntegrationUnlinkParams { ID = "id", IntegrationID = "integrationId" };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IntegrationUnlinkParams
        {
            ID = "id",
            IntegrationID = "integrationId",

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
        IntegrationUnlinkParams parameters = new() { ID = "id", IntegrationID = "integrationId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/customers/id/integrations/integrationId"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        IntegrationUnlinkParams parameters = new()
        {
            ID = "id",
            IntegrationID = "integrationId",
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
        var parameters = new IntegrationUnlinkParams
        {
            ID = "id",
            IntegrationID = "integrationId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        IntegrationUnlinkParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
