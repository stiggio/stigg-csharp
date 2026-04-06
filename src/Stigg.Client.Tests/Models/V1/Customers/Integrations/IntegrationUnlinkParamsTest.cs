using System;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationUnlinkParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationUnlinkParams { ID = "id", IntegrationID = "integrationId" };

        string expectedID = "id";
        string expectedIntegrationID = "integrationId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIntegrationID, parameters.IntegrationID);
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationUnlinkParams parameters = new() { ID = "id", IntegrationID = "integrationId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri("https://api.stigg.io/api/v1/customers/id/integrations/integrationId"),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new IntegrationUnlinkParams { ID = "id", IntegrationID = "integrationId" };

        IntegrationUnlinkParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
