using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerListContractsResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListContractsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = BillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = Status.Open,
                        AmountDue = 0,
                        BillingReason = BillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InvoiceID = "invoiceId",
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = State.Draft,
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
        };

        List<CustomerListContractsResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = BillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = Status.Open,
                    AmountDue = 0,
                    BillingReason = BillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Name = "name",
                NextInvoice = new()
                {
                    Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = State.Draft,
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

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListContractsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = BillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = Status.Open,
                        AmountDue = 0,
                        BillingReason = BillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InvoiceID = "invoiceId",
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = State.Draft,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListContractsResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListContractsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = BillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = Status.Open,
                        AmountDue = 0,
                        BillingReason = BillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InvoiceID = "invoiceId",
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = State.Draft,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListContractsResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CustomerListContractsResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = BillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = Status.Open,
                    AmountDue = 0,
                    BillingReason = BillingReason.BillingCycle,
                    Currency = "currency",
                    PdfUrl = "pdfUrl",
                    Total = 0,
                },
                Name = "name",
                NextInvoice = new()
                {
                    Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = State.Draft,
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

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListContractsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = BillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = Status.Open,
                        AmountDue = 0,
                        BillingReason = BillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InvoiceID = "invoiceId",
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = State.Draft,
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListContractsResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    BillingID = "billingId",
                    BillingState = BillingState.Draft,
                    ContractID = "contractId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerExternalID = "customerExternalId",
                    ExternalID = "externalId",
                    LatestInvoice = new()
                    {
                        BillingID = "billingId",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        RequiresAction = true,
                        Status = Status.Open,
                        AmountDue = 0,
                        BillingReason = BillingReason.BillingCycle,
                        Currency = "currency",
                        PdfUrl = "pdfUrl",
                        Total = 0,
                    },
                    Name = "name",
                    NextInvoice = new()
                    {
                        Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                        DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        InvoiceID = "invoiceId",
                        PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    },
                    PoNumber = "poNumber",
                    RefID = "refId",
                    State = State.Draft,
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
        };

        CustomerListContractsResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerListContractsResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerListContractsResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = BillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = Status.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Name = "name",
            NextInvoice = new()
            {
                Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = State.Draft,
            Subscriptions =
            [
                new()
                {
                    PlanDisplayName = "planDisplayName",
                    ProductDisplayName = "productDisplayName",
                    SubscriptionID = "subscriptionId",
                },
            ],
        };

        string expectedID = "id";
        DateTimeOffset expectedActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedActivationStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedBillingID = "billingId";
        ApiEnum<string, BillingState> expectedBillingState = BillingState.Draft;
        string expectedContractID = "contractId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerExternalID = "customerExternalId";
        string expectedExternalID = "externalId";
        LatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        string expectedName = "name";
        NextInvoice expectedNextInvoice = new()
        {
            Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, State> expectedState = State.Draft;
        List<Subscription> expectedSubscriptions =
        [
            new()
            {
                PlanDisplayName = "planDisplayName",
                ProductDisplayName = "productDisplayName",
                SubscriptionID = "subscriptionId",
            },
        ];

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedActivationEndDate, model.ActivationEndDate);
        Assert.Equal(expectedActivationStartDate, model.ActivationStartDate);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedBillingState, model.BillingState);
        Assert.Equal(expectedContractID, model.ContractID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerExternalID, model.CustomerExternalID);
        Assert.Equal(expectedExternalID, model.ExternalID);
        Assert.Equal(expectedLatestInvoice, model.LatestInvoice);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedNextInvoice, model.NextInvoice);
        Assert.Equal(expectedPoNumber, model.PoNumber);
        Assert.Equal(expectedRefID, model.RefID);
        Assert.Equal(expectedState, model.State);
        Assert.Equal(expectedSubscriptions.Count, model.Subscriptions.Count);
        for (int i = 0; i < expectedSubscriptions.Count; i++)
        {
            Assert.Equal(expectedSubscriptions[i], model.Subscriptions[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerListContractsResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = BillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = Status.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Name = "name",
            NextInvoice = new()
            {
                Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = State.Draft,
            Subscriptions =
            [
                new()
                {
                    PlanDisplayName = "planDisplayName",
                    ProductDisplayName = "productDisplayName",
                    SubscriptionID = "subscriptionId",
                },
            ],
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListContractsResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerListContractsResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = BillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = Status.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Name = "name",
            NextInvoice = new()
            {
                Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = State.Draft,
            Subscriptions =
            [
                new()
                {
                    PlanDisplayName = "planDisplayName",
                    ProductDisplayName = "productDisplayName",
                    SubscriptionID = "subscriptionId",
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerListContractsResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedActivationStartDate = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        string expectedBillingID = "billingId";
        ApiEnum<string, BillingState> expectedBillingState = BillingState.Draft;
        string expectedContractID = "contractId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerExternalID = "customerExternalId";
        string expectedExternalID = "externalId";
        LatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        string expectedName = "name";
        NextInvoice expectedNextInvoice = new()
        {
            Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, State> expectedState = State.Draft;
        List<Subscription> expectedSubscriptions =
        [
            new()
            {
                PlanDisplayName = "planDisplayName",
                ProductDisplayName = "productDisplayName",
                SubscriptionID = "subscriptionId",
            },
        ];

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedActivationEndDate, deserialized.ActivationEndDate);
        Assert.Equal(expectedActivationStartDate, deserialized.ActivationStartDate);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedBillingState, deserialized.BillingState);
        Assert.Equal(expectedContractID, deserialized.ContractID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerExternalID, deserialized.CustomerExternalID);
        Assert.Equal(expectedExternalID, deserialized.ExternalID);
        Assert.Equal(expectedLatestInvoice, deserialized.LatestInvoice);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedNextInvoice, deserialized.NextInvoice);
        Assert.Equal(expectedPoNumber, deserialized.PoNumber);
        Assert.Equal(expectedRefID, deserialized.RefID);
        Assert.Equal(expectedState, deserialized.State);
        Assert.Equal(expectedSubscriptions.Count, deserialized.Subscriptions.Count);
        for (int i = 0; i < expectedSubscriptions.Count; i++)
        {
            Assert.Equal(expectedSubscriptions[i], deserialized.Subscriptions[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerListContractsResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = BillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = Status.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Name = "name",
            NextInvoice = new()
            {
                Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = State.Draft,
            Subscriptions =
            [
                new()
                {
                    PlanDisplayName = "planDisplayName",
                    ProductDisplayName = "productDisplayName",
                    SubscriptionID = "subscriptionId",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerListContractsResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = BillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = Status.Open,
                AmountDue = 0,
                BillingReason = BillingReason.BillingCycle,
                Currency = "currency",
                PdfUrl = "pdfUrl",
                Total = 0,
            },
            Name = "name",
            NextInvoice = new()
            {
                Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = State.Draft,
            Subscriptions =
            [
                new()
                {
                    PlanDisplayName = "planDisplayName",
                    ProductDisplayName = "productDisplayName",
                    SubscriptionID = "subscriptionId",
                },
            ],
        };

        CustomerListContractsResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingStateTest : TestBase
{
    [Theory]
    [InlineData(BillingState.Draft)]
    [InlineData(BillingState.Active)]
    [InlineData(BillingState.Canceled)]
    [InlineData(BillingState.EndBilling)]
    public void Validation_Works(BillingState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(BillingState.Draft)]
    [InlineData(BillingState.Active)]
    [InlineData(BillingState.Canceled)]
    [InlineData(BillingState.EndBilling)]
    public void SerializationRoundtrip_Works(BillingState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, BillingState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, BillingState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, BillingState>>(
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, Status> expectedStatus = Status.Open;
        double expectedAmountDue = 0;
        ApiEnum<string, BillingReason> expectedBillingReason = BillingReason.BillingCycle;
        string expectedCurrency = "currency";
        string expectedPdfUrl = "pdfUrl";
        double expectedTotal = 0;

        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedRequiresAction, model.RequiresAction);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedAmountDue, model.AmountDue);
        Assert.Equal(expectedBillingReason, model.BillingReason);
        Assert.Equal(expectedCurrency, model.Currency);
        Assert.Equal(expectedPdfUrl, model.PdfUrl);
        Assert.Equal(expectedTotal, model.Total);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
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
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<LatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, Status> expectedStatus = Status.Open;
        double expectedAmountDue = 0;
        ApiEnum<string, BillingReason> expectedBillingReason = BillingReason.BillingCycle;
        string expectedCurrency = "currency";
        string expectedPdfUrl = "pdfUrl";
        double expectedTotal = 0;

        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedRequiresAction, deserialized.RequiresAction);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedAmountDue, deserialized.AmountDue);
        Assert.Equal(expectedBillingReason, deserialized.BillingReason);
        Assert.Equal(expectedCurrency, deserialized.Currency);
        Assert.Equal(expectedPdfUrl, deserialized.PdfUrl);
        Assert.Equal(expectedTotal, deserialized.Total);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
        };

        Assert.Null(model.AmountDue);
        Assert.False(model.RawData.ContainsKey("amountDue"));
        Assert.Null(model.BillingReason);
        Assert.False(model.RawData.ContainsKey("billingReason"));
        Assert.Null(model.Currency);
        Assert.False(model.RawData.ContainsKey("currency"));
        Assert.Null(model.PdfUrl);
        Assert.False(model.RawData.ContainsKey("pdfUrl"));
        Assert.Null(model.Total);
        Assert.False(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,

            AmountDue = null,
            BillingReason = null,
            Currency = null,
            PdfUrl = null,
            Total = null,
        };

        Assert.Null(model.AmountDue);
        Assert.True(model.RawData.ContainsKey("amountDue"));
        Assert.Null(model.BillingReason);
        Assert.True(model.RawData.ContainsKey("billingReason"));
        Assert.Null(model.Currency);
        Assert.True(model.RawData.ContainsKey("currency"));
        Assert.Null(model.PdfUrl);
        Assert.True(model.RawData.ContainsKey("pdfUrl"));
        Assert.Null(model.Total);
        Assert.True(model.RawData.ContainsKey("total"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,

            AmountDue = null,
            BillingReason = null,
            Currency = null,
            PdfUrl = null,
            Total = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new LatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = Status.Open,
            AmountDue = 0,
            BillingReason = BillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        LatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Open)]
    [InlineData(Status.Canceled)]
    [InlineData(Status.Paid)]
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
    [InlineData(Status.Canceled)]
    [InlineData(Status.Paid)]
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

public class BillingReasonTest : TestBase
{
    [Theory]
    [InlineData(BillingReason.BillingCycle)]
    [InlineData(BillingReason.SubscriptionCreation)]
    [InlineData(BillingReason.SubscriptionUpdate)]
    [InlineData(BillingReason.Manual)]
    [InlineData(BillingReason.MinimumInvoiceAmountExceeded)]
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
    [InlineData(BillingReason.BillingCycle)]
    [InlineData(BillingReason.SubscriptionCreation)]
    [InlineData(BillingReason.SubscriptionUpdate)]
    [InlineData(BillingReason.Manual)]
    [InlineData(BillingReason.MinimumInvoiceAmountExceeded)]
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

public class NextInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new NextInvoice
        {
            Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Amount expectedAmount = new() { AmountValue = 0, Currency = AmountCurrency.Usd };
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInvoiceID = "invoiceId";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedDueDate, model.DueDate);
        Assert.Equal(expectedInvoiceID, model.InvoiceID);
        Assert.Equal(expectedPeriodEnd, model.PeriodEnd);
        Assert.Equal(expectedPeriodStart, model.PeriodStart);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new NextInvoice
        {
            Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NextInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new NextInvoice
        {
            Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<NextInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Amount expectedAmount = new() { AmountValue = 0, Currency = AmountCurrency.Usd };
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedInvoiceID = "invoiceId";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedDueDate, deserialized.DueDate);
        Assert.Equal(expectedInvoiceID, deserialized.InvoiceID);
        Assert.Equal(expectedPeriodEnd, deserialized.PeriodEnd);
        Assert.Equal(expectedPeriodStart, deserialized.PeriodStart);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new NextInvoice
        {
            Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new NextInvoice
        {
            Amount = new() { AmountValue = 0, Currency = AmountCurrency.Usd },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        NextInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Amount { AmountValue = 0, Currency = AmountCurrency.Usd };

        double expectedAmountValue = 0;
        ApiEnum<string, AmountCurrency> expectedCurrency = AmountCurrency.Usd;

        Assert.Equal(expectedAmountValue, model.AmountValue);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Amount { AmountValue = 0, Currency = AmountCurrency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Amount>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Amount { AmountValue = 0, Currency = AmountCurrency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Amount>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedAmountValue = 0;
        ApiEnum<string, AmountCurrency> expectedCurrency = AmountCurrency.Usd;

        Assert.Equal(expectedAmountValue, deserialized.AmountValue);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Amount { AmountValue = 0, Currency = AmountCurrency.Usd };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Amount { AmountValue = 0, Currency = AmountCurrency.Usd };

        Amount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class AmountCurrencyTest : TestBase
{
    [Theory]
    [InlineData(AmountCurrency.Usd)]
    [InlineData(AmountCurrency.Aed)]
    [InlineData(AmountCurrency.All)]
    [InlineData(AmountCurrency.Amd)]
    [InlineData(AmountCurrency.Ang)]
    [InlineData(AmountCurrency.Aud)]
    [InlineData(AmountCurrency.Awg)]
    [InlineData(AmountCurrency.Azn)]
    [InlineData(AmountCurrency.Bam)]
    [InlineData(AmountCurrency.Bbd)]
    [InlineData(AmountCurrency.Bdt)]
    [InlineData(AmountCurrency.Bgn)]
    [InlineData(AmountCurrency.Bif)]
    [InlineData(AmountCurrency.Bmd)]
    [InlineData(AmountCurrency.Bnd)]
    [InlineData(AmountCurrency.Bsd)]
    [InlineData(AmountCurrency.Bwp)]
    [InlineData(AmountCurrency.Byn)]
    [InlineData(AmountCurrency.Bzd)]
    [InlineData(AmountCurrency.Brl)]
    [InlineData(AmountCurrency.Cad)]
    [InlineData(AmountCurrency.Cdf)]
    [InlineData(AmountCurrency.Chf)]
    [InlineData(AmountCurrency.Cny)]
    [InlineData(AmountCurrency.Czk)]
    [InlineData(AmountCurrency.Dkk)]
    [InlineData(AmountCurrency.Dop)]
    [InlineData(AmountCurrency.Dzd)]
    [InlineData(AmountCurrency.Egp)]
    [InlineData(AmountCurrency.Etb)]
    [InlineData(AmountCurrency.Eur)]
    [InlineData(AmountCurrency.Fjd)]
    [InlineData(AmountCurrency.Gbp)]
    [InlineData(AmountCurrency.Gel)]
    [InlineData(AmountCurrency.Gip)]
    [InlineData(AmountCurrency.Gmd)]
    [InlineData(AmountCurrency.Gyd)]
    [InlineData(AmountCurrency.Hkd)]
    [InlineData(AmountCurrency.Hrk)]
    [InlineData(AmountCurrency.Htg)]
    [InlineData(AmountCurrency.Idr)]
    [InlineData(AmountCurrency.Ils)]
    [InlineData(AmountCurrency.Inr)]
    [InlineData(AmountCurrency.Isk)]
    [InlineData(AmountCurrency.Jmd)]
    [InlineData(AmountCurrency.Jpy)]
    [InlineData(AmountCurrency.Kes)]
    [InlineData(AmountCurrency.Kgs)]
    [InlineData(AmountCurrency.Khr)]
    [InlineData(AmountCurrency.Kmf)]
    [InlineData(AmountCurrency.Krw)]
    [InlineData(AmountCurrency.Kyd)]
    [InlineData(AmountCurrency.Kzt)]
    [InlineData(AmountCurrency.Lbp)]
    [InlineData(AmountCurrency.Lkr)]
    [InlineData(AmountCurrency.Lrd)]
    [InlineData(AmountCurrency.Lsl)]
    [InlineData(AmountCurrency.Mad)]
    [InlineData(AmountCurrency.Mdl)]
    [InlineData(AmountCurrency.Mga)]
    [InlineData(AmountCurrency.Mkd)]
    [InlineData(AmountCurrency.Mmk)]
    [InlineData(AmountCurrency.Mnt)]
    [InlineData(AmountCurrency.Mop)]
    [InlineData(AmountCurrency.Mro)]
    [InlineData(AmountCurrency.Mvr)]
    [InlineData(AmountCurrency.Mwk)]
    [InlineData(AmountCurrency.Mxn)]
    [InlineData(AmountCurrency.Myr)]
    [InlineData(AmountCurrency.Mzn)]
    [InlineData(AmountCurrency.Nad)]
    [InlineData(AmountCurrency.Ngn)]
    [InlineData(AmountCurrency.Nok)]
    [InlineData(AmountCurrency.Npr)]
    [InlineData(AmountCurrency.Nzd)]
    [InlineData(AmountCurrency.Pgk)]
    [InlineData(AmountCurrency.Php)]
    [InlineData(AmountCurrency.Pkr)]
    [InlineData(AmountCurrency.Pln)]
    [InlineData(AmountCurrency.Qar)]
    [InlineData(AmountCurrency.Ron)]
    [InlineData(AmountCurrency.Rsd)]
    [InlineData(AmountCurrency.Rub)]
    [InlineData(AmountCurrency.Rwf)]
    [InlineData(AmountCurrency.Sar)]
    [InlineData(AmountCurrency.Sbd)]
    [InlineData(AmountCurrency.Scr)]
    [InlineData(AmountCurrency.Sek)]
    [InlineData(AmountCurrency.Sgd)]
    [InlineData(AmountCurrency.Sle)]
    [InlineData(AmountCurrency.Sll)]
    [InlineData(AmountCurrency.Sos)]
    [InlineData(AmountCurrency.Szl)]
    [InlineData(AmountCurrency.Thb)]
    [InlineData(AmountCurrency.Tjs)]
    [InlineData(AmountCurrency.Top)]
    [InlineData(AmountCurrency.Try)]
    [InlineData(AmountCurrency.Ttd)]
    [InlineData(AmountCurrency.Tzs)]
    [InlineData(AmountCurrency.Uah)]
    [InlineData(AmountCurrency.Uzs)]
    [InlineData(AmountCurrency.Vnd)]
    [InlineData(AmountCurrency.Vuv)]
    [InlineData(AmountCurrency.Wst)]
    [InlineData(AmountCurrency.Xaf)]
    [InlineData(AmountCurrency.Xcd)]
    [InlineData(AmountCurrency.Yer)]
    [InlineData(AmountCurrency.Zar)]
    [InlineData(AmountCurrency.Zmw)]
    [InlineData(AmountCurrency.Clp)]
    [InlineData(AmountCurrency.Djf)]
    [InlineData(AmountCurrency.Gnf)]
    [InlineData(AmountCurrency.Ugx)]
    [InlineData(AmountCurrency.Pyg)]
    [InlineData(AmountCurrency.Xof)]
    [InlineData(AmountCurrency.Xpf)]
    public void Validation_Works(AmountCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(AmountCurrency.Usd)]
    [InlineData(AmountCurrency.Aed)]
    [InlineData(AmountCurrency.All)]
    [InlineData(AmountCurrency.Amd)]
    [InlineData(AmountCurrency.Ang)]
    [InlineData(AmountCurrency.Aud)]
    [InlineData(AmountCurrency.Awg)]
    [InlineData(AmountCurrency.Azn)]
    [InlineData(AmountCurrency.Bam)]
    [InlineData(AmountCurrency.Bbd)]
    [InlineData(AmountCurrency.Bdt)]
    [InlineData(AmountCurrency.Bgn)]
    [InlineData(AmountCurrency.Bif)]
    [InlineData(AmountCurrency.Bmd)]
    [InlineData(AmountCurrency.Bnd)]
    [InlineData(AmountCurrency.Bsd)]
    [InlineData(AmountCurrency.Bwp)]
    [InlineData(AmountCurrency.Byn)]
    [InlineData(AmountCurrency.Bzd)]
    [InlineData(AmountCurrency.Brl)]
    [InlineData(AmountCurrency.Cad)]
    [InlineData(AmountCurrency.Cdf)]
    [InlineData(AmountCurrency.Chf)]
    [InlineData(AmountCurrency.Cny)]
    [InlineData(AmountCurrency.Czk)]
    [InlineData(AmountCurrency.Dkk)]
    [InlineData(AmountCurrency.Dop)]
    [InlineData(AmountCurrency.Dzd)]
    [InlineData(AmountCurrency.Egp)]
    [InlineData(AmountCurrency.Etb)]
    [InlineData(AmountCurrency.Eur)]
    [InlineData(AmountCurrency.Fjd)]
    [InlineData(AmountCurrency.Gbp)]
    [InlineData(AmountCurrency.Gel)]
    [InlineData(AmountCurrency.Gip)]
    [InlineData(AmountCurrency.Gmd)]
    [InlineData(AmountCurrency.Gyd)]
    [InlineData(AmountCurrency.Hkd)]
    [InlineData(AmountCurrency.Hrk)]
    [InlineData(AmountCurrency.Htg)]
    [InlineData(AmountCurrency.Idr)]
    [InlineData(AmountCurrency.Ils)]
    [InlineData(AmountCurrency.Inr)]
    [InlineData(AmountCurrency.Isk)]
    [InlineData(AmountCurrency.Jmd)]
    [InlineData(AmountCurrency.Jpy)]
    [InlineData(AmountCurrency.Kes)]
    [InlineData(AmountCurrency.Kgs)]
    [InlineData(AmountCurrency.Khr)]
    [InlineData(AmountCurrency.Kmf)]
    [InlineData(AmountCurrency.Krw)]
    [InlineData(AmountCurrency.Kyd)]
    [InlineData(AmountCurrency.Kzt)]
    [InlineData(AmountCurrency.Lbp)]
    [InlineData(AmountCurrency.Lkr)]
    [InlineData(AmountCurrency.Lrd)]
    [InlineData(AmountCurrency.Lsl)]
    [InlineData(AmountCurrency.Mad)]
    [InlineData(AmountCurrency.Mdl)]
    [InlineData(AmountCurrency.Mga)]
    [InlineData(AmountCurrency.Mkd)]
    [InlineData(AmountCurrency.Mmk)]
    [InlineData(AmountCurrency.Mnt)]
    [InlineData(AmountCurrency.Mop)]
    [InlineData(AmountCurrency.Mro)]
    [InlineData(AmountCurrency.Mvr)]
    [InlineData(AmountCurrency.Mwk)]
    [InlineData(AmountCurrency.Mxn)]
    [InlineData(AmountCurrency.Myr)]
    [InlineData(AmountCurrency.Mzn)]
    [InlineData(AmountCurrency.Nad)]
    [InlineData(AmountCurrency.Ngn)]
    [InlineData(AmountCurrency.Nok)]
    [InlineData(AmountCurrency.Npr)]
    [InlineData(AmountCurrency.Nzd)]
    [InlineData(AmountCurrency.Pgk)]
    [InlineData(AmountCurrency.Php)]
    [InlineData(AmountCurrency.Pkr)]
    [InlineData(AmountCurrency.Pln)]
    [InlineData(AmountCurrency.Qar)]
    [InlineData(AmountCurrency.Ron)]
    [InlineData(AmountCurrency.Rsd)]
    [InlineData(AmountCurrency.Rub)]
    [InlineData(AmountCurrency.Rwf)]
    [InlineData(AmountCurrency.Sar)]
    [InlineData(AmountCurrency.Sbd)]
    [InlineData(AmountCurrency.Scr)]
    [InlineData(AmountCurrency.Sek)]
    [InlineData(AmountCurrency.Sgd)]
    [InlineData(AmountCurrency.Sle)]
    [InlineData(AmountCurrency.Sll)]
    [InlineData(AmountCurrency.Sos)]
    [InlineData(AmountCurrency.Szl)]
    [InlineData(AmountCurrency.Thb)]
    [InlineData(AmountCurrency.Tjs)]
    [InlineData(AmountCurrency.Top)]
    [InlineData(AmountCurrency.Try)]
    [InlineData(AmountCurrency.Ttd)]
    [InlineData(AmountCurrency.Tzs)]
    [InlineData(AmountCurrency.Uah)]
    [InlineData(AmountCurrency.Uzs)]
    [InlineData(AmountCurrency.Vnd)]
    [InlineData(AmountCurrency.Vuv)]
    [InlineData(AmountCurrency.Wst)]
    [InlineData(AmountCurrency.Xaf)]
    [InlineData(AmountCurrency.Xcd)]
    [InlineData(AmountCurrency.Yer)]
    [InlineData(AmountCurrency.Zar)]
    [InlineData(AmountCurrency.Zmw)]
    [InlineData(AmountCurrency.Clp)]
    [InlineData(AmountCurrency.Djf)]
    [InlineData(AmountCurrency.Gnf)]
    [InlineData(AmountCurrency.Ugx)]
    [InlineData(AmountCurrency.Pyg)]
    [InlineData(AmountCurrency.Xof)]
    [InlineData(AmountCurrency.Xpf)]
    public void SerializationRoundtrip_Works(AmountCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, AmountCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AmountCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, AmountCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, AmountCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StateTest : TestBase
{
    [Theory]
    [InlineData(State.Draft)]
    [InlineData(State.Active)]
    [InlineData(State.Canceled)]
    [InlineData(State.EndBilling)]
    public void Validation_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(State.Draft)]
    [InlineData(State.Active)]
    [InlineData(State.Canceled)]
    [InlineData(State.EndBilling)]
    public void SerializationRoundtrip_Works(State rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, State> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, State>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string expectedPlanDisplayName = "planDisplayName";
        string expectedProductDisplayName = "productDisplayName";
        string expectedSubscriptionID = "subscriptionId";

        Assert.Equal(expectedPlanDisplayName, model.PlanDisplayName);
        Assert.Equal(expectedProductDisplayName, model.ProductDisplayName);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Subscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedPlanDisplayName = "planDisplayName";
        string expectedProductDisplayName = "productDisplayName";
        string expectedSubscriptionID = "subscriptionId";

        Assert.Equal(expectedPlanDisplayName, deserialized.PlanDisplayName);
        Assert.Equal(expectedProductDisplayName, deserialized.ProductDisplayName);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
