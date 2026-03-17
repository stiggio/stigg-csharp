using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1;

public class ProductServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ArchiveProduct_Works()
    {
        var product = await this.client.V1.Products.ArchiveProduct(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        product.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateProduct_Works()
    {
        var product = await this.client.V1.Products.CreateProduct(
            new() { ID = "id", DisplayName = "displayName" },
            TestContext.Current.CancellationToken
        );
        product.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task DuplicateProduct_Works()
    {
        var product = await this.client.V1.Products.DuplicateProduct(
            "x",
            new() { TargetID = "targetId" },
            TestContext.Current.CancellationToken
        );
        product.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListProducts_Works()
    {
        var page = await this.client.V1.Products.ListProducts(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UnarchiveProduct_Works()
    {
        var product = await this.client.V1.Products.UnarchiveProduct(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        product.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateProduct_Works()
    {
        var product = await this.client.V1.Products.UpdateProduct(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        product.Validate();
    }
}
