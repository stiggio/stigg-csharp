using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponse
        {
            Data = new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = CustomerResponseDataCouponID.Undefined,
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = CustomerResponseDataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                        InvoiceCustomFields = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
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
                        Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        PaymentMethodID = "paymentMethodId",
                    },
                },
                Timezone = "timezone",
            },
        };

        CustomerResponseData expectedData = new()
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerResponse
        {
            Data = new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = CustomerResponseDataCouponID.Undefined,
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = CustomerResponseDataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                        InvoiceCustomFields = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
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
                        Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        PaymentMethodID = "paymentMethodId",
                    },
                },
                Timezone = "timezone",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponse
        {
            Data = new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = CustomerResponseDataCouponID.Undefined,
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = CustomerResponseDataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                        InvoiceCustomFields = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
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
                        Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        PaymentMethodID = "paymentMethodId",
                    },
                },
                Timezone = "timezone",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerResponseData expectedData = new()
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerResponse
        {
            Data = new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = CustomerResponseDataCouponID.Undefined,
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = CustomerResponseDataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                        InvoiceCustomFields = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
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
                        Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        PaymentMethodID = "paymentMethodId",
                    },
                },
                Timezone = "timezone",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerResponse
        {
            Data = new()
            {
                ID = "id",
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = CustomerResponseDataCouponID.Undefined,
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = CustomerResponseDataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                        InvoiceCustomFields = new Dictionary<string, string>()
                        {
                            { "foo", "string" },
                        },
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
                        Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        PaymentMethodID = "paymentMethodId",
                    },
                },
                Timezone = "timezone",
            },
        };

        CustomerResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CustomerResponseDataBillingCurrency> expectedBillingCurrency =
            CustomerResponseDataBillingCurrency.Usd;
        string expectedBillingID = "billingId";
        ApiEnum<string, CustomerResponseDataCouponID> expectedCouponID =
            CustomerResponseDataCouponID.Undefined;
        CustomerResponseDataDefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerResponseDataDefaultPaymentMethodType.Card,
        };
        string expectedEmail = "dev@stainless.com";
        List<CustomerResponseDataIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
            },
        ];
        string expectedLanguage = "language";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        CustomerResponseDataPassthrough expectedPassthrough = new()
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
                Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };
        string expectedTimezone = "timezone";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedBillingCurrency, model.BillingCurrency);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCouponID, model.CouponID);
        Assert.Equal(expectedDefaultPaymentMethod, model.DefaultPaymentMethod);
        Assert.Equal(expectedEmail, model.Email);
        Assert.NotNull(model.Integrations);
        Assert.Equal(expectedIntegrations.Count, model.Integrations.Count);
        for (int i = 0; i < expectedIntegrations.Count; i++)
        {
            Assert.Equal(expectedIntegrations[i], model.Integrations[i]);
        }
        Assert.Equal(expectedLanguage, model.Language);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPassthrough, model.Passthrough);
        Assert.Equal(expectedTimezone, model.Timezone);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CustomerResponseDataBillingCurrency> expectedBillingCurrency =
            CustomerResponseDataBillingCurrency.Usd;
        string expectedBillingID = "billingId";
        ApiEnum<string, CustomerResponseDataCouponID> expectedCouponID =
            CustomerResponseDataCouponID.Undefined;
        CustomerResponseDataDefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerResponseDataDefaultPaymentMethodType.Card,
        };
        string expectedEmail = "dev@stainless.com";
        List<CustomerResponseDataIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
            },
        ];
        string expectedLanguage = "language";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        CustomerResponseDataPassthrough expectedPassthrough = new()
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
                Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };
        string expectedTimezone = "timezone";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedBillingCurrency, deserialized.BillingCurrency);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCouponID, deserialized.CouponID);
        Assert.Equal(expectedDefaultPaymentMethod, deserialized.DefaultPaymentMethod);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.NotNull(deserialized.Integrations);
        Assert.Equal(expectedIntegrations.Count, deserialized.Integrations.Count);
        for (int i = 0; i < expectedIntegrations.Count; i++)
        {
            Assert.Equal(expectedIntegrations[i], deserialized.Integrations[i]);
        }
        Assert.Equal(expectedLanguage, deserialized.Language);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPassthrough, deserialized.Passthrough);
        Assert.Equal(expectedTimezone, deserialized.Timezone);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Language = "language",
            Name = "name",
            Timezone = "timezone",
        };

        Assert.Null(model.Integrations);
        Assert.False(model.RawData.ContainsKey("integrations"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Passthrough);
        Assert.False(model.RawData.ContainsKey("passthrough"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Language = "language",
            Name = "name",
            Timezone = "timezone",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Language = "language",
            Name = "name",
            Timezone = "timezone",

            // Null should be interpreted as omitted for these properties
            Integrations = null,
            Metadata = null,
            Passthrough = null,
        };

        Assert.Null(model.Integrations);
        Assert.False(model.RawData.ContainsKey("integrations"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Passthrough);
        Assert.False(model.RawData.ContainsKey("passthrough"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Language = "language",
            Name = "name",
            Timezone = "timezone",

            // Null should be interpreted as omitted for these properties
            Integrations = null,
            Metadata = null,
            Passthrough = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
        };

        Assert.Null(model.BillingCurrency);
        Assert.False(model.RawData.ContainsKey("billingCurrency"));
        Assert.Null(model.BillingID);
        Assert.False(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.CouponID);
        Assert.False(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.DefaultPaymentMethod);
        Assert.False(model.RawData.ContainsKey("defaultPaymentMethod"));
        Assert.Null(model.Email);
        Assert.False(model.RawData.ContainsKey("email"));
        Assert.Null(model.Language);
        Assert.False(model.RawData.ContainsKey("language"));
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
        Assert.Null(model.Timezone);
        Assert.False(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },

            BillingCurrency = null,
            BillingID = null,
            CouponID = null,
            DefaultPaymentMethod = null,
            Email = null,
            Language = null,
            Name = null,
            Timezone = null,
        };

        Assert.Null(model.BillingCurrency);
        Assert.True(model.RawData.ContainsKey("billingCurrency"));
        Assert.Null(model.BillingID);
        Assert.True(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.CouponID);
        Assert.True(model.RawData.ContainsKey("couponId"));
        Assert.Null(model.DefaultPaymentMethod);
        Assert.True(model.RawData.ContainsKey("defaultPaymentMethod"));
        Assert.Null(model.Email);
        Assert.True(model.RawData.ContainsKey("email"));
        Assert.Null(model.Language);
        Assert.True(model.RawData.ContainsKey("language"));
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
        Assert.Null(model.Timezone);
        Assert.True(model.RawData.ContainsKey("timezone"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },

            BillingCurrency = null,
            BillingID = null,
            CouponID = null,
            DefaultPaymentMethod = null,
            Email = null,
            Language = null,
            Name = null,
            Timezone = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerResponseData
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerResponseDataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerResponseDataCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerResponseDataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        CustomerResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataBillingCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CustomerResponseDataBillingCurrency.Usd)]
    [InlineData(CustomerResponseDataBillingCurrency.Aed)]
    [InlineData(CustomerResponseDataBillingCurrency.All)]
    [InlineData(CustomerResponseDataBillingCurrency.Amd)]
    [InlineData(CustomerResponseDataBillingCurrency.Ang)]
    [InlineData(CustomerResponseDataBillingCurrency.Aud)]
    [InlineData(CustomerResponseDataBillingCurrency.Awg)]
    [InlineData(CustomerResponseDataBillingCurrency.Azn)]
    [InlineData(CustomerResponseDataBillingCurrency.Bam)]
    [InlineData(CustomerResponseDataBillingCurrency.Bbd)]
    [InlineData(CustomerResponseDataBillingCurrency.Bdt)]
    [InlineData(CustomerResponseDataBillingCurrency.Bgn)]
    [InlineData(CustomerResponseDataBillingCurrency.Bif)]
    [InlineData(CustomerResponseDataBillingCurrency.Bmd)]
    [InlineData(CustomerResponseDataBillingCurrency.Bnd)]
    [InlineData(CustomerResponseDataBillingCurrency.Bsd)]
    [InlineData(CustomerResponseDataBillingCurrency.Bwp)]
    [InlineData(CustomerResponseDataBillingCurrency.Byn)]
    [InlineData(CustomerResponseDataBillingCurrency.Bzd)]
    [InlineData(CustomerResponseDataBillingCurrency.Brl)]
    [InlineData(CustomerResponseDataBillingCurrency.Cad)]
    [InlineData(CustomerResponseDataBillingCurrency.Cdf)]
    [InlineData(CustomerResponseDataBillingCurrency.Chf)]
    [InlineData(CustomerResponseDataBillingCurrency.Cny)]
    [InlineData(CustomerResponseDataBillingCurrency.Czk)]
    [InlineData(CustomerResponseDataBillingCurrency.Dkk)]
    [InlineData(CustomerResponseDataBillingCurrency.Dop)]
    [InlineData(CustomerResponseDataBillingCurrency.Dzd)]
    [InlineData(CustomerResponseDataBillingCurrency.Egp)]
    [InlineData(CustomerResponseDataBillingCurrency.Etb)]
    [InlineData(CustomerResponseDataBillingCurrency.Eur)]
    [InlineData(CustomerResponseDataBillingCurrency.Fjd)]
    [InlineData(CustomerResponseDataBillingCurrency.Gbp)]
    [InlineData(CustomerResponseDataBillingCurrency.Gel)]
    [InlineData(CustomerResponseDataBillingCurrency.Gip)]
    [InlineData(CustomerResponseDataBillingCurrency.Gmd)]
    [InlineData(CustomerResponseDataBillingCurrency.Gyd)]
    [InlineData(CustomerResponseDataBillingCurrency.Hkd)]
    [InlineData(CustomerResponseDataBillingCurrency.Hrk)]
    [InlineData(CustomerResponseDataBillingCurrency.Htg)]
    [InlineData(CustomerResponseDataBillingCurrency.Idr)]
    [InlineData(CustomerResponseDataBillingCurrency.Ils)]
    [InlineData(CustomerResponseDataBillingCurrency.Inr)]
    [InlineData(CustomerResponseDataBillingCurrency.Isk)]
    [InlineData(CustomerResponseDataBillingCurrency.Jmd)]
    [InlineData(CustomerResponseDataBillingCurrency.Jpy)]
    [InlineData(CustomerResponseDataBillingCurrency.Kes)]
    [InlineData(CustomerResponseDataBillingCurrency.Kgs)]
    [InlineData(CustomerResponseDataBillingCurrency.Khr)]
    [InlineData(CustomerResponseDataBillingCurrency.Kmf)]
    [InlineData(CustomerResponseDataBillingCurrency.Krw)]
    [InlineData(CustomerResponseDataBillingCurrency.Kyd)]
    [InlineData(CustomerResponseDataBillingCurrency.Kzt)]
    [InlineData(CustomerResponseDataBillingCurrency.Lbp)]
    [InlineData(CustomerResponseDataBillingCurrency.Lkr)]
    [InlineData(CustomerResponseDataBillingCurrency.Lrd)]
    [InlineData(CustomerResponseDataBillingCurrency.Lsl)]
    [InlineData(CustomerResponseDataBillingCurrency.Mad)]
    [InlineData(CustomerResponseDataBillingCurrency.Mdl)]
    [InlineData(CustomerResponseDataBillingCurrency.Mga)]
    [InlineData(CustomerResponseDataBillingCurrency.Mkd)]
    [InlineData(CustomerResponseDataBillingCurrency.Mmk)]
    [InlineData(CustomerResponseDataBillingCurrency.Mnt)]
    [InlineData(CustomerResponseDataBillingCurrency.Mop)]
    [InlineData(CustomerResponseDataBillingCurrency.Mro)]
    [InlineData(CustomerResponseDataBillingCurrency.Mvr)]
    [InlineData(CustomerResponseDataBillingCurrency.Mwk)]
    [InlineData(CustomerResponseDataBillingCurrency.Mxn)]
    [InlineData(CustomerResponseDataBillingCurrency.Myr)]
    [InlineData(CustomerResponseDataBillingCurrency.Mzn)]
    [InlineData(CustomerResponseDataBillingCurrency.Nad)]
    [InlineData(CustomerResponseDataBillingCurrency.Ngn)]
    [InlineData(CustomerResponseDataBillingCurrency.Nok)]
    [InlineData(CustomerResponseDataBillingCurrency.Npr)]
    [InlineData(CustomerResponseDataBillingCurrency.Nzd)]
    [InlineData(CustomerResponseDataBillingCurrency.Pgk)]
    [InlineData(CustomerResponseDataBillingCurrency.Php)]
    [InlineData(CustomerResponseDataBillingCurrency.Pkr)]
    [InlineData(CustomerResponseDataBillingCurrency.Pln)]
    [InlineData(CustomerResponseDataBillingCurrency.Qar)]
    [InlineData(CustomerResponseDataBillingCurrency.Ron)]
    [InlineData(CustomerResponseDataBillingCurrency.Rsd)]
    [InlineData(CustomerResponseDataBillingCurrency.Rub)]
    [InlineData(CustomerResponseDataBillingCurrency.Rwf)]
    [InlineData(CustomerResponseDataBillingCurrency.Sar)]
    [InlineData(CustomerResponseDataBillingCurrency.Sbd)]
    [InlineData(CustomerResponseDataBillingCurrency.Scr)]
    [InlineData(CustomerResponseDataBillingCurrency.Sek)]
    [InlineData(CustomerResponseDataBillingCurrency.Sgd)]
    [InlineData(CustomerResponseDataBillingCurrency.Sle)]
    [InlineData(CustomerResponseDataBillingCurrency.Sll)]
    [InlineData(CustomerResponseDataBillingCurrency.Sos)]
    [InlineData(CustomerResponseDataBillingCurrency.Szl)]
    [InlineData(CustomerResponseDataBillingCurrency.Thb)]
    [InlineData(CustomerResponseDataBillingCurrency.Tjs)]
    [InlineData(CustomerResponseDataBillingCurrency.Top)]
    [InlineData(CustomerResponseDataBillingCurrency.Try)]
    [InlineData(CustomerResponseDataBillingCurrency.Ttd)]
    [InlineData(CustomerResponseDataBillingCurrency.Tzs)]
    [InlineData(CustomerResponseDataBillingCurrency.Uah)]
    [InlineData(CustomerResponseDataBillingCurrency.Uzs)]
    [InlineData(CustomerResponseDataBillingCurrency.Vnd)]
    [InlineData(CustomerResponseDataBillingCurrency.Vuv)]
    [InlineData(CustomerResponseDataBillingCurrency.Wst)]
    [InlineData(CustomerResponseDataBillingCurrency.Xaf)]
    [InlineData(CustomerResponseDataBillingCurrency.Xcd)]
    [InlineData(CustomerResponseDataBillingCurrency.Yer)]
    [InlineData(CustomerResponseDataBillingCurrency.Zar)]
    [InlineData(CustomerResponseDataBillingCurrency.Zmw)]
    [InlineData(CustomerResponseDataBillingCurrency.Clp)]
    [InlineData(CustomerResponseDataBillingCurrency.Djf)]
    [InlineData(CustomerResponseDataBillingCurrency.Gnf)]
    [InlineData(CustomerResponseDataBillingCurrency.Ugx)]
    [InlineData(CustomerResponseDataBillingCurrency.Pyg)]
    [InlineData(CustomerResponseDataBillingCurrency.Xof)]
    [InlineData(CustomerResponseDataBillingCurrency.Xpf)]
    public void Validation_Works(CustomerResponseDataBillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataBillingCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataBillingCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerResponseDataBillingCurrency.Usd)]
    [InlineData(CustomerResponseDataBillingCurrency.Aed)]
    [InlineData(CustomerResponseDataBillingCurrency.All)]
    [InlineData(CustomerResponseDataBillingCurrency.Amd)]
    [InlineData(CustomerResponseDataBillingCurrency.Ang)]
    [InlineData(CustomerResponseDataBillingCurrency.Aud)]
    [InlineData(CustomerResponseDataBillingCurrency.Awg)]
    [InlineData(CustomerResponseDataBillingCurrency.Azn)]
    [InlineData(CustomerResponseDataBillingCurrency.Bam)]
    [InlineData(CustomerResponseDataBillingCurrency.Bbd)]
    [InlineData(CustomerResponseDataBillingCurrency.Bdt)]
    [InlineData(CustomerResponseDataBillingCurrency.Bgn)]
    [InlineData(CustomerResponseDataBillingCurrency.Bif)]
    [InlineData(CustomerResponseDataBillingCurrency.Bmd)]
    [InlineData(CustomerResponseDataBillingCurrency.Bnd)]
    [InlineData(CustomerResponseDataBillingCurrency.Bsd)]
    [InlineData(CustomerResponseDataBillingCurrency.Bwp)]
    [InlineData(CustomerResponseDataBillingCurrency.Byn)]
    [InlineData(CustomerResponseDataBillingCurrency.Bzd)]
    [InlineData(CustomerResponseDataBillingCurrency.Brl)]
    [InlineData(CustomerResponseDataBillingCurrency.Cad)]
    [InlineData(CustomerResponseDataBillingCurrency.Cdf)]
    [InlineData(CustomerResponseDataBillingCurrency.Chf)]
    [InlineData(CustomerResponseDataBillingCurrency.Cny)]
    [InlineData(CustomerResponseDataBillingCurrency.Czk)]
    [InlineData(CustomerResponseDataBillingCurrency.Dkk)]
    [InlineData(CustomerResponseDataBillingCurrency.Dop)]
    [InlineData(CustomerResponseDataBillingCurrency.Dzd)]
    [InlineData(CustomerResponseDataBillingCurrency.Egp)]
    [InlineData(CustomerResponseDataBillingCurrency.Etb)]
    [InlineData(CustomerResponseDataBillingCurrency.Eur)]
    [InlineData(CustomerResponseDataBillingCurrency.Fjd)]
    [InlineData(CustomerResponseDataBillingCurrency.Gbp)]
    [InlineData(CustomerResponseDataBillingCurrency.Gel)]
    [InlineData(CustomerResponseDataBillingCurrency.Gip)]
    [InlineData(CustomerResponseDataBillingCurrency.Gmd)]
    [InlineData(CustomerResponseDataBillingCurrency.Gyd)]
    [InlineData(CustomerResponseDataBillingCurrency.Hkd)]
    [InlineData(CustomerResponseDataBillingCurrency.Hrk)]
    [InlineData(CustomerResponseDataBillingCurrency.Htg)]
    [InlineData(CustomerResponseDataBillingCurrency.Idr)]
    [InlineData(CustomerResponseDataBillingCurrency.Ils)]
    [InlineData(CustomerResponseDataBillingCurrency.Inr)]
    [InlineData(CustomerResponseDataBillingCurrency.Isk)]
    [InlineData(CustomerResponseDataBillingCurrency.Jmd)]
    [InlineData(CustomerResponseDataBillingCurrency.Jpy)]
    [InlineData(CustomerResponseDataBillingCurrency.Kes)]
    [InlineData(CustomerResponseDataBillingCurrency.Kgs)]
    [InlineData(CustomerResponseDataBillingCurrency.Khr)]
    [InlineData(CustomerResponseDataBillingCurrency.Kmf)]
    [InlineData(CustomerResponseDataBillingCurrency.Krw)]
    [InlineData(CustomerResponseDataBillingCurrency.Kyd)]
    [InlineData(CustomerResponseDataBillingCurrency.Kzt)]
    [InlineData(CustomerResponseDataBillingCurrency.Lbp)]
    [InlineData(CustomerResponseDataBillingCurrency.Lkr)]
    [InlineData(CustomerResponseDataBillingCurrency.Lrd)]
    [InlineData(CustomerResponseDataBillingCurrency.Lsl)]
    [InlineData(CustomerResponseDataBillingCurrency.Mad)]
    [InlineData(CustomerResponseDataBillingCurrency.Mdl)]
    [InlineData(CustomerResponseDataBillingCurrency.Mga)]
    [InlineData(CustomerResponseDataBillingCurrency.Mkd)]
    [InlineData(CustomerResponseDataBillingCurrency.Mmk)]
    [InlineData(CustomerResponseDataBillingCurrency.Mnt)]
    [InlineData(CustomerResponseDataBillingCurrency.Mop)]
    [InlineData(CustomerResponseDataBillingCurrency.Mro)]
    [InlineData(CustomerResponseDataBillingCurrency.Mvr)]
    [InlineData(CustomerResponseDataBillingCurrency.Mwk)]
    [InlineData(CustomerResponseDataBillingCurrency.Mxn)]
    [InlineData(CustomerResponseDataBillingCurrency.Myr)]
    [InlineData(CustomerResponseDataBillingCurrency.Mzn)]
    [InlineData(CustomerResponseDataBillingCurrency.Nad)]
    [InlineData(CustomerResponseDataBillingCurrency.Ngn)]
    [InlineData(CustomerResponseDataBillingCurrency.Nok)]
    [InlineData(CustomerResponseDataBillingCurrency.Npr)]
    [InlineData(CustomerResponseDataBillingCurrency.Nzd)]
    [InlineData(CustomerResponseDataBillingCurrency.Pgk)]
    [InlineData(CustomerResponseDataBillingCurrency.Php)]
    [InlineData(CustomerResponseDataBillingCurrency.Pkr)]
    [InlineData(CustomerResponseDataBillingCurrency.Pln)]
    [InlineData(CustomerResponseDataBillingCurrency.Qar)]
    [InlineData(CustomerResponseDataBillingCurrency.Ron)]
    [InlineData(CustomerResponseDataBillingCurrency.Rsd)]
    [InlineData(CustomerResponseDataBillingCurrency.Rub)]
    [InlineData(CustomerResponseDataBillingCurrency.Rwf)]
    [InlineData(CustomerResponseDataBillingCurrency.Sar)]
    [InlineData(CustomerResponseDataBillingCurrency.Sbd)]
    [InlineData(CustomerResponseDataBillingCurrency.Scr)]
    [InlineData(CustomerResponseDataBillingCurrency.Sek)]
    [InlineData(CustomerResponseDataBillingCurrency.Sgd)]
    [InlineData(CustomerResponseDataBillingCurrency.Sle)]
    [InlineData(CustomerResponseDataBillingCurrency.Sll)]
    [InlineData(CustomerResponseDataBillingCurrency.Sos)]
    [InlineData(CustomerResponseDataBillingCurrency.Szl)]
    [InlineData(CustomerResponseDataBillingCurrency.Thb)]
    [InlineData(CustomerResponseDataBillingCurrency.Tjs)]
    [InlineData(CustomerResponseDataBillingCurrency.Top)]
    [InlineData(CustomerResponseDataBillingCurrency.Try)]
    [InlineData(CustomerResponseDataBillingCurrency.Ttd)]
    [InlineData(CustomerResponseDataBillingCurrency.Tzs)]
    [InlineData(CustomerResponseDataBillingCurrency.Uah)]
    [InlineData(CustomerResponseDataBillingCurrency.Uzs)]
    [InlineData(CustomerResponseDataBillingCurrency.Vnd)]
    [InlineData(CustomerResponseDataBillingCurrency.Vuv)]
    [InlineData(CustomerResponseDataBillingCurrency.Wst)]
    [InlineData(CustomerResponseDataBillingCurrency.Xaf)]
    [InlineData(CustomerResponseDataBillingCurrency.Xcd)]
    [InlineData(CustomerResponseDataBillingCurrency.Yer)]
    [InlineData(CustomerResponseDataBillingCurrency.Zar)]
    [InlineData(CustomerResponseDataBillingCurrency.Zmw)]
    [InlineData(CustomerResponseDataBillingCurrency.Clp)]
    [InlineData(CustomerResponseDataBillingCurrency.Djf)]
    [InlineData(CustomerResponseDataBillingCurrency.Gnf)]
    [InlineData(CustomerResponseDataBillingCurrency.Ugx)]
    [InlineData(CustomerResponseDataBillingCurrency.Pyg)]
    [InlineData(CustomerResponseDataBillingCurrency.Xof)]
    [InlineData(CustomerResponseDataBillingCurrency.Xpf)]
    public void SerializationRoundtrip_Works(CustomerResponseDataBillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataBillingCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataBillingCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataBillingCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataBillingCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerResponseDataCouponIDTest : TestBase
{
    [Theory]
    [InlineData(CustomerResponseDataCouponID.Undefined)]
    public void Validation_Works(CustomerResponseDataCouponID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataCouponID> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerResponseDataCouponID>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerResponseDataCouponID.Undefined)]
    public void SerializationRoundtrip_Works(CustomerResponseDataCouponID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataCouponID> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataCouponID>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerResponseDataCouponID>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataCouponID>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerResponseDataDefaultPaymentMethodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerResponseDataDefaultPaymentMethodType.Card,
        };

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType> expectedType =
            CustomerResponseDataDefaultPaymentMethodType.Card;

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCardExpiryMonth, model.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, model.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, model.CardLast4Digits);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerResponseDataDefaultPaymentMethodType.Card,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataDefaultPaymentMethod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerResponseDataDefaultPaymentMethodType.Card,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataDefaultPaymentMethod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType> expectedType =
            CustomerResponseDataDefaultPaymentMethodType.Card;

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCardExpiryMonth, deserialized.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, deserialized.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, deserialized.CardLast4Digits);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerResponseDataDefaultPaymentMethodType.Card,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerResponseDataDefaultPaymentMethodType.Card,
        };

        CustomerResponseDataDefaultPaymentMethod copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataDefaultPaymentMethodTypeTest : TestBase
{
    [Theory]
    [InlineData(CustomerResponseDataDefaultPaymentMethodType.Card)]
    [InlineData(CustomerResponseDataDefaultPaymentMethodType.Bank)]
    [InlineData(CustomerResponseDataDefaultPaymentMethodType.CashApp)]
    public void Validation_Works(CustomerResponseDataDefaultPaymentMethodType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerResponseDataDefaultPaymentMethodType.Card)]
    [InlineData(CustomerResponseDataDefaultPaymentMethodType.Bank)]
    [InlineData(CustomerResponseDataDefaultPaymentMethodType.CashApp)]
    public void SerializationRoundtrip_Works(CustomerResponseDataDefaultPaymentMethodType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataDefaultPaymentMethodType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerResponseDataIntegrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier> expectedVendorIdentifier =
            CustomerResponseDataIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataIntegration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataIntegration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier> expectedVendorIdentifier =
            CustomerResponseDataIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerResponseDataIntegrationVendorIdentifier.Auth0,
        };

        CustomerResponseDataIntegration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataIntegrationVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Auth0)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Zuora)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Stripe)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Hubspot)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Snowflake)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Salesforce)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.BigQuery)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.OpenFga)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.AppStore)]
    public void Validation_Works(CustomerResponseDataIntegrationVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Auth0)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Zuora)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Stripe)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Hubspot)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Snowflake)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.Salesforce)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.BigQuery)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.OpenFga)]
    [InlineData(CustomerResponseDataIntegrationVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(
        CustomerResponseDataIntegrationVendorIdentifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerResponseDataPassthroughTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataPassthrough
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
                Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        CustomerResponseDataPassthroughStripe expectedStripe = new()
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
        CustomerResponseDataPassthroughZuora expectedZuora = new()
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
            Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, model.Stripe);
        Assert.Equal(expectedZuora, model.Zuora);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerResponseDataPassthrough
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
                Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataPassthrough>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataPassthrough
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
                Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataPassthrough>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerResponseDataPassthroughStripe expectedStripe = new()
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
        CustomerResponseDataPassthroughZuora expectedZuora = new()
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
            Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, deserialized.Stripe);
        Assert.Equal(expectedZuora, deserialized.Zuora);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerResponseDataPassthrough
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
                Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerResponseDataPassthrough { };

        Assert.Null(model.Stripe);
        Assert.False(model.RawData.ContainsKey("stripe"));
        Assert.Null(model.Zuora);
        Assert.False(model.RawData.ContainsKey("zuora"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerResponseDataPassthrough { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerResponseDataPassthrough
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
        var model = new CustomerResponseDataPassthrough
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
        var model = new CustomerResponseDataPassthrough
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
                Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        CustomerResponseDataPassthrough copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataPassthroughStripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataPassthroughStripe
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

        CustomerResponseDataPassthroughStripeBillingAddress expectedBillingAddress = new()
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
        CustomerResponseDataPassthroughStripeShippingAddress expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        List<CustomerResponseDataPassthroughStripeTaxID> expectedTaxIds =
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
        var model = new CustomerResponseDataPassthroughStripe
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
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataPassthroughStripe>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataPassthroughStripe
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
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataPassthroughStripe>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerResponseDataPassthroughStripeBillingAddress expectedBillingAddress = new()
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
        CustomerResponseDataPassthroughStripeShippingAddress expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        List<CustomerResponseDataPassthroughStripeTaxID> expectedTaxIds =
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
        var model = new CustomerResponseDataPassthroughStripe
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
        var model = new CustomerResponseDataPassthroughStripe { };

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
        var model = new CustomerResponseDataPassthroughStripe { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerResponseDataPassthroughStripe
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
        var model = new CustomerResponseDataPassthroughStripe
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
        var model = new CustomerResponseDataPassthroughStripe
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

        CustomerResponseDataPassthroughStripe copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataPassthroughStripeBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeBillingAddress
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
        var model = new CustomerResponseDataPassthroughStripeBillingAddress
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
            JsonSerializer.Deserialize<CustomerResponseDataPassthroughStripeBillingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeBillingAddress
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
            JsonSerializer.Deserialize<CustomerResponseDataPassthroughStripeBillingAddress>(
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
        var model = new CustomerResponseDataPassthroughStripeBillingAddress
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
        var model = new CustomerResponseDataPassthroughStripeBillingAddress { };

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
        var model = new CustomerResponseDataPassthroughStripeBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeBillingAddress
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
        var model = new CustomerResponseDataPassthroughStripeBillingAddress
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
        var model = new CustomerResponseDataPassthroughStripeBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        CustomerResponseDataPassthroughStripeBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataPassthroughStripeShippingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeShippingAddress
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
        var model = new CustomerResponseDataPassthroughStripeShippingAddress
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
            JsonSerializer.Deserialize<CustomerResponseDataPassthroughStripeShippingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeShippingAddress
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
            JsonSerializer.Deserialize<CustomerResponseDataPassthroughStripeShippingAddress>(
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
        var model = new CustomerResponseDataPassthroughStripeShippingAddress
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
        var model = new CustomerResponseDataPassthroughStripeShippingAddress { };

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
        var model = new CustomerResponseDataPassthroughStripeShippingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeShippingAddress
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
        var model = new CustomerResponseDataPassthroughStripeShippingAddress
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
        var model = new CustomerResponseDataPassthroughStripeShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        CustomerResponseDataPassthroughStripeShippingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataPassthroughStripeTaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeTaxID
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
        var model = new CustomerResponseDataPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataPassthroughStripeTaxID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataPassthroughStripeTaxID>(
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
        var model = new CustomerResponseDataPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerResponseDataPassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        CustomerResponseDataPassthroughStripeTaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataPassthroughZuoraTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataPassthroughZuora
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
            Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        CustomerResponseDataPassthroughZuoraBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency> expectedCurrency =
            CustomerResponseDataPassthroughZuoraCurrency.Usd;
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
        var model = new CustomerResponseDataPassthroughZuora
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
            Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataPassthroughZuora>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataPassthroughZuora
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
            Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerResponseDataPassthroughZuora>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerResponseDataPassthroughZuoraBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency> expectedCurrency =
            CustomerResponseDataPassthroughZuoraCurrency.Usd;
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
        var model = new CustomerResponseDataPassthroughZuora
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
            Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerResponseDataPassthroughZuora { };

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
        var model = new CustomerResponseDataPassthroughZuora { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerResponseDataPassthroughZuora
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
        var model = new CustomerResponseDataPassthroughZuora
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
        var model = new CustomerResponseDataPassthroughZuora
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
            Currency = CustomerResponseDataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        CustomerResponseDataPassthroughZuora copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataPassthroughZuoraBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress
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
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress
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
            JsonSerializer.Deserialize<CustomerResponseDataPassthroughZuoraBillingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress
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
            JsonSerializer.Deserialize<CustomerResponseDataPassthroughZuoraBillingAddress>(
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
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress
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
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress { };

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
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress
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
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress
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
        var model = new CustomerResponseDataPassthroughZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        CustomerResponseDataPassthroughZuoraBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerResponseDataPassthroughZuoraCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Usd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Aed)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.All)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Amd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ang)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Aud)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Awg)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Azn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bam)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bbd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bdt)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bgn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bif)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bmd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bnd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bsd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bwp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Byn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bzd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Brl)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Cad)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Cdf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Chf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Cny)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Czk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Dkk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Dop)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Dzd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Egp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Etb)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Eur)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Fjd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gbp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gel)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gip)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gmd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gyd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Hkd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Hrk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Htg)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Idr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ils)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Inr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Isk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Jmd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Jpy)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kes)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kgs)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Khr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kmf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Krw)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kyd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kzt)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Lbp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Lkr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Lrd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Lsl)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mad)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mdl)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mga)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mkd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mmk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mnt)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mop)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mro)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mvr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mwk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mxn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Myr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mzn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Nad)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ngn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Nok)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Npr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Nzd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Pgk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Php)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Pkr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Pln)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Qar)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ron)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Rsd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Rub)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Rwf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sar)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sbd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Scr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sek)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sgd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sle)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sll)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sos)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Szl)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Thb)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Tjs)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Top)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Try)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ttd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Tzs)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Uah)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Uzs)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Vnd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Vuv)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Wst)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Xaf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Xcd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Yer)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Zar)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Zmw)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Clp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Djf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gnf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ugx)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Pyg)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Xof)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Xpf)]
    public void Validation_Works(CustomerResponseDataPassthroughZuoraCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Usd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Aed)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.All)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Amd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ang)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Aud)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Awg)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Azn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bam)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bbd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bdt)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bgn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bif)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bmd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bnd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bsd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bwp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Byn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Bzd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Brl)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Cad)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Cdf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Chf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Cny)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Czk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Dkk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Dop)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Dzd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Egp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Etb)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Eur)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Fjd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gbp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gel)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gip)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gmd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gyd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Hkd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Hrk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Htg)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Idr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ils)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Inr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Isk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Jmd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Jpy)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kes)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kgs)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Khr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kmf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Krw)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kyd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Kzt)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Lbp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Lkr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Lrd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Lsl)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mad)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mdl)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mga)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mkd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mmk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mnt)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mop)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mro)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mvr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mwk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mxn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Myr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Mzn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Nad)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ngn)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Nok)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Npr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Nzd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Pgk)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Php)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Pkr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Pln)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Qar)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ron)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Rsd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Rub)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Rwf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sar)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sbd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Scr)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sek)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sgd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sle)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sll)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Sos)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Szl)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Thb)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Tjs)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Top)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Try)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ttd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Tzs)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Uah)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Uzs)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Vnd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Vuv)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Wst)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Xaf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Xcd)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Yer)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Zar)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Zmw)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Clp)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Djf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Gnf)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Ugx)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Pyg)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Xof)]
    [InlineData(CustomerResponseDataPassthroughZuoraCurrency.Xpf)]
    public void SerializationRoundtrip_Works(CustomerResponseDataPassthroughZuoraCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerResponseDataPassthroughZuoraCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
