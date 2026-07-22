using System;
using System.Net.Http;
using Stigg.Client.Models.V1.Credits;

namespace Stigg.Client.Tests.Models.V1.Credits;

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
            EventType = "eventType",
            Limit = 1,
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedCustomerID = "customerId";
        string expectedAfter = "after";
        string expectedBefore = "before";
        string expectedCurrencyID = "currencyId";
        string expectedEventType = "eventType";
        long expectedLimit = 1;
        string expectedResourceID = "resourceId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedEventType, parameters.EventType);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
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
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("eventType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
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
            EventType = null,
            Limit = null,
            ResourceID = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.EventType);
        Assert.False(parameters.RawQueryData.ContainsKey("eventType"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
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
            EventType = "eventType",
            Limit = 1,
            ResourceID = "resourceId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://edge.api.stigg.io/api/v1/credits/ledger?customerId=customerId&after=after&before=before&currencyId=currencyId&eventType=eventType&limit=1&resourceId=resourceId"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CreditListLedgerParams parameters = new()
        {
            CustomerID = "customerId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["X-ACCOUNT-ID"], requestMessage.Headers.GetValues("X-ACCOUNT-ID"));
        Assert.Equal(["X-ENVIRONMENT-ID"], requestMessage.Headers.GetValues("X-ENVIRONMENT-ID"));
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
            EventType = "eventType",
            Limit = 1,
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CreditListLedgerParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
