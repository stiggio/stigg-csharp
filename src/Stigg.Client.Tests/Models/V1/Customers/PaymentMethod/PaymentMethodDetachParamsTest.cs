using System;
using Stigg.Client.Models.V1.Customers.PaymentMethod;

namespace Stigg.Client.Tests.Models.V1.Customers.PaymentMethod;

public class PaymentMethodDetachParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PaymentMethodDetachParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        PaymentMethodDetachParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/customers/x/payment-method"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PaymentMethodDetachParams { ID = "x" };

        PaymentMethodDetachParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
