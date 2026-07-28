using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Contracts;

namespace Stigg.Client.Tests.Models.V1.Contracts;

public class ContractListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractListResponse
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
        ContractListResponseLatestInvoice expectedLatestInvoice = new()
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
        };
        string expectedName = "name";
        ContractListResponseNextInvoice expectedNextInvoice = new()
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, ContractListResponseState> expectedState = ContractListResponseState.Draft;
        List<ContractListResponseSubscription> expectedSubscriptions =
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
        var model = new ContractListResponse
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractListResponse
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponse>(
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
        ContractListResponseLatestInvoice expectedLatestInvoice = new()
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
        };
        string expectedName = "name";
        ContractListResponseNextInvoice expectedNextInvoice = new()
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedPoNumber = "poNumber";
        string expectedRefID = "refId";
        ApiEnum<string, ContractListResponseState> expectedState = ContractListResponseState.Draft;
        List<ContractListResponseSubscription> expectedSubscriptions =
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
        var model = new ContractListResponse
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
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractListResponse
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
        };

        ContractListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractListResponseLatestInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractListResponseLatestInvoice
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
        };

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, ContractListResponseLatestInvoiceStatus> expectedStatus =
            ContractListResponseLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<string, ContractListResponseLatestInvoiceBillingReason> expectedBillingReason =
            ContractListResponseLatestInvoiceBillingReason.BillingCycle;
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
        var model = new ContractListResponseLatestInvoice
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
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponseLatestInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractListResponseLatestInvoice
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
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponseLatestInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        bool expectedRequiresAction = true;
        ApiEnum<string, ContractListResponseLatestInvoiceStatus> expectedStatus =
            ContractListResponseLatestInvoiceStatus.Open;
        double expectedAmountDue = 0;
        ApiEnum<string, ContractListResponseLatestInvoiceBillingReason> expectedBillingReason =
            ContractListResponseLatestInvoiceBillingReason.BillingCycle;
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
        var model = new ContractListResponseLatestInvoice
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
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new ContractListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractListResponseLatestInvoiceStatus.Open,
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
        var model = new ContractListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractListResponseLatestInvoiceStatus.Open,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new ContractListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractListResponseLatestInvoiceStatus.Open,

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
        var model = new ContractListResponseLatestInvoice
        {
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            RequiresAction = true,
            Status = ContractListResponseLatestInvoiceStatus.Open,

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
        var model = new ContractListResponseLatestInvoice
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
        };

        ContractListResponseLatestInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractListResponseLatestInvoiceStatusTest : TestBase
{
    [Theory]
    [InlineData(ContractListResponseLatestInvoiceStatus.Open)]
    [InlineData(ContractListResponseLatestInvoiceStatus.Canceled)]
    [InlineData(ContractListResponseLatestInvoiceStatus.Paid)]
    public void Validation_Works(ContractListResponseLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractListResponseLatestInvoiceStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractListResponseLatestInvoiceStatus.Open)]
    [InlineData(ContractListResponseLatestInvoiceStatus.Canceled)]
    [InlineData(ContractListResponseLatestInvoiceStatus.Paid)]
    public void SerializationRoundtrip_Works(ContractListResponseLatestInvoiceStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractListResponseLatestInvoiceStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseLatestInvoiceStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseLatestInvoiceStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractListResponseLatestInvoiceBillingReasonTest : TestBase
{
    [Theory]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.Manual)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.Other)]
    public void Validation_Works(ContractListResponseLatestInvoiceBillingReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractListResponseLatestInvoiceBillingReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.BillingCycle)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.SubscriptionCreation)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.SubscriptionUpdate)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.Manual)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.MinimumInvoiceAmountExceeded)]
    [InlineData(ContractListResponseLatestInvoiceBillingReason.Other)]
    public void SerializationRoundtrip_Works(
        ContractListResponseLatestInvoiceBillingReason rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractListResponseLatestInvoiceBillingReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseLatestInvoiceBillingReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseLatestInvoiceBillingReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractListResponseNextInvoiceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractListResponseNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ContractListResponseNextInvoiceAmount expectedAmount = new()
        {
            Amount = 0,
            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
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
        var model = new ContractListResponseNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponseNextInvoice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractListResponseNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponseNextInvoice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        ContractListResponseNextInvoiceAmount expectedAmount = new()
        {
            Amount = 0,
            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
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
        var model = new ContractListResponseNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
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
        var model = new ContractListResponseNextInvoice
        {
            Amount = new()
            {
                Amount = 0,
                Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
            },
            DueDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        ContractListResponseNextInvoice copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractListResponseNextInvoiceAmountTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractListResponseNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency> expectedCurrency =
            ContractListResponseNextInvoiceAmountCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ContractListResponseNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponseNextInvoiceAmount>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractListResponseNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponseNextInvoiceAmount>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency> expectedCurrency =
            ContractListResponseNextInvoiceAmountCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ContractListResponseNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ContractListResponseNextInvoiceAmount
        {
            Amount = 0,
            Currency = ContractListResponseNextInvoiceAmountCurrency.Usd,
        };

        ContractListResponseNextInvoiceAmount copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class ContractListResponseNextInvoiceAmountCurrencyTest : TestBase
{
    [Theory]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Usd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Aed)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.All)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Amd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ang)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Aud)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Awg)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Azn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bam)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bbd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bdt)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bgn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bif)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bmd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bnd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bsd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bwp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Byn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bzd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Brl)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Cad)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Cdf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Chf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Cny)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Czk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Dkk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Dop)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Dzd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Egp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Etb)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Eur)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Fjd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gbp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gel)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gip)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gmd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gyd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Hkd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Hrk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Htg)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Idr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ils)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Inr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Isk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Jmd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Jpy)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kes)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kgs)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Khr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kmf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Krw)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kyd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kzt)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Lbp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Lkr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Lrd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Lsl)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mad)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mdl)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mga)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mkd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mmk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mnt)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mop)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mro)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mvr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mwk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mxn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Myr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mzn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Nad)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ngn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Nok)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Npr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Nzd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Pgk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Php)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Pkr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Pln)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Qar)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ron)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Rsd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Rub)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Rwf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sar)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sbd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Scr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sek)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sgd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sle)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sll)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sos)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Szl)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Thb)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Tjs)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Top)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Try)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ttd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Tzs)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Uah)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Uzs)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Vnd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Vuv)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Wst)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Xaf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Xcd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Yer)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Zar)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Zmw)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Clp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Djf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gnf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ugx)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Pyg)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Xof)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Xpf)]
    public void Validation_Works(ContractListResponseNextInvoiceAmountCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Usd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Aed)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.All)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Amd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ang)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Aud)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Awg)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Azn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bam)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bbd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bdt)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bgn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bif)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bmd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bnd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bsd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bwp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Byn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Bzd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Brl)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Cad)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Cdf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Chf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Cny)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Czk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Dkk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Dop)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Dzd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Egp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Etb)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Eur)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Fjd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gbp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gel)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gip)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gmd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gyd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Hkd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Hrk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Htg)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Idr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ils)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Inr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Isk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Jmd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Jpy)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kes)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kgs)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Khr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kmf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Krw)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kyd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Kzt)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Lbp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Lkr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Lrd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Lsl)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mad)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mdl)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mga)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mkd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mmk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mnt)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mop)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mro)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mvr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mwk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mxn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Myr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Mzn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Nad)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ngn)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Nok)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Npr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Nzd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Pgk)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Php)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Pkr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Pln)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Qar)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ron)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Rsd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Rub)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Rwf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sar)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sbd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Scr)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sek)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sgd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sle)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sll)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Sos)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Szl)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Thb)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Tjs)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Top)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Try)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ttd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Tzs)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Uah)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Uzs)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Vnd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Vuv)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Wst)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Xaf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Xcd)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Yer)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Zar)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Zmw)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Clp)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Djf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Gnf)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Ugx)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Pyg)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Xof)]
    [InlineData(ContractListResponseNextInvoiceAmountCurrency.Xpf)]
    public void SerializationRoundtrip_Works(ContractListResponseNextInvoiceAmountCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, ContractListResponseNextInvoiceAmountCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class ContractListResponseStateTest : TestBase
{
    [Theory]
    [InlineData(ContractListResponseState.Draft)]
    [InlineData(ContractListResponseState.Active)]
    [InlineData(ContractListResponseState.Canceled)]
    [InlineData(ContractListResponseState.EndBilling)]
    public void Validation_Works(ContractListResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractListResponseState> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContractListResponseState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ContractListResponseState.Draft)]
    [InlineData(ContractListResponseState.Active)]
    [InlineData(ContractListResponseState.Canceled)]
    [InlineData(ContractListResponseState.EndBilling)]
    public void SerializationRoundtrip_Works(ContractListResponseState rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ContractListResponseState> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContractListResponseState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ContractListResponseState>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ContractListResponseState>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ContractListResponseSubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ContractListResponseSubscription
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
        var model = new ContractListResponseSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponseSubscription>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ContractListResponseSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ContractListResponseSubscription>(
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
        var model = new ContractListResponseSubscription
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
        var model = new ContractListResponseSubscription
        {
            PlanDisplayName = "planDisplayName",
            ProductDisplayName = "productDisplayName",
            SubscriptionID = "subscriptionId",
        };

        ContractListResponseSubscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
