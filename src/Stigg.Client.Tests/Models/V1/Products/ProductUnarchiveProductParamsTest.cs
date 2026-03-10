using System;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductUnarchiveProductParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductUnarchiveProductParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProductUnarchiveProductParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/products/x/unarchive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductUnarchiveProductParams { ID = "x" };

        ProductUnarchiveProductParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
