using System;
using Stigg.Client.Models.V1Beta.Entities;

namespace Stigg.Client.Tests.Models.V1Beta.Entities;

public class EntityRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityRetrieveParams { ID = "id", EntityID = "x" };

        string expectedID = "id";
        string expectedEntityID = "x";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEntityID, parameters.EntityID);
    }

    [Fact]
    public void Url_Works()
    {
        EntityRetrieveParams parameters = new() { ID = "id", EntityID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1-beta/customers/id/entities/x"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityRetrieveParams { ID = "id", EntityID = "x" };

        EntityRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
