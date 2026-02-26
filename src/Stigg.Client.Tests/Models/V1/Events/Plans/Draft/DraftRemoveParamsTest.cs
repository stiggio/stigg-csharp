using System;
using Stigg.Client.Models.V1.Events.Plans.Draft;

namespace Stigg.Client.Tests.Models.V1.Events.Plans.Draft;

public class DraftRemoveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new DraftRemoveParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        DraftRemoveParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans/x/draft"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new DraftRemoveParams { ID = "x" };

        DraftRemoveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
