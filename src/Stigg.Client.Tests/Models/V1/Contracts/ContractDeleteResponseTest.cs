using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Tests.Models.V1.Contracts;

public class ContractDeleteResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractDeleteResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractDeleteResponseDataState.Draft,
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

        ContractDeleteResponseData expectedData = new()
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractDeleteResponseDataState.Draft,
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
        var model = new ContractDeleteResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractDeleteResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractDeleteResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractDeleteResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContractDeleteResponseData expectedData = new()
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractDeleteResponseDataState.Draft,
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
        var model = new ContractDeleteResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractDeleteResponseDataState.Draft,
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
        var model = new ContractDeleteResponse
        {
            Data = new()
            {
                ID = "id",
                ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                BillingID = "billingId",
                ContractID = "contractId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerExternalID = "customerExternalId",
                ExternalID = "externalId",
                LatestInvoice = new()
                {
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    RequiresAction = true,
                    Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                    AmountDue = 0,
                    BillingReason =
                        ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                        Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                    },
                    DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                PoNumber = "poNumber",
                RefID = "refId",
                State = ContractDeleteResponseDataState.Draft,
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

        ContractDeleteResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractDeleteResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractDeleteResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractDeleteResponseDataState.Draft,
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
        string expectedContractID = "contractId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerExternalID = "customerExternalId";
        string expectedExternalID = "externalId";
        ContractDeleteResponseDataLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        string expectedName = "name";
        ContractDeleteResponseDataNextInvoice expectedNextInvoice = new()
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, ContractDeleteResponseDataState> expectedState =
            ContractDeleteResponseDataState.Draft;
        List<ContractDeleteResponseDataSubscription> expectedSubscriptions =
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
        var model = new ContractDeleteResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractDeleteResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractDeleteResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractDeleteResponseDataState.Draft,
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
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseData>(
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
        string expectedContractID = "contractId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerExternalID = "customerExternalId";
        string expectedExternalID = "externalId";
        ContractDeleteResponseDataLatestInvoice expectedLatestInvoice = new()
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };
        string expectedName = "name";
        ContractDeleteResponseDataNextInvoice expectedNextInvoice = new()
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, ContractDeleteResponseDataState> expectedState =
            ContractDeleteResponseDataState.Draft;
        List<ContractDeleteResponseDataSubscription> expectedSubscriptions =
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
        var model = new ContractDeleteResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractDeleteResponseDataState.Draft,
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
        var model = new ContractDeleteResponseData
        {
            ID = "id",
            ActivationEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ActivationStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            BillingID = "billingId",
            ContractID = "contractId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerExternalID = "customerExternalId",
            ExternalID = "externalId",
            LatestInvoice = new()
            {
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                RequiresAction = true,
                Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
                AmountDue = 0,
                BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
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
                    Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
                },
                DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            PoNumber = "poNumber",
            RefID = "refId",
            State = ContractDeleteResponseDataState.Draft,
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

        ContractDeleteResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractDeleteResponseDataLatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus> expectedStatus =
            ContractDeleteResponseDataLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<
            string,
            ContractDeleteResponseDataLatestInvoiceBillingReason
        > expectedBillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle;
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
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseDataLatestInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseDataLatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus> expectedStatus =
            ContractDeleteResponseDataLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<
            string,
            ContractDeleteResponseDataLatestInvoiceBillingReason
        > expectedBillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle;
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
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
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
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,

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
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,

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
        var model = new ContractDeleteResponseDataLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractDeleteResponseDataLatestInvoiceStatus.Open,
            AmountDue = 0,
            BillingReason = ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle,
            Currency = "currency",
            PdfUrl = "pdfUrl",
            Total = 0,
        };

        ContractDeleteResponseDataLatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractDeleteResponseDataLatestInvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(ContractDeleteResponseDataLatestInvoiceStatus.Open)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceStatus.Canceled)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceStatus.Paid)]
    public void Validation_Works(ContractDeleteResponseDataLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractDeleteResponseDataLatestInvoiceStatus.Open)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceStatus.Canceled)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceStatus.Paid)]
    public void SerializationRoundtrip_Works(ContractDeleteResponseDataLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractDeleteResponseDataLatestInvoiceBillingReasonTest : TestBase
{
    [Theory]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.Manual)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.Other)]
    public void Validation_Works(ContractDeleteResponseDataLatestInvoiceBillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractDeleteResponseDataLatestInvoiceBillingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.Manual)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(ContractDeleteResponseDataLatestInvoiceBillingReason.Other)]
    public void SerializationRoundtrip_Works(
        ContractDeleteResponseDataLatestInvoiceBillingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractDeleteResponseDataLatestInvoiceBillingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractDeleteResponseDataNextInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ContractDeleteResponseDataNextInvoiceAmount expectedAmount = new()
        {
            Amount = 0,
            Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
        };
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedDueDate, model.DueDate);
        Assert.Equal(expectedPeriodEnd, model.PeriodEnd);
        Assert.Equal(expectedPeriodStart, model.PeriodStart);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseDataNextInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseDataNextInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContractDeleteResponseDataNextInvoiceAmount expectedAmount = new()
        {
            Amount = 0,
            Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
        };
        DateTimeOffset expectedDueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedDueDate, deserialized.DueDate);
        Assert.Equal(expectedPeriodEnd, deserialized.PeriodEnd);
        Assert.Equal(expectedPeriodStart, deserialized.PeriodStart);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ContractDeleteResponseDataNextInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractDeleteResponseDataNextInvoiceAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency> expectedCurrency =
            ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseDataNextInvoiceAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseDataNextInvoiceAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency> expectedCurrency =
            ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractDeleteResponseDataNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd,
        };

        ContractDeleteResponseDataNextInvoiceAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractDeleteResponseDataNextInvoiceAmountCurrencyTest : TestBase
{
    [Theory]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Aed)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.All)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Amd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ang)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Aud)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Awg)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Azn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bam)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bbd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bdt)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bgn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bif)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bmd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bnd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bsd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bwp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Byn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bzd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Brl)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Cad)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Cdf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Chf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Cny)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Czk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Dkk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Dop)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Dzd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Egp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Etb)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Eur)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Fjd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gbp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gel)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gip)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gmd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gyd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Hkd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Hrk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Htg)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Idr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ils)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Inr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Isk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Jmd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Jpy)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kes)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kgs)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Khr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kmf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Krw)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kyd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kzt)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Lbp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Lkr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Lrd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Lsl)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mad)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mdl)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mga)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mkd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mmk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mnt)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mop)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mro)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mvr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mwk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mxn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Myr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mzn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Nad)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ngn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Nok)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Npr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Nzd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Pgk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Php)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Pkr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Pln)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Qar)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ron)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Rsd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Rub)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Rwf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sar)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sbd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Scr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sek)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sgd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sle)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sll)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sos)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Szl)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Thb)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Tjs)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Top)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Try)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ttd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Tzs)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Uah)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Uzs)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Vnd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Vuv)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Wst)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Xaf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Xcd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Yer)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Zar)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Zmw)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Clp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Djf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gnf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ugx)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Pyg)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Xof)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Xpf)]
    public void Validation_Works(ContractDeleteResponseDataNextInvoiceAmountCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Usd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Aed)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.All)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Amd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ang)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Aud)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Awg)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Azn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bam)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bbd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bdt)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bgn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bif)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bmd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bnd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bsd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bwp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Byn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Bzd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Brl)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Cad)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Cdf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Chf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Cny)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Czk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Dkk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Dop)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Dzd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Egp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Etb)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Eur)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Fjd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gbp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gel)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gip)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gmd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gyd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Hkd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Hrk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Htg)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Idr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ils)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Inr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Isk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Jmd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Jpy)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kes)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kgs)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Khr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kmf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Krw)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kyd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Kzt)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Lbp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Lkr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Lrd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Lsl)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mad)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mdl)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mga)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mkd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mmk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mnt)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mop)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mro)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mvr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mwk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mxn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Myr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Mzn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Nad)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ngn)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Nok)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Npr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Nzd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Pgk)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Php)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Pkr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Pln)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Qar)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ron)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Rsd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Rub)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Rwf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sar)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sbd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Scr)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sek)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sgd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sle)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sll)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Sos)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Szl)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Thb)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Tjs)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Top)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Try)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ttd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Tzs)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Uah)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Uzs)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Vnd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Vuv)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Wst)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Xaf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Xcd)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Yer)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Zar)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Zmw)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Clp)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Djf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Gnf)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Ugx)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Pyg)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Xof)]
    [InlineData(ContractDeleteResponseDataNextInvoiceAmountCurrency.Xpf)]
    public void SerializationRoundtrip_Works(
        ContractDeleteResponseDataNextInvoiceAmountCurrency rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataNextInvoiceAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractDeleteResponseDataStateTest : TestBase
{
    [Theory]
    [InlineData(ContractDeleteResponseDataState.Draft)]
    [InlineData(ContractDeleteResponseDataState.Active)]
    [InlineData(ContractDeleteResponseDataState.Canceled)]
    [InlineData(ContractDeleteResponseDataState.EndBilling)]
    public void Validation_Works(ContractDeleteResponseDataState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractDeleteResponseDataState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContractDeleteResponseDataState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractDeleteResponseDataState.Draft)]
    [InlineData(ContractDeleteResponseDataState.Active)]
    [InlineData(ContractDeleteResponseDataState.Canceled)]
    [InlineData(ContractDeleteResponseDataState.EndBilling)]
    public void SerializationRoundtrip_Works(ContractDeleteResponseDataState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractDeleteResponseDataState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContractDeleteResponseDataState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractDeleteResponseDataState>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractDeleteResponseDataSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractDeleteResponseDataSubscription
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
        var model = new ContractDeleteResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseDataSubscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractDeleteResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractDeleteResponseDataSubscription>(
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
        var model = new ContractDeleteResponseDataSubscription
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
        var model = new ContractDeleteResponseDataSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        ContractDeleteResponseDataSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
