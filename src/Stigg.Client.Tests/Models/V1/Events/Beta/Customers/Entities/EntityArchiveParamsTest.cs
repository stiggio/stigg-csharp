using System;
using System.Collections.Generic;
using Stigg.Client.Models.V1.Events.Beta.Customers.Entities;

namespace Stigg.Client.Tests.Models.V1.Events.Beta.Customers.Entities;

public class EntityArchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new EntityArchiveParams
        {
            ID = "id",
            Ids = ["user-7f3a0c1d", "user-c4d1b2e9"],
        };

        string expectedID = "id";
        List<string> expectedIds = ["user-7f3a0c1d", "user-c4d1b2e9"];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIds.Count, parameters.Ids.Count);
        for (int i = 0; i < expectedIds.Count; i++)
        {
            Assert.Equal(expectedIds[i], parameters.Ids[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        EntityArchiveParams parameters = new()
        {
            ID = "id",
            Ids = ["user-7f3a0c1d", "user-c4d1b2e9"],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1-beta/customers/id/entities/archive"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new EntityArchiveParams
        {
            ID = "id",
            Ids = ["user-7f3a0c1d", "user-c4d1b2e9"],
        };

        EntityArchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
