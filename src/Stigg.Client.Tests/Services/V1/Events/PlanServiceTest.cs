using System.Threading.Tasks;
using Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Tests.Services.V1.Events;

public class PlanServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var plan = await this.client.V1.Events.Plans.Create(
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                ProductID = "productId",
            },
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var plan = await this.client.V1.Events.Plans.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var plan = await this.client.V1.Events.Plans.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Events.Plans.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var plan = await this.client.V1.Events.Plans.Archive(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        plan.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Publish_Works()
    {
        var response = await this.client.V1.Events.Plans.Publish(
            "x",
            new() { MigrationType = MigrationType.NewCustomers },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task SetPricing_Works()
    {
        var setPackagePricingResponse = await this.client.V1.Events.Plans.SetPricing(
            "x",
            new() { PricingType = PlanSetPricingParamsPricingType.Free },
            TestContext.Current.CancellationToken
        );
        setPackagePricingResponse.Validate();
    }
}
