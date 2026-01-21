using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Customers;

namespace Stigg.Tests.Models.V1.Customers;

public class CustomerListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponse
        {
            Data =
            [
                new()
                {
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "dev@stainless.com",
                    ExternalID = "externalId",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DefaultPaymentMethod = new()
                    {
                        BillingID = "billingId",
                        CardExpiryMonth = 0,
                        CardExpiryYear = 0,
                        CardLast4Digits = "cardLast4Digits",
                        Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
                    },
                    Integrations =
                    [
                        new()
                        {
                            ID = "id",
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier =
                                CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
        };

        List<CustomerListResponseData> expectedData =
        [
            new()
            {
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Email = "dev@stainless.com",
                ExternalID = "externalId",
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
                },
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier =
                            CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListResponse
        {
            Data =
            [
                new()
                {
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "dev@stainless.com",
                    ExternalID = "externalId",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DefaultPaymentMethod = new()
                    {
                        BillingID = "billingId",
                        CardExpiryMonth = 0,
                        CardExpiryYear = 0,
                        CardLast4Digits = "cardLast4Digits",
                        Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
                    },
                    Integrations =
                    [
                        new()
                        {
                            ID = "id",
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier =
                                CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
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
            Data =
            [
                new()
                {
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "dev@stainless.com",
                    ExternalID = "externalId",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DefaultPaymentMethod = new()
                    {
                        BillingID = "billingId",
                        CardExpiryMonth = 0,
                        CardExpiryYear = 0,
                        CardLast4Digits = "cardLast4Digits",
                        Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
                    },
                    Integrations =
                    [
                        new()
                        {
                            ID = "id",
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier =
                                CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CustomerListResponseData> expectedData =
        [
            new()
            {
                ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Email = "dev@stainless.com",
                ExternalID = "externalId",
                Name = "name",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                DefaultPaymentMethod = new()
                {
                    BillingID = "billingId",
                    CardExpiryMonth = 0,
                    CardExpiryYear = 0,
                    CardLast4Digits = "cardLast4Digits",
                    Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
                },
                Integrations =
                [
                    new()
                    {
                        ID = "id",
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier =
                            CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                    },
                ],
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            },
        ];

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListResponse
        {
            Data =
            [
                new()
                {
                    ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Email = "dev@stainless.com",
                    ExternalID = "externalId",
                    Name = "name",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    DefaultPaymentMethod = new()
                    {
                        BillingID = "billingId",
                        CardExpiryMonth = 0,
                        CardExpiryYear = 0,
                        CardLast4Digits = "cardLast4Digits",
                        Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
                    },
                    Integrations =
                    [
                        new()
                        {
                            ID = "id",
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier =
                                CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                        },
                    ],
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                },
            ],
        };

        model.Validate();
    }
}

public class CustomerListResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
            },
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedEmail = "dev@stainless.com";
        string expectedExternalID = "externalId";
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        CustomerListResponseDataDefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
        };
        List<CustomerListResponseDataIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedArchivedAt, model.ArchivedAt);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCursorID, model.CursorID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedExternalID, model.ExternalID);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedDefaultPaymentMethod, model.DefaultPaymentMethod);
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
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
            },
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
            },
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedEmail = "dev@stainless.com";
        string expectedExternalID = "externalId";
        string expectedName = "name";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        CustomerListResponseDataDefaultPaymentMethod expectedDefaultPaymentMethod = new()
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
        };
        List<CustomerListResponseDataIntegration> expectedIntegrations =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
            },
        ];
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };

        Assert.Equal(expectedArchivedAt, deserialized.ArchivedAt);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCursorID, deserialized.CursorID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedExternalID, deserialized.ExternalID);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedDefaultPaymentMethod, deserialized.DefaultPaymentMethod);
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
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
            },
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
            },
        };

        Assert.Null(model.Integrations);
        Assert.False(model.RawData.ContainsKey("integrations"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
            },

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
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            DefaultPaymentMethod = new()
            {
                BillingID = "billingId",
                CardExpiryMonth = 0,
                CardExpiryYear = 0,
                CardLast4Digits = "cardLast4Digits",
                Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
            },

            // Null should be interpreted as omitted for these properties
            Integrations = null,
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(model.DefaultPaymentMethod);
        Assert.False(model.RawData.ContainsKey("defaultPaymentMethod"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            DefaultPaymentMethod = null,
        };

        Assert.Null(model.DefaultPaymentMethod);
        Assert.True(model.RawData.ContainsKey("defaultPaymentMethod"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CustomerListResponseData
        {
            ArchivedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Email = "dev@stainless.com",
            ExternalID = "externalId",
            Name = "name",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Integrations =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
                },
            ],
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            DefaultPaymentMethod = null,
        };

        model.Validate();
    }
}

