using System;
using System.Net.Http;
using Stigg.Client.Models.V1.Events.DataExport;

namespace Stigg.Client.Tests.Models.V1.Events.DataExport;

public class DataExportMintScopedTokenParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DataExportMintScopedTokenParams
        {
            ApplicationOrigin = "x",
            DestinationType = "destinationType",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedApplicationOrigin = "x";
        string expectedDestinationType = "destinationType";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedApplicationOrigin, parameters.ApplicationOrigin);
        Assert.Equal(expectedDestinationType, parameters.DestinationType);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataExportMintScopedTokenParams { ApplicationOrigin = "x" };

        Assert.Null(parameters.DestinationType);
        Assert.False(parameters.RawBodyData.ContainsKey("destinationType"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DataExportMintScopedTokenParams
        {
            ApplicationOrigin = "x",

            // Null should be interpreted as omitted for these properties
            DestinationType = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.DestinationType);
        Assert.False(parameters.RawBodyData.ContainsKey("destinationType"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        DataExportMintScopedTokenParams parameters = new() { ApplicationOrigin = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/data-export/scoped-token"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        DataExportMintScopedTokenParams parameters = new()
        {
            ApplicationOrigin = "x",
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
        var parameters = new DataExportMintScopedTokenParams
        {
            ApplicationOrigin = "x",
            DestinationType = "destinationType",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        DataExportMintScopedTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
