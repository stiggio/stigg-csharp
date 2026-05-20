using System;
using Stigg.Client.Models.V1.Events.Credits;

namespace Stigg.Client.Tests.Models.V1.Events.Credits;

public class CreditGetAutoRechargeParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditGetAutoRechargeParams
        {
            CurrencyID = "currencyId",
            CustomerID = "customerId",
        };

        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";

        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
    }

    [Fact]
    public void Url_Works()
    {
        CreditGetAutoRechargeParams parameters = new()
        {
            CurrencyID = "currencyId",
            CustomerID = "customerId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/credits/auto-recharge?currencyId=currencyId&customerId=customerId"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditGetAutoRechargeParams
        {
            CurrencyID = "currencyId",
            CustomerID = "customerId",
        };

        CreditGetAutoRechargeParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
