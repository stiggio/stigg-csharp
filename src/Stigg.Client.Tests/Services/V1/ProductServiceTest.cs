using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1;

public class ProductServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task ListProducts_Works()
    {
        var page = await this.client.V1.Products.ListProducts(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }
}
