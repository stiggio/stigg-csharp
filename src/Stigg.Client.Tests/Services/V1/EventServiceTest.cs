using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stigg.Client.Models.V1.Events;

namespace Stigg.Client.Tests.Services.V1;

public class EventServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Report_Works()
    {
        var response = await this.client.V1.Events.Report(
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
}
