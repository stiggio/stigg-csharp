using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Tests.Models.V1.Contracts;

public class ContractListPageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = ContractListResponseBillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = ContractListResponseLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason = ContractListResponseLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new()
                        {
                            Amount = 0,
                            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
                        },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = ContractListResponseState.Draft,
                    Subscriptions =
                    [
                        new()
                        {
                            PlanDisplayName = "planDisplayName",
                            ProductDisplayName = "productDisplayName",
                            SubscriptionID = "subscriptionId",
                        },
                    ],
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        List<ContractListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractListResponseBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractListResponseLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason = ContractListResponseLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Name = "name",
                NextInvoice = new()
                {
                    Amount = new()
                    {
                        Amount = 0,
                        Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractListResponseState.Draft,
                Subscriptions =
                [
                    new()
                    {
                        PlanDisplayName = "planDisplayName",
                        ProductDisplayName = "productDisplayName",
                        SubscriptionID = "subscriptionId",
                    },
                ],
            },
        ];
        Pagination expectedPagination = new() { Next = "next", Prev = "prev" };

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
        var model = new ContractListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = ContractListResponseBillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = ContractListResponseLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason = ContractListResponseLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new()
                        {
                            Amount = 0,
                            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
                        },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = ContractListResponseState.Draft,
                    Subscriptions =
                    [
                        new()
                        {
                            PlanDisplayName = "planDisplayName",
                            ProductDisplayName = "productDisplayName",
                            SubscriptionID = "subscriptionId",
                        },
                    ],
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListPageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = ContractListResponseBillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = ContractListResponseLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason = ContractListResponseLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new()
                        {
                            Amount = 0,
                            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
                        },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = ContractListResponseState.Draft,
                    Subscriptions =
                    [
                        new()
                        {
                            PlanDisplayName = "planDisplayName",
                            ProductDisplayName = "productDisplayName",
                            SubscriptionID = "subscriptionId",
                        },
                    ],
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListPageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<ContractListResponse> expectedData =
        [
            new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractListResponseBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractListResponseLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason = ContractListResponseLatestInvoiceBillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Name = "name",
                NextInvoice = new()
                {
                    Amount = new()
                    {
                        Amount = 0,
                        Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractListResponseState.Draft,
                Subscriptions =
                [
                    new()
                    {
                        PlanDisplayName = "planDisplayName",
                        ProductDisplayName = "productDisplayName",
                        SubscriptionID = "subscriptionId",
                    },
                ],
            },
        ];
        Pagination expectedPagination = new() { Next = "next", Prev = "prev" };

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
        var model = new ContractListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = ContractListResponseBillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = ContractListResponseLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason = ContractListResponseLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new()
                        {
                            Amount = 0,
                            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
                        },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = ContractListResponseState.Draft,
                    Subscriptions =
                    [
                        new()
                        {
                            PlanDisplayName = "planDisplayName",
                            ProductDisplayName = "productDisplayName",
                            SubscriptionID = "subscriptionId",
                        },
                    ],
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractListPageResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = ContractListResponseBillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = ContractListResponseLatestInvoiceStatus.Open,
                        AmountDue = 0,
                        BillingReason = ContractListResponseLatestInvoiceBillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new()
                        {
                            Amount = 0,
                            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
                        },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = ContractListResponseState.Draft,
                    Subscriptions =
                    [
                        new()
                        {
                            PlanDisplayName = "planDisplayName",
                            ProductDisplayName = "productDisplayName",
                            SubscriptionID = "subscriptionId",
                        },
                    ],
                },
            ],
            Pagination = new() { Next = "next", Prev = "prev" },
        };

        ContractListPageResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaginationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        string expectedNext = "next";
        string expectedPrev = "prev";

        Assert.Equal(expectedNext, model.Next);
        Assert.Equal(expectedPrev, model.Prev);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

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
        var model = new Pagination { Next = "next", Prev = "prev" };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Pagination>(
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
        var model = new Pagination { Next = "next", Prev = "prev" };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Pagination { Next = "next", Prev = "prev" };

        Pagination copied = new(model);

        Assert.Equal(model, copied);
    }
}
