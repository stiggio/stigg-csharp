using System;
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
        };

        string expectedID = "x";
        string expectedIDValue = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, IntegrationLinkParamsVendorIdentifier> expectedVendorIdentifier =
            IntegrationLinkParamsVendorIdentifier.Auth0;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedIDValue, parameters.IDValue);
        Assert.Equal(expectedSyncedEntityID, parameters.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, parameters.VendorIdentifier);
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
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/customers/x/integrations"), url)
        );
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
