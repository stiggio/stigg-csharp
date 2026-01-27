using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stigg.Models.V1;

namespace Stigg.Tests.Services;

public class V1ServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateEvent_Works()
    {
        var response = await this.client.V1.CreateEvent(
            new()
            {
                Events =
                [
                    new()
                    {
                        CustomerID = "customerId",
                        EventName = "x",
                        IdempotencyKey = "x",
                        Dimensions = new Dictionary<string, Dimension>() { { "foo", "string" } },
                        ResourceID = "resourceId",
                        Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task CreateUsage_Works()
    {
        var response = await this.client.V1.CreateUsage(
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
                        Dimensions = new Dictionary<string, string>() { { "foo", "string" } },
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
