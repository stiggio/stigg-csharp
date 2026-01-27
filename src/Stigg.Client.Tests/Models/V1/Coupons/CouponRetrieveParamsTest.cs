using System;
using Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Tests.Models.V1.Coupons;

public class CouponRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CouponRetrieveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CouponRetrieveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/coupons/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CouponRetrieveParams { ID = "x" };

        CouponRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
