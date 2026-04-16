using System;
using Stigg.Client.Models.V1.Features;

namespace Stigg.Client.Tests.Models.V1.Features;

public class FeatureRetrieveFeatureParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FeatureRetrieveFeatureParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        FeatureRetrieveFeatureParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/features/x"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FeatureRetrieveFeatureParams { ID = "x" };

        FeatureRetrieveFeatureParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
