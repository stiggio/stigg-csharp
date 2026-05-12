using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits.Grants;

namespace Stigg.Client.Tests.Models.V1.Credits.Grants;

public class GrantListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantListResponse
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        double expectedAmount = 0;
        string expectedComment = "comment";
        double expectedConsumedAmount = 0;
        GrantListResponseCost expectedCost = new() { Amount = 0, Currency = "currency" };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedDisplayName = "displayName";
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, GrantListResponseGrantType> expectedGrantType =
            GrantListResponseGrantType.Paid;
        string expectedInvoiceID = "invoiceId";
        GrantListResponseLatestInvoice expectedLatestInvoice = new()
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
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, GrantListResponsePaymentCollection> expectedPaymentCollection =
            GrantListResponsePaymentCollection.NotRequired;
        double expectedPriority = 0;
        string expectedResourceID = "resourceId";
        ApiEnum<string, GrantListResponseSourceType> expectedSourceType =
            GrantListResponseSourceType.Price;
        ApiEnum<string, GrantListResponseStatus> expectedStatus =
            GrantListResponseStatus.PaymentPending;
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
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
        Assert.Equal(expectedVoidedAt, model.VoidedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GrantListResponse
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantListResponse
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 0;
        string expectedComment = "comment";
        double expectedConsumedAmount = 0;
        GrantListResponseCost expectedCost = new() { Amount = 0, Currency = "currency" };
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedDisplayName = "displayName";
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, GrantListResponseGrantType> expectedGrantType =
            GrantListResponseGrantType.Paid;
        string expectedInvoiceID = "invoiceId";
        GrantListResponseLatestInvoice expectedLatestInvoice = new()
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
        };
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, GrantListResponsePaymentCollection> expectedPaymentCollection =
            GrantListResponsePaymentCollection.NotRequired;
        double expectedPriority = 0;
        string expectedResourceID = "resourceId";
        ApiEnum<string, GrantListResponseSourceType> expectedSourceType =
            GrantListResponseSourceType.Price;
        ApiEnum<string, GrantListResponseStatus> expectedStatus =
            GrantListResponseStatus.PaymentPending;
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
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
        Assert.Equal(expectedVoidedAt, deserialized.VoidedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new GrantListResponse
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GrantListResponse
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
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            VoidedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        GrantListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantListResponseCostTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantListResponseCost { Amount = 0, Currency = "currency" };

        double expectedAmount = 0;
        string expectedCurrency = "currency";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new GrantListResponseCost { Amount = 0, Currency = "currency" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListResponseCost>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantListResponseCost { Amount = 0, Currency = "currency" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListResponseCost>(
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
        var model = new GrantListResponseCost { Amount = 0, Currency = "currency" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GrantListResponseCost { Amount = 0, Currency = "currency" };

        GrantListResponseCost copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantListResponseGrantTypeTest : TestBase
{
    [Theory]
    [InlineData(GrantListResponseGrantType.Paid)]
    [InlineData(GrantListResponseGrantType.Promotional)]
    [InlineData(GrantListResponseGrantType.Recurring)]
    [InlineData(GrantListResponseGrantType.Overdraft)]
    public void Validation_Works(GrantListResponseGrantType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseGrantType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseGrantType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantListResponseGrantType.Paid)]
    [InlineData(GrantListResponseGrantType.Promotional)]
    [InlineData(GrantListResponseGrantType.Recurring)]
    [InlineData(GrantListResponseGrantType.Overdraft)]
    public void SerializationRoundtrip_Works(GrantListResponseGrantType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseGrantType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseGrantType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseGrantType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseGrantType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GrantListResponseLatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new GrantListResponseLatestInvoice
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
        };

        string expectedBillingID = "billingId";
        ApiEnum<string, GrantListResponseLatestInvoiceBillingReason> expectedBillingReason =
            GrantListResponseLatestInvoiceBillingReason.Manual;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        string expectedPaymentUrl = "paymentUrl";
        string expectedPdfUrl = "pdfUrl";
        bool expectedRequiresAction = true;
        ApiEnum<string, GrantListResponseLatestInvoiceStatus> expectedStatus =
            GrantListResponseLatestInvoiceStatus.Open;
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
        var model = new GrantListResponseLatestInvoice
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListResponseLatestInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new GrantListResponseLatestInvoice
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<GrantListResponseLatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        ApiEnum<string, GrantListResponseLatestInvoiceBillingReason> expectedBillingReason =
            GrantListResponseLatestInvoiceBillingReason.Manual;
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrency = "currency";
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedErrorMessage = "errorMessage";
        string expectedPaymentUrl = "paymentUrl";
        string expectedPdfUrl = "pdfUrl";
        bool expectedRequiresAction = true;
        ApiEnum<string, GrantListResponseLatestInvoiceStatus> expectedStatus =
            GrantListResponseLatestInvoiceStatus.Open;
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
        var model = new GrantListResponseLatestInvoice
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new GrantListResponseLatestInvoice
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
        };

        GrantListResponseLatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantListResponseLatestInvoiceBillingReasonTest : TestBase
{
    [Theory]
    [InlineData(GrantListResponseLatestInvoiceBillingReason.Manual)]
    [InlineData(GrantListResponseLatestInvoiceBillingReason.Other)]
    public void Validation_Works(GrantListResponseLatestInvoiceBillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseLatestInvoiceBillingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponseLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantListResponseLatestInvoiceBillingReason.Manual)]
    [InlineData(GrantListResponseLatestInvoiceBillingReason.Other)]
    public void SerializationRoundtrip_Works(GrantListResponseLatestInvoiceBillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseLatestInvoiceBillingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponseLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponseLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponseLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GrantListResponseLatestInvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(GrantListResponseLatestInvoiceStatus.Open)]
    [InlineData(GrantListResponseLatestInvoiceStatus.Paid)]
    [InlineData(GrantListResponseLatestInvoiceStatus.Canceled)]
    public void Validation_Works(GrantListResponseLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseLatestInvoiceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponseLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantListResponseLatestInvoiceStatus.Open)]
    [InlineData(GrantListResponseLatestInvoiceStatus.Paid)]
    [InlineData(GrantListResponseLatestInvoiceStatus.Canceled)]
    public void SerializationRoundtrip_Works(GrantListResponseLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseLatestInvoiceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponseLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponseLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponseLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GrantListResponsePaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(GrantListResponsePaymentCollection.NotRequired)]
    [InlineData(GrantListResponsePaymentCollection.Processing)]
    [InlineData(GrantListResponsePaymentCollection.Failed)]
    [InlineData(GrantListResponsePaymentCollection.ActionRequired)]
    public void Validation_Works(GrantListResponsePaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponsePaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponsePaymentCollection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantListResponsePaymentCollection.NotRequired)]
    [InlineData(GrantListResponsePaymentCollection.Processing)]
    [InlineData(GrantListResponsePaymentCollection.Failed)]
    [InlineData(GrantListResponsePaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(GrantListResponsePaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponsePaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponsePaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponsePaymentCollection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, GrantListResponsePaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class GrantListResponseSourceTypeTest : TestBase
{
    [Theory]
    [InlineData(GrantListResponseSourceType.Price)]
    [InlineData(GrantListResponseSourceType.PlanEntitlement)]
    [InlineData(GrantListResponseSourceType.AddonEntitlement)]
    public void Validation_Works(GrantListResponseSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseSourceType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantListResponseSourceType.Price)]
    [InlineData(GrantListResponseSourceType.PlanEntitlement)]
    [InlineData(GrantListResponseSourceType.AddonEntitlement)]
    public void SerializationRoundtrip_Works(GrantListResponseSourceType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseSourceType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseSourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseSourceType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseSourceType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class GrantListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(GrantListResponseStatus.PaymentPending)]
    [InlineData(GrantListResponseStatus.Active)]
    [InlineData(GrantListResponseStatus.Expired)]
    [InlineData(GrantListResponseStatus.Voided)]
    [InlineData(GrantListResponseStatus.Scheduled)]
    public void Validation_Works(GrantListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantListResponseStatus.PaymentPending)]
    [InlineData(GrantListResponseStatus.Active)]
    [InlineData(GrantListResponseStatus.Expired)]
    [InlineData(GrantListResponseStatus.Voided)]
    [InlineData(GrantListResponseStatus.Scheduled)]
    public void SerializationRoundtrip_Works(GrantListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
