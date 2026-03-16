using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
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
        ApiEnum<string, CustomerListResponseBillingCurrency> expectedBillingCurrency =
            CustomerListResponseBillingCurrency.Usd;
        string expectedBillingID = "billingId";
        ApiEnum<string, CustomerListResponseCouponID> expectedCouponID =
            CustomerListResponseCouponID.Undefined;
        CustomerListResponseDefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDefaultPaymentMethodType.Card,
        };
        string expectedEmail = "dev@stainless.com";
        List<CustomerListResponseIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
            },
        ];
        string expectedLanguage = "language";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        CustomerListResponsePassthrough expectedPassthrough = new()
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
                Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
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
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CustomerListResponseBillingCurrency> expectedBillingCurrency =
            CustomerListResponseBillingCurrency.Usd;
        string expectedBillingID = "billingId";
        ApiEnum<string, CustomerListResponseCouponID> expectedCouponID =
            CustomerListResponseCouponID.Undefined;
        CustomerListResponseDefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDefaultPaymentMethodType.Card,
        };
        string expectedEmail = "dev@stainless.com";
        List<CustomerListResponseIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
            },
        ];
        string expectedLanguage = "language";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        CustomerListResponsePassthrough expectedPassthrough = new()
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
                Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
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
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
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
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
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
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
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
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
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
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
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
        var model = new CustomerListResponse
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
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
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
        var model = new CustomerListResponse
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
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
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
        var model = new CustomerListResponse
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
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
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
        var model = new CustomerListResponse
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
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
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
        var model = new CustomerListResponse
        {
            ID = "id",
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingCurrency = CustomerListResponseBillingCurrency.Usd,
            BillingID = "billingId",
            CouponID = CustomerListResponseCouponID.Undefined,
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDefaultPaymentMethodType.Card,
            },
            Email = "dev@stainless.com",
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
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
                    Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                },
            },
            Timezone = "timezone",
        };

        CustomerListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponseBillingCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CustomerListResponseBillingCurrency.Usd)]
    [InlineData(CustomerListResponseBillingCurrency.Aed)]
    [InlineData(CustomerListResponseBillingCurrency.All)]
    [InlineData(CustomerListResponseBillingCurrency.Amd)]
    [InlineData(CustomerListResponseBillingCurrency.Ang)]
    [InlineData(CustomerListResponseBillingCurrency.Aud)]
    [InlineData(CustomerListResponseBillingCurrency.Awg)]
    [InlineData(CustomerListResponseBillingCurrency.Azn)]
    [InlineData(CustomerListResponseBillingCurrency.Bam)]
    [InlineData(CustomerListResponseBillingCurrency.Bbd)]
    [InlineData(CustomerListResponseBillingCurrency.Bdt)]
    [InlineData(CustomerListResponseBillingCurrency.Bgn)]
    [InlineData(CustomerListResponseBillingCurrency.Bif)]
    [InlineData(CustomerListResponseBillingCurrency.Bmd)]
    [InlineData(CustomerListResponseBillingCurrency.Bnd)]
    [InlineData(CustomerListResponseBillingCurrency.Bsd)]
    [InlineData(CustomerListResponseBillingCurrency.Bwp)]
    [InlineData(CustomerListResponseBillingCurrency.Byn)]
    [InlineData(CustomerListResponseBillingCurrency.Bzd)]
    [InlineData(CustomerListResponseBillingCurrency.Brl)]
    [InlineData(CustomerListResponseBillingCurrency.Cad)]
    [InlineData(CustomerListResponseBillingCurrency.Cdf)]
    [InlineData(CustomerListResponseBillingCurrency.Chf)]
    [InlineData(CustomerListResponseBillingCurrency.Cny)]
    [InlineData(CustomerListResponseBillingCurrency.Czk)]
    [InlineData(CustomerListResponseBillingCurrency.Dkk)]
    [InlineData(CustomerListResponseBillingCurrency.Dop)]
    [InlineData(CustomerListResponseBillingCurrency.Dzd)]
    [InlineData(CustomerListResponseBillingCurrency.Egp)]
    [InlineData(CustomerListResponseBillingCurrency.Etb)]
    [InlineData(CustomerListResponseBillingCurrency.Eur)]
    [InlineData(CustomerListResponseBillingCurrency.Fjd)]
    [InlineData(CustomerListResponseBillingCurrency.Gbp)]
    [InlineData(CustomerListResponseBillingCurrency.Gel)]
    [InlineData(CustomerListResponseBillingCurrency.Gip)]
    [InlineData(CustomerListResponseBillingCurrency.Gmd)]
    [InlineData(CustomerListResponseBillingCurrency.Gyd)]
    [InlineData(CustomerListResponseBillingCurrency.Hkd)]
    [InlineData(CustomerListResponseBillingCurrency.Hrk)]
    [InlineData(CustomerListResponseBillingCurrency.Htg)]
    [InlineData(CustomerListResponseBillingCurrency.Idr)]
    [InlineData(CustomerListResponseBillingCurrency.Ils)]
    [InlineData(CustomerListResponseBillingCurrency.Inr)]
    [InlineData(CustomerListResponseBillingCurrency.Isk)]
    [InlineData(CustomerListResponseBillingCurrency.Jmd)]
    [InlineData(CustomerListResponseBillingCurrency.Jpy)]
    [InlineData(CustomerListResponseBillingCurrency.Kes)]
    [InlineData(CustomerListResponseBillingCurrency.Kgs)]
    [InlineData(CustomerListResponseBillingCurrency.Khr)]
    [InlineData(CustomerListResponseBillingCurrency.Kmf)]
    [InlineData(CustomerListResponseBillingCurrency.Krw)]
    [InlineData(CustomerListResponseBillingCurrency.Kyd)]
    [InlineData(CustomerListResponseBillingCurrency.Kzt)]
    [InlineData(CustomerListResponseBillingCurrency.Lbp)]
    [InlineData(CustomerListResponseBillingCurrency.Lkr)]
    [InlineData(CustomerListResponseBillingCurrency.Lrd)]
    [InlineData(CustomerListResponseBillingCurrency.Lsl)]
    [InlineData(CustomerListResponseBillingCurrency.Mad)]
    [InlineData(CustomerListResponseBillingCurrency.Mdl)]
    [InlineData(CustomerListResponseBillingCurrency.Mga)]
    [InlineData(CustomerListResponseBillingCurrency.Mkd)]
    [InlineData(CustomerListResponseBillingCurrency.Mmk)]
    [InlineData(CustomerListResponseBillingCurrency.Mnt)]
    [InlineData(CustomerListResponseBillingCurrency.Mop)]
    [InlineData(CustomerListResponseBillingCurrency.Mro)]
    [InlineData(CustomerListResponseBillingCurrency.Mvr)]
    [InlineData(CustomerListResponseBillingCurrency.Mwk)]
    [InlineData(CustomerListResponseBillingCurrency.Mxn)]
    [InlineData(CustomerListResponseBillingCurrency.Myr)]
    [InlineData(CustomerListResponseBillingCurrency.Mzn)]
    [InlineData(CustomerListResponseBillingCurrency.Nad)]
    [InlineData(CustomerListResponseBillingCurrency.Ngn)]
    [InlineData(CustomerListResponseBillingCurrency.Nok)]
    [InlineData(CustomerListResponseBillingCurrency.Npr)]
    [InlineData(CustomerListResponseBillingCurrency.Nzd)]
    [InlineData(CustomerListResponseBillingCurrency.Pgk)]
    [InlineData(CustomerListResponseBillingCurrency.Php)]
    [InlineData(CustomerListResponseBillingCurrency.Pkr)]
    [InlineData(CustomerListResponseBillingCurrency.Pln)]
    [InlineData(CustomerListResponseBillingCurrency.Qar)]
    [InlineData(CustomerListResponseBillingCurrency.Ron)]
    [InlineData(CustomerListResponseBillingCurrency.Rsd)]
    [InlineData(CustomerListResponseBillingCurrency.Rub)]
    [InlineData(CustomerListResponseBillingCurrency.Rwf)]
    [InlineData(CustomerListResponseBillingCurrency.Sar)]
    [InlineData(CustomerListResponseBillingCurrency.Sbd)]
    [InlineData(CustomerListResponseBillingCurrency.Scr)]
    [InlineData(CustomerListResponseBillingCurrency.Sek)]
    [InlineData(CustomerListResponseBillingCurrency.Sgd)]
    [InlineData(CustomerListResponseBillingCurrency.Sle)]
    [InlineData(CustomerListResponseBillingCurrency.Sll)]
    [InlineData(CustomerListResponseBillingCurrency.Sos)]
    [InlineData(CustomerListResponseBillingCurrency.Szl)]
    [InlineData(CustomerListResponseBillingCurrency.Thb)]
    [InlineData(CustomerListResponseBillingCurrency.Tjs)]
    [InlineData(CustomerListResponseBillingCurrency.Top)]
    [InlineData(CustomerListResponseBillingCurrency.Try)]
    [InlineData(CustomerListResponseBillingCurrency.Ttd)]
    [InlineData(CustomerListResponseBillingCurrency.Tzs)]
    [InlineData(CustomerListResponseBillingCurrency.Uah)]
    [InlineData(CustomerListResponseBillingCurrency.Uzs)]
    [InlineData(CustomerListResponseBillingCurrency.Vnd)]
    [InlineData(CustomerListResponseBillingCurrency.Vuv)]
    [InlineData(CustomerListResponseBillingCurrency.Wst)]
    [InlineData(CustomerListResponseBillingCurrency.Xaf)]
    [InlineData(CustomerListResponseBillingCurrency.Xcd)]
    [InlineData(CustomerListResponseBillingCurrency.Yer)]
    [InlineData(CustomerListResponseBillingCurrency.Zar)]
    [InlineData(CustomerListResponseBillingCurrency.Zmw)]
    [InlineData(CustomerListResponseBillingCurrency.Clp)]
    [InlineData(CustomerListResponseBillingCurrency.Djf)]
    [InlineData(CustomerListResponseBillingCurrency.Gnf)]
    [InlineData(CustomerListResponseBillingCurrency.Ugx)]
    [InlineData(CustomerListResponseBillingCurrency.Pyg)]
    [InlineData(CustomerListResponseBillingCurrency.Xof)]
    [InlineData(CustomerListResponseBillingCurrency.Xpf)]
    public void Validation_Works(CustomerListResponseBillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseBillingCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseBillingCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerListResponseBillingCurrency.Usd)]
    [InlineData(CustomerListResponseBillingCurrency.Aed)]
    [InlineData(CustomerListResponseBillingCurrency.All)]
    [InlineData(CustomerListResponseBillingCurrency.Amd)]
    [InlineData(CustomerListResponseBillingCurrency.Ang)]
    [InlineData(CustomerListResponseBillingCurrency.Aud)]
    [InlineData(CustomerListResponseBillingCurrency.Awg)]
    [InlineData(CustomerListResponseBillingCurrency.Azn)]
    [InlineData(CustomerListResponseBillingCurrency.Bam)]
    [InlineData(CustomerListResponseBillingCurrency.Bbd)]
    [InlineData(CustomerListResponseBillingCurrency.Bdt)]
    [InlineData(CustomerListResponseBillingCurrency.Bgn)]
    [InlineData(CustomerListResponseBillingCurrency.Bif)]
    [InlineData(CustomerListResponseBillingCurrency.Bmd)]
    [InlineData(CustomerListResponseBillingCurrency.Bnd)]
    [InlineData(CustomerListResponseBillingCurrency.Bsd)]
    [InlineData(CustomerListResponseBillingCurrency.Bwp)]
    [InlineData(CustomerListResponseBillingCurrency.Byn)]
    [InlineData(CustomerListResponseBillingCurrency.Bzd)]
    [InlineData(CustomerListResponseBillingCurrency.Brl)]
    [InlineData(CustomerListResponseBillingCurrency.Cad)]
    [InlineData(CustomerListResponseBillingCurrency.Cdf)]
    [InlineData(CustomerListResponseBillingCurrency.Chf)]
    [InlineData(CustomerListResponseBillingCurrency.Cny)]
    [InlineData(CustomerListResponseBillingCurrency.Czk)]
    [InlineData(CustomerListResponseBillingCurrency.Dkk)]
    [InlineData(CustomerListResponseBillingCurrency.Dop)]
    [InlineData(CustomerListResponseBillingCurrency.Dzd)]
    [InlineData(CustomerListResponseBillingCurrency.Egp)]
    [InlineData(CustomerListResponseBillingCurrency.Etb)]
    [InlineData(CustomerListResponseBillingCurrency.Eur)]
    [InlineData(CustomerListResponseBillingCurrency.Fjd)]
    [InlineData(CustomerListResponseBillingCurrency.Gbp)]
    [InlineData(CustomerListResponseBillingCurrency.Gel)]
    [InlineData(CustomerListResponseBillingCurrency.Gip)]
    [InlineData(CustomerListResponseBillingCurrency.Gmd)]
    [InlineData(CustomerListResponseBillingCurrency.Gyd)]
    [InlineData(CustomerListResponseBillingCurrency.Hkd)]
    [InlineData(CustomerListResponseBillingCurrency.Hrk)]
    [InlineData(CustomerListResponseBillingCurrency.Htg)]
    [InlineData(CustomerListResponseBillingCurrency.Idr)]
    [InlineData(CustomerListResponseBillingCurrency.Ils)]
    [InlineData(CustomerListResponseBillingCurrency.Inr)]
    [InlineData(CustomerListResponseBillingCurrency.Isk)]
    [InlineData(CustomerListResponseBillingCurrency.Jmd)]
    [InlineData(CustomerListResponseBillingCurrency.Jpy)]
    [InlineData(CustomerListResponseBillingCurrency.Kes)]
    [InlineData(CustomerListResponseBillingCurrency.Kgs)]
    [InlineData(CustomerListResponseBillingCurrency.Khr)]
    [InlineData(CustomerListResponseBillingCurrency.Kmf)]
    [InlineData(CustomerListResponseBillingCurrency.Krw)]
    [InlineData(CustomerListResponseBillingCurrency.Kyd)]
    [InlineData(CustomerListResponseBillingCurrency.Kzt)]
    [InlineData(CustomerListResponseBillingCurrency.Lbp)]
    [InlineData(CustomerListResponseBillingCurrency.Lkr)]
    [InlineData(CustomerListResponseBillingCurrency.Lrd)]
    [InlineData(CustomerListResponseBillingCurrency.Lsl)]
    [InlineData(CustomerListResponseBillingCurrency.Mad)]
    [InlineData(CustomerListResponseBillingCurrency.Mdl)]
    [InlineData(CustomerListResponseBillingCurrency.Mga)]
    [InlineData(CustomerListResponseBillingCurrency.Mkd)]
    [InlineData(CustomerListResponseBillingCurrency.Mmk)]
    [InlineData(CustomerListResponseBillingCurrency.Mnt)]
    [InlineData(CustomerListResponseBillingCurrency.Mop)]
    [InlineData(CustomerListResponseBillingCurrency.Mro)]
    [InlineData(CustomerListResponseBillingCurrency.Mvr)]
    [InlineData(CustomerListResponseBillingCurrency.Mwk)]
    [InlineData(CustomerListResponseBillingCurrency.Mxn)]
    [InlineData(CustomerListResponseBillingCurrency.Myr)]
    [InlineData(CustomerListResponseBillingCurrency.Mzn)]
    [InlineData(CustomerListResponseBillingCurrency.Nad)]
    [InlineData(CustomerListResponseBillingCurrency.Ngn)]
    [InlineData(CustomerListResponseBillingCurrency.Nok)]
    [InlineData(CustomerListResponseBillingCurrency.Npr)]
    [InlineData(CustomerListResponseBillingCurrency.Nzd)]
    [InlineData(CustomerListResponseBillingCurrency.Pgk)]
    [InlineData(CustomerListResponseBillingCurrency.Php)]
    [InlineData(CustomerListResponseBillingCurrency.Pkr)]
    [InlineData(CustomerListResponseBillingCurrency.Pln)]
    [InlineData(CustomerListResponseBillingCurrency.Qar)]
    [InlineData(CustomerListResponseBillingCurrency.Ron)]
    [InlineData(CustomerListResponseBillingCurrency.Rsd)]
    [InlineData(CustomerListResponseBillingCurrency.Rub)]
    [InlineData(CustomerListResponseBillingCurrency.Rwf)]
    [InlineData(CustomerListResponseBillingCurrency.Sar)]
    [InlineData(CustomerListResponseBillingCurrency.Sbd)]
    [InlineData(CustomerListResponseBillingCurrency.Scr)]
    [InlineData(CustomerListResponseBillingCurrency.Sek)]
    [InlineData(CustomerListResponseBillingCurrency.Sgd)]
    [InlineData(CustomerListResponseBillingCurrency.Sle)]
    [InlineData(CustomerListResponseBillingCurrency.Sll)]
    [InlineData(CustomerListResponseBillingCurrency.Sos)]
    [InlineData(CustomerListResponseBillingCurrency.Szl)]
    [InlineData(CustomerListResponseBillingCurrency.Thb)]
    [InlineData(CustomerListResponseBillingCurrency.Tjs)]
    [InlineData(CustomerListResponseBillingCurrency.Top)]
    [InlineData(CustomerListResponseBillingCurrency.Try)]
    [InlineData(CustomerListResponseBillingCurrency.Ttd)]
    [InlineData(CustomerListResponseBillingCurrency.Tzs)]
    [InlineData(CustomerListResponseBillingCurrency.Uah)]
    [InlineData(CustomerListResponseBillingCurrency.Uzs)]
    [InlineData(CustomerListResponseBillingCurrency.Vnd)]
    [InlineData(CustomerListResponseBillingCurrency.Vuv)]
    [InlineData(CustomerListResponseBillingCurrency.Wst)]
    [InlineData(CustomerListResponseBillingCurrency.Xaf)]
    [InlineData(CustomerListResponseBillingCurrency.Xcd)]
    [InlineData(CustomerListResponseBillingCurrency.Yer)]
    [InlineData(CustomerListResponseBillingCurrency.Zar)]
    [InlineData(CustomerListResponseBillingCurrency.Zmw)]
    [InlineData(CustomerListResponseBillingCurrency.Clp)]
    [InlineData(CustomerListResponseBillingCurrency.Djf)]
    [InlineData(CustomerListResponseBillingCurrency.Gnf)]
    [InlineData(CustomerListResponseBillingCurrency.Ugx)]
    [InlineData(CustomerListResponseBillingCurrency.Pyg)]
    [InlineData(CustomerListResponseBillingCurrency.Xof)]
    [InlineData(CustomerListResponseBillingCurrency.Xpf)]
    public void SerializationRoundtrip_Works(CustomerListResponseBillingCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseBillingCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseBillingCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseBillingCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseBillingCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerListResponseCouponIDTest : TestBase
{
    [Theory]
    [InlineData(CustomerListResponseCouponID.Undefined)]
    public void Validation_Works(CustomerListResponseCouponID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseCouponID> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerListResponseCouponID>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerListResponseCouponID.Undefined)]
    public void SerializationRoundtrip_Works(CustomerListResponseCouponID rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseCouponID> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseCouponID>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerListResponseCouponID>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseCouponID>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerListResponseDefaultPaymentMethodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponseDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDefaultPaymentMethodType.Card,
        };

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, CustomerListResponseDefaultPaymentMethodType> expectedType =
            CustomerListResponseDefaultPaymentMethodType.Card;

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCardExpiryMonth, model.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, model.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, model.CardLast4Digits);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListResponseDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDefaultPaymentMethodType.Card,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseDefaultPaymentMethod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponseDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDefaultPaymentMethodType.Card,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseDefaultPaymentMethod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, CustomerListResponseDefaultPaymentMethodType> expectedType =
            CustomerListResponseDefaultPaymentMethodType.Card;

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCardExpiryMonth, deserialized.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, deserialized.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, deserialized.CardLast4Digits);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListResponseDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDefaultPaymentMethodType.Card,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListResponseDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDefaultPaymentMethodType.Card,
        };

        CustomerListResponseDefaultPaymentMethod copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponseDefaultPaymentMethodTypeTest : TestBase
{
    [Theory]
    [InlineData(CustomerListResponseDefaultPaymentMethodType.Card)]
    [InlineData(CustomerListResponseDefaultPaymentMethodType.Bank)]
    [InlineData(CustomerListResponseDefaultPaymentMethodType.CashApp)]
    public void Validation_Works(CustomerListResponseDefaultPaymentMethodType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseDefaultPaymentMethodType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDefaultPaymentMethodType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerListResponseDefaultPaymentMethodType.Card)]
    [InlineData(CustomerListResponseDefaultPaymentMethodType.Bank)]
    [InlineData(CustomerListResponseDefaultPaymentMethodType.CashApp)]
    public void SerializationRoundtrip_Works(CustomerListResponseDefaultPaymentMethodType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseDefaultPaymentMethodType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDefaultPaymentMethodType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDefaultPaymentMethodType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDefaultPaymentMethodType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerListResponseIntegrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponseIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier> expectedVendorIdentifier =
            CustomerListResponseIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListResponseIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseIntegration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponseIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseIntegration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier> expectedVendorIdentifier =
            CustomerListResponseIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListResponseIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListResponseIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseIntegrationVendorIdentifier.Auth0,
        };

        CustomerListResponseIntegration copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponseIntegrationVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Auth0)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Zuora)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Stripe)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Hubspot)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Snowflake)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Salesforce)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.BigQuery)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.OpenFga)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.AppStore)]
    public void Validation_Works(CustomerListResponseIntegrationVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Auth0)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Zuora)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Stripe)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Hubspot)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Snowflake)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.Salesforce)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.BigQuery)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.OpenFga)]
    [InlineData(CustomerListResponseIntegrationVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(
        CustomerListResponseIntegrationVendorIdentifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerListResponsePassthroughTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponsePassthrough
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
                Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        CustomerListResponsePassthroughStripe expectedStripe = new()
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
        CustomerListResponsePassthroughZuora expectedZuora = new()
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
            Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, model.Stripe);
        Assert.Equal(expectedZuora, model.Zuora);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListResponsePassthrough
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
                Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponsePassthrough>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponsePassthrough
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
                Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponsePassthrough>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerListResponsePassthroughStripe expectedStripe = new()
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
        CustomerListResponsePassthroughZuora expectedZuora = new()
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
            Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        Assert.Equal(expectedStripe, deserialized.Stripe);
        Assert.Equal(expectedZuora, deserialized.Zuora);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListResponsePassthrough
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
                Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerListResponsePassthrough { };

        Assert.Null(model.Stripe);
        Assert.False(model.RawData.ContainsKey("stripe"));
        Assert.Null(model.Zuora);
        Assert.False(model.RawData.ContainsKey("zuora"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerListResponsePassthrough { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerListResponsePassthrough
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
        var model = new CustomerListResponsePassthrough
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
        var model = new CustomerListResponsePassthrough
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
                Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
            },
        };

        CustomerListResponsePassthrough copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponsePassthroughStripeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponsePassthroughStripe
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

        CustomerListResponsePassthroughStripeBillingAddress expectedBillingAddress = new()
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
        CustomerListResponsePassthroughStripeShippingAddress expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        List<CustomerListResponsePassthroughStripeTaxID> expectedTaxIds =
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
        var model = new CustomerListResponsePassthroughStripe
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
        var deserialized = JsonSerializer.Deserialize<CustomerListResponsePassthroughStripe>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponsePassthroughStripe
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
        var deserialized = JsonSerializer.Deserialize<CustomerListResponsePassthroughStripe>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerListResponsePassthroughStripeBillingAddress expectedBillingAddress = new()
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
        CustomerListResponsePassthroughStripeShippingAddress expectedShippingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        List<CustomerListResponsePassthroughStripeTaxID> expectedTaxIds =
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
        var model = new CustomerListResponsePassthroughStripe
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
        var model = new CustomerListResponsePassthroughStripe { };

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
        var model = new CustomerListResponsePassthroughStripe { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerListResponsePassthroughStripe
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
        var model = new CustomerListResponsePassthroughStripe
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
        var model = new CustomerListResponsePassthroughStripe
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

        CustomerListResponsePassthroughStripe copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponsePassthroughStripeBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponsePassthroughStripeBillingAddress
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
        var model = new CustomerListResponsePassthroughStripeBillingAddress
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
            JsonSerializer.Deserialize<CustomerListResponsePassthroughStripeBillingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponsePassthroughStripeBillingAddress
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
            JsonSerializer.Deserialize<CustomerListResponsePassthroughStripeBillingAddress>(
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
        var model = new CustomerListResponsePassthroughStripeBillingAddress
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
        var model = new CustomerListResponsePassthroughStripeBillingAddress { };

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
        var model = new CustomerListResponsePassthroughStripeBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerListResponsePassthroughStripeBillingAddress
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
        var model = new CustomerListResponsePassthroughStripeBillingAddress
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
        var model = new CustomerListResponsePassthroughStripeBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        CustomerListResponsePassthroughStripeBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponsePassthroughStripeShippingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponsePassthroughStripeShippingAddress
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
        var model = new CustomerListResponsePassthroughStripeShippingAddress
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
            JsonSerializer.Deserialize<CustomerListResponsePassthroughStripeShippingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponsePassthroughStripeShippingAddress
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
            JsonSerializer.Deserialize<CustomerListResponsePassthroughStripeShippingAddress>(
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
        var model = new CustomerListResponsePassthroughStripeShippingAddress
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
        var model = new CustomerListResponsePassthroughStripeShippingAddress { };

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
        var model = new CustomerListResponsePassthroughStripeShippingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerListResponsePassthroughStripeShippingAddress
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
        var model = new CustomerListResponsePassthroughStripeShippingAddress
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
        var model = new CustomerListResponsePassthroughStripeShippingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        CustomerListResponsePassthroughStripeShippingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponsePassthroughStripeTaxIDTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponsePassthroughStripeTaxID
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
        var model = new CustomerListResponsePassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponsePassthroughStripeTaxID>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponsePassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponsePassthroughStripeTaxID>(
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
        var model = new CustomerListResponsePassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListResponsePassthroughStripeTaxID
        {
            Type = "type",
            Value = "value",
        };

        CustomerListResponsePassthroughStripeTaxID copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponsePassthroughZuoraTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponsePassthroughZuora
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
            Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        CustomerListResponsePassthroughZuoraBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency> expectedCurrency =
            CustomerListResponsePassthroughZuoraCurrency.Usd;
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
        var model = new CustomerListResponsePassthroughZuora
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
            Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponsePassthroughZuora>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponsePassthroughZuora
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
            Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponsePassthroughZuora>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerListResponsePassthroughZuoraBillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency> expectedCurrency =
            CustomerListResponsePassthroughZuoraCurrency.Usd;
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
        var model = new CustomerListResponsePassthroughZuora
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
            Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerListResponsePassthroughZuora { };

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
        var model = new CustomerListResponsePassthroughZuora { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerListResponsePassthroughZuora
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
        var model = new CustomerListResponsePassthroughZuora
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
        var model = new CustomerListResponsePassthroughZuora
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
            Currency = CustomerListResponsePassthroughZuoraCurrency.Usd,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
        };

        CustomerListResponsePassthroughZuora copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponsePassthroughZuoraBillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponsePassthroughZuoraBillingAddress
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
        var model = new CustomerListResponsePassthroughZuoraBillingAddress
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
            JsonSerializer.Deserialize<CustomerListResponsePassthroughZuoraBillingAddress>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponsePassthroughZuoraBillingAddress
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
            JsonSerializer.Deserialize<CustomerListResponsePassthroughZuoraBillingAddress>(
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
        var model = new CustomerListResponsePassthroughZuoraBillingAddress
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
        var model = new CustomerListResponsePassthroughZuoraBillingAddress { };

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
        var model = new CustomerListResponsePassthroughZuoraBillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerListResponsePassthroughZuoraBillingAddress
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
        var model = new CustomerListResponsePassthroughZuoraBillingAddress
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
        var model = new CustomerListResponsePassthroughZuoraBillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        CustomerListResponsePassthroughZuoraBillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListResponsePassthroughZuoraCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Usd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Aed)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.All)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Amd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ang)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Aud)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Awg)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Azn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bam)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bbd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bdt)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bgn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bif)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bmd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bnd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bsd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bwp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Byn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bzd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Brl)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Cad)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Cdf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Chf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Cny)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Czk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Dkk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Dop)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Dzd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Egp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Etb)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Eur)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Fjd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gbp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gel)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gip)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gmd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gyd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Hkd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Hrk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Htg)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Idr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ils)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Inr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Isk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Jmd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Jpy)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kes)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kgs)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Khr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kmf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Krw)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kyd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kzt)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Lbp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Lkr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Lrd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Lsl)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mad)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mdl)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mga)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mkd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mmk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mnt)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mop)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mro)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mvr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mwk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mxn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Myr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mzn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Nad)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ngn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Nok)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Npr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Nzd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Pgk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Php)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Pkr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Pln)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Qar)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ron)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Rsd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Rub)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Rwf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sar)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sbd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Scr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sek)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sgd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sle)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sll)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sos)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Szl)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Thb)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Tjs)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Top)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Try)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ttd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Tzs)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Uah)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Uzs)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Vnd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Vuv)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Wst)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Xaf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Xcd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Yer)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Zar)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Zmw)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Clp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Djf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gnf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ugx)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Pyg)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Xof)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Xpf)]
    public void Validation_Works(CustomerListResponsePassthroughZuoraCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Usd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Aed)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.All)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Amd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ang)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Aud)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Awg)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Azn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bam)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bbd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bdt)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bgn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bif)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bmd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bnd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bsd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bwp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Byn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Bzd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Brl)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Cad)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Cdf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Chf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Cny)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Czk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Dkk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Dop)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Dzd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Egp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Etb)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Eur)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Fjd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gbp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gel)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gip)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gmd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gyd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Hkd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Hrk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Htg)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Idr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ils)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Inr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Isk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Jmd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Jpy)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kes)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kgs)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Khr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kmf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Krw)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kyd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Kzt)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Lbp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Lkr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Lrd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Lsl)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mad)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mdl)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mga)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mkd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mmk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mnt)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mop)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mro)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mvr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mwk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mxn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Myr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Mzn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Nad)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ngn)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Nok)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Npr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Nzd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Pgk)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Php)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Pkr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Pln)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Qar)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ron)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Rsd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Rub)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Rwf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sar)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sbd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Scr)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sek)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sgd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sle)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sll)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Sos)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Szl)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Thb)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Tjs)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Top)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Try)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ttd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Tzs)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Uah)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Uzs)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Vnd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Vuv)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Wst)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Xaf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Xcd)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Yer)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Zar)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Zmw)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Clp)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Djf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Gnf)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Ugx)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Pyg)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Xof)]
    [InlineData(CustomerListResponsePassthroughZuoraCurrency.Xpf)]
    public void SerializationRoundtrip_Works(CustomerListResponsePassthroughZuoraCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponsePassthroughZuoraCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
