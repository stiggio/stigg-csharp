using System;
using Stigg.Models.V1.Customers;

namespace Stigg.Tests.Models.V1.Customers;

public class CustomerArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerArchiveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerArchiveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/customers/x/archive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerArchiveParams { ID = "x" };

        CustomerArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
