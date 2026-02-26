using System;
using Stigg.Client.Models.V1.Features;

namespace Stigg.Client.Tests.Models.V1.Features;

public class FeatureUnarchiveFeatureParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FeatureUnarchiveFeatureParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        FeatureUnarchiveFeatureParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/features/x/unarchive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FeatureUnarchiveFeatureParams { ID = "x" };

        FeatureUnarchiveFeatureParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
