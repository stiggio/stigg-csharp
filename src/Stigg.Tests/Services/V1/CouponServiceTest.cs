using System.Threading.Tasks;
using Stigg.Models.V1.Coupons;

namespace Stigg.Tests.Services.V1;

public class CouponServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var coupon = await this.client.V1.Coupons.Create(
            new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = Currency.Usd }],
                Description = "description",
                DurationInMonths = 1,
                Name = "name",
                PercentOff = 1,
            },
            TestContext.Current.CancellationToken
        );
        coupon.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Retrieve_Works()
    {
        var coupon = await this.client.V1.Coupons.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        coupon.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task List_Works()
    {
        var coupons = await this.client.V1.Coupons.List(
            new(),
            TestContext.Current.CancellationToken
        );
        coupons.Validate();
    }
}
