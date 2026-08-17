using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Tests.Models.V1.Contracts;

public class ContractRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractRetrieveResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractRetrieveResponseDataState.Draft,
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
        };

        ContractRetrieveResponseData expectedData = new()
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractRetrieveResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractRetrieveResponseDataState.Draft,
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

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContractRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractRetrieveResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractRetrieveResponseDataState.Draft,
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractRetrieveResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractRetrieveResponseDataState.Draft,
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContractRetrieveResponseData expectedData = new()
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractRetrieveResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractRetrieveResponseDataState.Draft,
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

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContractRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractRetrieveResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractRetrieveResponseDataState.Draft,
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractRetrieveResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractRetrieveResponseDataState.Draft,
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
        };

        ContractRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractRetrieveResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractRetrieveResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractRetrieveResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractRetrieveResponseDataState.Draft,
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
        ApiEnum<string, ContractRetrieveResponseDataBillingState> expectedBillingState =
            ContractRetrieveResponseDataBillingState.Draft;
        string expectedContractID = "contractId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerExternalID = "customerExternalId";
        string expectedExternalID = "externalId";
        ContractRetrieveResponseDataLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        string expectedName = "name";
        ContractRetrieveResponseDataNextInvoice expectedNextInvoice = new()
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, ContractRetrieveResponseDataState> expectedState =
            ContractRetrieveResponseDataState.Draft;
        List<ContractRetrieveResponseDataSubscription> expectedSubscriptions =
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
        var model = new ContractRetrieveResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractRetrieveResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractRetrieveResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractRetrieveResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractRetrieveResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractRetrieveResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponseData>(
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
        ApiEnum<string, ContractRetrieveResponseDataBillingState> expectedBillingState =
            ContractRetrieveResponseDataBillingState.Draft;
        string expectedContractID = "contractId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerExternalID = "customerExternalId";
        string expectedExternalID = "externalId";
        ContractRetrieveResponseDataLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        string expectedName = "name";
        ContractRetrieveResponseDataNextInvoice expectedNextInvoice = new()
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, ContractRetrieveResponseDataState> expectedState =
            ContractRetrieveResponseDataState.Draft;
        List<ContractRetrieveResponseDataSubscription> expectedSubscriptions =
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
        var model = new ContractRetrieveResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractRetrieveResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractRetrieveResponseDataState.Draft,
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
        var model = new ContractRetrieveResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractRetrieveResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractRetrieveResponseDataState.Draft,
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

        ContractRetrieveResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractRetrieveResponseDataBillingStateTest : TestBase
{
    [Theory]
    [InlineData(ContractRetrieveResponseDataBillingState.Draft)]
    [InlineData(ContractRetrieveResponseDataBillingState.Active)]
    [InlineData(ContractRetrieveResponseDataBillingState.Canceled)]
    [InlineData(ContractRetrieveResponseDataBillingState.EndBilling)]
    public void Validation_Works(ContractRetrieveResponseDataBillingState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataBillingState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataBillingState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractRetrieveResponseDataBillingState.Draft)]
    [InlineData(ContractRetrieveResponseDataBillingState.Active)]
    [InlineData(ContractRetrieveResponseDataBillingState.Canceled)]
    [InlineData(ContractRetrieveResponseDataBillingState.EndBilling)]
    public void SerializationRoundtrip_Works(ContractRetrieveResponseDataBillingState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataBillingState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataBillingState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataBillingState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataBillingState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractRetrieveResponseDataLatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus> expectedStatus =
            ContractRetrieveResponseDataLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<
            string,
            ContractRetrieveResponseDataLatestInvoiceBillingReason
        > expectedBillingReason =
            ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle;
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
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponseDataLatestInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponseDataLatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus> expectedStatus =
            ContractRetrieveResponseDataLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<
            string,
            ContractRetrieveResponseDataLatestInvoiceBillingReason
        > expectedBillingReason =
            ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle;
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
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
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
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,

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
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,

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
        var model = new ContractRetrieveResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractRetrieveResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        ContractRetrieveResponseDataLatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractRetrieveResponseDataLatestInvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceStatus.Open)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceStatus.Canceled)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceStatus.Paid)]
    public void Validation_Works(ContractRetrieveResponseDataLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceStatus.Open)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceStatus.Canceled)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceStatus.Paid)]
    public void SerializationRoundtrip_Works(
        ContractRetrieveResponseDataLatestInvoiceStatus rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractRetrieveResponseDataLatestInvoiceBillingReasonTest : TestBase
{
    [Theory]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.Manual)]
    [InlineData(
        ContractRetrieveResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded
    )]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.Other)]
    public void Validation_Works(ContractRetrieveResponseDataLatestInvoiceBillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceBillingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.Manual)]
    [InlineData(
        ContractRetrieveResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded
    )]
    [InlineData(ContractRetrieveResponseDataLatestInvoiceBillingReason.Other)]
    public void SerializationRoundtrip_Works(
        ContractRetrieveResponseDataLatestInvoiceBillingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceBillingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractRetrieveResponseDataNextInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractRetrieveResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ContractRetrieveResponseDataNextInvoiceAmount expectedAmount = new()
        {
            Amount = 0,
            Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
        };
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
        var model = new ContractRetrieveResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponseDataNextInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractRetrieveResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponseDataNextInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContractRetrieveResponseDataNextInvoiceAmount expectedAmount = new()
        {
            Amount = 0,
            Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
        };
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
        var model = new ContractRetrieveResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
            },
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
        var model = new ContractRetrieveResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ContractRetrieveResponseDataNextInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractRetrieveResponseDataNextInvoiceAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractRetrieveResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency> expectedCurrency =
            ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContractRetrieveResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ContractRetrieveResponseDataNextInvoiceAmount>(
                json,
                ModelBase.SerializerOptions
            );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractRetrieveResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized =
            JsonSerializer.Deserialize<ContractRetrieveResponseDataNextInvoiceAmount>(
                element,
                ModelBase.SerializerOptions
            );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency> expectedCurrency =
            ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContractRetrieveResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractRetrieveResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd,
        };

        ContractRetrieveResponseDataNextInvoiceAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractRetrieveResponseDataNextInvoiceAmountCurrencyTest : TestBase
{
    [Theory]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Aed)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.All)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Amd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ang)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Aud)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Awg)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Azn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bam)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bbd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bdt)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bgn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bif)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bmd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bnd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bsd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bwp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Byn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bzd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Brl)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cad)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cdf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Chf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cny)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Czk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dkk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dop)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dzd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Egp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Etb)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Eur)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Fjd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gbp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gel)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gip)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gmd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gyd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Hkd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Hrk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Htg)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Idr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ils)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Inr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Isk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Jmd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Jpy)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kes)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kgs)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Khr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kmf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Krw)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kyd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kzt)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lbp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lkr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lrd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lsl)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mad)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mdl)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mga)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mkd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mmk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mnt)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mop)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mro)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mvr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mwk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mxn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Myr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mzn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nad)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ngn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nok)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Npr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nzd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pgk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Php)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pkr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pln)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Qar)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ron)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rsd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rub)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rwf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sar)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sbd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Scr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sek)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sgd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sle)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sll)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sos)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Szl)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Thb)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Tjs)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Top)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Try)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ttd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Tzs)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Uah)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Uzs)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Vnd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Vuv)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Wst)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xaf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xcd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Yer)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Zar)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Zmw)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Clp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Djf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gnf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ugx)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pyg)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xof)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xpf)]
    public void Validation_Works(ContractRetrieveResponseDataNextInvoiceAmountCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Usd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Aed)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.All)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Amd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ang)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Aud)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Awg)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Azn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bam)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bbd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bdt)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bgn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bif)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bmd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bnd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bsd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bwp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Byn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Bzd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Brl)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cad)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cdf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Chf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Cny)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Czk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dkk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dop)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Dzd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Egp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Etb)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Eur)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Fjd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gbp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gel)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gip)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gmd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gyd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Hkd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Hrk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Htg)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Idr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ils)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Inr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Isk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Jmd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Jpy)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kes)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kgs)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Khr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kmf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Krw)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kyd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Kzt)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lbp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lkr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lrd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Lsl)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mad)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mdl)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mga)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mkd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mmk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mnt)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mop)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mro)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mvr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mwk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mxn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Myr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Mzn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nad)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ngn)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nok)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Npr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Nzd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pgk)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Php)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pkr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pln)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Qar)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ron)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rsd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rub)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Rwf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sar)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sbd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Scr)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sek)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sgd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sle)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sll)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Sos)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Szl)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Thb)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Tjs)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Top)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Try)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ttd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Tzs)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Uah)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Uzs)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Vnd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Vuv)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Wst)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xaf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xcd)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Yer)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Zar)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Zmw)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Clp)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Djf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Gnf)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Ugx)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Pyg)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xof)]
    [InlineData(ContractRetrieveResponseDataNextInvoiceAmountCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        ContractRetrieveResponseDataNextInvoiceAmountCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataNextInvoiceAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractRetrieveResponseDataStateTest : TestBase
{
    [Theory]
    [InlineData(ContractRetrieveResponseDataState.Draft)]
    [InlineData(ContractRetrieveResponseDataState.Active)]
    [InlineData(ContractRetrieveResponseDataState.Canceled)]
    [InlineData(ContractRetrieveResponseDataState.EndBilling)]
    public void Validation_Works(ContractRetrieveResponseDataState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContractRetrieveResponseDataState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractRetrieveResponseDataState.Draft)]
    [InlineData(ContractRetrieveResponseDataState.Active)]
    [InlineData(ContractRetrieveResponseDataState.Canceled)]
    [InlineData(ContractRetrieveResponseDataState.EndBilling)]
    public void SerializationRoundtrip_Works(ContractRetrieveResponseDataState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractRetrieveResponseDataState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContractRetrieveResponseDataState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractRetrieveResponseDataState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractRetrieveResponseDataSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractRetrieveResponseDataSubscription
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
        var model = new ContractRetrieveResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponseDataSubscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractRetrieveResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractRetrieveResponseDataSubscription>(
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
        var model = new ContractRetrieveResponseDataSubscription
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
        var model = new ContractRetrieveResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        ContractRetrieveResponseDataSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
