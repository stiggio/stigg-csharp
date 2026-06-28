using System;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationLinkParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new IntegrationLinkParams
        {
            ID = "x",
            IDValue = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkParamsVendorIdentifier.Auth0,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        string expectedIDValue = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationLinkParamsVendorIdentifier> expectedVendorIdentifier =
            IntegrationLinkParamsVendorIdentifier.Auth0;
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIDValue, parameters.IDValue);
        Assert.Equal(expectedSyncedEntityID, parameters.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, parameters.VendorIdentifier);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new IntegrationLinkParams
        {
            ID = "x",
            IDValue = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkParamsVendorIdentifier.Auth0,
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new IntegrationLinkParams
        {
            ID = "x",
            IDValue = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkParamsVendorIdentifier.Auth0,

            // Null should be interpreted as omitted for these properties
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        IntegrationLinkParams parameters = new()
        {
            ID = "x",
            IDValue = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkParamsVendorIdentifier.Auth0,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://edge.api.stigg.io/api/v1/customers/x/integrations"),
                url
            )
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        IntegrationLinkParams parameters = new()
        {
            ID = "x",
            IDValue = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkParamsVendorIdentifier.Auth0,
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
        var parameters = new IntegrationLinkParams
        {
            ID = "x",
            IDValue = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = IntegrationLinkParamsVendorIdentifier.Auth0,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        IntegrationLinkParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class IntegrationLinkParamsVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Auth0)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Zuora)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Stripe)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Hubspot)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Snowflake)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Salesforce)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.BigQuery)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.OpenFga)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.AppStore)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Received)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Prequel)]
    public void Validation_Works(IntegrationLinkParamsVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationLinkParamsVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationLinkParamsVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Auth0)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Zuora)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Stripe)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Hubspot)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.AwsMarketplace)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Snowflake)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Salesforce)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.BigQuery)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.OpenFga)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.AppStore)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Received)]
    [InlineData(IntegrationLinkParamsVendorIdentifier.Prequel)]
    public void SerializationRoundtrip_Works(IntegrationLinkParamsVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, IntegrationLinkParamsVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationLinkParamsVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationLinkParamsVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, IntegrationLinkParamsVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
