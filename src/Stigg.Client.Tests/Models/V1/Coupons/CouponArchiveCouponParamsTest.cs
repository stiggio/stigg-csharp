using System;
using Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Tests.Models.V1.Coupons;

public class CouponArchiveCouponParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CouponArchiveCouponParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        CouponArchiveCouponParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/coupons/x/archive"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CouponArchiveCouponParams { ID = "x" };

        CouponArchiveCouponParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
