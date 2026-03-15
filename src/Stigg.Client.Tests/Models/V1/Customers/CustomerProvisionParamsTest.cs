using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Customers = Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerProvisionParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            BillingCurrency = Customers::CustomerProvisionParamsBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier =
                        Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        string expectedID = "id";
        ApiEnum<string, Customers::CustomerProvisionParamsBillingCurrency> expectedBillingCurrency =
            Customers::CustomerProvisionParamsBillingCurrency.Usd;
        string expectedBillingID = "billingId";
        string expectedCouponID = "couponId";
        Customers::DefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = Customers::Type.Card,
        };
        string expectedEmail = "dev@stainless.com";
        List<Customers::CustomerProvisionParamsIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier =
                    Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBillingCurrency, parameters.BillingCurrency);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.Equal(expectedCouponID, parameters.CouponID);
        Assert.Equal(expectedDefaultPaymentMethod, parameters.DefaultPaymentMethod);
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
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            BillingCurrency = Customers::CustomerProvisionParamsBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
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
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            BillingCurrency = Customers::CustomerProvisionParamsBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
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
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier =
                        Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
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
        Assert.Null(parameters.DefaultPaymentMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultPaymentMethod"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier =
                        Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            BillingCurrency = null,
            BillingID = null,
            CouponID = null,
            DefaultPaymentMethod = null,
            Email = null,
            Name = null,
        };

        Assert.Null(parameters.BillingCurrency);
        Assert.True(parameters.RawBodyData.ContainsKey("billingCurrency"));
        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CouponID);
        Assert.True(parameters.RawBodyData.ContainsKey("couponId"));
        Assert.Null(parameters.DefaultPaymentMethod);
        Assert.True(parameters.RawBodyData.ContainsKey("defaultPaymentMethod"));
        Assert.Null(parameters.Email);
        Assert.True(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
    }

    [Fact]
    public void Url_Works()
    {
        Customers::CustomerProvisionParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/customers"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            BillingCurrency = Customers::CustomerProvisionParamsBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier =
                        Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
        };

        Customers::CustomerProvisionParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CustomerProvisionParamsBillingCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Usd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Aed)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.All)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Amd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ang)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Aud)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Awg)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Azn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bam)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bbd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bdt)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bgn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bif)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bmd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bnd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bsd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bwp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Byn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bzd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Brl)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Cad)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Cdf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Chf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Cny)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Czk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Dkk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Dop)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Dzd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Egp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Etb)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Eur)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Fjd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gbp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gel)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gip)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gmd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gyd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Hkd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Hrk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Htg)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Idr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ils)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Inr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Isk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Jmd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Jpy)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kes)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kgs)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Khr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kmf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Krw)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kyd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kzt)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Lbp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Lkr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Lrd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Lsl)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mad)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mdl)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mga)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mkd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mmk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mnt)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mop)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mro)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mvr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mwk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mxn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Myr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mzn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Nad)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ngn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Nok)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Npr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Nzd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Pgk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Php)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Pkr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Pln)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Qar)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ron)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Rsd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Rub)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Rwf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sar)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sbd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Scr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sek)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sgd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sle)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sll)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sos)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Szl)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Thb)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Tjs)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Top)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Try)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ttd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Tzs)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Uah)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Uzs)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Vnd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Vuv)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Wst)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Xaf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Xcd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Yer)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Zar)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Zmw)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Clp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Djf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gnf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ugx)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Pyg)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Xof)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Xpf)]
    public void Validation_Works(Customers::CustomerProvisionParamsBillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::CustomerProvisionParamsBillingCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsBillingCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Usd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Aed)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.All)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Amd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ang)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Aud)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Awg)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Azn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bam)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bbd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bdt)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bgn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bif)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bmd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bnd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bsd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bwp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Byn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Bzd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Brl)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Cad)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Cdf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Chf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Cny)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Czk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Dkk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Dop)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Dzd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Egp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Etb)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Eur)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Fjd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gbp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gel)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gip)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gmd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gyd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Hkd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Hrk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Htg)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Idr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ils)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Inr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Isk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Jmd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Jpy)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kes)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kgs)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Khr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kmf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Krw)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kyd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Kzt)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Lbp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Lkr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Lrd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Lsl)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mad)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mdl)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mga)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mkd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mmk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mnt)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mop)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mro)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mvr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mwk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mxn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Myr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Mzn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Nad)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ngn)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Nok)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Npr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Nzd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Pgk)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Php)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Pkr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Pln)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Qar)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ron)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Rsd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Rub)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Rwf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sar)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sbd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Scr)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sek)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sgd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sle)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sll)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Sos)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Szl)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Thb)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Tjs)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Top)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Try)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ttd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Tzs)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Uah)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Uzs)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Vnd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Vuv)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Wst)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Xaf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Xcd)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Yer)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Zar)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Zmw)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Clp)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Djf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Gnf)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Ugx)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Pyg)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Xof)]
    [InlineData(Customers::CustomerProvisionParamsBillingCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        Customers::CustomerProvisionParamsBillingCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::CustomerProvisionParamsBillingCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsBillingCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsBillingCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsBillingCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
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

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Customers::DefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = Customers::Type.Card,
        };

        Customers::DefaultPaymentMethod copied = new(model);

        Assert.Equal(model, copied);
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

public class CustomerProvisionParamsIntegrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<
            string,
            Customers::CustomerProvisionParamsIntegrationVendorIdentifier
        > expectedVendorIdentifier =
            Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsIntegration>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::CustomerProvisionParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsIntegration>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<
            string,
            Customers::CustomerProvisionParamsIntegrationVendorIdentifier
        > expectedVendorIdentifier =
            Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Customers::CustomerProvisionParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Customers::CustomerProvisionParamsIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0,
        };

        Customers::CustomerProvisionParamsIntegration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerProvisionParamsIntegrationVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Zuora)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Stripe)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Hubspot)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Snowflake)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Salesforce)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.BigQuery)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.OpenFga)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.AppStore)]
    public void Validation_Works(
        Customers::CustomerProvisionParamsIntegrationVendorIdentifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::CustomerProvisionParamsIntegrationVendorIdentifier> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Auth0)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Zuora)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Stripe)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Hubspot)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Snowflake)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Salesforce)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.BigQuery)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.OpenFga)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(
        Customers::CustomerProvisionParamsIntegrationVendorIdentifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::CustomerProvisionParamsIntegrationVendorIdentifier> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
