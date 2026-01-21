using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Customers;

namespace Stigg.Tests.Models.V1.Customers;

public class CustomerUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        string expectedID = "x";
        string expectedEmail = "dev@stainless.com";
        List<CustomerUpdateParamsIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedEmail, parameters.Email);
        Assert.NotNull(parameters.Integrations);
        Assert.Equal(expectedIntegrations.Count, parameters.Integrations.Count);
        for (int i = 0; i < expectedIntegrations.Count; i++)
        {
            Assert.Equal(expectedIntegrations[i], parameters.Integrations[i]);
        }
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            Email = "dev@stainless.com",
            Name = "name",
        };

        Assert.Null(parameters.Integrations);
        Assert.False(parameters.RawBodyData.ContainsKey("integrations"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            Email = "dev@stainless.com",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Integrations = null,
            Metadata = null,
        };

        Assert.Null(parameters.Integrations);
        Assert.False(parameters.RawBodyData.ContainsKey("integrations"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            Email = null,
            Name = null,
        };

        Assert.Null(parameters.Email);
        Assert.True(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerUpdateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/customers/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        CustomerUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CustomerUpdateParamsIntegrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerUpdateParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, CustomerUpdateParamsIntegrationVendorIdentifier> expectedVendorIdentifier =
            CustomerUpdateParamsIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerUpdateParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsIntegration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerUpdateParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerUpdateParamsIntegration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, CustomerUpdateParamsIntegrationVendorIdentifier> expectedVendorIdentifier =
            CustomerUpdateParamsIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerUpdateParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerUpdateParamsIntegrationVendorIdentifier.Auth0,
        };

        model.Validate();
    }
}

public class CustomerUpdateParamsIntegrationVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Auth0)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Zuora)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Stripe)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Hubspot)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Snowflake)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Salesforce)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.BigQuery)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.OpenFga)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.AppStore)]
    public void Validation_Works(CustomerUpdateParamsIntegrationVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerUpdateParamsIntegrationVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Auth0)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Zuora)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Stripe)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Hubspot)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Snowflake)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.Salesforce)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.BigQuery)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.OpenFga)]
    [InlineData(CustomerUpdateParamsIntegrationVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(
        CustomerUpdateParamsIntegrationVendorIdentifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerUpdateParamsIntegrationVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerUpdateParamsIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
