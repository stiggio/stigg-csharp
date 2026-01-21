using System.Threading.Tasks;

namespace Stigg.Tests.Services.V1;

public class CustomerServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var customerResponse = await this.client.V1.Customers.Create(
            new()
            {
                Email = "dev@stainless.com",
                ExternalID = "externalId",
                Name = "name",
            },
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var customerResponse = await this.client.V1.Customers.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Update_Works()
    {
        var customerResponse = await this.client.V1.Customers.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var customers = await this.client.V1.Customers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        customers.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Archive_Works()
    {
        var customerResponse = await this.client.V1.Customers.Archive(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Unarchive_Works()
    {
        var customerResponse = await this.client.V1.Customers.Unarchive(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }
}
