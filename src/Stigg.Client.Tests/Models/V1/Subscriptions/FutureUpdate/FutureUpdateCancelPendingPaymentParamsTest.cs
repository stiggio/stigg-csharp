using System;
using Stigg.Client.Models.V1.Subscriptions.FutureUpdate;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.FutureUpdate;

public class FutureUpdateCancelPendingPaymentParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new FutureUpdateCancelPendingPaymentParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        FutureUpdateCancelPendingPaymentParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.example.com/api/v1/subscriptions/x/future-update/pending-payment"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new FutureUpdateCancelPendingPaymentParams { ID = "x" };

        FutureUpdateCancelPendingPaymentParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
