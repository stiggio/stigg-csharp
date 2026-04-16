using System;
using Stigg.Client.Models.V1.Events.Credits;

namespace Stigg.Client.Tests.Models.V1.Events.Credits;

public class CreditListLedgerParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CreditListLedgerParams
        {
            CustomerID = "customerId",
            After = "after",
            Before = "before",
            CurrencyID = "currencyId",
            Limit = 1,
            ResourceID = "resourceId",
        };

        string expectedCustomerID = "customerId";
        string expectedAfter = "after";
        string expectedBefore = "before";
        string expectedCurrencyID = "currencyId";
        long expectedLimit = 1;
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CreditListLedgerParams { CustomerID = "customerId" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CreditListLedgerParams
        {
            CustomerID = "customerId",

            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            CurrencyID = null,
            Limit = null,
            ResourceID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
    }

    [Fact]
    public void Url_Works()
    {
        CreditListLedgerParams parameters = new()
        {
            CustomerID = "customerId",
            After = "after",
            Before = "before",
            CurrencyID = "currencyId",
            Limit = 1,
            ResourceID = "resourceId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/credits/ledger?customerId=customerId&after=after&before=before&currencyId=currencyId&limit=1&resourceId=resourceId"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CreditListLedgerParams
        {
            CustomerID = "customerId",
            After = "after",
            Before = "before",
            CurrencyID = "currencyId",
            Limit = 1,
            ResourceID = "resourceId",
        };

        CreditListLedgerParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
