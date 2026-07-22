using System;
using System.Collections.Generic;
using System.Net.Http;
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
            CouponID = Customers::CustomerProvisionParamsCouponID.Undefined,
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
                    Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        string expectedID = "id";
        ApiEnum<string, Customers::CustomerProvisionParamsBillingCurrency> expectedBillingCurrency =
            Customers::CustomerProvisionParamsBillingCurrency.Usd;
        string expectedBillingID = "billingId";
        ApiEnum<string, Customers::CustomerProvisionParamsCouponID> expectedCouponID =
            Customers::CustomerProvisionParamsCouponID.Undefined;
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
        string expectedLanguage = "language";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        Customers::CustomerProvisionParamsPassthrough expectedPassthrough = new()
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
                Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
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
        Assert.Equal(expectedDefaultPaymentMethod, parameters.DefaultPaymentMethod);
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
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            BillingCurrency = Customers::CustomerProvisionParamsBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = Customers::CustomerProvisionParamsCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
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
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            BillingCurrency = Customers::CustomerProvisionParamsBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = Customers::CustomerProvisionParamsCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = Customers::Type.Card,
            },
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
                    Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
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
        Assert.Null(parameters.DefaultPaymentMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultPaymentMethod"));
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
                    Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",

            BillingCurrency = null,
            BillingID = null,
            CouponID = null,
            DefaultPaymentMethod = null,
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
        Assert.Null(parameters.DefaultPaymentMethod);
        Assert.True(parameters.RawBodyData.ContainsKey("defaultPaymentMethod"));
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
        Customers::CustomerProvisionParams parameters = new() { ID = "id" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://edge.api.stigg.io/api/v1/customers"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        Customers::CustomerProvisionParams parameters = new()
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
        var parameters = new Customers::CustomerProvisionParams
        {
            ID = "id",
            BillingCurrency = Customers::CustomerProvisionParamsBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = Customers::CustomerProvisionParamsCouponID.Undefined,
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
                    Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
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

public class CustomerProvisionParamsCouponIDTest : TestBase
{
    [Theory]
    [InlineData(Customers::CustomerProvisionParamsCouponID.Undefined)]
    public void Validation_Works(Customers::CustomerProvisionParamsCouponID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::CustomerProvisionParamsCouponID> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsCouponID>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Customers::CustomerProvisionParamsCouponID.Undefined)]
    public void SerializationRoundtrip_Works(Customers::CustomerProvisionParamsCouponID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::CustomerProvisionParamsCouponID> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsCouponID>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsCouponID>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsCouponID>
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
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Received)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Prequel)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Airwallex)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.StripeInvoicing)]
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
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Received)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Prequel)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.Airwallex)]
    [InlineData(Customers::CustomerProvisionParamsIntegrationVendorIdentifier.StripeInvoicing)]
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

public class CustomerProvisionParamsPassthroughTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthrough
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
                Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        Customers::CustomerProvisionParamsPassthroughStripe expectedStripe = new()
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
        Customers::CustomerProvisionParamsPassthroughZuora expectedZuora = new()
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
            Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, model.Stripe);
        Assert.Equal(expectedZuora, model.Zuora);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthrough
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
                Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthrough>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthrough
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
                Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthrough>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Customers::CustomerProvisionParamsPassthroughStripe expectedStripe = new()
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
        Customers::CustomerProvisionParamsPassthroughZuora expectedZuora = new()
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
            Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, deserialized.Stripe);
        Assert.Equal(expectedZuora, deserialized.Zuora);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthrough
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
                Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthrough { };

        Assert.Null(model.Stripe);
        Assert.False(model.RawData.ContainsKey("stripe"));
        Assert.Null(model.Zuora);
        Assert.False(model.RawData.ContainsKey("zuora"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthrough { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthrough
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
        var model = new Customers::CustomerProvisionParamsPassthrough
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
        var model = new Customers::CustomerProvisionParamsPassthrough
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
                Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        Customers::CustomerProvisionParamsPassthrough copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerProvisionParamsPassthroughStripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripe
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

        Customers::CustomerProvisionParamsPassthroughStripeBillingAddress expectedBillingAddress =
            new()
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
        Customers::CustomerProvisionParamsPassthroughStripeShippingAddress expectedShippingAddress =
            new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            };
        List<Customers::CustomerProvisionParamsPassthroughStripeTaxID> expectedTaxIds =
        [
            new() { Type = "type", Value = "value" },
        ];

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
        var model = new Customers::CustomerProvisionParamsPassthroughStripe
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
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughStripe>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripe
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
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughStripe>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Customers::CustomerProvisionParamsPassthroughStripeBillingAddress expectedBillingAddress =
            new()
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
        Customers::CustomerProvisionParamsPassthroughStripeShippingAddress expectedShippingAddress =
            new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            };
        List<Customers::CustomerProvisionParamsPassthroughStripeTaxID> expectedTaxIds =
        [
            new() { Type = "type", Value = "value" },
        ];

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
        var model = new Customers::CustomerProvisionParamsPassthroughStripe
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripe { };

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
        var model = new Customers::CustomerProvisionParamsPassthroughStripe { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripe
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripe
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripe
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

        Customers::CustomerProvisionParamsPassthroughStripe copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerProvisionParamsPassthroughStripeBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughStripeBillingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughStripeBillingAddress>(
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress { };

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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        Customers::CustomerProvisionParamsPassthroughStripeBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerProvisionParamsPassthroughStripeShippingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughStripeShippingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughStripeShippingAddress>(
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress { };

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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughStripeShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        Customers::CustomerProvisionParamsPassthroughStripeShippingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerProvisionParamsPassthroughStripeTaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughStripeTaxID>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughStripeTaxID>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedValue, deserialized.Value);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        Customers::CustomerProvisionParamsPassthroughStripeTaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerProvisionParamsPassthroughZuoraTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughZuora
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
            Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress expectedBillingAddress =
            new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            };
        ApiEnum<
            string,
            Customers::CustomerProvisionParamsPassthroughZuoraCurrency
        > expectedCurrency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd;
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuora
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
            Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughZuora>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughZuora
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
            Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughZuora>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress expectedBillingAddress =
            new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            };
        ApiEnum<
            string,
            Customers::CustomerProvisionParamsPassthroughZuoraCurrency
        > expectedCurrency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd;
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuora
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
            Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughZuora { };

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
        var model = new Customers::CustomerProvisionParamsPassthroughZuora { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughZuora
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuora
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuora
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
            Currency = Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Customers::CustomerProvisionParamsPassthroughZuora copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerProvisionParamsPassthroughZuoraBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress>(
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress { };

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
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress
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
        var model = new Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        Customers::CustomerProvisionParamsPassthroughZuoraBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerProvisionParamsPassthroughZuoraCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Aed)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.All)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Amd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ang)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Aud)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Awg)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Azn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bam)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bbd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bdt)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bgn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bif)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bmd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bnd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bsd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bwp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Byn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bzd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Brl)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Cad)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Cdf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Chf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Cny)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Czk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Dkk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Dop)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Dzd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Egp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Etb)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Eur)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Fjd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gbp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gel)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gip)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gmd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gyd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Hkd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Hrk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Htg)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Idr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ils)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Inr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Isk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Jmd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Jpy)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kes)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kgs)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Khr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kmf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Krw)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kyd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kzt)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Lbp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Lkr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Lrd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Lsl)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mad)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mdl)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mga)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mkd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mmk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mnt)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mop)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mro)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mvr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mwk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mxn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Myr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mzn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Nad)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ngn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Nok)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Npr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Nzd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Pgk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Php)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Pkr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Pln)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Qar)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ron)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Rsd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Rub)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Rwf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sar)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sbd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Scr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sek)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sgd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sle)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sll)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sos)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Szl)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Thb)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Tjs)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Top)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Try)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ttd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Tzs)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Uah)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Uzs)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Vnd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Vuv)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Wst)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Xaf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Xcd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Yer)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Zar)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Zmw)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Clp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Djf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gnf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ugx)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Pyg)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Xof)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Xpf)]
    public void Validation_Works(
        Customers::CustomerProvisionParamsPassthroughZuoraCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::CustomerProvisionParamsPassthroughZuoraCurrency> value =
            rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsPassthroughZuoraCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Usd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Aed)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.All)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Amd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ang)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Aud)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Awg)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Azn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bam)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bbd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bdt)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bgn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bif)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bmd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bnd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bsd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bwp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Byn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Bzd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Brl)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Cad)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Cdf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Chf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Cny)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Czk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Dkk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Dop)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Dzd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Egp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Etb)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Eur)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Fjd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gbp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gel)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gip)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gmd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gyd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Hkd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Hrk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Htg)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Idr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ils)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Inr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Isk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Jmd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Jpy)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kes)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kgs)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Khr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kmf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Krw)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kyd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Kzt)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Lbp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Lkr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Lrd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Lsl)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mad)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mdl)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mga)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mkd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mmk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mnt)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mop)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mro)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mvr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mwk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mxn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Myr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Mzn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Nad)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ngn)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Nok)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Npr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Nzd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Pgk)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Php)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Pkr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Pln)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Qar)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ron)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Rsd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Rub)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Rwf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sar)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sbd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Scr)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sek)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sgd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sle)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sll)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Sos)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Szl)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Thb)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Tjs)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Top)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Try)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ttd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Tzs)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Uah)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Uzs)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Vnd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Vuv)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Wst)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Xaf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Xcd)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Yer)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Zar)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Zmw)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Clp)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Djf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Gnf)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Ugx)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Pyg)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Xof)]
    [InlineData(Customers::CustomerProvisionParamsPassthroughZuoraCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        Customers::CustomerProvisionParamsPassthroughZuoraCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Customers::CustomerProvisionParamsPassthroughZuoraCurrency> value =
            rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsPassthroughZuoraCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsPassthroughZuoraCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Customers::CustomerProvisionParamsPassthroughZuoraCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
