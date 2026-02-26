using System;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanRetrieveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        PlanRetrieveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanRetrieveParams { ID = "x" };

        PlanRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
