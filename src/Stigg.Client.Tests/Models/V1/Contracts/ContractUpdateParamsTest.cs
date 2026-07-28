using System;
using System.Collections.Generic;
using System.Net.Http;
using Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Tests.Models.V1.Contracts;

public class ContractUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new ContractUpdateParams
        {
            ID = "x",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PoNumber = "poNumber",
            SetupBilling = true,
            SubscriptionIds = ["NxI"],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        DateTimeOffset expectedActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedActivationStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedName = "name";
        string expectedPoNumber = "poNumber";
        bool expectedSetupBilling = true;
        List<string> expectedSubscriptionIds = ["NxI"];
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedActivationEndDate, parameters.ActivationEndDate);
        Assert.Equal(expectedActivationStartDate, parameters.ActivationStartDate);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPoNumber, parameters.PoNumber);
        Assert.Equal(expectedSetupBilling, parameters.SetupBilling);
        Assert.NotNull(parameters.SubscriptionIds);
        Assert.Equal(expectedSubscriptionIds.Count, parameters.SubscriptionIds.Count);
        for (int i = 0; i < expectedSubscriptionIds.Count; i++)
        {
            Assert.Equal(expectedSubscriptionIds[i], parameters.SubscriptionIds[i]);
        }
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContractUpdateParams
        {
            ID = "x",
            Name = "name",
            PoNumber = "poNumber",
        };

        Assert.Null(parameters.ActivationEndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("activationEndDate"));
        Assert.Null(parameters.ActivationStartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("activationStartDate"));
        Assert.Null(parameters.SetupBilling);
        Assert.False(parameters.RawBodyData.ContainsKey("setupBilling"));
        Assert.Null(parameters.SubscriptionIds);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionIds"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new ContractUpdateParams
        {
            ID = "x",
            Name = "name",
            PoNumber = "poNumber",

            // Null should be interpreted as omitted for these properties
            ActivationEndDate = null,
            ActivationStartDate = null,
            SetupBilling = null,
            SubscriptionIds = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.ActivationEndDate);
        Assert.False(parameters.RawBodyData.ContainsKey("activationEndDate"));
        Assert.Null(parameters.ActivationStartDate);
        Assert.False(parameters.RawBodyData.ContainsKey("activationStartDate"));
        Assert.Null(parameters.SetupBilling);
        Assert.False(parameters.RawBodyData.ContainsKey("setupBilling"));
        Assert.Null(parameters.SubscriptionIds);
        Assert.False(parameters.RawBodyData.ContainsKey("subscriptionIds"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new ContractUpdateParams
        {
            ID = "x",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SetupBilling = true,
            SubscriptionIds = ["NxI"],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PoNumber);
        Assert.False(parameters.RawBodyData.ContainsKey("poNumber"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new ContractUpdateParams
        {
            ID = "x",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SetupBilling = true,
            SubscriptionIds = ["NxI"],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            Name = null,
            PoNumber = null,
        };

        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.PoNumber);
        Assert.True(parameters.RawBodyData.ContainsKey("poNumber"));
    }

    [Fact]
    public void Url_Works()
    {
        ContractUpdateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/contracts/x"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        ContractUpdateParams parameters = new()
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
        var parameters = new ContractUpdateParams
        {
            ID = "x",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Name = "name",
            PoNumber = "poNumber",
            SetupBilling = true,
            SubscriptionIds = ["NxI"],
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        ContractUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
