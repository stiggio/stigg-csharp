using System.Threading.Tasks;
using Stigg.Client.Models.V1.Plans.Entitlements;

namespace Stigg.Client.Tests.Services.V1.Plans;

public class EntitlementServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var entitlement = await this.client.V1.Plans.Entitlements.Create(
            "planId",
            new()
            {
                Entitlements =
                [
                    new()
                    {
                        Credit = new()
                        {
                            Amount = 1,
                            Cadence = Cadence.Month,
                            CustomCurrencyID = "customCurrencyId",
                            Behavior = Behavior.Increment,
                            Description = "description",
                            DisplayNameOverride = "displayNameOverride",
                            HiddenFromWidgets = [HiddenFromWidget.Paywall],
                            IsCustom = true,
                            IsGranted = true,
                            Order = 0,
                        },
                        Feature = new()
                        {
                            FeatureID = "featureId",
                            Behavior = FeatureBehavior.Increment,
                            Description = "description",
                            DisplayNameOverride = "displayNameOverride",
                            EnumValues = ["string"],
                            HasSoftLimit = true,
                            HasUnlimitedUsage = true,
                            HiddenFromWidgets = [FeatureHiddenFromWidget.Paywall],
                            IsCustom = true,
                            IsGranted = true,
                            MonthlyResetPeriodConfiguration = new(AccordingTo.SubscriptionStart),
                            Order = 0,
                            ResetPeriod = ResetPeriod.Year,
                            UsageLimit = 0,
                            WeeklyResetPeriodConfiguration = new(
                                WeeklyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                            YearlyResetPeriodConfiguration = new(
                                YearlyResetPeriodConfigurationAccordingTo.SubscriptionStart
                            ),
                        },
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        entitlement.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var planEntitlement = await this.client.V1.Plans.Entitlements.Update(
            "id",
            new() { PlanID = "planId" },
            TestContext.Current.CancellationToken
        );
        planEntitlement.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var entitlements = await this.client.V1.Plans.Entitlements.List(
            "planId",
            new(),
            TestContext.Current.CancellationToken
        );
        entitlements.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var planEntitlement = await this.client.V1.Plans.Entitlements.Delete(
            "id",
            new() { PlanID = "planId" },
            TestContext.Current.CancellationToken
        );
        planEntitlement.Validate();
    }
}
