using System;
using System.Collections.Generic;
using System.Net.Http;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerCheckEntitlementParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerCheckEntitlementParams
        {
            ID = "x",
            CurrencyID = "x",
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ReservationExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReservationID = "x",
            ReservationMetadata = "reservationMetadata",
            ReservationTtlSeconds = 1,
            ReserveAmount = 1,
            ResourceID = "x",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        string expectedCurrencyID = "x";
        string expectedFeatureID = "x";
        long expectedRequestedUsage = 0;
        List<string> expectedRequestedValues = ["string"];
        DateTimeOffset expectedReservationExpiresAt = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedReservationID = "x";
        string expectedReservationMetadata = "reservationMetadata";
        long expectedReservationTtlSeconds = 1;
        double expectedReserveAmount = 1;
        string expectedResourceID = "x";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedFeatureID, parameters.FeatureID);
        Assert.Equal(expectedRequestedUsage, parameters.RequestedUsage);
        Assert.NotNull(parameters.RequestedValues);
        Assert.Equal(expectedRequestedValues.Count, parameters.RequestedValues.Count);
        for (int i = 0; i < expectedRequestedValues.Count; i++)
        {
            Assert.Equal(expectedRequestedValues[i], parameters.RequestedValues[i]);
        }
        Assert.Equal(expectedReservationExpiresAt, parameters.ReservationExpiresAt);
        Assert.Equal(expectedReservationID, parameters.ReservationID);
        Assert.Equal(expectedReservationMetadata, parameters.ReservationMetadata);
        Assert.Equal(expectedReservationTtlSeconds, parameters.ReservationTtlSeconds);
        Assert.Equal(expectedReserveAmount, parameters.ReserveAmount);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerCheckEntitlementParams { ID = "x" };

        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.FeatureID);
        Assert.False(parameters.RawQueryData.ContainsKey("featureId"));
        Assert.Null(parameters.RequestedUsage);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedUsage"));
        Assert.Null(parameters.RequestedValues);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedValues"));
        Assert.Null(parameters.ReservationExpiresAt);
        Assert.False(parameters.RawQueryData.ContainsKey("reservationExpiresAt"));
        Assert.Null(parameters.ReservationID);
        Assert.False(parameters.RawQueryData.ContainsKey("reservationId"));
        Assert.Null(parameters.ReservationMetadata);
        Assert.False(parameters.RawQueryData.ContainsKey("reservationMetadata"));
        Assert.Null(parameters.ReservationTtlSeconds);
        Assert.False(parameters.RawQueryData.ContainsKey("reservationTtlSeconds"));
        Assert.Null(parameters.ReserveAmount);
        Assert.False(parameters.RawQueryData.ContainsKey("reserveAmount"));
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
        var parameters = new CustomerCheckEntitlementParams
        {
            ID = "x",

            // Null should be interpreted as omitted for these properties
            CurrencyID = null,
            FeatureID = null,
            RequestedUsage = null,
            RequestedValues = null,
            ReservationExpiresAt = null,
            ReservationID = null,
            ReservationMetadata = null,
            ReservationTtlSeconds = null,
            ReserveAmount = null,
            ResourceID = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.FeatureID);
        Assert.False(parameters.RawQueryData.ContainsKey("featureId"));
        Assert.Null(parameters.RequestedUsage);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedUsage"));
        Assert.Null(parameters.RequestedValues);
        Assert.False(parameters.RawQueryData.ContainsKey("requestedValues"));
        Assert.Null(parameters.ReservationExpiresAt);
        Assert.False(parameters.RawQueryData.ContainsKey("reservationExpiresAt"));
        Assert.Null(parameters.ReservationID);
        Assert.False(parameters.RawQueryData.ContainsKey("reservationId"));
        Assert.Null(parameters.ReservationMetadata);
        Assert.False(parameters.RawQueryData.ContainsKey("reservationMetadata"));
        Assert.Null(parameters.ReservationTtlSeconds);
        Assert.False(parameters.RawQueryData.ContainsKey("reservationTtlSeconds"));
        Assert.Null(parameters.ReserveAmount);
        Assert.False(parameters.RawQueryData.ContainsKey("reserveAmount"));
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
        CustomerCheckEntitlementParams parameters = new()
        {
            ID = "x",
            CurrencyID = "x",
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ReservationExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            ReservationID = "x",
            ReservationMetadata = "reservationMetadata",
            ReservationTtlSeconds = 1,
            ReserveAmount = 1,
            ResourceID = "x",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://edge.api.stigg.io/api/v1/customers/x/entitlements/check?currencyId=x&featureId=x&requestedUsage=0&requestedValues=string&reservationExpiresAt=2019-12-27T18%3a11%3a19.117%2b00%3a00&reservationId=x&reservationMetadata=reservationMetadata&reservationTtlSeconds=1&reserveAmount=1&resourceId=x"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomerCheckEntitlementParams parameters = new()
        {
            ID = "x",
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
        var parameters = new CustomerCheckEntitlementParams
        {
            ID = "x",
            CurrencyID = "x",
            FeatureID = "x",
            RequestedUsage = 0,
            RequestedValues = ["string"],
            ReservationExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ReservationID = "x",
            ReservationMetadata = "reservationMetadata",
            ReservationTtlSeconds = 1,
            ReserveAmount = 1,
            ResourceID = "x",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CustomerCheckEntitlementParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
