using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionTransferResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionTransferResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionTransferResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionTransferResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = "createdAt",
                        UpdatedAt = "updatedAt",
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        SubscriptionTransferResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionTransferResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionTransferResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionTransferResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = "createdAt",
                        UpdatedAt = "updatedAt",
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionTransferResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionTransferResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionTransferResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionTransferResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = "createdAt",
                        UpdatedAt = "updatedAt",
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionTransferResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionTransferResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionTransferResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionTransferResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionTransferResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = "createdAt",
                        UpdatedAt = "updatedAt",
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionTransferResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionTransferResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionTransferResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
                Prices =
                [
                    new()
                    {
                        ID = "id",
                        CreatedAt = "createdAt",
                        UpdatedAt = "updatedAt",
                    },
                ],
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        SubscriptionTransferResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionTransferResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<
            string,
            SubscriptionTransferResponseDataPaymentCollection
        > expectedPaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionTransferResponseDataPricingType> expectedPricingType =
            SubscriptionTransferResponseDataPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionTransferResponseDataStatus> expectedStatus =
            SubscriptionTransferResponseDataStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionTransferResponseDataCancelReason> expectedCancelReason =
            SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade;
        DateTimeOffset expectedCurrentBillingPeriodEnd = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStart = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedEffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<
            string,
            SubscriptionTransferResponseDataPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionTransferResponseDataPaymentCollectionMethod.Charge;
        List<SubscriptionTransferResponseDataPrice> expectedPrices =
        [
            new()
            {
                ID = "id",
                CreatedAt = "createdAt",
                UpdatedAt = "updatedAt",
            },
        ];
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedPaymentCollection, model.PaymentCollection);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.Equal(expectedPricingType, model.PricingType);
        Assert.Equal(expectedStartDate, model.StartDate);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCancellationDate, model.CancellationDate);
        Assert.Equal(expectedCancelReason, model.CancelReason);
        Assert.Equal(expectedCurrentBillingPeriodEnd, model.CurrentBillingPeriodEnd);
        Assert.Equal(expectedCurrentBillingPeriodStart, model.CurrentBillingPeriodStart);
        Assert.Equal(expectedEffectiveEndDate, model.EffectiveEndDate);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPayingCustomerID, model.PayingCustomerID);
        Assert.Equal(expectedPaymentCollectionMethod, model.PaymentCollectionMethod);
        Assert.NotNull(model.Prices);
        Assert.Equal(expectedPrices.Count, model.Prices.Count);
        for (int i = 0; i < expectedPrices.Count; i++)
        {
            Assert.Equal(expectedPrices[i], model.Prices[i]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionTransferResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionTransferResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<
            string,
            SubscriptionTransferResponseDataPaymentCollection
        > expectedPaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionTransferResponseDataPricingType> expectedPricingType =
            SubscriptionTransferResponseDataPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionTransferResponseDataStatus> expectedStatus =
            SubscriptionTransferResponseDataStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionTransferResponseDataCancelReason> expectedCancelReason =
            SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade;
        DateTimeOffset expectedCurrentBillingPeriodEnd = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedCurrentBillingPeriodStart = DateTimeOffset.Parse(
            "2019-12-27T18:11:19.117Z"
        );
        DateTimeOffset expectedEffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPayingCustomerID = "payingCustomerId";
        ApiEnum<
            string,
            SubscriptionTransferResponseDataPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionTransferResponseDataPaymentCollectionMethod.Charge;
        List<SubscriptionTransferResponseDataPrice> expectedPrices =
        [
            new()
            {
                ID = "id",
                CreatedAt = "createdAt",
                UpdatedAt = "updatedAt",
            },
        ];
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedTrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedPaymentCollection, deserialized.PaymentCollection);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.Equal(expectedPricingType, deserialized.PricingType);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCancellationDate, deserialized.CancellationDate);
        Assert.Equal(expectedCancelReason, deserialized.CancelReason);
        Assert.Equal(expectedCurrentBillingPeriodEnd, deserialized.CurrentBillingPeriodEnd);
        Assert.Equal(expectedCurrentBillingPeriodStart, deserialized.CurrentBillingPeriodStart);
        Assert.Equal(expectedEffectiveEndDate, deserialized.EffectiveEndDate);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPayingCustomerID, deserialized.PayingCustomerID);
        Assert.Equal(expectedPaymentCollectionMethod, deserialized.PaymentCollectionMethod);
        Assert.NotNull(deserialized.Prices);
        Assert.Equal(expectedPrices.Count, deserialized.Prices.Count);
        for (int i = 0; i < expectedPrices.Count; i++)
        {
            Assert.Equal(expectedPrices[i], deserialized.Prices[i]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Prices);
        Assert.False(model.RawData.ContainsKey("prices"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Prices = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.Prices);
        Assert.False(model.RawData.ContainsKey("prices"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Prices = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
        };

        Assert.Null(model.CancellationDate);
        Assert.False(model.RawData.ContainsKey("cancellationDate"));
        Assert.Null(model.CancelReason);
        Assert.False(model.RawData.ContainsKey("cancelReason"));
        Assert.Null(model.CurrentBillingPeriodEnd);
        Assert.False(model.RawData.ContainsKey("currentBillingPeriodEnd"));
        Assert.Null(model.CurrentBillingPeriodStart);
        Assert.False(model.RawData.ContainsKey("currentBillingPeriodStart"));
        Assert.Null(model.EffectiveEndDate);
        Assert.False(model.RawData.ContainsKey("effectiveEndDate"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("endDate"));
        Assert.Null(model.PayingCustomerID);
        Assert.False(model.RawData.ContainsKey("payingCustomerId"));
        Assert.Null(model.PaymentCollectionMethod);
        Assert.False(model.RawData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.TrialEndDate);
        Assert.False(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],

            CancellationDate = null,
            CancelReason = null,
            CurrentBillingPeriodEnd = null,
            CurrentBillingPeriodStart = null,
            EffectiveEndDate = null,
            EndDate = null,
            PayingCustomerID = null,
            PaymentCollectionMethod = null,
            ResourceID = null,
            TrialEndDate = null,
        };

        Assert.Null(model.CancellationDate);
        Assert.True(model.RawData.ContainsKey("cancellationDate"));
        Assert.Null(model.CancelReason);
        Assert.True(model.RawData.ContainsKey("cancelReason"));
        Assert.Null(model.CurrentBillingPeriodEnd);
        Assert.True(model.RawData.ContainsKey("currentBillingPeriodEnd"));
        Assert.Null(model.CurrentBillingPeriodStart);
        Assert.True(model.RawData.ContainsKey("currentBillingPeriodStart"));
        Assert.Null(model.EffectiveEndDate);
        Assert.True(model.RawData.ContainsKey("effectiveEndDate"));
        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("endDate"));
        Assert.Null(model.PayingCustomerID);
        Assert.True(model.RawData.ContainsKey("payingCustomerId"));
        Assert.Null(model.PaymentCollectionMethod);
        Assert.True(model.RawData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
        Assert.Null(model.TrialEndDate);
        Assert.True(model.RawData.ContainsKey("trialEndDate"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],

            CancellationDate = null,
            CancelReason = null,
            CurrentBillingPeriodEnd = null,
            CurrentBillingPeriodStart = null,
            EffectiveEndDate = null,
            EndDate = null,
            PayingCustomerID = null,
            PaymentCollectionMethod = null,
            ResourceID = null,
            TrialEndDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionTransferResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionTransferResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionTransferResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionTransferResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionTransferResponseDataPaymentCollectionMethod.Charge,
            Prices =
            [
                new()
                {
                    ID = "id",
                    CreatedAt = "createdAt",
                    UpdatedAt = "updatedAt",
                },
            ],
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionTransferResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionTransferResponseDataPaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionTransferResponseDataPaymentCollection.NotRequired)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollection.Processing)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollection.Failed)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollection.ActionRequired)]
    public void Validation_Works(SubscriptionTransferResponseDataPaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataPaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionTransferResponseDataPaymentCollection.NotRequired)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollection.Processing)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollection.Failed)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(
        SubscriptionTransferResponseDataPaymentCollection rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataPaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionTransferResponseDataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionTransferResponseDataPricingType.Free)]
    [InlineData(SubscriptionTransferResponseDataPricingType.Paid)]
    [InlineData(SubscriptionTransferResponseDataPricingType.Custom)]
    public void Validation_Works(SubscriptionTransferResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionTransferResponseDataPricingType.Free)]
    [InlineData(SubscriptionTransferResponseDataPricingType.Paid)]
    [InlineData(SubscriptionTransferResponseDataPricingType.Custom)]
    public void SerializationRoundtrip_Works(SubscriptionTransferResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionTransferResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionTransferResponseDataStatus.PaymentPending)]
    [InlineData(SubscriptionTransferResponseDataStatus.Active)]
    [InlineData(SubscriptionTransferResponseDataStatus.Expired)]
    [InlineData(SubscriptionTransferResponseDataStatus.InTrial)]
    [InlineData(SubscriptionTransferResponseDataStatus.Canceled)]
    [InlineData(SubscriptionTransferResponseDataStatus.NotStarted)]
    public void Validation_Works(SubscriptionTransferResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionTransferResponseDataStatus.PaymentPending)]
    [InlineData(SubscriptionTransferResponseDataStatus.Active)]
    [InlineData(SubscriptionTransferResponseDataStatus.Expired)]
    [InlineData(SubscriptionTransferResponseDataStatus.InTrial)]
    [InlineData(SubscriptionTransferResponseDataStatus.Canceled)]
    [InlineData(SubscriptionTransferResponseDataStatus.NotStarted)]
    public void SerializationRoundtrip_Works(SubscriptionTransferResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionTransferResponseDataCancelReasonTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.Expired)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.DetachBilling)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.TrialEnded)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.Immediate)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.TrialConverted)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.CustomerArchived)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.AutoCancellationRule)]
    public void Validation_Works(SubscriptionTransferResponseDataCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataCancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionTransferResponseDataCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.Expired)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.DetachBilling)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.TrialEnded)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.Immediate)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.TrialConverted)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.CustomerArchived)]
    [InlineData(SubscriptionTransferResponseDataCancelReason.AutoCancellationRule)]
    public void SerializationRoundtrip_Works(SubscriptionTransferResponseDataCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataCancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionTransferResponseDataPaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionTransferResponseDataPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollectionMethod.None)]
    public void Validation_Works(SubscriptionTransferResponseDataPaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataPaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionTransferResponseDataPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionTransferResponseDataPaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(
        SubscriptionTransferResponseDataPaymentCollectionMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionTransferResponseDataPaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionTransferResponseDataPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionTransferResponseDataPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionTransferResponseDataPrice
        {
            ID = "id",
            CreatedAt = "createdAt",
            UpdatedAt = "updatedAt",
        };

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedUpdatedAt = "updatedAt";

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionTransferResponseDataPrice
        {
            ID = "id",
            CreatedAt = "createdAt",
            UpdatedAt = "updatedAt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionTransferResponseDataPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionTransferResponseDataPrice
        {
            ID = "id",
            CreatedAt = "createdAt",
            UpdatedAt = "updatedAt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionTransferResponseDataPrice>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCreatedAt = "createdAt";
        string expectedUpdatedAt = "updatedAt";

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionTransferResponseDataPrice
        {
            ID = "id",
            CreatedAt = "createdAt",
            UpdatedAt = "updatedAt",
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionTransferResponseDataPrice
        {
            ID = "id",
            CreatedAt = "createdAt",
            UpdatedAt = "updatedAt",
        };

        SubscriptionTransferResponseDataPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}
