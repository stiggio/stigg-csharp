using System;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerUnarchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerUnarchiveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomerUnarchiveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/customers/x/unarchive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerUnarchiveParams { ID = "x" };

        CustomerUnarchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
