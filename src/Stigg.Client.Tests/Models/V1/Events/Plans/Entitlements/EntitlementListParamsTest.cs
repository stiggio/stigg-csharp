using System;
using Stigg.Client.Models.V1.Events.Plans.Entitlements;

namespace Stigg.Client.Tests.Models.V1.Events.Plans.Entitlements;

public class EntitlementListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntitlementListParams { PlanID = "planId" };

        string expectedPlanID = "planId";

        Assert.Equal(expectedPlanID, parameters.PlanID);
    }

    [Fact]
    public void Url_Works()
    {
        EntitlementListParams parameters = new() { PlanID = "planId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans/planId/entitlements"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntitlementListParams { PlanID = "planId" };

        EntitlementListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
