using System;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationUpdateParams
        {
            ID = "id",
            IntegrationID = "integrationId",
            SyncedEntityID = "syncedEntityId",
        };

        string expectedID = "id";
        string expectedIntegrationID = "integrationId";
        string expectedSyncedEntityID = "syncedEntityId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIntegrationID, parameters.IntegrationID);
        Assert.Equal(expectedSyncedEntityID, parameters.SyncedEntityID);
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationUpdateParams parameters = new()
        {
            ID = "id",
            IntegrationID = "integrationId",
            SyncedEntityID = "syncedEntityId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/customers/id/integrations/integrationId"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntegrationUpdateParams
        {
            ID = "id",
            IntegrationID = "integrationId",
            SyncedEntityID = "syncedEntityId",
        };

        IntegrationUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
