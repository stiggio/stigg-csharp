using System;
using System.Collections.Generic;
using System.Net.Http;
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
            CouponID = CouponID.Undefined,
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
            Language = "language",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Passthrough = new()
            {
                Stripe = new()
                {
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    CustomerName = "customerName",
                    InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    ShippingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    TaxIds = [new() { Type = "type", Value = "value" }],
                },
                Zuora = new()
                {
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    Currency = Currency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "x";
        ApiEnum<string, BillingCurrency> expectedBillingCurrency = BillingCurrency.Usd;
        string expectedBillingID = "billingId";
        ApiEnum<string, CouponID> expectedCouponID = CouponID.Undefined;
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
        string expectedLanguage = "language";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        Passthrough expectedPassthrough = new()
        {
            Stripe = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                CustomerName = "customerName",
                InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
                ShippingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                TaxIds = [new() { Type = "type", Value = "value" }],
            },
            Zuora = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                Currency = Currency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };
        string expectedTimezone = "timezone";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

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
        Assert.Equal(expectedLanguage, parameters.Language);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPassthrough, parameters.Passthrough);
        Assert.Equal(expectedTimezone, parameters.Timezone);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            BillingCurrency = BillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CouponID.Undefined,
            Email = "dev@stainless.com",
            Language = "language",
            Name = "name",
            Timezone = "timezone",
        };

        Assert.Null(parameters.Integrations);
        Assert.False(parameters.RawBodyData.ContainsKey("integrations"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Passthrough);
        Assert.False(parameters.RawBodyData.ContainsKey("passthrough"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            BillingCurrency = BillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CouponID.Undefined,
            Email = "dev@stainless.com",
            Language = "language",
            Name = "name",
            Timezone = "timezone",

            // Null should be interpreted as omitted for these properties
            Integrations = null,
            Metadata = null,
            Passthrough = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.Integrations);
        Assert.False(parameters.RawBodyData.ContainsKey("integrations"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Passthrough);
        Assert.False(parameters.RawBodyData.ContainsKey("passthrough"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
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
            Passthrough = new()
            {
                Stripe = new()
                {
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    CustomerName = "customerName",
                    InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    ShippingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    TaxIds = [new() { Type = "type", Value = "value" }],
                },
                Zuora = new()
                {
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    Currency = Currency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        Assert.Null(parameters.BillingCurrency);
        Assert.False(parameters.RawBodyData.ContainsKey("billingCurrency"));
        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CouponID);
        Assert.False(parameters.RawBodyData.ContainsKey("couponId"));
        Assert.Null(parameters.Email);
        Assert.False(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Language);
        Assert.False(parameters.RawBodyData.ContainsKey("language"));
        Assert.Null(parameters.Name);
        Assert.False(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Timezone);
        Assert.False(parameters.RawBodyData.ContainsKey("timezone"));
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
            Passthrough = new()
            {
                Stripe = new()
                {
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    CustomerName = "customerName",
                    InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    ShippingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    TaxIds = [new() { Type = "type", Value = "value" }],
                },
                Zuora = new()
                {
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    Currency = Currency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            BillingCurrency = null,
            BillingID = null,
            CouponID = null,
            Email = null,
            Language = null,
            Name = null,
            Timezone = null,
        };

        Assert.Null(parameters.BillingCurrency);
        Assert.True(parameters.RawBodyData.ContainsKey("billingCurrency"));
        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CouponID);
        Assert.True(parameters.RawBodyData.ContainsKey("couponId"));
        Assert.Null(parameters.Email);
        Assert.True(parameters.RawBodyData.ContainsKey("email"));
        Assert.Null(parameters.Language);
        Assert.True(parameters.RawBodyData.ContainsKey("language"));
        Assert.Null(parameters.Name);
        Assert.True(parameters.RawBodyData.ContainsKey("name"));
        Assert.Null(parameters.Timezone);
        Assert.True(parameters.RawBodyData.ContainsKey("timezone"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerUpdateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://edge.api.stigg.io/api/v1/customers/x"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomerUpdateParams parameters = new()
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
        var parameters = new CustomerUpdateParams
        {
            ID = "x",
            BillingCurrency = BillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CouponID.Undefined,
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
            Language = "language",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            Passthrough = new()
            {
                Stripe = new()
                {
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    CustomerName = "customerName",
                    InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    ShippingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    TaxIds = [new() { Type = "type", Value = "value" }],
                },
                Zuora = new()
                {
                    BillingAddress = new()
                    {
                        City = "city",
                        Country = "country",
                        Line1 = "line1",
                        Line2 = "line2",
                        PostalCode = "postalCode",
                        State = "state",
                    },
                    Currency = Currency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
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

public class CouponIDTest : TestBase
{
    [Theory]
    [InlineData(CouponID.Undefined)]
    public void Validation_Works(CouponID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponID> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponID>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponID.Undefined)]
    public void SerializationRoundtrip_Works(CouponID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponID> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponID>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponID>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponID>>(
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
    [InlineData(VendorIdentifier.Received)]
    [InlineData(VendorIdentifier.Prequel)]
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
    [InlineData(VendorIdentifier.Received)]
    [InlineData(VendorIdentifier.Prequel)]
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

public class PassthroughTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Passthrough
        {
            Stripe = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                CustomerName = "customerName",
                InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
                ShippingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                TaxIds = [new() { Type = "type", Value = "value" }],
            },
            Zuora = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                Currency = Currency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        Stripe expectedStripe = new()
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            CustomerName = "customerName",
            InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            TaxIds = [new() { Type = "type", Value = "value" }],
        };
        Zuora expectedZuora = new()
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            Currency = Currency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, model.Stripe);
        Assert.Equal(expectedZuora, model.Zuora);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Passthrough
        {
            Stripe = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                CustomerName = "customerName",
                InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
                ShippingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                TaxIds = [new() { Type = "type", Value = "value" }],
            },
            Zuora = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                Currency = Currency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Passthrough>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Passthrough
        {
            Stripe = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                CustomerName = "customerName",
                InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
                ShippingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                TaxIds = [new() { Type = "type", Value = "value" }],
            },
            Zuora = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                Currency = Currency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Passthrough>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Stripe expectedStripe = new()
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            CustomerName = "customerName",
            InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            TaxIds = [new() { Type = "type", Value = "value" }],
        };
        Zuora expectedZuora = new()
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            Currency = Currency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, deserialized.Stripe);
        Assert.Equal(expectedZuora, deserialized.Zuora);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Passthrough
        {
            Stripe = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                CustomerName = "customerName",
                InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
                ShippingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                TaxIds = [new() { Type = "type", Value = "value" }],
            },
            Zuora = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                Currency = Currency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Passthrough { };

        Assert.Null(model.Stripe);
        Assert.False(model.RawData.ContainsKey("stripe"));
        Assert.Null(model.Zuora);
        Assert.False(model.RawData.ContainsKey("zuora"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Passthrough { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Passthrough
        {
            // Null should be interpreted as omitted for these properties
            Stripe = null,
            Zuora = null,
        };

        Assert.Null(model.Stripe);
        Assert.False(model.RawData.ContainsKey("stripe"));
        Assert.Null(model.Zuora);
        Assert.False(model.RawData.ContainsKey("zuora"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Passthrough
        {
            // Null should be interpreted as omitted for these properties
            Stripe = null,
            Zuora = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Passthrough
        {
            Stripe = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                CustomerName = "customerName",
                InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
                ShippingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                TaxIds = [new() { Type = "type", Value = "value" }],
            },
            Zuora = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                Currency = Currency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        Passthrough copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Stripe
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            CustomerName = "customerName",
            InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            TaxIds = [new() { Type = "type", Value = "value" }],
        };

        BillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        string expectedCustomerName = "customerName";
        Dictionary<string, string> expectedInvoiceCustomFields = new() { { "foo", "string" } };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentMethodID = "paymentMethodId";
        ShippingAddress expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        List<TaxID> expectedTaxIds = [new() { Type = "type", Value = "value" }];

        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedCustomerName, model.CustomerName);
        Assert.NotNull(model.InvoiceCustomFields);
        Assert.Equal(expectedInvoiceCustomFields.Count, model.InvoiceCustomFields.Count);
        foreach (var item in expectedInvoiceCustomFields)
        {
            Assert.True(model.InvoiceCustomFields.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.InvoiceCustomFields[item.Key]);
        }
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedShippingAddress, model.ShippingAddress);
        Assert.NotNull(model.TaxIds);
        Assert.Equal(expectedTaxIds.Count, model.TaxIds.Count);
        for (int i = 0; i < expectedTaxIds.Count; i++)
        {
            Assert.Equal(expectedTaxIds[i], model.TaxIds[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Stripe
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            CustomerName = "customerName",
            InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            TaxIds = [new() { Type = "type", Value = "value" }],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stripe>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Stripe
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            CustomerName = "customerName",
            InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            TaxIds = [new() { Type = "type", Value = "value" }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Stripe>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        BillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        string expectedCustomerName = "customerName";
        Dictionary<string, string> expectedInvoiceCustomFields = new() { { "foo", "string" } };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentMethodID = "paymentMethodId";
        ShippingAddress expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        List<TaxID> expectedTaxIds = [new() { Type = "type", Value = "value" }];

        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedCustomerName, deserialized.CustomerName);
        Assert.NotNull(deserialized.InvoiceCustomFields);
        Assert.Equal(expectedInvoiceCustomFields.Count, deserialized.InvoiceCustomFields.Count);
        foreach (var item in expectedInvoiceCustomFields)
        {
            Assert.True(deserialized.InvoiceCustomFields.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.InvoiceCustomFields[item.Key]);
        }
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedShippingAddress, deserialized.ShippingAddress);
        Assert.NotNull(deserialized.TaxIds);
        Assert.Equal(expectedTaxIds.Count, deserialized.TaxIds.Count);
        for (int i = 0; i < expectedTaxIds.Count; i++)
        {
            Assert.Equal(expectedTaxIds[i], deserialized.TaxIds[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Stripe
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            CustomerName = "customerName",
            InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            TaxIds = [new() { Type = "type", Value = "value" }],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Stripe { };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.CustomerName);
        Assert.False(model.RawData.ContainsKey("customerName"));
        Assert.Null(model.InvoiceCustomFields);
        Assert.False(model.RawData.ContainsKey("invoiceCustomFields"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("paymentMethodId"));
        Assert.Null(model.ShippingAddress);
        Assert.False(model.RawData.ContainsKey("shippingAddress"));
        Assert.Null(model.TaxIds);
        Assert.False(model.RawData.ContainsKey("taxIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Stripe { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Stripe
        {
            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            CustomerName = null,
            InvoiceCustomFields = null,
            Metadata = null,
            PaymentMethodID = null,
            ShippingAddress = null,
            TaxIds = null,
        };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.CustomerName);
        Assert.False(model.RawData.ContainsKey("customerName"));
        Assert.Null(model.InvoiceCustomFields);
        Assert.False(model.RawData.ContainsKey("invoiceCustomFields"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("paymentMethodId"));
        Assert.Null(model.ShippingAddress);
        Assert.False(model.RawData.ContainsKey("shippingAddress"));
        Assert.Null(model.TaxIds);
        Assert.False(model.RawData.ContainsKey("taxIds"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Stripe
        {
            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            CustomerName = null,
            InvoiceCustomFields = null,
            Metadata = null,
            PaymentMethodID = null,
            ShippingAddress = null,
            TaxIds = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Stripe
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            CustomerName = "customerName",
            InvoiceCustomFields = new Dictionary<string, string>() { { "foo", "string" } },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            ShippingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            TaxIds = [new() { Type = "type", Value = "value" }],
        };

        Stripe copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingAddress { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BillingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        BillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ShippingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShippingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ShippingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ShippingAddress { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ShippingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ShippingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ShippingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        ShippingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new TaxID { Type = "type", Value = "value" };

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new TaxID { Type = "type", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxID>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new TaxID { Type = "type", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<TaxID>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new TaxID { Type = "type", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new TaxID { Type = "type", Value = "value" };

        TaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ZuoraTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Zuora
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            Currency = Currency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        ZuoraBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentMethodID = "paymentMethodId";

        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Zuora
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            Currency = Currency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Zuora>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Zuora
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            Currency = Currency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Zuora>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        ZuoraBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentMethodID = "paymentMethodId";

        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Zuora
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            Currency = Currency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Zuora { };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("paymentMethodId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Zuora { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Zuora
        {
            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            Currency = null,
            Metadata = null,
            PaymentMethodID = null,
        };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("paymentMethodId"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Zuora
        {
            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            Currency = null,
            Metadata = null,
            PaymentMethodID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Zuora
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            Currency = Currency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Zuora copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ZuoraBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ZuoraBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ZuoraBillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ZuoraBillingAddress { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new ZuoraBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new ZuoraBillingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new ZuoraBillingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        ZuoraBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Ang)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Cdf)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Hrk)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Isk)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mro)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sll)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Tjs)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Xaf)]
    [InlineData(Currency.Xcd)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Zmw)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Xof)]
    [InlineData(Currency.Xpf)]
    public void Validation_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Ang)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Cdf)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Hrk)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Isk)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mro)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sll)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Tjs)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Xaf)]
    [InlineData(Currency.Xcd)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Zmw)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Xof)]
    [InlineData(Currency.Xpf)]
    public void SerializationRoundtrip_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
