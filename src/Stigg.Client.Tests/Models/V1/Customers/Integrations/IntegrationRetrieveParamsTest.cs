using System;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationRetrieveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationRetrieveParams
        {
            ID = "id",
            IntegrationID = "integrationId",
        };

        string expectedID = "id";
        string expectedIntegrationID = "integrationId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIntegrationID, parameters.IntegrationID);
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationRetrieveParams parameters = new() { ID = "id", IntegrationID = "integrationId" };

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
        var parameters = new IntegrationRetrieveParams
        {
            ID = "id",
            IntegrationID = "integrationId",
        };

        IntegrationRetrieveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
