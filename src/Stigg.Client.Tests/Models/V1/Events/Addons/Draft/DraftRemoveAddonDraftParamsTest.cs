using System;
using Stigg.Client.Models.V1.Events.Addons.Draft;

namespace Stigg.Client.Tests.Models.V1.Events.Addons.Draft;

public class DraftRemoveAddonDraftParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DraftRemoveAddonDraftParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DraftRemoveAddonDraftParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/addons/x/draft"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DraftRemoveAddonDraftParams { ID = "x" };

        DraftRemoveAddonDraftParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
