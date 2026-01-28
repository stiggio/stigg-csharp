using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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

        SubscriptionRetrieveResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionRetrieveResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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

        SubscriptionRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionRetrieveResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
            SubscriptionRetrieveResponseDataPaymentCollection
        > expectedPaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionRetrieveResponseDataPricingType> expectedPricingType =
            SubscriptionRetrieveResponseDataPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionRetrieveResponseDataStatus> expectedStatus =
            SubscriptionRetrieveResponseDataStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason> expectedCancelReason =
            SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade;
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
            SubscriptionRetrieveResponseDataPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge;
        List<SubscriptionRetrieveResponseDataPrice> expectedPrices =
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveResponseData>(
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
            SubscriptionRetrieveResponseDataPaymentCollection
        > expectedPaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionRetrieveResponseDataPricingType> expectedPricingType =
            SubscriptionRetrieveResponseDataPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionRetrieveResponseDataStatus> expectedStatus =
            SubscriptionRetrieveResponseDataStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason> expectedCancelReason =
            SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade;
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
            SubscriptionRetrieveResponseDataPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge;
        List<SubscriptionRetrieveResponseDataPrice> expectedPrices =
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
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
        var model = new SubscriptionRetrieveResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionRetrieveResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionRetrieveResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionRetrieveResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge,
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

        SubscriptionRetrieveResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionRetrieveResponseDataPaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollection.NotRequired)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollection.Processing)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollection.Failed)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollection.ActionRequired)]
    public void Validation_Works(SubscriptionRetrieveResponseDataPaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollection.NotRequired)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollection.Processing)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollection.Failed)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(
        SubscriptionRetrieveResponseDataPaymentCollection rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionRetrieveResponseDataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataPricingType.Free)]
    [InlineData(SubscriptionRetrieveResponseDataPricingType.Paid)]
    [InlineData(SubscriptionRetrieveResponseDataPricingType.Custom)]
    public void Validation_Works(SubscriptionRetrieveResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataPricingType.Free)]
    [InlineData(SubscriptionRetrieveResponseDataPricingType.Paid)]
    [InlineData(SubscriptionRetrieveResponseDataPricingType.Custom)]
    public void SerializationRoundtrip_Works(SubscriptionRetrieveResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionRetrieveResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataStatus.PaymentPending)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.Active)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.Expired)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.InTrial)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.Canceled)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.NotStarted)]
    public void Validation_Works(SubscriptionRetrieveResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataStatus.PaymentPending)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.Active)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.Expired)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.InTrial)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.Canceled)]
    [InlineData(SubscriptionRetrieveResponseDataStatus.NotStarted)]
    public void SerializationRoundtrip_Works(SubscriptionRetrieveResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionRetrieveResponseDataCancelReasonTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.Expired)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.DetachBilling)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.TrialEnded)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.Immediate)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.TrialConverted)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.CustomerArchived)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.AutoCancellationRule)]
    public void Validation_Works(SubscriptionRetrieveResponseDataCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.Expired)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.DetachBilling)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.TrialEnded)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.Immediate)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.TrialConverted)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.CustomerArchived)]
    [InlineData(SubscriptionRetrieveResponseDataCancelReason.AutoCancellationRule)]
    public void SerializationRoundtrip_Works(SubscriptionRetrieveResponseDataCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionRetrieveResponseDataPaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollectionMethod.None)]
    public void Validation_Works(SubscriptionRetrieveResponseDataPaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionRetrieveResponseDataPaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(
        SubscriptionRetrieveResponseDataPaymentCollectionMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionRetrieveResponseDataPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionRetrieveResponseDataPriceTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionRetrieveResponseDataPrice
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
        var model = new SubscriptionRetrieveResponseDataPrice
        {
            ID = "id",
            CreatedAt = "createdAt",
            UpdatedAt = "updatedAt",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveResponseDataPrice>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionRetrieveResponseDataPrice
        {
            ID = "id",
            CreatedAt = "createdAt",
            UpdatedAt = "updatedAt",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionRetrieveResponseDataPrice>(
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
        var model = new SubscriptionRetrieveResponseDataPrice
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
        var model = new SubscriptionRetrieveResponseDataPrice
        {
            ID = "id",
            CreatedAt = "createdAt",
            UpdatedAt = "updatedAt",
        };

        SubscriptionRetrieveResponseDataPrice copied = new(model);

        Assert.Equal(model, copied);
    }
}
