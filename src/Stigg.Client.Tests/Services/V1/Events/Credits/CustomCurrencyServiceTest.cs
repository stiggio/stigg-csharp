using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1.Events.Credits;

public class CustomCurrencyServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var customCurrency = await this.client.V1.Events.Credits.CustomCurrencies.Create(
            new() { ID = "id", DisplayName = "displayName" },
            TestContext.Current.CancellationToken
        );
        customCurrency.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var customCurrency = await this.client.V1.Events.Credits.CustomCurrencies.Update(
            "currencyId",
            new(),
            TestContext.Current.CancellationToken
        );
        customCurrency.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Events.Credits.CustomCurrencies.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var response = await this.client.V1.Events.Credits.CustomCurrencies.Archive(
            "currencyId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListAssociatedEntities_Works()
    {
        var response = await this.client.V1.Events.Credits.CustomCurrencies.ListAssociatedEntities(
            "currencyId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Unarchive_Works()
    {
        var response = await this.client.V1.Events.Credits.CustomCurrencies.Unarchive(
            "currencyId",
            new(),
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
