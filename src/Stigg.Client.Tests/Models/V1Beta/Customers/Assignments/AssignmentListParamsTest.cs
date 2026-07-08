using System;
using System.Net.Http;
using Stigg.Client.Models.V1Beta.Customers.Assignments;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Assignments;

public class AssignmentListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AssignmentListParams
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CurrencyID = "currencyId",
            EntityID = "entityId",
            FeatureID = "featureId",
            Limit = 1,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedCurrencyID = "currencyId";
        string expectedEntityID = "entityId";
        string expectedFeatureID = "featureId";
        long expectedLimit = 1;
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedEntityID, parameters.EntityID);
        Assert.Equal(expectedFeatureID, parameters.FeatureID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new AssignmentListParams { ID = "id" };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawQueryData.ContainsKey("entityId"));
        Assert.Null(parameters.FeatureID);
        Assert.False(parameters.RawQueryData.ContainsKey("featureId"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new AssignmentListParams
        {
            ID = "id",

            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            CurrencyID = null,
            EntityID = null,
            FeatureID = null,
            Limit = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CurrencyID);
        Assert.False(parameters.RawQueryData.ContainsKey("currencyId"));
        Assert.Null(parameters.EntityID);
        Assert.False(parameters.RawQueryData.ContainsKey("entityId"));
        Assert.Null(parameters.FeatureID);
        Assert.False(parameters.RawQueryData.ContainsKey("featureId"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        AssignmentListParams parameters = new()
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CurrencyID = "currencyId",
            EntityID = "entityId",
            FeatureID = "featureId",
            Limit = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1-beta/customers/id/assignments?after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&currencyId=currencyId&entityId=entityId&featureId=featureId&limit=1"
                ),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        AssignmentListParams parameters = new()
        {
            ID = "id",
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
        var parameters = new AssignmentListParams
        {
            ID = "id",
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CurrencyID = "currencyId",
            EntityID = "entityId",
            FeatureID = "featureId",
            Limit = 1,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        AssignmentListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
