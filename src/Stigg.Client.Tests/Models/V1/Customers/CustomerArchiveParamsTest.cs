using System;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

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

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/customers/x/archive"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerArchiveParams { ID = "x" };

        CustomerArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
