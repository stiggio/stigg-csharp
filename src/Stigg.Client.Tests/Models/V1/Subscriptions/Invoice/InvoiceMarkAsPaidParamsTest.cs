using System;
using Stigg.Client.Models.V1.Subscriptions.Invoice;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.Invoice;

public class InvoiceMarkAsPaidParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new InvoiceMarkAsPaidParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        InvoiceMarkAsPaidParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/subscriptions/x/invoice/paid"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new InvoiceMarkAsPaidParams { ID = "x" };

        InvoiceMarkAsPaidParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
