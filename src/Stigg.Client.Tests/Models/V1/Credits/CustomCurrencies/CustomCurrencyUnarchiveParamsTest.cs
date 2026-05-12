using System;
using Stigg.Client.Models.V1.Credits.CustomCurrencies;

namespace Stigg.Client.Tests.Models.V1.Credits.CustomCurrencies;

public class CustomCurrencyUnarchiveParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomCurrencyUnarchiveParams { CurrencyID = "currencyId" };

        string expectedCurrencyID = "currencyId";

        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
    }

    [Fact]
    public void Url_Works()
    {
        CustomCurrencyUnarchiveParams parameters = new() { CurrencyID = "currencyId" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/credits/custom-currencies/currencyId/unarchive"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomCurrencyUnarchiveParams { CurrencyID = "currencyId" };

        CustomCurrencyUnarchiveParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
