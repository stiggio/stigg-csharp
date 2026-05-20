using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Credits;

public class CustomCurrencyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var customCurrencyResponse = await this.client.V1.Credits.CustomCurrencies.Create(
            new() { ID = "id", DisplayName = "displayName" },
            TestContext.Current.CancellationToken
        );
        customCurrencyResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var customCurrencyResponse = await this.client.V1.Credits.CustomCurrencies.Update(
            "currencyId",
            new(),
            TestContext.Current.CancellationToken
        );
        customCurrencyResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Credits.CustomCurrencies.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var customCurrencyResponse = await this.client.V1.Credits.CustomCurrencies.Archive(
            "currencyId",
            new(),
            TestContext.Current.CancellationToken
        );
        customCurrencyResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAssociatedEntities_Works()
    {
        var response = await this.client.V1.Credits.CustomCurrencies.ListAssociatedEntities(
            "currencyId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Unarchive_Works()
    {
        var customCurrencyResponse = await this.client.V1.Credits.CustomCurrencies.Unarchive(
            "currencyId",
            new(),
            TestContext.Current.CancellationToken
        );
        customCurrencyResponse.Validate();
    }
}
