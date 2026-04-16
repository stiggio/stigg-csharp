using System;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanRemoveDraftParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanRemoveDraftParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        PlanRemoveDraftParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/plans/x/draft"), url));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanRemoveDraftParams { ID = "x" };

        PlanRemoveDraftParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
