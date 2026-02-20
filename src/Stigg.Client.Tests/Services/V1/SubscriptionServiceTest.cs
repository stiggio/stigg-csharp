using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1;

public class SubscriptionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var subscription = await this.client.V1.Subscriptions.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var subscription = await this.client.V1.Subscriptions.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Subscriptions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Cancel_Works()
    {
        var subscription = await this.client.V1.Subscriptions.Cancel(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delegate_Works()
    {
        var subscription = await this.client.V1.Subscriptions.Delegate(
            "x",
            new() { TargetCustomerID = "targetCustomerId" },
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Import_Works()
    {
        var response = await this.client.V1.Subscriptions.Import(
            new()
            {
                Subscriptions =
                [
                    new()
                    {
                        ID = "id",
                        CustomerID = "customerId",
                        PlanID = "planId",
                        BillingID = "billingId",
                        EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        ResourceID = "resourceId",
                        StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Migrate_Works()
    {
        var subscription = await this.client.V1.Subscriptions.Migrate(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Preview_Works()
    {
        var response = await this.client.V1.Subscriptions.Preview(
            new() { CustomerID = "customerId", PlanID = "planId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Provision_Works()
    {
        var response = await this.client.V1.Subscriptions.Provision(
            new() { CustomerID = "customerId", PlanID = "planId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Transfer_Works()
    {
        var subscription = await this.client.V1.Subscriptions.Transfer(
            "x",
            new() { DestinationResourceID = "destinationResourceId" },
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }
}
