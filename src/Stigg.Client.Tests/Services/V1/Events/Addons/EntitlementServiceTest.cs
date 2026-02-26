using System.Threading.Tasks;
using Stigg.Client.Models.V1.Events.Addons.Entitlements;

namespace Stigg.Client.Tests.Services.V1.Events.Addons;

public class EntitlementServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Create_Works()
    {
        var entitlement = await this.client.V1.Events.Addons.Entitlements.Create(
            "addonId",
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
        var addonPackageEntitlement = await this.client.V1.Events.Addons.Entitlements.Update(
            "id",
            new() { AddonID = "addonId" },
            TestContext.Current.CancellationToken
        );
        addonPackageEntitlement.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var entitlements = await this.client.V1.Events.Addons.Entitlements.List(
            "addonId",
            new(),
            TestContext.Current.CancellationToken
        );
        entitlements.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Delete_Works()
    {
        var addonPackageEntitlement = await this.client.V1.Events.Addons.Entitlements.Delete(
            "id",
            new() { AddonID = "addonId" },
            TestContext.Current.CancellationToken
        );
        addonPackageEntitlement.Validate();
    }
}
