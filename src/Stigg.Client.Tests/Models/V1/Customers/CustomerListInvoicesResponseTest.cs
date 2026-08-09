using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerListInvoicesResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListInvoicesResponse
        {
            ContractExternalID = "contractExternalId",
            Currency = "currency",
            CustomerExternalID = "customerExternalId",
            Discount = 0,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceExternalID = "invoiceExternalId",
            InvoiceID = "invoiceId",
            InvoiceNumber = "invoiceNumber",
            IssueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    Amount = 0,
                    Description = "description",
                    ProductExternalID = "productExternalId",
                    Quantity = 0,
                    UnitPrice = 0,
                },
            ],
            PaidDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            State = CustomerListInvoicesResponseState.Open,
            Subtotal = 0,
            Tax = 0,
            Total = 0,
        };

        string expectedContractExternalID = "contractExternalId";
        string expectedCurrency = "currency";
        string expectedCustomerExternalID = "customerExternalId";
        double expectedDiscount = 0;
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInvoiceExternalID = "invoiceExternalId";
        string expectedInvoiceID = "invoiceId";
        string expectedInvoiceNumber = "invoiceNumber";
        DateTimeOffset expectedIssueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<LineItem> expectedLineItems =
        [
            new()
            {
                Amount = 0,
                Description = "description",
                ProductExternalID = "productExternalId",
                Quantity = 0,
                UnitPrice = 0,
            },
        ];
        DateTimeOffset expectedPaidDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CustomerListInvoicesResponseState> expectedState =
            CustomerListInvoicesResponseState.Open;
        double expectedSubtotal = 0;
        double expectedTax = 0;
        double expectedTotal = 0;

        Assert.Equal(expectedContractExternalID, model.ContractExternalID);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedCustomerExternalID, model.CustomerExternalID);
        Assert.Equal(expectedDiscount, model.Discount);
        Assert.Equal(expectedDueDate, model.DueDate);
        Assert.Equal(expectedInvoiceExternalID, model.InvoiceExternalID);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedInvoiceNumber, model.InvoiceNumber);
        Assert.Equal(expectedIssueDate, model.IssueDate);
        Assert.Equal(expectedLineItems.Count, model.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], model.LineItems[i]);
        }
        Assert.Equal(expectedPaidDate, model.PaidDate);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedSubtotal, model.Subtotal);
        Assert.Equal(expectedTax, model.Tax);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListInvoicesResponse
        {
            ContractExternalID = "contractExternalId",
            Currency = "currency",
            CustomerExternalID = "customerExternalId",
            Discount = 0,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceExternalID = "invoiceExternalId",
            InvoiceID = "invoiceId",
            InvoiceNumber = "invoiceNumber",
            IssueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    Amount = 0,
                    Description = "description",
                    ProductExternalID = "productExternalId",
                    Quantity = 0,
                    UnitPrice = 0,
                },
            ],
            PaidDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            State = CustomerListInvoicesResponseState.Open,
            Subtotal = 0,
            Tax = 0,
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListInvoicesResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListInvoicesResponse
        {
            ContractExternalID = "contractExternalId",
            Currency = "currency",
            CustomerExternalID = "customerExternalId",
            Discount = 0,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceExternalID = "invoiceExternalId",
            InvoiceID = "invoiceId",
            InvoiceNumber = "invoiceNumber",
            IssueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    Amount = 0,
                    Description = "description",
                    ProductExternalID = "productExternalId",
                    Quantity = 0,
                    UnitPrice = 0,
                },
            ],
            PaidDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            State = CustomerListInvoicesResponseState.Open,
            Subtotal = 0,
            Tax = 0,
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListInvoicesResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedContractExternalID = "contractExternalId";
        string expectedCurrency = "currency";
        string expectedCustomerExternalID = "customerExternalId";
        double expectedDiscount = 0;
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInvoiceExternalID = "invoiceExternalId";
        string expectedInvoiceID = "invoiceId";
        string expectedInvoiceNumber = "invoiceNumber";
        DateTimeOffset expectedIssueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        List<LineItem> expectedLineItems =
        [
            new()
            {
                Amount = 0,
                Description = "description",
                ProductExternalID = "productExternalId",
                Quantity = 0,
                UnitPrice = 0,
            },
        ];
        DateTimeOffset expectedPaidDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CustomerListInvoicesResponseState> expectedState =
            CustomerListInvoicesResponseState.Open;
        double expectedSubtotal = 0;
        double expectedTax = 0;
        double expectedTotal = 0;

        Assert.Equal(expectedContractExternalID, deserialized.ContractExternalID);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedCustomerExternalID, deserialized.CustomerExternalID);
        Assert.Equal(expectedDiscount, deserialized.Discount);
        Assert.Equal(expectedDueDate, deserialized.DueDate);
        Assert.Equal(expectedInvoiceExternalID, deserialized.InvoiceExternalID);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedInvoiceNumber, deserialized.InvoiceNumber);
        Assert.Equal(expectedIssueDate, deserialized.IssueDate);
        Assert.Equal(expectedLineItems.Count, deserialized.LineItems.Count);
        for (int i = 0; i < expectedLineItems.Count; i++)
        {
            Assert.Equal(expectedLineItems[i], deserialized.LineItems[i]);
        }
        Assert.Equal(expectedPaidDate, deserialized.PaidDate);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedSubtotal, deserialized.Subtotal);
        Assert.Equal(expectedTax, deserialized.Tax);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListInvoicesResponse
        {
            ContractExternalID = "contractExternalId",
            Currency = "currency",
            CustomerExternalID = "customerExternalId",
            Discount = 0,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceExternalID = "invoiceExternalId",
            InvoiceID = "invoiceId",
            InvoiceNumber = "invoiceNumber",
            IssueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    Amount = 0,
                    Description = "description",
                    ProductExternalID = "productExternalId",
                    Quantity = 0,
                    UnitPrice = 0,
                },
            ],
            PaidDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            State = CustomerListInvoicesResponseState.Open,
            Subtotal = 0,
            Tax = 0,
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListInvoicesResponse
        {
            ContractExternalID = "contractExternalId",
            Currency = "currency",
            CustomerExternalID = "customerExternalId",
            Discount = 0,
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceExternalID = "invoiceExternalId",
            InvoiceID = "invoiceId",
            InvoiceNumber = "invoiceNumber",
            IssueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            LineItems =
            [
                new()
                {
                    Amount = 0,
                    Description = "description",
                    ProductExternalID = "productExternalId",
                    Quantity = 0,
                    UnitPrice = 0,
                },
            ],
            PaidDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            State = CustomerListInvoicesResponseState.Open,
            Subtotal = 0,
            Tax = 0,
            Total = 0,
        };

        CustomerListInvoicesResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class LineItemTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new LineItem
        {
            Amount = 0,
            Description = "description",
            ProductExternalID = "productExternalId",
            Quantity = 0,
            UnitPrice = 0,
        };

        double expectedAmount = 0;
        string expectedDescription = "description";
        string expectedProductExternalID = "productExternalId";
        double expectedQuantity = 0;
        double expectedUnitPrice = 0;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedProductExternalID, model.ProductExternalID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedUnitPrice, model.UnitPrice);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LineItem
        {
            Amount = 0,
            Description = "description",
            ProductExternalID = "productExternalId",
            Quantity = 0,
            UnitPrice = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineItem>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new LineItem
        {
            Amount = 0,
            Description = "description",
            ProductExternalID = "productExternalId",
            Quantity = 0,
            UnitPrice = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LineItem>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedDescription = "description";
        string expectedProductExternalID = "productExternalId";
        double expectedQuantity = 0;
        double expectedUnitPrice = 0;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedProductExternalID, deserialized.ProductExternalID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedUnitPrice, deserialized.UnitPrice);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LineItem
        {
            Amount = 0,
            Description = "description",
            ProductExternalID = "productExternalId",
            Quantity = 0,
            UnitPrice = 0,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LineItem
        {
            Amount = 0,
            Description = "description",
            ProductExternalID = "productExternalId",
            Quantity = 0,
            UnitPrice = 0,
        };

        LineItem copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListInvoicesResponseStateTest : TestBase
{
    [Theory]
    [InlineData(CustomerListInvoicesResponseState.Open)]
    [InlineData(CustomerListInvoicesResponseState.Canceled)]
    [InlineData(CustomerListInvoicesResponseState.Paid)]
    public void Validation_Works(CustomerListInvoicesResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListInvoicesResponseState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerListInvoicesResponseState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CustomerListInvoicesResponseState.Open)]
    [InlineData(CustomerListInvoicesResponseState.Canceled)]
    [InlineData(CustomerListInvoicesResponseState.Paid)]
    public void SerializationRoundtrip_Works(CustomerListInvoicesResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CustomerListInvoicesResponseState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListInvoicesResponseState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CustomerListInvoicesResponseState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CustomerListInvoicesResponseState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
