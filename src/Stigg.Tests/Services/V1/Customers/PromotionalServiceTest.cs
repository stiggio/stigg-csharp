using System;
using System.Threading.Tasks;
using Stigg.Models.V1.Customers.Promotional;

namespace Stigg.Tests.Services.V1.Customers;

public class PromotionalServiceTest : TestBase
{
    [Fact(Skip = "Prism tests are disabled")]
    public async Task Create_Works()
    {
        var promotional = await this.client.V1.Customers.Promotional.Create(
            "customerId",
            new()
            {
                PromotionalEntitlements =
                [
                    new()
                    {
                        CustomEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        EnumValues = ["string"],
                        FeatureID = "featureId",
                        HasSoftLimit = true,
                        HasUnlimitedUsage = true,
                        IsVisible = true,
                        MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                        Period = Period.V1Week,
                        ResetPeriod = ResetPeriod.Year,
                        UsageLimit = -9007199254740991,
                        WeeklyResetPeriodConfiguration = new(
                            WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                        YearlyResetPeriodConfiguration = new(
                            YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                        ),
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        promotional.Validate();
    }

    [Fact(Skip = "Prism tests are disabled")]
    public async Task Revoke_Works()
    {
        var response = await this.client.V1.Customers.Promotional.Revoke(
            "featureId",
            new() { CustomerID = "customerId" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
