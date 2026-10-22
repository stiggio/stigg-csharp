using System;
using System.Net.Http;
using Stigg.Client.Models.V1.Credits.Reservations;

namespace Stigg.Client.Tests.Models.V1.Credits.Reservations;

public class ReservationReleaseParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ReservationReleaseParams
        {
            ReservationID = "x",
            ConsumedAmount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedReservationID = "x";
        double expectedConsumedAmount = 0;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedResourceID = "resourceId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedReservationID, parameters.ReservationID);
        Assert.Equal(expectedConsumedAmount, parameters.ConsumedAmount);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ReservationReleaseParams
        {
            ReservationID = "x",
            ConsumedAmount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
        };

        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ReservationReleaseParams
        {
            ReservationID = "x",
            ConsumedAmount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",

            // Null should be interpreted as omitted for these properties
            ResourceID = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        ReservationReleaseParams parameters = new()
        {
            ReservationID = "x",
            ConsumedAmount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1/credits/reservations/x/release"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ReservationReleaseParams parameters = new()
        {
            ReservationID = "x",
            ConsumedAmount = 0,
            CurrencyID = "currencyId",
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
        var parameters = new ReservationReleaseParams
        {
            ReservationID = "x",
            ConsumedAmount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        ReservationReleaseParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
