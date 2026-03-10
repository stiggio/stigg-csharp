using System;
using Stigg.Client.Models.V1.Products;

namespace Stigg.Client.Tests.Models.V1.Products;

public class ProductArchiveProductParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ProductArchiveProductParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        ProductArchiveProductParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/products/x/archive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new ProductArchiveProductParams { ID = "x" };

        ProductArchiveProductParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
