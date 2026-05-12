using System;
using Stigg.Client.Models.V1.Credits.CustomCurrencies;

namespace Stigg.Client.Tests.Models.V1.Credits.CustomCurrencies;

public class CustomCurrencyListAssociatedEntitiesParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomCurrencyListAssociatedEntitiesParams
        {
            CurrencyID = "currencyId",
        };

        string expectedCurrencyID = "currencyId";

        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomCurrencyListAssociatedEntitiesParams parameters = new() { CurrencyID = "currencyId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/credits/custom-currencies/currencyId/associated-entities"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomCurrencyListAssociatedEntitiesParams
        {
            CurrencyID = "currencyId",
        };

        CustomCurrencyListAssociatedEntitiesParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
