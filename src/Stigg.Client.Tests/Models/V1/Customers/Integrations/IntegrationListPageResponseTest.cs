using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers.Integrations;

namespace Stigg.Client.Tests.Models.V1.Customers.Integrations;

public class IntegrationListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new IntegrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
                    SyncData = new IntegrationListResponseSyncDataSyncRevisionPriceBillingData()
                    {
                        BillingID = "billingId",
                        BillingLinkUrl = "billingLinkUrl",
                        PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                    },
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        List<IntegrationListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
                SyncData = new IntegrationListResponseSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
        Assert.Equal(expectedPagination, model.Pagination);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new IntegrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
                    SyncData = new IntegrationListResponseSyncDataSyncRevisionPriceBillingData()
                    {
                        BillingID = "billingId",
                        BillingLinkUrl = "billingLinkUrl",
                        PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                    },
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new IntegrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
                    SyncData = new IntegrationListResponseSyncDataSyncRevisionPriceBillingData()
                    {
                        BillingID = "billingId",
                        BillingLinkUrl = "billingLinkUrl",
                        PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                    },
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<IntegrationListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<IntegrationListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
                SyncData = new IntegrationListResponseSyncDataSyncRevisionPriceBillingData()
                {
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                },
            },
        ];
        Pagination expectedPagination = new()
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
        Assert.Equal(expectedPagination, deserialized.Pagination);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new IntegrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
                    SyncData = new IntegrationListResponseSyncDataSyncRevisionPriceBillingData()
                    {
                        BillingID = "billingId",
                        BillingLinkUrl = "billingLinkUrl",
                        PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                    },
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new IntegrationListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = IntegrationListResponseVendorIdentifier.Auth0,
                    SyncData = new IntegrationListResponseSyncDataSyncRevisionPriceBillingData()
                    {
                        BillingID = "billingId",
                        BillingLinkUrl = "billingLinkUrl",
                        PriceGroupPackageBillingID = "priceGroupPackageBillingId",
                    },
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        IntegrationListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedPrev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination
        {
            Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
