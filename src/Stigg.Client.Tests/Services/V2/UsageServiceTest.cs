using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stigg.Client.Models.V2.Usage;

namespace Stigg.Client.Tests.Services.V2;

public class UsageServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Report_Works()
    {
        var response = await this.client.V2.Usage.Report(
            new()
            {
                Usages =
                [
                    new()
                    {
                        CustomerID = "customerId",
                        FeatureID = "featureId",
                        Value = -9007199254740991,
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                        IdempotencyKey = "x",
                        ResourceID = "resourceId",
                        UpdateBehavior = UpdateBehavior.Delta,
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
