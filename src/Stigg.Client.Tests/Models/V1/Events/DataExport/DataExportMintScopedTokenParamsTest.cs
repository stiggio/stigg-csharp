using System;
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
        };

        string expectedApplicationOrigin = "x";
        string expectedDestinationType = "destinationType";

        Assert.Equal(expectedApplicationOrigin, parameters.ApplicationOrigin);
        Assert.Equal(expectedDestinationType, parameters.DestinationType);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new DataExportMintScopedTokenParams { ApplicationOrigin = "x" };

        Assert.Null(parameters.DestinationType);
        Assert.False(parameters.RawBodyData.ContainsKey("destinationType"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new DataExportMintScopedTokenParams
        {
            ApplicationOrigin = "x",

            // Null should be interpreted as omitted for these properties
            DestinationType = null,
        };

        Assert.Null(parameters.DestinationType);
        Assert.False(parameters.RawBodyData.ContainsKey("destinationType"));
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
    public void CopyConstructor_Works()
    {
        var parameters = new DataExportMintScopedTokenParams
        {
            ApplicationOrigin = "x",
            DestinationType = "destinationType",
        };

        DataExportMintScopedTokenParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