public class CustomerListResponseDataDefaultPaymentMethodTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
        };

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType> expectedType =
            CustomerListResponseDataDefaultPaymentMethodType.Card;

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCardExpiryMonth, model.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, model.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, model.CardLast4Digits);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseDataDefaultPaymentMethod>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseDataDefaultPaymentMethod>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        double expectedCardExpiryMonth = 0;
        double expectedCardExpiryYear = 0;
        string expectedCardLast4Digits = "cardLast4Digits";
        ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType> expectedType =
            CustomerListResponseDataDefaultPaymentMethodType.Card;

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCardExpiryMonth, deserialized.CardExpiryMonth);
        Assert.Equal(expectedCardExpiryYear, deserialized.CardExpiryYear);
        Assert.Equal(expectedCardLast4Digits, deserialized.CardLast4Digits);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListResponseDataDefaultPaymentMethod
        {
            BillingID = "billingId",
            CardExpiryMonth = 0,
            CardExpiryYear = 0,
            CardLast4Digits = "cardLast4Digits",
            Type = CustomerListResponseDataDefaultPaymentMethodType.Card,
        };

        model.Validate();
    }
}

public class CustomerListResponseDataDefaultPaymentMethodTypeTest : TestBase
{
    [Theory]
    [InlineData(CustomerListResponseDataDefaultPaymentMethodType.Card)]
    [InlineData(CustomerListResponseDataDefaultPaymentMethodType.Bank)]
    [InlineData(CustomerListResponseDataDefaultPaymentMethodType.CashApp)]
    public void Validation_Works(CustomerListResponseDataDefaultPaymentMethodType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerListResponseDataDefaultPaymentMethodType.Card)]
    [InlineData(CustomerListResponseDataDefaultPaymentMethodType.Bank)]
    [InlineData(CustomerListResponseDataDefaultPaymentMethodType.CashApp)]
    public void SerializationRoundtrip_Works(
        CustomerListResponseDataDefaultPaymentMethodType rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDataDefaultPaymentMethodType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CustomerListResponseDataIntegrationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
        };

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<
            string,
            CustomerListResponseDataIntegrationVendorIdentifier
        > expectedVendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseDataIntegration>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListResponseDataIntegration>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<
            string,
            CustomerListResponseDataIntegrationVendorIdentifier
        > expectedVendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListResponseDataIntegration
        {
            ID = "id",
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = CustomerListResponseDataIntegrationVendorIdentifier.Auth0,
        };

        model.Validate();
    }
}

public class CustomerListResponseDataIntegrationVendorIdentifierTest : TestBase
{
    [Theory]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Auth0)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Zuora)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Stripe)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Hubspot)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Snowflake)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Salesforce)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.BigQuery)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.OpenFga)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.AppStore)]
    public void Validation_Works(CustomerListResponseDataIntegrationVendorIdentifier rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseDataIntegrationVendorIdentifier> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDataIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Auth0)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Zuora)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Stripe)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Hubspot)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.AwsMarketplace)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Snowflake)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.Salesforce)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.BigQuery)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.OpenFga)]
    [InlineData(CustomerListResponseDataIntegrationVendorIdentifier.AppStore)]
    public void SerializationRoundtrip_Works(
        CustomerListResponseDataIntegrationVendorIdentifier rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListResponseDataIntegrationVendorIdentifier> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDataIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDataIntegrationVendorIdentifier>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListResponseDataIntegrationVendorIdentifier>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
