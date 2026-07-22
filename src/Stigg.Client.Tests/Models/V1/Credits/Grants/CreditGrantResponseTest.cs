using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits.Grants;

namespace Stigg.Client.Tests.Models.V1.Credits.Grants;

public class CreditGrantResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreditGrantResponse
        {
            Data = new()
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
                GrantType = DataGrantType.Paid,
                InvoiceID = "invoiceId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    BillingReason = BillingReason.Manual,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    PaymentUrl = "paymentUrl",
                    PdfUrl = "pdfUrl",
                    RequiresAction = true,
                    Status = Status.Open,
                    SubTotal = 0,
                    Tax = 0,
                    Total = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentCollection = PaymentCollection.NotRequired,
                Priority = 0,
                ResourceID = "resourceId",
                SourceType = SourceType.Price,
                Status = DataStatus.PaymentPending,
                SyncStates =
                [
                    new()
                    {
                        Status = SyncStateStatus.Pending,
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = VendorIdentifier.Auth0,
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Data expectedData = new()
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
            GrantType = DataGrantType.Paid,
            InvoiceID = "invoiceId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                BillingReason = BillingReason.Manual,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                PaymentUrl = "paymentUrl",
                PdfUrl = "pdfUrl",
                RequiresAction = true,
                Status = Status.Open,
                SubTotal = 0,
                Tax = 0,
                Total = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollection = PaymentCollection.NotRequired,
            Priority = 0,
            ResourceID = "resourceId",
            SourceType = SourceType.Price,
            Status = DataStatus.PaymentPending,
            SyncStates =
            [
                new()
                {
                    Status = SyncStateStatus.Pending,
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreditGrantResponse
        {
            Data = new()
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
                GrantType = DataGrantType.Paid,
                InvoiceID = "invoiceId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    BillingReason = BillingReason.Manual,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    PaymentUrl = "paymentUrl",
                    PdfUrl = "pdfUrl",
                    RequiresAction = true,
                    Status = Status.Open,
                    SubTotal = 0,
                    Tax = 0,
                    Total = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentCollection = PaymentCollection.NotRequired,
                Priority = 0,
                ResourceID = "resourceId",
                SourceType = SourceType.Price,
                Status = DataStatus.PaymentPending,
                SyncStates =
                [
                    new()
                    {
                        Status = SyncStateStatus.Pending,
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = VendorIdentifier.Auth0,
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditGrantResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreditGrantResponse
        {
            Data = new()
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
                GrantType = DataGrantType.Paid,
                InvoiceID = "invoiceId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    BillingReason = BillingReason.Manual,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    PaymentUrl = "paymentUrl",
                    PdfUrl = "pdfUrl",
                    RequiresAction = true,
                    Status = Status.Open,
                    SubTotal = 0,
                    Tax = 0,
                    Total = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentCollection = PaymentCollection.NotRequired,
                Priority = 0,
                ResourceID = "resourceId",
                SourceType = SourceType.Price,
                Status = DataStatus.PaymentPending,
                SyncStates =
                [
                    new()
                    {
                        Status = SyncStateStatus.Pending,
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = VendorIdentifier.Auth0,
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreditGrantResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
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
            GrantType = DataGrantType.Paid,
            InvoiceID = "invoiceId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                BillingReason = BillingReason.Manual,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                PaymentUrl = "paymentUrl",
                PdfUrl = "pdfUrl",
                RequiresAction = true,
                Status = Status.Open,
                SubTotal = 0,
                Tax = 0,
                Total = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollection = PaymentCollection.NotRequired,
            Priority = 0,
            ResourceID = "resourceId",
            SourceType = SourceType.Price,
            Status = DataStatus.PaymentPending,
            SyncStates =
            [
                new()
                {
                    Status = SyncStateStatus.Pending,
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreditGrantResponse
        {
            Data = new()
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
                GrantType = DataGrantType.Paid,
                InvoiceID = "invoiceId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    BillingReason = BillingReason.Manual,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    PaymentUrl = "paymentUrl",
                    PdfUrl = "pdfUrl",
                    RequiresAction = true,
                    Status = Status.Open,
                    SubTotal = 0,
                    Tax = 0,
                    Total = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentCollection = PaymentCollection.NotRequired,
                Priority = 0,
                ResourceID = "resourceId",
                SourceType = SourceType.Price,
                Status = DataStatus.PaymentPending,
                SyncStates =
                [
                    new()
                    {
                        Status = SyncStateStatus.Pending,
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = VendorIdentifier.Auth0,
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreditGrantResponse
        {
            Data = new()
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
                GrantType = DataGrantType.Paid,
                InvoiceID = "invoiceId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    BillingReason = BillingReason.Manual,
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Currency = "currency",
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ErrorMessage = "errorMessage",
                    PaymentUrl = "paymentUrl",
                    PdfUrl = "pdfUrl",
                    RequiresAction = true,
                    Status = Status.Open,
                    SubTotal = 0,
                    Tax = 0,
                    Total = 0,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentCollection = PaymentCollection.NotRequired,
                Priority = 0,
                ResourceID = "resourceId",
                SourceType = SourceType.Price,
                Status = DataStatus.PaymentPending,
                SyncStates =
                [
                    new()
                    {
                        Status = SyncStateStatus.Pending,
                        SyncedEntityID = "syncedEntityId",
                        VendorIdentifier = VendorIdentifier.Auth0,
                    },
                ],
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        CreditGrantResponse copied = new(model);

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
            GrantType = DataGrantType.Paid,
            InvoiceID = "invoiceId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                BillingReason = BillingReason.Manual,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                PaymentUrl = "paymentUrl",
                PdfUrl = "pdfUrl",
                RequiresAction = true,
                Status = Status.Open,
                SubTotal = 0,
                Tax = 0,
                Total = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollection = PaymentCollection.NotRequired,
            Priority = 0,
            ResourceID = "resourceId",
            SourceType = SourceType.Price,
            Status = DataStatus.PaymentPending,
            SyncStates =
            [
                new()
                {
                    Status = SyncStateStatus.Pending,
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        double expectedAmount = 0;
        string expectedComment = "comment";
        double expectedConsumedAmount = 0;
        DataCost expectedCost = new() { Amount = 0, Currency = "currency" };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedDisplayName = "displayName";
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DataGrantType> expectedGrantType = DataGrantType.Paid;
        string expectedInvoiceID = "invoiceId";
        LatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            BillingReason = BillingReason.Manual,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            PaymentUrl = "paymentUrl",
            PdfUrl = "pdfUrl",
            RequiresAction = true,
            Status = Status.Open,
            SubTotal = 0,
            Tax = 0,
            Total = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, PaymentCollection> expectedPaymentCollection =
            PaymentCollection.NotRequired;
        double expectedPriority = 0;
        string expectedResourceID = "resourceId";
        ApiEnum<string, SourceType> expectedSourceType = SourceType.Price;
        ApiEnum<string, DataStatus> expectedStatus = DataStatus.PaymentPending;
        List<SyncState> expectedSyncStates =
        [
            new()
            {
                Status = SyncStateStatus.Pending,
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = VendorIdentifier.Auth0,
            },
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedComment, model.Comment);
        Assert.Equal(expectedConsumedAmount, model.ConsumedAmount);
        Assert.Equal(expectedCost, model.Cost);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedDisplayName, model.DisplayName);
        Assert.Equal(expectedEffectiveAt, model.EffectiveAt);
        Assert.Equal(expectedExpireAt, model.ExpireAt);
        Assert.Equal(expectedGrantType, model.GrantType);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedLatestInvoice, model.LatestInvoice);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentCollection, model.PaymentCollection);
        Assert.Equal(expectedPriority, model.Priority);
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedSourceType, model.SourceType);
        Assert.Equal(expectedStatus, model.Status);
        Assert.NotNull(model.SyncStates);
        Assert.Equal(expectedSyncStates.Count, model.SyncStates.Count);
        for (int i = 0; i < expectedSyncStates.Count; i++)
        {
            Assert.Equal(expectedSyncStates[i], model.SyncStates[i]);
        }
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVoidedAt, model.VoidedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
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
            GrantType = DataGrantType.Paid,
            InvoiceID = "invoiceId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                BillingReason = BillingReason.Manual,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                PaymentUrl = "paymentUrl",
                PdfUrl = "pdfUrl",
                RequiresAction = true,
                Status = Status.Open,
                SubTotal = 0,
                Tax = 0,
                Total = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollection = PaymentCollection.NotRequired,
            Priority = 0,
            ResourceID = "resourceId",
            SourceType = SourceType.Price,
            Status = DataStatus.PaymentPending,
            SyncStates =
            [
                new()
                {
                    Status = SyncStateStatus.Pending,
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            GrantType = DataGrantType.Paid,
            InvoiceID = "invoiceId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                BillingReason = BillingReason.Manual,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                PaymentUrl = "paymentUrl",
                PdfUrl = "pdfUrl",
                RequiresAction = true,
                Status = Status.Open,
                SubTotal = 0,
                Tax = 0,
                Total = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollection = PaymentCollection.NotRequired,
            Priority = 0,
            ResourceID = "resourceId",
            SourceType = SourceType.Price,
            Status = DataStatus.PaymentPending,
            SyncStates =
            [
                new()
                {
                    Status = SyncStateStatus.Pending,
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        string expectedComment = "comment";
        double expectedConsumedAmount = 0;
        DataCost expectedCost = new() { Amount = 0, Currency = "currency" };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedDisplayName = "displayName";
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, DataGrantType> expectedGrantType = DataGrantType.Paid;
        string expectedInvoiceID = "invoiceId";
        LatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            BillingReason = BillingReason.Manual,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            PaymentUrl = "paymentUrl",
            PdfUrl = "pdfUrl",
            RequiresAction = true,
            Status = Status.Open,
            SubTotal = 0,
            Tax = 0,
            Total = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, PaymentCollection> expectedPaymentCollection =
            PaymentCollection.NotRequired;
        double expectedPriority = 0;
        string expectedResourceID = "resourceId";
        ApiEnum<string, SourceType> expectedSourceType = SourceType.Price;
        ApiEnum<string, DataStatus> expectedStatus = DataStatus.PaymentPending;
        List<SyncState> expectedSyncStates =
        [
            new()
            {
                Status = SyncStateStatus.Pending,
                SyncedEntityID = "syncedEntityId",
                VendorIdentifier = VendorIdentifier.Auth0,
            },
        ];
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedVoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedComment, deserialized.Comment);
        Assert.Equal(expectedConsumedAmount, deserialized.ConsumedAmount);
        Assert.Equal(expectedCost, deserialized.Cost);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedDisplayName, deserialized.DisplayName);
        Assert.Equal(expectedEffectiveAt, deserialized.EffectiveAt);
        Assert.Equal(expectedExpireAt, deserialized.ExpireAt);
        Assert.Equal(expectedGrantType, deserialized.GrantType);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedLatestInvoice, deserialized.LatestInvoice);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentCollection, deserialized.PaymentCollection);
        Assert.Equal(expectedPriority, deserialized.Priority);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedSourceType, deserialized.SourceType);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.NotNull(deserialized.SyncStates);
        Assert.Equal(expectedSyncStates.Count, deserialized.SyncStates.Count);
        for (int i = 0; i < expectedSyncStates.Count; i++)
        {
            Assert.Equal(expectedSyncStates[i], deserialized.SyncStates[i]);
        }
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVoidedAt, deserialized.VoidedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
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
            GrantType = DataGrantType.Paid,
            InvoiceID = "invoiceId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                BillingReason = BillingReason.Manual,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                PaymentUrl = "paymentUrl",
                PdfUrl = "pdfUrl",
                RequiresAction = true,
                Status = Status.Open,
                SubTotal = 0,
                Tax = 0,
                Total = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollection = PaymentCollection.NotRequired,
            Priority = 0,
            ResourceID = "resourceId",
            SourceType = SourceType.Price,
            Status = DataStatus.PaymentPending,
            SyncStates =
            [
                new()
                {
                    Status = SyncStateStatus.Pending,
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
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
            GrantType = DataGrantType.Paid,
            InvoiceID = "invoiceId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                BillingReason = BillingReason.Manual,
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Currency = "currency",
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ErrorMessage = "errorMessage",
                PaymentUrl = "paymentUrl",
                PdfUrl = "pdfUrl",
                RequiresAction = true,
                Status = Status.Open,
                SubTotal = 0,
                Tax = 0,
                Total = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollection = PaymentCollection.NotRequired,
            Priority = 0,
            ResourceID = "resourceId",
            SourceType = SourceType.Price,
            Status = DataStatus.PaymentPending,
            SyncStates =
            [
                new()
                {
                    Status = SyncStateStatus.Pending,
                    SyncedEntityID = "syncedEntityId",
                    VendorIdentifier = VendorIdentifier.Auth0,
                },
            ],
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataCostTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataCost { Amount = 0, Currency = "currency" };

        double expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataCost { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataCost>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataCost { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataCost>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataCost { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataCost { Amount = 0, Currency = "currency" };

        DataCost copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataGrantTypeTest : TestBase
{
    [Theory]
    [InlineData(DataGrantType.Paid)]
    [InlineData(DataGrantType.Promotional)]
    [InlineData(DataGrantType.Recurring)]
    [InlineData(DataGrantType.Overdraft)]
    public void Validation_Works(DataGrantType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataGrantType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataGrantType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataGrantType.Paid)]
    [InlineData(DataGrantType.Promotional)]
    [InlineData(DataGrantType.Recurring)]
    [InlineData(DataGrantType.Overdraft)]
    public void SerializationRoundtrip_Works(DataGrantType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataGrantType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataGrantType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataGrantType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataGrantType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class LatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            BillingReason = BillingReason.Manual,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            PaymentUrl = "paymentUrl",
            PdfUrl = "pdfUrl",
            RequiresAction = true,
            Status = Status.Open,
            SubTotal = 0,
            Tax = 0,
            Total = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedBillingID = "billingId";
        ApiEnum<string, BillingReason> expectedBillingReason = BillingReason.Manual;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        string expectedPaymentUrl = "paymentUrl";
        string expectedPdfUrl = "pdfUrl";
        bool expectedRequiresAction = true;
        ApiEnum<string, Status> expectedStatus = Status.Open;
        double expectedSubTotal = 0;
        double expectedTax = 0;
        double expectedTotal = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedBillingReason, model.BillingReason);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedDueDate, model.DueDate);
        Assert.Equal(expectedErrorMessage, model.ErrorMessage);
        Assert.Equal(expectedPaymentUrl, model.PaymentUrl);
        Assert.Equal(expectedPdfUrl, model.PdfUrl);
        Assert.Equal(expectedRequiresAction, model.RequiresAction);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSubTotal, model.SubTotal);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedTotal, model.Total);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            BillingReason = BillingReason.Manual,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            PaymentUrl = "paymentUrl",
            PdfUrl = "pdfUrl",
            RequiresAction = true,
            Status = Status.Open,
            SubTotal = 0,
            Tax = 0,
            Total = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LatestInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            BillingReason = BillingReason.Manual,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            PaymentUrl = "paymentUrl",
            PdfUrl = "pdfUrl",
            RequiresAction = true,
            Status = Status.Open,
            SubTotal = 0,
            Tax = 0,
            Total = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        ApiEnum<string, BillingReason> expectedBillingReason = BillingReason.Manual;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        string expectedPaymentUrl = "paymentUrl";
        string expectedPdfUrl = "pdfUrl";
        bool expectedRequiresAction = true;
        ApiEnum<string, Status> expectedStatus = Status.Open;
        double expectedSubTotal = 0;
        double expectedTax = 0;
        double expectedTotal = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedBillingReason, deserialized.BillingReason);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedDueDate, deserialized.DueDate);
        Assert.Equal(expectedErrorMessage, deserialized.ErrorMessage);
        Assert.Equal(expectedPaymentUrl, deserialized.PaymentUrl);
        Assert.Equal(expectedPdfUrl, deserialized.PdfUrl);
        Assert.Equal(expectedRequiresAction, deserialized.RequiresAction);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSubTotal, deserialized.SubTotal);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedTotal, deserialized.Total);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            BillingReason = BillingReason.Manual,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            PaymentUrl = "paymentUrl",
            PdfUrl = "pdfUrl",
            RequiresAction = true,
            Status = Status.Open,
            SubTotal = 0,
            Tax = 0,
            Total = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            BillingReason = BillingReason.Manual,
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Currency = "currency",
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ErrorMessage = "errorMessage",
            PaymentUrl = "paymentUrl",
            PdfUrl = "pdfUrl",
            RequiresAction = true,
            Status = Status.Open,
            SubTotal = 0,
            Tax = 0,
            Total = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        LatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingReasonTest : TestBase
{
    [Theory]
    [InlineData(BillingReason.Manual)]
    [InlineData(BillingReason.Other)]
    public void Validation_Works(BillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillingReason.Manual)]
    [InlineData(BillingReason.Other)]
    public void SerializationRoundtrip_Works(BillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Open)]
    [InlineData(Status.Paid)]
    [InlineData(Status.Canceled)]
    public void Validation_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Status.Open)]
    [InlineData(Status.Paid)]
    [InlineData(Status.Canceled)]
    public void SerializationRoundtrip_Works(Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(PaymentCollection.NotRequired)]
    [InlineData(PaymentCollection.Processing)]
    [InlineData(PaymentCollection.Failed)]
    [InlineData(PaymentCollection.ActionRequired)]
    public void Validation_Works(PaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentCollection.NotRequired)]
    [InlineData(PaymentCollection.Processing)]
    [InlineData(PaymentCollection.Failed)]
    [InlineData(PaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(PaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTypeTest : TestBase
{
    [Theory]
    [InlineData(SourceType.Price)]
    [InlineData(SourceType.PlanEntitlement)]
    [InlineData(SourceType.AddonEntitlement)]
    public void Validation_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SourceType.Price)]
    [InlineData(SourceType.PlanEntitlement)]
    [InlineData(SourceType.AddonEntitlement)]
    public void SerializationRoundtrip_Works(SourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataStatusTest : TestBase
{
    [Theory]
    [InlineData(DataStatus.PaymentPending)]
    [InlineData(DataStatus.Active)]
    [InlineData(DataStatus.Expired)]
    [InlineData(DataStatus.Voided)]
    [InlineData(DataStatus.Scheduled)]
    public void Validation_Works(DataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataStatus.PaymentPending)]
    [InlineData(DataStatus.Active)]
    [InlineData(DataStatus.Expired)]
    [InlineData(DataStatus.Voided)]
    [InlineData(DataStatus.Scheduled)]
    public void SerializationRoundtrip_Works(DataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SyncStateTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SyncState
        {
            Status = SyncStateStatus.Pending,
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        ApiEnum<string, SyncStateStatus> expectedStatus = SyncStateStatus.Pending;
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, VendorIdentifier> expectedVendorIdentifier = VendorIdentifier.Auth0;

        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedSyncedEntityID, model.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, model.VendorIdentifier);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SyncState
        {
            Status = SyncStateStatus.Pending,
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncState>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SyncState
        {
            Status = SyncStateStatus.Pending,
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SyncState>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ApiEnum<string, SyncStateStatus> expectedStatus = SyncStateStatus.Pending;
        string expectedSyncedEntityID = "syncedEntityId";
        ApiEnum<string, VendorIdentifier> expectedVendorIdentifier = VendorIdentifier.Auth0;

        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedSyncedEntityID, deserialized.SyncedEntityID);
        Assert.Equal(expectedVendorIdentifier, deserialized.VendorIdentifier);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SyncState
        {
            Status = SyncStateStatus.Pending,
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SyncState
        {
            Status = SyncStateStatus.Pending,
            SyncedEntityID = "syncedEntityId",
            VendorIdentifier = VendorIdentifier.Auth0,
        };

        SyncState copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SyncStateStatusTest : TestBase
{
    [Theory]
    [InlineData(SyncStateStatus.Pending)]
    [InlineData(SyncStateStatus.Error)]
    [InlineData(SyncStateStatus.Success)]
    [InlineData(SyncStateStatus.NoSyncRequired)]
    public void Validation_Works(SyncStateStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SyncStateStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SyncStateStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SyncStateStatus.Pending)]
    [InlineData(SyncStateStatus.Error)]
    [InlineData(SyncStateStatus.Success)]
    [InlineData(SyncStateStatus.NoSyncRequired)]
    public void SerializationRoundtrip_Works(SyncStateStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SyncStateStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SyncStateStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SyncStateStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SyncStateStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
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
    [InlineData(VendorIdentifier.Airwallex)]
    [InlineData(VendorIdentifier.StripeInvoicing)]
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
    [InlineData(VendorIdentifier.Airwallex)]
    [InlineData(VendorIdentifier.StripeInvoicing)]
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
