using System;
using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Customers;

public class UsageServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var usage = await this.client.V1.Customers.Usage.Retrieve(
            "featureId",
            new()
            {
                CustomerID = "customerId",
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            TestContext.Current.CancellationToken
        );
        usage.Validate();
    }
}
