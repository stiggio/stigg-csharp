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
                BillingCurrency = DataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = "couponId",
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = DataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                        Currency = DataPassthroughZuoraCurrency.Usd,
                        Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                        PaymentMethodID = "paymentMethodId",
                    },
                },
                Timezone = "timezone",
            },
        };

        Data expectedData = new()
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
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
                BillingCurrency = DataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = "couponId",
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = DataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                        Currency = DataPassthroughZuoraCurrency.Usd,
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
                BillingCurrency = DataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = "couponId",
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = DataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                        Currency = DataPassthroughZuoraCurrency.Usd,
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

        Data expectedData = new()
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
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
                BillingCurrency = DataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = "couponId",
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = DataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                        Currency = DataPassthroughZuoraCurrency.Usd,
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
                BillingCurrency = DataBillingCurrency.Usd,
                BillingID = "billingId",
                CouponID = "couponId",
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = DataDefaultPaymentMethodType.Card,
                },
                Email = "dev@stainless.com",
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                        Currency = DataPassthroughZuoraCurrency.Usd,
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

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
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
        ApiEnum<string, DataBillingCurrency> expectedBillingCurrency = DataBillingCurrency.Usd;
        string expectedBillingID = "billingId";
        string expectedCouponID = "couponId";
        DataDefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = DataDefaultPaymentMethodType.Card,
        };
        string expectedEmail = "dev@stainless.com";
        List<DataIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
            },
        ];
        string expectedLanguage = "language";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        DataPassthrough expectedPassthrough = new()
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
                Currency = DataPassthroughZuoraCurrency.Usd,
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
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DataBillingCurrency> expectedBillingCurrency = DataBillingCurrency.Usd;
        string expectedBillingID = "billingId";
        string expectedCouponID = "couponId";
        DataDefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = DataDefaultPaymentMethodType.Card,
        };
        string expectedEmail = "dev@stainless.com";
        List<DataIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
            },
        ];
        string expectedLanguage = "language";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        DataPassthrough expectedPassthrough = new()
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
                Currency = DataPassthroughZuoraCurrency.Usd,
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
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
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
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
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
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
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
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
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
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
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
        var model = new Data
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
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
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
        var model = new Data
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
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
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
        var model = new Data
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
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
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
        var model = new Data
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
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
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
        var model = new Data
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = DataBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = "couponId",
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = DataDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
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
                    Currency = DataPassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataBillingCurrencyTest : TestBase
{
    [Theory]
    [InlineData(DataBillingCurrency.Usd)]
    [InlineData(DataBillingCurrency.Aed)]
    [InlineData(DataBillingCurrency.All)]
    [InlineData(DataBillingCurrency.Amd)]
    [InlineData(DataBillingCurrency.Ang)]
    [InlineData(DataBillingCurrency.Aud)]
    [InlineData(DataBillingCurrency.Awg)]
    [InlineData(DataBillingCurrency.Azn)]
    [InlineData(DataBillingCurrency.Bam)]
    [InlineData(DataBillingCurrency.Bbd)]
    [InlineData(DataBillingCurrency.Bdt)]
    [InlineData(DataBillingCurrency.Bgn)]
    [InlineData(DataBillingCurrency.Bif)]
    [InlineData(DataBillingCurrency.Bmd)]
    [InlineData(DataBillingCurrency.Bnd)]
    [InlineData(DataBillingCurrency.Bsd)]
    [InlineData(DataBillingCurrency.Bwp)]
    [InlineData(DataBillingCurrency.Byn)]
    [InlineData(DataBillingCurrency.Bzd)]
    [InlineData(DataBillingCurrency.Brl)]
    [InlineData(DataBillingCurrency.Cad)]
    [InlineData(DataBillingCurrency.Cdf)]
    [InlineData(DataBillingCurrency.Chf)]
    [InlineData(DataBillingCurrency.Cny)]
    [InlineData(DataBillingCurrency.Czk)]
    [InlineData(DataBillingCurrency.Dkk)]
    [InlineData(DataBillingCurrency.Dop)]
    [InlineData(DataBillingCurrency.Dzd)]
    [InlineData(DataBillingCurrency.Egp)]
    [InlineData(DataBillingCurrency.Etb)]
    [InlineData(DataBillingCurrency.Eur)]
    [InlineData(DataBillingCurrency.Fjd)]
    [InlineData(DataBillingCurrency.Gbp)]
    [InlineData(DataBillingCurrency.Gel)]
    [InlineData(DataBillingCurrency.Gip)]
    [InlineData(DataBillingCurrency.Gmd)]
    [InlineData(DataBillingCurrency.Gyd)]
    [InlineData(DataBillingCurrency.Hkd)]
    [InlineData(DataBillingCurrency.Hrk)]
    [InlineData(DataBillingCurrency.Htg)]
    [InlineData(DataBillingCurrency.Idr)]
    [InlineData(DataBillingCurrency.Ils)]
    [InlineData(DataBillingCurrency.Inr)]
    [InlineData(DataBillingCurrency.Isk)]
    [InlineData(DataBillingCurrency.Jmd)]
    [InlineData(DataBillingCurrency.Jpy)]
    [InlineData(DataBillingCurrency.Kes)]
    [InlineData(DataBillingCurrency.Kgs)]
    [InlineData(DataBillingCurrency.Khr)]
    [InlineData(DataBillingCurrency.Kmf)]
    [InlineData(DataBillingCurrency.Krw)]
    [InlineData(DataBillingCurrency.Kyd)]
    [InlineData(DataBillingCurrency.Kzt)]
    [InlineData(DataBillingCurrency.Lbp)]
    [InlineData(DataBillingCurrency.Lkr)]
    [InlineData(DataBillingCurrency.Lrd)]
    [InlineData(DataBillingCurrency.Lsl)]
    [InlineData(DataBillingCurrency.Mad)]
    [InlineData(DataBillingCurrency.Mdl)]
    [InlineData(DataBillingCurrency.Mga)]
    [InlineData(DataBillingCurrency.Mkd)]
    [InlineData(DataBillingCurrency.Mmk)]
    [InlineData(DataBillingCurrency.Mnt)]
    [InlineData(DataBillingCurrency.Mop)]
    [InlineData(DataBillingCurrency.Mro)]
    [InlineData(DataBillingCurrency.Mvr)]
    [InlineData(DataBillingCurrency.Mwk)]
    [InlineData(DataBillingCurrency.Mxn)]
    [InlineData(DataBillingCurrency.Myr)]
    [InlineData(DataBillingCurrency.Mzn)]
    [InlineData(DataBillingCurrency.Nad)]
    [InlineData(DataBillingCurrency.Ngn)]
    [InlineData(DataBillingCurrency.Nok)]
    [InlineData(DataBillingCurrency.Npr)]
    [InlineData(DataBillingCurrency.Nzd)]
    [InlineData(DataBillingCurrency.Pgk)]
    [InlineData(DataBillingCurrency.Php)]
    [InlineData(DataBillingCurrency.Pkr)]
    [InlineData(DataBillingCurrency.Pln)]
    [InlineData(DataBillingCurrency.Qar)]
    [InlineData(DataBillingCurrency.Ron)]
    [InlineData(DataBillingCurrency.Rsd)]
    [InlineData(DataBillingCurrency.Rub)]
    [InlineData(DataBillingCurrency.Rwf)]
    [InlineData(DataBillingCurrency.Sar)]
    [InlineData(DataBillingCurrency.Sbd)]
    [InlineData(DataBillingCurrency.Scr)]
    [InlineData(DataBillingCurrency.Sek)]
    [InlineData(DataBillingCurrency.Sgd)]
    [InlineData(DataBillingCurrency.Sle)]
    [InlineData(DataBillingCurrency.Sll)]
    [InlineData(DataBillingCurrency.Sos)]
    [InlineData(DataBillingCurrency.Szl)]
    [InlineData(DataBillingCurrency.Thb)]
    [InlineData(DataBillingCurrency.Tjs)]
    [InlineData(DataBillingCurrency.Top)]
    [InlineData(DataBillingCurrency.Try)]
    [InlineData(DataBillingCurrency.Ttd)]
    [InlineData(DataBillingCurrency.Tzs)]
    [InlineData(DataBillingCurrency.Uah)]
    [InlineData(DataBillingCurrency.Uzs)]
    [InlineData(DataBillingCurrency.Vnd)]
    [InlineData(DataBillingCurrency.Vuv)]
    [InlineData(DataBillingCurrency.Wst)]
    [InlineData(DataBillingCurrency.Xaf)]
    [InlineData(DataBillingCurrency.Xcd)]
    [InlineData(DataBillingCurrency.Yer)]
    [InlineData(DataBillingCurrency.Zar)]
    [InlineData(DataBillingCurrency.Zmw)]
    [InlineData(DataBillingCurrency.Clp)]
    [InlineData(DataBillingCurrency.Djf)]
    [InlineData(DataBillingCurrency.Gnf)]
    [InlineData(DataBillingCurrency.Ugx)]
    [InlineData(DataBillingCurrency.Pyg)]
    [InlineData(DataBillingCurrency.Xof)]
    [InlineData(DataBillingCurrency.Xpf)]
    public void Validation_Works(DataBillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataBillingCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataBillingCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataBillingCurrency.Usd)]
    [InlineData(DataBillingCurrency.Aed)]
    [InlineData(DataBillingCurrency.All)]
    [InlineData(DataBillingCurrency.Amd)]
    [InlineData(DataBillingCurrency.Ang)]
    [InlineData(DataBillingCurrency.Aud)]
    [InlineData(DataBillingCurrency.Awg)]
    [InlineData(DataBillingCurrency.Azn)]
    [InlineData(DataBillingCurrency.Bam)]
    [InlineData(DataBillingCurrency.Bbd)]
    [InlineData(DataBillingCurrency.Bdt)]
    [InlineData(DataBillingCurrency.Bgn)]
    [InlineData(DataBillingCurrency.Bif)]
    [InlineData(DataBillingCurrency.Bmd)]
    [InlineData(DataBillingCurrency.Bnd)]
    [InlineData(DataBillingCurrency.Bsd)]
    [InlineData(DataBillingCurrency.Bwp)]
    [InlineData(DataBillingCurrency.Byn)]
    [InlineData(DataBillingCurrency.Bzd)]
    [InlineData(DataBillingCurrency.Brl)]
    [InlineData(DataBillingCurrency.Cad)]
    [InlineData(DataBillingCurrency.Cdf)]
    [InlineData(DataBillingCurrency.Chf)]
    [InlineData(DataBillingCurrency.Cny)]
    [InlineData(DataBillingCurrency.Czk)]
    [InlineData(DataBillingCurrency.Dkk)]
    [InlineData(DataBillingCurrency.Dop)]
    [InlineData(DataBillingCurrency.Dzd)]
    [InlineData(DataBillingCurrency.Egp)]
    [InlineData(DataBillingCurrency.Etb)]
    [InlineData(DataBillingCurrency.Eur)]
    [InlineData(DataBillingCurrency.Fjd)]
    [InlineData(DataBillingCurrency.Gbp)]
    [InlineData(DataBillingCurrency.Gel)]
    [InlineData(DataBillingCurrency.Gip)]
    [InlineData(DataBillingCurrency.Gmd)]
    [InlineData(DataBillingCurrency.Gyd)]
    [InlineData(DataBillingCurrency.Hkd)]
    [InlineData(DataBillingCurrency.Hrk)]
    [InlineData(DataBillingCurrency.Htg)]
    [InlineData(DataBillingCurrency.Idr)]
    [InlineData(DataBillingCurrency.Ils)]
    [InlineData(DataBillingCurrency.Inr)]
    [InlineData(DataBillingCurrency.Isk)]
    [InlineData(DataBillingCurrency.Jmd)]
    [InlineData(DataBillingCurrency.Jpy)]
    [InlineData(DataBillingCurrency.Kes)]
    [InlineData(DataBillingCurrency.Kgs)]
    [InlineData(DataBillingCurrency.Khr)]
    [InlineData(DataBillingCurrency.Kmf)]
    [InlineData(DataBillingCurrency.Krw)]
    [InlineData(DataBillingCurrency.Kyd)]
    [InlineData(DataBillingCurrency.Kzt)]
    [InlineData(DataBillingCurrency.Lbp)]
    [InlineData(DataBillingCurrency.Lkr)]
    [InlineData(DataBillingCurrency.Lrd)]
    [InlineData(DataBillingCurrency.Lsl)]
    [InlineData(DataBillingCurrency.Mad)]
    [InlineData(DataBillingCurrency.Mdl)]
    [InlineData(DataBillingCurrency.Mga)]
    [InlineData(DataBillingCurrency.Mkd)]
    [InlineData(DataBillingCurrency.Mmk)]
    [InlineData(DataBillingCurrency.Mnt)]
    [InlineData(DataBillingCurrency.Mop)]
    [InlineData(DataBillingCurrency.Mro)]
    [InlineData(DataBillingCurrency.Mvr)]
    [InlineData(DataBillingCurrency.Mwk)]
    [InlineData(DataBillingCurrency.Mxn)]
    [InlineData(DataBillingCurrency.Myr)]
    [InlineData(DataBillingCurrency.Mzn)]
    [InlineData(DataBillingCurrency.Nad)]
    [InlineData(DataBillingCurrency.Ngn)]
    [InlineData(DataBillingCurrency.Nok)]
    [InlineData(DataBillingCurrency.Npr)]
    [InlineData(DataBillingCurrency.Nzd)]
    [InlineData(DataBillingCurrency.Pgk)]
    [InlineData(DataBillingCurrency.Php)]
    [InlineData(DataBillingCurrency.Pkr)]
    [InlineData(DataBillingCurrency.Pln)]
    [InlineData(DataBillingCurrency.Qar)]
    [InlineData(DataBillingCurrency.Ron)]
    [InlineData(DataBillingCurrency.Rsd)]
    [InlineData(DataBillingCurrency.Rub)]
    [InlineData(DataBillingCurrency.Rwf)]
    [InlineData(DataBillingCurrency.Sar)]
    [InlineData(DataBillingCurrency.Sbd)]
    [InlineData(DataBillingCurrency.Scr)]
    [InlineData(DataBillingCurrency.Sek)]
    [InlineData(DataBillingCurrency.Sgd)]
    [InlineData(DataBillingCurrency.Sle)]
    [InlineData(DataBillingCurrency.Sll)]
    [InlineData(DataBillingCurrency.Sos)]
    [InlineData(DataBillingCurrency.Szl)]
    [InlineData(DataBillingCurrency.Thb)]
    [InlineData(DataBillingCurrency.Tjs)]
    [InlineData(DataBillingCurrency.Top)]
    [InlineData(DataBillingCurrency.Try)]
    [InlineData(DataBillingCurrency.Ttd)]
    [InlineData(DataBillingCurrency.Tzs)]
    [InlineData(DataBillingCurrency.Uah)]
    [InlineData(DataBillingCurrency.Uzs)]
    [InlineData(DataBillingCurrency.Vnd)]
    [InlineData(DataBillingCurrency.Vuv)]
    [InlineData(DataBillingCurrency.Wst)]
    [InlineData(DataBillingCurrency.Xaf)]
    [InlineData(DataBillingCurrency.Xcd)]
    [InlineData(DataBillingCurrency.Yer)]
    [InlineData(DataBillingCurrency.Zar)]
    [InlineData(DataBillingCurrency.Zmw)]
    [InlineData(DataBillingCurrency.Clp)]
    [InlineData(DataBillingCurrency.Djf)]
    [InlineData(DataBillingCurrency.Gnf)]
    [InlineData(DataBillingCurrency.Ugx)]
    [InlineData(DataBillingCurrency.Pyg)]
    [InlineData(DataBillingCurrency.Xof)]
    [InlineData(DataBillingCurrency.Xpf)]
    public void SerializationRoundtrip_Works(DataBillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataBillingCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataBillingCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataBillingCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataBillingCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataDefaultPaymentMethodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = DataDefaultPaymentMethodType.Card,
        };

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, DataDefaultPaymentMethodType> expectedType =
            DataDefaultPaymentMethodType.Card;

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCardExpiryMonth, model.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, model.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, model.CardLast4Digits);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = DataDefaultPaymentMethodType.Card,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataDefaultPaymentMethod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = DataDefaultPaymentMethodType.Card,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataDefaultPaymentMethod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, DataDefaultPaymentMethodType> expectedType =
            DataDefaultPaymentMethodType.Card;

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCardExpiryMonth, deserialized.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, deserialized.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, deserialized.CardLast4Digits);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = DataDefaultPaymentMethodType.Card,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = DataDefaultPaymentMethodType.Card,
        };

        DataDefaultPaymentMethod copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataDefaultPaymentMethodTypeTest : TestBase
{
    [Theory]
    [InlineData(DataDefaultPaymentMethodType.Card)]
    [InlineData(DataDefaultPaymentMethodType.Bank)]
    [InlineData(DataDefaultPaymentMethodType.CashApp)]
    public void Validation_Works(DataDefaultPaymentMethodType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataDefaultPaymentMethodType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataDefaultPaymentMethodType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataDefaultPaymentMethodType.Card)]
    [InlineData(DataDefaultPaymentMethodType.Bank)]
    [InlineData(DataDefaultPaymentMethodType.CashApp)]
    public void SerializationRoundtrip_Works(DataDefaultPaymentMethodType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataDefaultPaymentMethodType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataDefaultPaymentMethodType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataDefaultPaymentMethodType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataDefaultPaymentMethodType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataIntegrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, DataIntegrationVendorIdentifier> expectedVendorIdentifier =
            DataIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataIntegration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataIntegration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, DataIntegrationVendorIdentifier> expectedVendorIdentifier =
            DataIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = DataIntegrationVendorIdentifier.Auth0,
        };

        DataIntegration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataIntegrationVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(DataIntegrationVendorIdentifier.Auth0)]
    [InlineData(DataIntegrationVendorIdentifier.Zuora)]
    [InlineData(DataIntegrationVendorIdentifier.Stripe)]
    [InlineData(DataIntegrationVendorIdentifier.Hubspot)]
    [InlineData(DataIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(DataIntegrationVendorIdentifier.Snowflake)]
    [InlineData(DataIntegrationVendorIdentifier.Salesforce)]
    [InlineData(DataIntegrationVendorIdentifier.BigQuery)]
    [InlineData(DataIntegrationVendorIdentifier.OpenFga)]
    [InlineData(DataIntegrationVendorIdentifier.AppStore)]
    public void Validation_Works(DataIntegrationVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataIntegrationVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataIntegrationVendorIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataIntegrationVendorIdentifier.Auth0)]
    [InlineData(DataIntegrationVendorIdentifier.Zuora)]
    [InlineData(DataIntegrationVendorIdentifier.Stripe)]
    [InlineData(DataIntegrationVendorIdentifier.Hubspot)]
    [InlineData(DataIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(DataIntegrationVendorIdentifier.Snowflake)]
    [InlineData(DataIntegrationVendorIdentifier.Salesforce)]
    [InlineData(DataIntegrationVendorIdentifier.BigQuery)]
    [InlineData(DataIntegrationVendorIdentifier.OpenFga)]
    [InlineData(DataIntegrationVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(DataIntegrationVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataIntegrationVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataIntegrationVendorIdentifier>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class DataPassthroughTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataPassthrough
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
                Currency = DataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        DataPassthroughStripe expectedStripe = new()
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
        DataPassthroughZuora expectedZuora = new()
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
            Currency = DataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, model.Stripe);
        Assert.Equal(expectedZuora, model.Zuora);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataPassthrough
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
                Currency = DataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthrough>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataPassthrough
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
                Currency = DataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthrough>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DataPassthroughStripe expectedStripe = new()
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
        DataPassthroughZuora expectedZuora = new()
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
            Currency = DataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, deserialized.Stripe);
        Assert.Equal(expectedZuora, deserialized.Zuora);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataPassthrough
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
                Currency = DataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataPassthrough { };

        Assert.Null(model.Stripe);
        Assert.False(model.RawData.ContainsKey("stripe"));
        Assert.Null(model.Zuora);
        Assert.False(model.RawData.ContainsKey("zuora"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new DataPassthrough { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DataPassthrough
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
        var model = new DataPassthrough
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
        var model = new DataPassthrough
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
                Currency = DataPassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        DataPassthrough copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataPassthroughStripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataPassthroughStripe
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

        DataPassthroughStripeBillingAddress expectedBillingAddress = new()
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
        DataPassthroughStripeShippingAddress expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        List<DataPassthroughStripeTaxID> expectedTaxIds =
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
        var model = new DataPassthroughStripe
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
        var deserialized = JsonSerializer.Deserialize<DataPassthroughStripe>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataPassthroughStripe
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
        var deserialized = JsonSerializer.Deserialize<DataPassthroughStripe>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DataPassthroughStripeBillingAddress expectedBillingAddress = new()
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
        DataPassthroughStripeShippingAddress expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        List<DataPassthroughStripeTaxID> expectedTaxIds =
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
        var model = new DataPassthroughStripe
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
        var model = new DataPassthroughStripe { };

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
        var model = new DataPassthroughStripe { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DataPassthroughStripe
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
        var model = new DataPassthroughStripe
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
        var model = new DataPassthroughStripe
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

        DataPassthroughStripe copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataPassthroughStripeBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataPassthroughStripeBillingAddress
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
        var model = new DataPassthroughStripeBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughStripeBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataPassthroughStripeBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughStripeBillingAddress>(
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
        var model = new DataPassthroughStripeBillingAddress
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
        var model = new DataPassthroughStripeBillingAddress { };

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
        var model = new DataPassthroughStripeBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DataPassthroughStripeBillingAddress
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
        var model = new DataPassthroughStripeBillingAddress
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
        var model = new DataPassthroughStripeBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        DataPassthroughStripeBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataPassthroughStripeShippingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataPassthroughStripeShippingAddress
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
        var model = new DataPassthroughStripeShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughStripeShippingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataPassthroughStripeShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughStripeShippingAddress>(
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
        var model = new DataPassthroughStripeShippingAddress
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
        var model = new DataPassthroughStripeShippingAddress { };

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
        var model = new DataPassthroughStripeShippingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DataPassthroughStripeShippingAddress
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
        var model = new DataPassthroughStripeShippingAddress
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
        var model = new DataPassthroughStripeShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        DataPassthroughStripeShippingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataPassthroughStripeTaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataPassthroughStripeTaxID { Type = "type", Value = "value" };

        string expectedType = "type";
        string expectedValue = "value";

        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedValue, model.Value);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataPassthroughStripeTaxID { Type = "type", Value = "value" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughStripeTaxID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataPassthroughStripeTaxID { Type = "type", Value = "value" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughStripeTaxID>(
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
        var model = new DataPassthroughStripeTaxID { Type = "type", Value = "value" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataPassthroughStripeTaxID { Type = "type", Value = "value" };

        DataPassthroughStripeTaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataPassthroughZuoraTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataPassthroughZuora
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
            Currency = DataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        DataPassthroughZuoraBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        ApiEnum<string, DataPassthroughZuoraCurrency> expectedCurrency =
            DataPassthroughZuoraCurrency.Usd;
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
        var model = new DataPassthroughZuora
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
            Currency = DataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughZuora>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataPassthroughZuora
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
            Currency = DataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughZuora>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DataPassthroughZuoraBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        ApiEnum<string, DataPassthroughZuoraCurrency> expectedCurrency =
            DataPassthroughZuoraCurrency.Usd;
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
        var model = new DataPassthroughZuora
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
            Currency = DataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DataPassthroughZuora { };

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
        var model = new DataPassthroughZuora { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DataPassthroughZuora
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
        var model = new DataPassthroughZuora
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
        var model = new DataPassthroughZuora
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
            Currency = DataPassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        DataPassthroughZuora copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataPassthroughZuoraBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataPassthroughZuoraBillingAddress
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
        var model = new DataPassthroughZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughZuoraBillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataPassthroughZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataPassthroughZuoraBillingAddress>(
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
        var model = new DataPassthroughZuoraBillingAddress
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
        var model = new DataPassthroughZuoraBillingAddress { };

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
        var model = new DataPassthroughZuoraBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new DataPassthroughZuoraBillingAddress
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
        var model = new DataPassthroughZuoraBillingAddress
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
        var model = new DataPassthroughZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        DataPassthroughZuoraBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataPassthroughZuoraCurrencyTest : TestBase
{
    [Theory]
    [InlineData(DataPassthroughZuoraCurrency.Usd)]
    [InlineData(DataPassthroughZuoraCurrency.Aed)]
    [InlineData(DataPassthroughZuoraCurrency.All)]
    [InlineData(DataPassthroughZuoraCurrency.Amd)]
    [InlineData(DataPassthroughZuoraCurrency.Ang)]
    [InlineData(DataPassthroughZuoraCurrency.Aud)]
    [InlineData(DataPassthroughZuoraCurrency.Awg)]
    [InlineData(DataPassthroughZuoraCurrency.Azn)]
    [InlineData(DataPassthroughZuoraCurrency.Bam)]
    [InlineData(DataPassthroughZuoraCurrency.Bbd)]
    [InlineData(DataPassthroughZuoraCurrency.Bdt)]
    [InlineData(DataPassthroughZuoraCurrency.Bgn)]
    [InlineData(DataPassthroughZuoraCurrency.Bif)]
    [InlineData(DataPassthroughZuoraCurrency.Bmd)]
    [InlineData(DataPassthroughZuoraCurrency.Bnd)]
    [InlineData(DataPassthroughZuoraCurrency.Bsd)]
    [InlineData(DataPassthroughZuoraCurrency.Bwp)]
    [InlineData(DataPassthroughZuoraCurrency.Byn)]
    [InlineData(DataPassthroughZuoraCurrency.Bzd)]
    [InlineData(DataPassthroughZuoraCurrency.Brl)]
    [InlineData(DataPassthroughZuoraCurrency.Cad)]
    [InlineData(DataPassthroughZuoraCurrency.Cdf)]
    [InlineData(DataPassthroughZuoraCurrency.Chf)]
    [InlineData(DataPassthroughZuoraCurrency.Cny)]
    [InlineData(DataPassthroughZuoraCurrency.Czk)]
    [InlineData(DataPassthroughZuoraCurrency.Dkk)]
    [InlineData(DataPassthroughZuoraCurrency.Dop)]
    [InlineData(DataPassthroughZuoraCurrency.Dzd)]
    [InlineData(DataPassthroughZuoraCurrency.Egp)]
    [InlineData(DataPassthroughZuoraCurrency.Etb)]
    [InlineData(DataPassthroughZuoraCurrency.Eur)]
    [InlineData(DataPassthroughZuoraCurrency.Fjd)]
    [InlineData(DataPassthroughZuoraCurrency.Gbp)]
    [InlineData(DataPassthroughZuoraCurrency.Gel)]
    [InlineData(DataPassthroughZuoraCurrency.Gip)]
    [InlineData(DataPassthroughZuoraCurrency.Gmd)]
    [InlineData(DataPassthroughZuoraCurrency.Gyd)]
    [InlineData(DataPassthroughZuoraCurrency.Hkd)]
    [InlineData(DataPassthroughZuoraCurrency.Hrk)]
    [InlineData(DataPassthroughZuoraCurrency.Htg)]
    [InlineData(DataPassthroughZuoraCurrency.Idr)]
    [InlineData(DataPassthroughZuoraCurrency.Ils)]
    [InlineData(DataPassthroughZuoraCurrency.Inr)]
    [InlineData(DataPassthroughZuoraCurrency.Isk)]
    [InlineData(DataPassthroughZuoraCurrency.Jmd)]
    [InlineData(DataPassthroughZuoraCurrency.Jpy)]
    [InlineData(DataPassthroughZuoraCurrency.Kes)]
    [InlineData(DataPassthroughZuoraCurrency.Kgs)]
    [InlineData(DataPassthroughZuoraCurrency.Khr)]
    [InlineData(DataPassthroughZuoraCurrency.Kmf)]
    [InlineData(DataPassthroughZuoraCurrency.Krw)]
    [InlineData(DataPassthroughZuoraCurrency.Kyd)]
    [InlineData(DataPassthroughZuoraCurrency.Kzt)]
    [InlineData(DataPassthroughZuoraCurrency.Lbp)]
    [InlineData(DataPassthroughZuoraCurrency.Lkr)]
    [InlineData(DataPassthroughZuoraCurrency.Lrd)]
    [InlineData(DataPassthroughZuoraCurrency.Lsl)]
    [InlineData(DataPassthroughZuoraCurrency.Mad)]
    [InlineData(DataPassthroughZuoraCurrency.Mdl)]
    [InlineData(DataPassthroughZuoraCurrency.Mga)]
    [InlineData(DataPassthroughZuoraCurrency.Mkd)]
    [InlineData(DataPassthroughZuoraCurrency.Mmk)]
    [InlineData(DataPassthroughZuoraCurrency.Mnt)]
    [InlineData(DataPassthroughZuoraCurrency.Mop)]
    [InlineData(DataPassthroughZuoraCurrency.Mro)]
    [InlineData(DataPassthroughZuoraCurrency.Mvr)]
    [InlineData(DataPassthroughZuoraCurrency.Mwk)]
    [InlineData(DataPassthroughZuoraCurrency.Mxn)]
    [InlineData(DataPassthroughZuoraCurrency.Myr)]
    [InlineData(DataPassthroughZuoraCurrency.Mzn)]
    [InlineData(DataPassthroughZuoraCurrency.Nad)]
    [InlineData(DataPassthroughZuoraCurrency.Ngn)]
    [InlineData(DataPassthroughZuoraCurrency.Nok)]
    [InlineData(DataPassthroughZuoraCurrency.Npr)]
    [InlineData(DataPassthroughZuoraCurrency.Nzd)]
    [InlineData(DataPassthroughZuoraCurrency.Pgk)]
    [InlineData(DataPassthroughZuoraCurrency.Php)]
    [InlineData(DataPassthroughZuoraCurrency.Pkr)]
    [InlineData(DataPassthroughZuoraCurrency.Pln)]
    [InlineData(DataPassthroughZuoraCurrency.Qar)]
    [InlineData(DataPassthroughZuoraCurrency.Ron)]
    [InlineData(DataPassthroughZuoraCurrency.Rsd)]
    [InlineData(DataPassthroughZuoraCurrency.Rub)]
    [InlineData(DataPassthroughZuoraCurrency.Rwf)]
    [InlineData(DataPassthroughZuoraCurrency.Sar)]
    [InlineData(DataPassthroughZuoraCurrency.Sbd)]
    [InlineData(DataPassthroughZuoraCurrency.Scr)]
    [InlineData(DataPassthroughZuoraCurrency.Sek)]
    [InlineData(DataPassthroughZuoraCurrency.Sgd)]
    [InlineData(DataPassthroughZuoraCurrency.Sle)]
    [InlineData(DataPassthroughZuoraCurrency.Sll)]
    [InlineData(DataPassthroughZuoraCurrency.Sos)]
    [InlineData(DataPassthroughZuoraCurrency.Szl)]
    [InlineData(DataPassthroughZuoraCurrency.Thb)]
    [InlineData(DataPassthroughZuoraCurrency.Tjs)]
    [InlineData(DataPassthroughZuoraCurrency.Top)]
    [InlineData(DataPassthroughZuoraCurrency.Try)]
    [InlineData(DataPassthroughZuoraCurrency.Ttd)]
    [InlineData(DataPassthroughZuoraCurrency.Tzs)]
    [InlineData(DataPassthroughZuoraCurrency.Uah)]
    [InlineData(DataPassthroughZuoraCurrency.Uzs)]
    [InlineData(DataPassthroughZuoraCurrency.Vnd)]
    [InlineData(DataPassthroughZuoraCurrency.Vuv)]
    [InlineData(DataPassthroughZuoraCurrency.Wst)]
    [InlineData(DataPassthroughZuoraCurrency.Xaf)]
    [InlineData(DataPassthroughZuoraCurrency.Xcd)]
    [InlineData(DataPassthroughZuoraCurrency.Yer)]
    [InlineData(DataPassthroughZuoraCurrency.Zar)]
    [InlineData(DataPassthroughZuoraCurrency.Zmw)]
    [InlineData(DataPassthroughZuoraCurrency.Clp)]
    [InlineData(DataPassthroughZuoraCurrency.Djf)]
    [InlineData(DataPassthroughZuoraCurrency.Gnf)]
    [InlineData(DataPassthroughZuoraCurrency.Ugx)]
    [InlineData(DataPassthroughZuoraCurrency.Pyg)]
    [InlineData(DataPassthroughZuoraCurrency.Xof)]
    [InlineData(DataPassthroughZuoraCurrency.Xpf)]
    public void Validation_Works(DataPassthroughZuoraCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataPassthroughZuoraCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataPassthroughZuoraCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataPassthroughZuoraCurrency.Usd)]
    [InlineData(DataPassthroughZuoraCurrency.Aed)]
    [InlineData(DataPassthroughZuoraCurrency.All)]
    [InlineData(DataPassthroughZuoraCurrency.Amd)]
    [InlineData(DataPassthroughZuoraCurrency.Ang)]
    [InlineData(DataPassthroughZuoraCurrency.Aud)]
    [InlineData(DataPassthroughZuoraCurrency.Awg)]
    [InlineData(DataPassthroughZuoraCurrency.Azn)]
    [InlineData(DataPassthroughZuoraCurrency.Bam)]
    [InlineData(DataPassthroughZuoraCurrency.Bbd)]
    [InlineData(DataPassthroughZuoraCurrency.Bdt)]
    [InlineData(DataPassthroughZuoraCurrency.Bgn)]
    [InlineData(DataPassthroughZuoraCurrency.Bif)]
    [InlineData(DataPassthroughZuoraCurrency.Bmd)]
    [InlineData(DataPassthroughZuoraCurrency.Bnd)]
    [InlineData(DataPassthroughZuoraCurrency.Bsd)]
    [InlineData(DataPassthroughZuoraCurrency.Bwp)]
    [InlineData(DataPassthroughZuoraCurrency.Byn)]
    [InlineData(DataPassthroughZuoraCurrency.Bzd)]
    [InlineData(DataPassthroughZuoraCurrency.Brl)]
    [InlineData(DataPassthroughZuoraCurrency.Cad)]
    [InlineData(DataPassthroughZuoraCurrency.Cdf)]
    [InlineData(DataPassthroughZuoraCurrency.Chf)]
    [InlineData(DataPassthroughZuoraCurrency.Cny)]
    [InlineData(DataPassthroughZuoraCurrency.Czk)]
    [InlineData(DataPassthroughZuoraCurrency.Dkk)]
    [InlineData(DataPassthroughZuoraCurrency.Dop)]
    [InlineData(DataPassthroughZuoraCurrency.Dzd)]
    [InlineData(DataPassthroughZuoraCurrency.Egp)]
    [InlineData(DataPassthroughZuoraCurrency.Etb)]
    [InlineData(DataPassthroughZuoraCurrency.Eur)]
    [InlineData(DataPassthroughZuoraCurrency.Fjd)]
    [InlineData(DataPassthroughZuoraCurrency.Gbp)]
    [InlineData(DataPassthroughZuoraCurrency.Gel)]
    [InlineData(DataPassthroughZuoraCurrency.Gip)]
    [InlineData(DataPassthroughZuoraCurrency.Gmd)]
    [InlineData(DataPassthroughZuoraCurrency.Gyd)]
    [InlineData(DataPassthroughZuoraCurrency.Hkd)]
    [InlineData(DataPassthroughZuoraCurrency.Hrk)]
    [InlineData(DataPassthroughZuoraCurrency.Htg)]
    [InlineData(DataPassthroughZuoraCurrency.Idr)]
    [InlineData(DataPassthroughZuoraCurrency.Ils)]
    [InlineData(DataPassthroughZuoraCurrency.Inr)]
    [InlineData(DataPassthroughZuoraCurrency.Isk)]
    [InlineData(DataPassthroughZuoraCurrency.Jmd)]
    [InlineData(DataPassthroughZuoraCurrency.Jpy)]
    [InlineData(DataPassthroughZuoraCurrency.Kes)]
    [InlineData(DataPassthroughZuoraCurrency.Kgs)]
    [InlineData(DataPassthroughZuoraCurrency.Khr)]
    [InlineData(DataPassthroughZuoraCurrency.Kmf)]
    [InlineData(DataPassthroughZuoraCurrency.Krw)]
    [InlineData(DataPassthroughZuoraCurrency.Kyd)]
    [InlineData(DataPassthroughZuoraCurrency.Kzt)]
    [InlineData(DataPassthroughZuoraCurrency.Lbp)]
    [InlineData(DataPassthroughZuoraCurrency.Lkr)]
    [InlineData(DataPassthroughZuoraCurrency.Lrd)]
    [InlineData(DataPassthroughZuoraCurrency.Lsl)]
    [InlineData(DataPassthroughZuoraCurrency.Mad)]
    [InlineData(DataPassthroughZuoraCurrency.Mdl)]
    [InlineData(DataPassthroughZuoraCurrency.Mga)]
    [InlineData(DataPassthroughZuoraCurrency.Mkd)]
    [InlineData(DataPassthroughZuoraCurrency.Mmk)]
    [InlineData(DataPassthroughZuoraCurrency.Mnt)]
    [InlineData(DataPassthroughZuoraCurrency.Mop)]
    [InlineData(DataPassthroughZuoraCurrency.Mro)]
    [InlineData(DataPassthroughZuoraCurrency.Mvr)]
    [InlineData(DataPassthroughZuoraCurrency.Mwk)]
    [InlineData(DataPassthroughZuoraCurrency.Mxn)]
    [InlineData(DataPassthroughZuoraCurrency.Myr)]
    [InlineData(DataPassthroughZuoraCurrency.Mzn)]
    [InlineData(DataPassthroughZuoraCurrency.Nad)]
    [InlineData(DataPassthroughZuoraCurrency.Ngn)]
    [InlineData(DataPassthroughZuoraCurrency.Nok)]
    [InlineData(DataPassthroughZuoraCurrency.Npr)]
    [InlineData(DataPassthroughZuoraCurrency.Nzd)]
    [InlineData(DataPassthroughZuoraCurrency.Pgk)]
    [InlineData(DataPassthroughZuoraCurrency.Php)]
    [InlineData(DataPassthroughZuoraCurrency.Pkr)]
    [InlineData(DataPassthroughZuoraCurrency.Pln)]
    [InlineData(DataPassthroughZuoraCurrency.Qar)]
    [InlineData(DataPassthroughZuoraCurrency.Ron)]
    [InlineData(DataPassthroughZuoraCurrency.Rsd)]
    [InlineData(DataPassthroughZuoraCurrency.Rub)]
    [InlineData(DataPassthroughZuoraCurrency.Rwf)]
    [InlineData(DataPassthroughZuoraCurrency.Sar)]
    [InlineData(DataPassthroughZuoraCurrency.Sbd)]
    [InlineData(DataPassthroughZuoraCurrency.Scr)]
    [InlineData(DataPassthroughZuoraCurrency.Sek)]
    [InlineData(DataPassthroughZuoraCurrency.Sgd)]
    [InlineData(DataPassthroughZuoraCurrency.Sle)]
    [InlineData(DataPassthroughZuoraCurrency.Sll)]
    [InlineData(DataPassthroughZuoraCurrency.Sos)]
    [InlineData(DataPassthroughZuoraCurrency.Szl)]
    [InlineData(DataPassthroughZuoraCurrency.Thb)]
    [InlineData(DataPassthroughZuoraCurrency.Tjs)]
    [InlineData(DataPassthroughZuoraCurrency.Top)]
    [InlineData(DataPassthroughZuoraCurrency.Try)]
    [InlineData(DataPassthroughZuoraCurrency.Ttd)]
    [InlineData(DataPassthroughZuoraCurrency.Tzs)]
    [InlineData(DataPassthroughZuoraCurrency.Uah)]
    [InlineData(DataPassthroughZuoraCurrency.Uzs)]
    [InlineData(DataPassthroughZuoraCurrency.Vnd)]
    [InlineData(DataPassthroughZuoraCurrency.Vuv)]
    [InlineData(DataPassthroughZuoraCurrency.Wst)]
    [InlineData(DataPassthroughZuoraCurrency.Xaf)]
    [InlineData(DataPassthroughZuoraCurrency.Xcd)]
    [InlineData(DataPassthroughZuoraCurrency.Yer)]
    [InlineData(DataPassthroughZuoraCurrency.Zar)]
    [InlineData(DataPassthroughZuoraCurrency.Zmw)]
    [InlineData(DataPassthroughZuoraCurrency.Clp)]
    [InlineData(DataPassthroughZuoraCurrency.Djf)]
    [InlineData(DataPassthroughZuoraCurrency.Gnf)]
    [InlineData(DataPassthroughZuoraCurrency.Ugx)]
    [InlineData(DataPassthroughZuoraCurrency.Pyg)]
    [InlineData(DataPassthroughZuoraCurrency.Xof)]
    [InlineData(DataPassthroughZuoraCurrency.Xpf)]
    public void SerializationRoundtrip_Works(DataPassthroughZuoraCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataPassthroughZuoraCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataPassthroughZuoraCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataPassthroughZuoraCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, DataPassthroughZuoraCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
