using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1;

public class SubscriptionServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var subscription = await this.client.V1.Subscriptions.Create(
            new() { CustomerID = "customerId", PlanID = "planId" },
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var subscription = await this.client.V1.Subscriptions.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        subscription.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Subscriptions.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Delegate_Works()
    {
        var response = await this.client.V1.Subscriptions.Delegate(
            "x",
            new() { TargetCustomerID = "targetCustomerId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Migrate_Works()
    {
        var response = await this.client.V1.Subscriptions.Migrate(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Preview_Works()
    {
        var response = await this.client.V1.Subscriptions.Preview(
            new() { CustomerID = "customerId", PlanID = "planId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Transfer_Works()
    {
        var response = await this.client.V1.Subscriptions.Transfer(
            "x",
            new() { DestinationResourceID = "destinationResourceId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
