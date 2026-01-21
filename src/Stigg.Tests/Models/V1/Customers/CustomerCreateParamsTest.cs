using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Customers = Stigg.Models.V1.Customers;

namespace Stigg.Tests.Models.V1.Customers;

public class CustomerCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Customers::CustomerCreateParams
        {
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = Customers::VendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string expectedEmail = "dev@stainless.com";
        string expectedExternalID = "externalId";
        string expectedName = "name";
        Customers::DefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = Customers::Type.Card,
        };
        List<Customers::Integration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = Customers::VendorIdentifier.Auth0,
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedEmail, parameters.Email);
        Assert.Equal(expectedExternalID, parameters.ExternalID);
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedDefaultPaymentMethod, parameters.DefaultPaymentMethod);
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
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new Customers::CustomerCreateParams
        {
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
        };

        Assert.Null(parameters.Integrations);
        Assert.False(parameters.RawBodyData.ContainsKey("integrations"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new Customers::CustomerCreateParams
        {
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },

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
        var parameters = new Customers::CustomerCreateParams
        {
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = Customers::VendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.DefaultPaymentMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultPaymentMethod"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Customers::CustomerCreateParams
        {
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = Customers::VendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            DefaultPaymentMethod = null,
        };

        Assert.Null(parameters.DefaultPaymentMethod);
        Assert.True(parameters.RawBodyData.ContainsKey("defaultPaymentMethod"));
    }

    [Fact]
    public void Url_Works()
    {
        Customers::CustomerCreateParams parameters = new()
        {
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/customers"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Customers::CustomerCreateParams
        {
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = Customers::VendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Customers::CustomerCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DefaultPaymentMethodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::DefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = Customers::Type.Card,
        };

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, Customers::Type> expectedType = Customers::Type.Card;

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCardExpiryMonth, model.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, model.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, model.CardLast4Digits);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Customers::DefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = Customers::Type.Card,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Customers::DefaultPaymentMethod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::DefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = Customers::Type.Card,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Customers::DefaultPaymentMethod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, Customers::Type> expectedType = Customers::Type.Card;

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCardExpiryMonth, deserialized.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, deserialized.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, deserialized.CardLast4Digits);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Customers::DefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = Customers::Type.Card,
        };

        model.Validate();
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Customers::Type.Card)]
    [InlineData(Customers::Type.Bank)]
    [InlineData(Customers::Type.CashApp)]
    public void Validation_Works(Customers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Customers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Customers::Type.Card)]
    [InlineData(Customers::Type.Bank)]
    [InlineData(Customers::Type.CashApp)]
    public void SerializationRoundtrip_Works(Customers::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Customers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Customers::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Customers::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class IntegrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::VendorIdentifier.Auth0,
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, Customers::VendorIdentifier> expectedVendorIdentifier =
            Customers::VendorIdentifier.Auth0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Customers::Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::VendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Customers::Integration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::VendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Customers::Integration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, Customers::VendorIdentifier> expectedVendorIdentifier =
            Customers::VendorIdentifier.Auth0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Customers::Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::VendorIdentifier.Auth0,
        };

        model.Validate();
    }
}

public class VendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(Customers::VendorIdentifier.Auth0)]
    [InlineData(Customers::VendorIdentifier.Zuora)]
    [InlineData(Customers::VendorIdentifier.Stripe)]
    [InlineData(Customers::VendorIdentifier.Hubspot)]
    [InlineData(Customers::VendorIdentifier.AwsMarketplace)]
    [InlineData(Customers::VendorIdentifier.Snowflake)]
    [InlineData(Customers::VendorIdentifier.Salesforce)]
    [InlineData(Customers::VendorIdentifier.BigQuery)]
    [InlineData(Customers::VendorIdentifier.OpenFga)]
    [InlineData(Customers::VendorIdentifier.AppStore)]
    public void Validation_Works(Customers::VendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::VendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Customers::VendorIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Customers::VendorIdentifier.Auth0)]
    [InlineData(Customers::VendorIdentifier.Zuora)]
    [InlineData(Customers::VendorIdentifier.Stripe)]
    [InlineData(Customers::VendorIdentifier.Hubspot)]
    [InlineData(Customers::VendorIdentifier.AwsMarketplace)]
    [InlineData(Customers::VendorIdentifier.Snowflake)]
    [InlineData(Customers::VendorIdentifier.Salesforce)]
    [InlineData(Customers::VendorIdentifier.BigQuery)]
    [InlineData(Customers::VendorIdentifier.OpenFga)]
    [InlineData(Customers::VendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(Customers::VendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::VendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Customers::VendorIdentifier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Customers::VendorIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Customers::VendorIdentifier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
