using System;
using Stigg.Client.Models.V1.Credits.Grants;

namespace Stigg.Client.Tests.Models.V1.Credits.Grants;

public class GrantVoidParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GrantVoidParams { ID = "x" };

        string expectedID = "x";

        Assert.Equal(expectedID, parameters.ID);
    }

    [Fact]
    public void Url_Works()
    {
        GrantVoidParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/credits/grants/x/void"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GrantVoidParams { ID = "x" };

        GrantVoidParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
