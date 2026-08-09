using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerListInvoicesPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListInvoicesPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        List<CustomerListInvoicesResponse> expectedData =
        [
            new()
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
            },
        ];
        CustomerListInvoicesPageResponsePagination expectedPagination = new()
        {
            Next = "next",
            Prev = "prev",
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
        var model = new CustomerListInvoicesPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListInvoicesPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListInvoicesPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListInvoicesPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CustomerListInvoicesResponse> expectedData =
        [
            new()
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
            },
        ];
        CustomerListInvoicesPageResponsePagination expectedPagination = new()
        {
            Next = "next",
            Prev = "prev",
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
        var model = new CustomerListInvoicesPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListInvoicesPageResponse
        {
            Data =
            [
                new()
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
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        CustomerListInvoicesPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListInvoicesPageResponsePaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListInvoicesPageResponsePagination { Next = "next", Prev = "prev" };

        string expectedNext = "next";
        string expectedPrev = "prev";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListInvoicesPageResponsePagination { Next = "next", Prev = "prev" };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListInvoicesPageResponsePagination>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListInvoicesPageResponsePagination { Next = "next", Prev = "prev" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListInvoicesPageResponsePagination>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedNext = "next";
        string expectedPrev = "prev";

        Assert.Equal(expectedNext, deserialized.Next);
        Assert.Equal(expectedPrev, deserialized.Prev);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListInvoicesPageResponsePagination { Next = "next", Prev = "prev" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListInvoicesPageResponsePagination { Next = "next", Prev = "prev" };

        CustomerListInvoicesPageResponsePagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
