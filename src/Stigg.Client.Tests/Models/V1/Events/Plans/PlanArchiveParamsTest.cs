using System;
using Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Tests.Models.V1.Events.Plans;

public class PlanArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanArchiveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        PlanArchiveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans/x/archive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanArchiveParams { ID = "x" };

        PlanArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
