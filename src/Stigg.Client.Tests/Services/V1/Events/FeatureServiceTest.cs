using System.Threading.Tasks;
using Stigg.Client.Models.V1.Events.Features;

namespace Stigg.Client.Tests.Services.V1.Events;

public class FeatureServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ArchiveFeature_Works()
    {
        var feature = await this.client.V1.Events.Features.ArchiveFeature(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        feature.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task CreateFeature_Works()
    {
        var feature = await this.client.V1.Events.Features.CreateFeature(
            new()
            {
                ID = "id",
                DisplayName = "displayName",
                FeatureType = FeatureType.Boolean,
            },
            TestContext.Current.CancellationToken
        );
        feature.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListFeatures_Works()
    {
        var page = await this.client.V1.Events.Features.ListFeatures(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task RetrieveFeature_Works()
    {
        var feature = await this.client.V1.Events.Features.RetrieveFeature(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        feature.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UnarchiveFeature_Works()
    {
        var feature = await this.client.V1.Events.Features.UnarchiveFeature(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        feature.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task UpdateFeature_Works()
    {
        var feature = await this.client.V1.Events.Features.UpdateFeature(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        feature.Validate();
    }
}
