using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1;

public class ContractServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var contract = await this.client.V1.Contracts.Create(
            new() { CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var contract = await this.client.V1.Contracts.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var contract = await this.client.V1.Contracts.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Contracts.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var contract = await this.client.V1.Contracts.Delete(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        contract.Validate();
    }
}
