using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.Grants;

namespace Stigg.Client.Tests.Models.V1.Credits.Grants;

public class GrantListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Comment = "comment",
                    ConsumedAmount = 0,
                    Cost = new() { Amount = 0, Currency = "currency" },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    DisplayName = "displayName",
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    GrantType = GrantListResponseGrantType.Paid,
                    InvoiceID = "invoiceId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        BillingReason = GrantListResponseLatestInvoiceBillingReason.Manual,
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ErrorMessage = "errorMessage",
                        PaymentUrl = "paymentUrl",
                        PdfUrl = "pdfUrl",
                        RequiresAction = true,
                        Status = GrantListResponseLatestInvoiceStatus.Open,
                        SubTotal = 0,
                        Tax = 0,
                        Total = 0,
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentCollection = GrantListResponsePaymentCollection.NotRequired,
                    Priority = 0,
                    ResourceID = "resourceId",
                    SourceType = GrantListResponseSourceType.Price,
                    Status = GrantListResponseStatus.PaymentPending,
                    SyncStates =
                    [
                        new()
                        {
                            Status = GrantListResponseSyncStateStatus.Pending,
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier = GrantListResponseSyncStateVendorIdentifier.Auth0,
                        },
                    ],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        List<GrantListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                Amount = 0,
                Comment = "comment",
                ConsumedAmount = 0,
                Cost = new() { Amount = 0, Currency = "currency" },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                DisplayName = "displayName",
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                GrantType = GrantListResponseGrantType.Paid,
                InvoiceID = "invoiceId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    BillingReason = GrantListResponseLatestInvoiceBillingReason.Manual,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    PaymentUrl = "paymentUrl",
                    PdfUrl = "pdfUrl",
                    RequiresAction = true,
                    Status = GrantListResponseLatestInvoiceStatus.Open,
                    SubTotal = 0,
                    Tax = 0,
                    Total = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentCollection = GrantListResponsePaymentCollection.NotRequired,
                Priority = 0,
                ResourceID = "resourceId",
                SourceType = GrantListResponseSourceType.Price,
                Status = GrantListResponseStatus.PaymentPending,
                SyncStates =
                [
                    new()
                    {
                        Status = GrantListResponseSyncStateStatus.Pending,
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = GrantListResponseSyncStateVendorIdentifier.Auth0,
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new GrantListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Comment = "comment",
                    ConsumedAmount = 0,
                    Cost = new() { Amount = 0, Currency = "currency" },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    DisplayName = "displayName",
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    GrantType = GrantListResponseGrantType.Paid,
                    InvoiceID = "invoiceId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        BillingReason = GrantListResponseLatestInvoiceBillingReason.Manual,
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ErrorMessage = "errorMessage",
                        PaymentUrl = "paymentUrl",
                        PdfUrl = "pdfUrl",
                        RequiresAction = true,
                        Status = GrantListResponseLatestInvoiceStatus.Open,
                        SubTotal = 0,
                        Tax = 0,
                        Total = 0,
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentCollection = GrantListResponsePaymentCollection.NotRequired,
                    Priority = 0,
                    ResourceID = "resourceId",
                    SourceType = GrantListResponseSourceType.Price,
                    Status = GrantListResponseStatus.PaymentPending,
                    SyncStates =
                    [
                        new()
                        {
                            Status = GrantListResponseSyncStateStatus.Pending,
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier = GrantListResponseSyncStateVendorIdentifier.Auth0,
                        },
                    ],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Comment = "comment",
                    ConsumedAmount = 0,
                    Cost = new() { Amount = 0, Currency = "currency" },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    DisplayName = "displayName",
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    GrantType = GrantListResponseGrantType.Paid,
                    InvoiceID = "invoiceId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        BillingReason = GrantListResponseLatestInvoiceBillingReason.Manual,
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ErrorMessage = "errorMessage",
                        PaymentUrl = "paymentUrl",
                        PdfUrl = "pdfUrl",
                        RequiresAction = true,
                        Status = GrantListResponseLatestInvoiceStatus.Open,
                        SubTotal = 0,
                        Tax = 0,
                        Total = 0,
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentCollection = GrantListResponsePaymentCollection.NotRequired,
                    Priority = 0,
                    ResourceID = "resourceId",
                    SourceType = GrantListResponseSourceType.Price,
                    Status = GrantListResponseStatus.PaymentPending,
                    SyncStates =
                    [
                        new()
                        {
                            Status = GrantListResponseSyncStateStatus.Pending,
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier = GrantListResponseSyncStateVendorIdentifier.Auth0,
                        },
                    ],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<GrantListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                Amount = 0,
                Comment = "comment",
                ConsumedAmount = 0,
                Cost = new() { Amount = 0, Currency = "currency" },
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                DisplayName = "displayName",
                EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                GrantType = GrantListResponseGrantType.Paid,
                InvoiceID = "invoiceId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    BillingReason = GrantListResponseLatestInvoiceBillingReason.Manual,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    PaymentUrl = "paymentUrl",
                    PdfUrl = "pdfUrl",
                    RequiresAction = true,
                    Status = GrantListResponseLatestInvoiceStatus.Open,
                    SubTotal = 0,
                    Tax = 0,
                    Total = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentCollection = GrantListResponsePaymentCollection.NotRequired,
                Priority = 0,
                ResourceID = "resourceId",
                SourceType = GrantListResponseSourceType.Price,
                Status = GrantListResponseStatus.PaymentPending,
                SyncStates =
                [
                    new()
                    {
                        Status = GrantListResponseSyncStateStatus.Pending,
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = GrantListResponseSyncStateVendorIdentifier.Auth0,
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new GrantListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Comment = "comment",
                    ConsumedAmount = 0,
                    Cost = new() { Amount = 0, Currency = "currency" },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    DisplayName = "displayName",
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    GrantType = GrantListResponseGrantType.Paid,
                    InvoiceID = "invoiceId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        BillingReason = GrantListResponseLatestInvoiceBillingReason.Manual,
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ErrorMessage = "errorMessage",
                        PaymentUrl = "paymentUrl",
                        PdfUrl = "pdfUrl",
                        RequiresAction = true,
                        Status = GrantListResponseLatestInvoiceStatus.Open,
                        SubTotal = 0,
                        Tax = 0,
                        Total = 0,
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentCollection = GrantListResponsePaymentCollection.NotRequired,
                    Priority = 0,
                    ResourceID = "resourceId",
                    SourceType = GrantListResponseSourceType.Price,
                    Status = GrantListResponseStatus.PaymentPending,
                    SyncStates =
                    [
                        new()
                        {
                            Status = GrantListResponseSyncStateStatus.Pending,
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier = GrantListResponseSyncStateVendorIdentifier.Auth0,
                        },
                    ],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
        var model = new GrantListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    Amount = 0,
                    Comment = "comment",
                    ConsumedAmount = 0,
                    Cost = new() { Amount = 0, Currency = "currency" },
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrencyID = "currencyId",
                    CustomerID = "customerId",
                    DisplayName = "displayName",
                    EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    GrantType = GrantListResponseGrantType.Paid,
                    InvoiceID = "invoiceId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        BillingReason = GrantListResponseLatestInvoiceBillingReason.Manual,
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Currency = "currency",
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        ErrorMessage = "errorMessage",
                        PaymentUrl = "paymentUrl",
                        PdfUrl = "pdfUrl",
                        RequiresAction = true,
                        Status = GrantListResponseLatestInvoiceStatus.Open,
                        SubTotal = 0,
                        Tax = 0,
                        Total = 0,
                        UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentCollection = GrantListResponsePaymentCollection.NotRequired,
                    Priority = 0,
                    ResourceID = "resourceId",
                    SourceType = GrantListResponseSourceType.Price,
                    Status = GrantListResponseStatus.PaymentPending,
                    SyncStates =
                    [
                        new()
                        {
                            Status = GrantListResponseSyncStateStatus.Pending,
                            SyncedEntityID = "syncedEntityId",
                            VendorIdentifier = GrantListResponseSyncStateVendorIdentifier.Auth0,
                        },
                    ],
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            Pagination = new()
            {
                Next = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Prev = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            },
        };

        GrantListPageResponse copied = new(model);

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
