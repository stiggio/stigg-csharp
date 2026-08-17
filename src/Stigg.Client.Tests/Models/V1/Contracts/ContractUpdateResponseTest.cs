using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Tests.Models.V1.Contracts;

public class ContractUpdateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractUpdateResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractUpdateResponseDataState.Draft,
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

        ContractUpdateResponseData expectedData = new()
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractUpdateResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractUpdateResponseDataState.Draft,
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
        var model = new ContractUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractUpdateResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractUpdateResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractUpdateResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractUpdateResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContractUpdateResponseData expectedData = new()
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractUpdateResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractUpdateResponseDataState.Draft,
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
        var model = new ContractUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractUpdateResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractUpdateResponseDataState.Draft,
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
        var model = new ContractUpdateResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                BillingState = ContractUpdateResponseDataBillingState.Draft,
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    InvoiceID = "invoiceId",
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractUpdateResponseDataState.Draft,
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

        ContractUpdateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractUpdateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractUpdateResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractUpdateResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractUpdateResponseDataState.Draft,
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
        ApiEnum<string, ContractUpdateResponseDataBillingState> expectedBillingState =
            ContractUpdateResponseDataBillingState.Draft;
        string expectedContractID = "contractId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerExternalID = "customerExternalId";
        string expectedExternalID = "externalId";
        ContractUpdateResponseDataLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        string expectedName = "name";
        ContractUpdateResponseDataNextInvoice expectedNextInvoice = new()
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, ContractUpdateResponseDataState> expectedState =
            ContractUpdateResponseDataState.Draft;
        List<ContractUpdateResponseDataSubscription> expectedSubscriptions =
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
        var model = new ContractUpdateResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractUpdateResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractUpdateResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractUpdateResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractUpdateResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractUpdateResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseData>(
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
        ApiEnum<string, ContractUpdateResponseDataBillingState> expectedBillingState =
            ContractUpdateResponseDataBillingState.Draft;
        string expectedContractID = "contractId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerExternalID = "customerExternalId";
        string expectedExternalID = "externalId";
        ContractUpdateResponseDataLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        string expectedName = "name";
        ContractUpdateResponseDataNextInvoice expectedNextInvoice = new()
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, ContractUpdateResponseDataState> expectedState =
            ContractUpdateResponseDataState.Draft;
        List<ContractUpdateResponseDataSubscription> expectedSubscriptions =
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
        var model = new ContractUpdateResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractUpdateResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractUpdateResponseDataState.Draft,
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
        var model = new ContractUpdateResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            BillingState = ContractUpdateResponseDataBillingState.Draft,
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                InvoiceID = "invoiceId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractUpdateResponseDataState.Draft,
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

        ContractUpdateResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractUpdateResponseDataBillingStateTest : TestBase
{
    [Theory]
    [InlineData(ContractUpdateResponseDataBillingState.Draft)]
    [InlineData(ContractUpdateResponseDataBillingState.Active)]
    [InlineData(ContractUpdateResponseDataBillingState.Canceled)]
    [InlineData(ContractUpdateResponseDataBillingState.EndBilling)]
    public void Validation_Works(ContractUpdateResponseDataBillingState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataBillingState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataBillingState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractUpdateResponseDataBillingState.Draft)]
    [InlineData(ContractUpdateResponseDataBillingState.Active)]
    [InlineData(ContractUpdateResponseDataBillingState.Canceled)]
    [InlineData(ContractUpdateResponseDataBillingState.EndBilling)]
    public void SerializationRoundtrip_Works(ContractUpdateResponseDataBillingState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataBillingState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataBillingState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataBillingState>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataBillingState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractUpdateResponseDataLatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus> expectedStatus =
            ContractUpdateResponseDataLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<
            string,
            ContractUpdateResponseDataLatestInvoiceBillingReason
        > expectedBillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle;
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
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseDataLatestInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseDataLatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus> expectedStatus =
            ContractUpdateResponseDataLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<
            string,
            ContractUpdateResponseDataLatestInvoiceBillingReason
        > expectedBillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle;
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
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
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
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,

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
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,

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
        var model = new ContractUpdateResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractUpdateResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        ContractUpdateResponseDataLatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractUpdateResponseDataLatestInvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(ContractUpdateResponseDataLatestInvoiceStatus.Open)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceStatus.Canceled)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceStatus.Paid)]
    public void Validation_Works(ContractUpdateResponseDataLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractUpdateResponseDataLatestInvoiceStatus.Open)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceStatus.Canceled)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceStatus.Paid)]
    public void SerializationRoundtrip_Works(ContractUpdateResponseDataLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractUpdateResponseDataLatestInvoiceBillingReasonTest : TestBase
{
    [Theory]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.Manual)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.Other)]
    public void Validation_Works(ContractUpdateResponseDataLatestInvoiceBillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataLatestInvoiceBillingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.Manual)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(ContractUpdateResponseDataLatestInvoiceBillingReason.Other)]
    public void SerializationRoundtrip_Works(
        ContractUpdateResponseDataLatestInvoiceBillingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataLatestInvoiceBillingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractUpdateResponseDataNextInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractUpdateResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ContractUpdateResponseDataNextInvoiceAmount expectedAmount = new()
        {
            Amount = 0,
            Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
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
        var model = new ContractUpdateResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseDataNextInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractUpdateResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseDataNextInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContractUpdateResponseDataNextInvoiceAmount expectedAmount = new()
        {
            Amount = 0,
            Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
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
        var model = new ContractUpdateResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
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
        var model = new ContractUpdateResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            InvoiceID = "invoiceId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ContractUpdateResponseDataNextInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractUpdateResponseDataNextInvoiceAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractUpdateResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency> expectedCurrency =
            ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContractUpdateResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseDataNextInvoiceAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractUpdateResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseDataNextInvoiceAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency> expectedCurrency =
            ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContractUpdateResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractUpdateResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd,
        };

        ContractUpdateResponseDataNextInvoiceAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractUpdateResponseDataNextInvoiceAmountCurrencyTest : TestBase
{
    [Theory]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Aed)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.All)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Amd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ang)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Aud)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Awg)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Azn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bam)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bbd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bdt)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bgn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bif)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bmd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bnd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bsd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bwp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Byn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bzd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Brl)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Cad)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Cdf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Chf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Cny)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Czk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Dkk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Dop)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Dzd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Egp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Etb)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Eur)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Fjd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gbp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gel)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gip)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gmd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gyd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Hkd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Hrk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Htg)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Idr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ils)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Inr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Isk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Jmd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Jpy)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kes)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kgs)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Khr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kmf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Krw)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kyd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kzt)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Lbp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Lkr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Lrd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Lsl)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mad)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mdl)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mga)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mkd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mmk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mnt)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mop)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mro)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mvr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mwk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mxn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Myr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mzn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Nad)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ngn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Nok)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Npr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Nzd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Pgk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Php)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Pkr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Pln)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Qar)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ron)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Rsd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Rub)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Rwf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sar)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sbd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Scr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sek)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sgd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sle)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sll)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sos)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Szl)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Thb)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Tjs)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Top)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Try)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ttd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Tzs)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Uah)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Uzs)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Vnd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Vuv)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Wst)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Xaf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Xcd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Yer)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Zar)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Zmw)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Clp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Djf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gnf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ugx)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Pyg)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Xof)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Xpf)]
    public void Validation_Works(ContractUpdateResponseDataNextInvoiceAmountCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Usd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Aed)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.All)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Amd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ang)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Aud)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Awg)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Azn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bam)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bbd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bdt)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bgn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bif)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bmd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bnd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bsd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bwp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Byn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Bzd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Brl)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Cad)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Cdf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Chf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Cny)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Czk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Dkk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Dop)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Dzd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Egp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Etb)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Eur)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Fjd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gbp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gel)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gip)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gmd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gyd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Hkd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Hrk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Htg)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Idr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ils)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Inr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Isk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Jmd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Jpy)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kes)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kgs)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Khr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kmf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Krw)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kyd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Kzt)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Lbp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Lkr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Lrd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Lsl)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mad)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mdl)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mga)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mkd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mmk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mnt)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mop)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mro)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mvr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mwk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mxn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Myr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Mzn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Nad)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ngn)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Nok)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Npr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Nzd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Pgk)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Php)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Pkr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Pln)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Qar)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ron)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Rsd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Rub)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Rwf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sar)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sbd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Scr)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sek)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sgd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sle)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sll)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Sos)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Szl)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Thb)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Tjs)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Top)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Try)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ttd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Tzs)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Uah)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Uzs)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Vnd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Vuv)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Wst)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Xaf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Xcd)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Yer)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Zar)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Zmw)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Clp)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Djf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Gnf)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Ugx)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Pyg)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Xof)]
    [InlineData(ContractUpdateResponseDataNextInvoiceAmountCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        ContractUpdateResponseDataNextInvoiceAmountCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataNextInvoiceAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractUpdateResponseDataStateTest : TestBase
{
    [Theory]
    [InlineData(ContractUpdateResponseDataState.Draft)]
    [InlineData(ContractUpdateResponseDataState.Active)]
    [InlineData(ContractUpdateResponseDataState.Canceled)]
    [InlineData(ContractUpdateResponseDataState.EndBilling)]
    public void Validation_Works(ContractUpdateResponseDataState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContractUpdateResponseDataState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractUpdateResponseDataState.Draft)]
    [InlineData(ContractUpdateResponseDataState.Active)]
    [InlineData(ContractUpdateResponseDataState.Canceled)]
    [InlineData(ContractUpdateResponseDataState.EndBilling)]
    public void SerializationRoundtrip_Works(ContractUpdateResponseDataState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractUpdateResponseDataState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContractUpdateResponseDataState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractUpdateResponseDataState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractUpdateResponseDataSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractUpdateResponseDataSubscription
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
        var model = new ContractUpdateResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseDataSubscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractUpdateResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractUpdateResponseDataSubscription>(
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
        var model = new ContractUpdateResponseDataSubscription
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
        var model = new ContractUpdateResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        ContractUpdateResponseDataSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
