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
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
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
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
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
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
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
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
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
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
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
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

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
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
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
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";

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
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
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
            Name = "name",
        };

        Assert.Null(model.Integrations);
        Assert.False(model.RawData.ContainsKey("integrations"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
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
            Name = "name",
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
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Integrations = null,
            Metadata = null,
        };

        Assert.Null(model.Integrations);
        Assert.False(model.RawData.ContainsKey("integrations"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
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
            Name = "name",

            // Null should be interpreted as omitted for these properties
            Integrations = null,
            Metadata = null,
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
        Assert.Null(model.Name);
        Assert.False(model.RawData.ContainsKey("name"));
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

            BillingCurrency = null,
            BillingID = null,
            CouponID = null,
            DefaultPaymentMethod = null,
            Email = null,
            Name = null,
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
        Assert.Null(model.Name);
        Assert.True(model.RawData.ContainsKey("name"));
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

            BillingCurrency = null,
            BillingID = null,
            CouponID = null,
            DefaultPaymentMethod = null,
            Email = null,
            Name = null,
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
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
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
