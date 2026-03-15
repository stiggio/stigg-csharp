using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            BillingCurrency = BillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        string expectedID = "x";
        ApiEnum<string, BillingCurrency> expectedBillingCurrency = BillingCurrency.Usd;
        string expectedBillingID = "billingId";
        string expectedCouponID = "couponId";
        string expectedEmail = "dev@stainless.com";
        List<Integration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = VendorIdentifier.Auth0,
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBillingCurrency, parameters.BillingCurrency);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.Equal(expectedCouponID, parameters.CouponID);
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
            BillingCurrency = BillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
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
            BillingCurrency = BillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
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
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.BillingCurrency);
        Assert.False(parameters.RawBodyData.ContainsKey("billingCurrency"));
        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CouponID);
        Assert.False(parameters.RawBodyData.ContainsKey("couponId"));
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
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            BillingCurrency = null,
            BillingID = null,
            CouponID = null,
            Email = null,
            Name = null,
        };

        Assert.Null(parameters.BillingCurrency);
        Assert.True(parameters.RawBodyData.ContainsKey("billingCurrency"));
        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CouponID);
        Assert.True(parameters.RawBodyData.ContainsKey("couponId"));
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

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/customers/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            BillingCurrency = BillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        CustomerUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class BillingCurrencyTest : TestBase
{
    [Theory]
    [InlineData(BillingCurrency.Usd)]
    [InlineData(BillingCurrency.Aed)]
    [InlineData(BillingCurrency.All)]
    [InlineData(BillingCurrency.Amd)]
    [InlineData(BillingCurrency.Ang)]
    [InlineData(BillingCurrency.Aud)]
    [InlineData(BillingCurrency.Awg)]
    [InlineData(BillingCurrency.Azn)]
    [InlineData(BillingCurrency.Bam)]
    [InlineData(BillingCurrency.Bbd)]
    [InlineData(BillingCurrency.Bdt)]
    [InlineData(BillingCurrency.Bgn)]
    [InlineData(BillingCurrency.Bif)]
    [InlineData(BillingCurrency.Bmd)]
    [InlineData(BillingCurrency.Bnd)]
    [InlineData(BillingCurrency.Bsd)]
    [InlineData(BillingCurrency.Bwp)]
    [InlineData(BillingCurrency.Byn)]
    [InlineData(BillingCurrency.Bzd)]
    [InlineData(BillingCurrency.Brl)]
    [InlineData(BillingCurrency.Cad)]
    [InlineData(BillingCurrency.Cdf)]
    [InlineData(BillingCurrency.Chf)]
    [InlineData(BillingCurrency.Cny)]
    [InlineData(BillingCurrency.Czk)]
    [InlineData(BillingCurrency.Dkk)]
    [InlineData(BillingCurrency.Dop)]
    [InlineData(BillingCurrency.Dzd)]
    [InlineData(BillingCurrency.Egp)]
    [InlineData(BillingCurrency.Etb)]
    [InlineData(BillingCurrency.Eur)]
    [InlineData(BillingCurrency.Fjd)]
    [InlineData(BillingCurrency.Gbp)]
    [InlineData(BillingCurrency.Gel)]
    [InlineData(BillingCurrency.Gip)]
    [InlineData(BillingCurrency.Gmd)]
    [InlineData(BillingCurrency.Gyd)]
    [InlineData(BillingCurrency.Hkd)]
    [InlineData(BillingCurrency.Hrk)]
    [InlineData(BillingCurrency.Htg)]
    [InlineData(BillingCurrency.Idr)]
    [InlineData(BillingCurrency.Ils)]
    [InlineData(BillingCurrency.Inr)]
    [InlineData(BillingCurrency.Isk)]
    [InlineData(BillingCurrency.Jmd)]
    [InlineData(BillingCurrency.Jpy)]
    [InlineData(BillingCurrency.Kes)]
    [InlineData(BillingCurrency.Kgs)]
    [InlineData(BillingCurrency.Khr)]
    [InlineData(BillingCurrency.Kmf)]
    [InlineData(BillingCurrency.Krw)]
    [InlineData(BillingCurrency.Kyd)]
    [InlineData(BillingCurrency.Kzt)]
    [InlineData(BillingCurrency.Lbp)]
    [InlineData(BillingCurrency.Lkr)]
    [InlineData(BillingCurrency.Lrd)]
    [InlineData(BillingCurrency.Lsl)]
    [InlineData(BillingCurrency.Mad)]
    [InlineData(BillingCurrency.Mdl)]
    [InlineData(BillingCurrency.Mga)]
    [InlineData(BillingCurrency.Mkd)]
    [InlineData(BillingCurrency.Mmk)]
    [InlineData(BillingCurrency.Mnt)]
    [InlineData(BillingCurrency.Mop)]
    [InlineData(BillingCurrency.Mro)]
    [InlineData(BillingCurrency.Mvr)]
    [InlineData(BillingCurrency.Mwk)]
    [InlineData(BillingCurrency.Mxn)]
    [InlineData(BillingCurrency.Myr)]
    [InlineData(BillingCurrency.Mzn)]
    [InlineData(BillingCurrency.Nad)]
    [InlineData(BillingCurrency.Ngn)]
    [InlineData(BillingCurrency.Nok)]
    [InlineData(BillingCurrency.Npr)]
    [InlineData(BillingCurrency.Nzd)]
    [InlineData(BillingCurrency.Pgk)]
    [InlineData(BillingCurrency.Php)]
    [InlineData(BillingCurrency.Pkr)]
    [InlineData(BillingCurrency.Pln)]
    [InlineData(BillingCurrency.Qar)]
    [InlineData(BillingCurrency.Ron)]
    [InlineData(BillingCurrency.Rsd)]
    [InlineData(BillingCurrency.Rub)]
    [InlineData(BillingCurrency.Rwf)]
    [InlineData(BillingCurrency.Sar)]
    [InlineData(BillingCurrency.Sbd)]
    [InlineData(BillingCurrency.Scr)]
    [InlineData(BillingCurrency.Sek)]
    [InlineData(BillingCurrency.Sgd)]
    [InlineData(BillingCurrency.Sle)]
    [InlineData(BillingCurrency.Sll)]
    [InlineData(BillingCurrency.Sos)]
    [InlineData(BillingCurrency.Szl)]
    [InlineData(BillingCurrency.Thb)]
    [InlineData(BillingCurrency.Tjs)]
    [InlineData(BillingCurrency.Top)]
    [InlineData(BillingCurrency.Try)]
    [InlineData(BillingCurrency.Ttd)]
    [InlineData(BillingCurrency.Tzs)]
    [InlineData(BillingCurrency.Uah)]
    [InlineData(BillingCurrency.Uzs)]
    [InlineData(BillingCurrency.Vnd)]
    [InlineData(BillingCurrency.Vuv)]
    [InlineData(BillingCurrency.Wst)]
    [InlineData(BillingCurrency.Xaf)]
    [InlineData(BillingCurrency.Xcd)]
    [InlineData(BillingCurrency.Yer)]
    [InlineData(BillingCurrency.Zar)]
    [InlineData(BillingCurrency.Zmw)]
    [InlineData(BillingCurrency.Clp)]
    [InlineData(BillingCurrency.Djf)]
    [InlineData(BillingCurrency.Gnf)]
    [InlineData(BillingCurrency.Ugx)]
    [InlineData(BillingCurrency.Pyg)]
    [InlineData(BillingCurrency.Xof)]
    [InlineData(BillingCurrency.Xpf)]
    public void Validation_Works(BillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillingCurrency.Usd)]
    [InlineData(BillingCurrency.Aed)]
    [InlineData(BillingCurrency.All)]
    [InlineData(BillingCurrency.Amd)]
    [InlineData(BillingCurrency.Ang)]
    [InlineData(BillingCurrency.Aud)]
    [InlineData(BillingCurrency.Awg)]
    [InlineData(BillingCurrency.Azn)]
    [InlineData(BillingCurrency.Bam)]
    [InlineData(BillingCurrency.Bbd)]
    [InlineData(BillingCurrency.Bdt)]
    [InlineData(BillingCurrency.Bgn)]
    [InlineData(BillingCurrency.Bif)]
    [InlineData(BillingCurrency.Bmd)]
    [InlineData(BillingCurrency.Bnd)]
    [InlineData(BillingCurrency.Bsd)]
    [InlineData(BillingCurrency.Bwp)]
    [InlineData(BillingCurrency.Byn)]
    [InlineData(BillingCurrency.Bzd)]
    [InlineData(BillingCurrency.Brl)]
    [InlineData(BillingCurrency.Cad)]
    [InlineData(BillingCurrency.Cdf)]
    [InlineData(BillingCurrency.Chf)]
    [InlineData(BillingCurrency.Cny)]
    [InlineData(BillingCurrency.Czk)]
    [InlineData(BillingCurrency.Dkk)]
    [InlineData(BillingCurrency.Dop)]
    [InlineData(BillingCurrency.Dzd)]
    [InlineData(BillingCurrency.Egp)]
    [InlineData(BillingCurrency.Etb)]
    [InlineData(BillingCurrency.Eur)]
    [InlineData(BillingCurrency.Fjd)]
    [InlineData(BillingCurrency.Gbp)]
    [InlineData(BillingCurrency.Gel)]
    [InlineData(BillingCurrency.Gip)]
    [InlineData(BillingCurrency.Gmd)]
    [InlineData(BillingCurrency.Gyd)]
    [InlineData(BillingCurrency.Hkd)]
    [InlineData(BillingCurrency.Hrk)]
    [InlineData(BillingCurrency.Htg)]
    [InlineData(BillingCurrency.Idr)]
    [InlineData(BillingCurrency.Ils)]
    [InlineData(BillingCurrency.Inr)]
    [InlineData(BillingCurrency.Isk)]
    [InlineData(BillingCurrency.Jmd)]
    [InlineData(BillingCurrency.Jpy)]
    [InlineData(BillingCurrency.Kes)]
    [InlineData(BillingCurrency.Kgs)]
    [InlineData(BillingCurrency.Khr)]
    [InlineData(BillingCurrency.Kmf)]
    [InlineData(BillingCurrency.Krw)]
    [InlineData(BillingCurrency.Kyd)]
    [InlineData(BillingCurrency.Kzt)]
    [InlineData(BillingCurrency.Lbp)]
    [InlineData(BillingCurrency.Lkr)]
    [InlineData(BillingCurrency.Lrd)]
    [InlineData(BillingCurrency.Lsl)]
    [InlineData(BillingCurrency.Mad)]
    [InlineData(BillingCurrency.Mdl)]
    [InlineData(BillingCurrency.Mga)]
    [InlineData(BillingCurrency.Mkd)]
    [InlineData(BillingCurrency.Mmk)]
    [InlineData(BillingCurrency.Mnt)]
    [InlineData(BillingCurrency.Mop)]
    [InlineData(BillingCurrency.Mro)]
    [InlineData(BillingCurrency.Mvr)]
    [InlineData(BillingCurrency.Mwk)]
    [InlineData(BillingCurrency.Mxn)]
    [InlineData(BillingCurrency.Myr)]
    [InlineData(BillingCurrency.Mzn)]
    [InlineData(BillingCurrency.Nad)]
    [InlineData(BillingCurrency.Ngn)]
    [InlineData(BillingCurrency.Nok)]
    [InlineData(BillingCurrency.Npr)]
    [InlineData(BillingCurrency.Nzd)]
    [InlineData(BillingCurrency.Pgk)]
    [InlineData(BillingCurrency.Php)]
    [InlineData(BillingCurrency.Pkr)]
    [InlineData(BillingCurrency.Pln)]
    [InlineData(BillingCurrency.Qar)]
    [InlineData(BillingCurrency.Ron)]
    [InlineData(BillingCurrency.Rsd)]
    [InlineData(BillingCurrency.Rub)]
    [InlineData(BillingCurrency.Rwf)]
    [InlineData(BillingCurrency.Sar)]
    [InlineData(BillingCurrency.Sbd)]
    [InlineData(BillingCurrency.Scr)]
    [InlineData(BillingCurrency.Sek)]
    [InlineData(BillingCurrency.Sgd)]
    [InlineData(BillingCurrency.Sle)]
    [InlineData(BillingCurrency.Sll)]
    [InlineData(BillingCurrency.Sos)]
    [InlineData(BillingCurrency.Szl)]
    [InlineData(BillingCurrency.Thb)]
    [InlineData(BillingCurrency.Tjs)]
    [InlineData(BillingCurrency.Top)]
    [InlineData(BillingCurrency.Try)]
    [InlineData(BillingCurrency.Ttd)]
    [InlineData(BillingCurrency.Tzs)]
    [InlineData(BillingCurrency.Uah)]
    [InlineData(BillingCurrency.Uzs)]
    [InlineData(BillingCurrency.Vnd)]
    [InlineData(BillingCurrency.Vuv)]
    [InlineData(BillingCurrency.Wst)]
    [InlineData(BillingCurrency.Xaf)]
    [InlineData(BillingCurrency.Xcd)]
    [InlineData(BillingCurrency.Yer)]
    [InlineData(BillingCurrency.Zar)]
    [InlineData(BillingCurrency.Zmw)]
    [InlineData(BillingCurrency.Clp)]
    [InlineData(BillingCurrency.Djf)]
    [InlineData(BillingCurrency.Gnf)]
    [InlineData(BillingCurrency.Ugx)]
    [InlineData(BillingCurrency.Pyg)]
    [InlineData(BillingCurrency.Xof)]
    [InlineData(BillingCurrency.Xpf)]
    public void SerializationRoundtrip_Works(BillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingCurrency>>(
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
        var model = new Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, VendorIdentifier> expectedVendorIdentifier = VendorIdentifier.Auth0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Integration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Integration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, VendorIdentifier> expectedVendorIdentifier = VendorIdentifier.Auth0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Integration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        Integration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class VendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(VendorIdentifier.Auth0)]
    [InlineData(VendorIdentifier.Zuora)]
    [InlineData(VendorIdentifier.Stripe)]
    [InlineData(VendorIdentifier.Hubspot)]
    [InlineData(VendorIdentifier.AwsMarketplace)]
    [InlineData(VendorIdentifier.Snowflake)]
    [InlineData(VendorIdentifier.Salesforce)]
    [InlineData(VendorIdentifier.BigQuery)]
    [InlineData(VendorIdentifier.OpenFga)]
    [InlineData(VendorIdentifier.AppStore)]
    public void Validation_Works(VendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VendorIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(VendorIdentifier.Auth0)]
    [InlineData(VendorIdentifier.Zuora)]
    [InlineData(VendorIdentifier.Stripe)]
    [InlineData(VendorIdentifier.Hubspot)]
    [InlineData(VendorIdentifier.AwsMarketplace)]
    [InlineData(VendorIdentifier.Snowflake)]
    [InlineData(VendorIdentifier.Salesforce)]
    [InlineData(VendorIdentifier.BigQuery)]
    [InlineData(VendorIdentifier.OpenFga)]
    [InlineData(VendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(VendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, VendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VendorIdentifier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, VendorIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, VendorIdentifier>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
