using System;
using System.Threading.Tasks;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Tests.Services.V1.Customers;

public class PromotionalEntitlementServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var promotionalEntitlement = await this.client.V1.Customers.PromotionalEntitlements.Create(
            "x",
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
        promotionalEntitlement.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Customers.PromotionalEntitlements.List(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Revoke_Works()
    {
        var response = await this.client.V1.Customers.PromotionalEntitlements.Revoke(
            "featureId",
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
