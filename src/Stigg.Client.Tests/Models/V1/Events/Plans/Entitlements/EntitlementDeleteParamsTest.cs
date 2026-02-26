using System;
using Stigg.Client.Models.V1.Events.Plans.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Events.Plans.Entitlements;

public class EntitlementDeleteParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementDeleteParams { PlanID = "planId", ID = "id" };

        string expectedPlanID = "planId";
        string expectedID = "id";

        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementDeleteParams parameters = new() { PlanID = "planId", ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans/planId/entitlements/id"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementDeleteParams { PlanID = "planId", ID = "id" };

        EntitlementDeleteParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
