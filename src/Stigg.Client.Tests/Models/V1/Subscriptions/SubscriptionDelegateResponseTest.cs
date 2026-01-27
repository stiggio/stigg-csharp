using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionDelegateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionDelegateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionDelegateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        SubscriptionDelegateResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionDelegateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionDelegateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionDelegateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionDelegateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionDelegateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionDelegateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionDelegateResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionDelegateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionDelegateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionDelegateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionDelegateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        SubscriptionDelegateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionDelegateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<
            string,
            SubscriptionDelegateResponseDataPaymentCollection
        > expectedPaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionDelegateResponseDataPricingType> expectedPricingType =
            SubscriptionDelegateResponseDataPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionDelegateResponseDataStatus> expectedStatus =
            SubscriptionDelegateResponseDataStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionDelegateResponseDataCancelReason> expectedCancelReason =
            SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade;
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
            SubscriptionDelegateResponseDataPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge;
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
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedTrialEndDate, model.TrialEndDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionDelegateResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionDelegateResponseData>(
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
            SubscriptionDelegateResponseDataPaymentCollection
        > expectedPaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionDelegateResponseDataPricingType> expectedPricingType =
            SubscriptionDelegateResponseDataPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionDelegateResponseDataStatus> expectedStatus =
            SubscriptionDelegateResponseDataStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionDelegateResponseDataCancelReason> expectedCancelReason =
            SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade;
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
            SubscriptionDelegateResponseDataPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge;
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
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedTrialEndDate, deserialized.TrialEndDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            // Null should be interpreted as omitted for these properties
            Metadata = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
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
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

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
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

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
        var model = new SubscriptionDelegateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionDelegateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionDelegateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionDelegateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod =
                SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionDelegateResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionDelegateResponseDataPaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollection.NotRequired)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollection.Processing)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollection.Failed)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollection.ActionRequired)]
    public void Validation_Works(SubscriptionDelegateResponseDataPaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollection.NotRequired)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollection.Processing)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollection.Failed)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(
        SubscriptionDelegateResponseDataPaymentCollection rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionDelegateResponseDataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionDelegateResponseDataPricingType.Free)]
    [InlineData(SubscriptionDelegateResponseDataPricingType.Paid)]
    [InlineData(SubscriptionDelegateResponseDataPricingType.Custom)]
    public void Validation_Works(SubscriptionDelegateResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionDelegateResponseDataPricingType.Free)]
    [InlineData(SubscriptionDelegateResponseDataPricingType.Paid)]
    [InlineData(SubscriptionDelegateResponseDataPricingType.Custom)]
    public void SerializationRoundtrip_Works(SubscriptionDelegateResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionDelegateResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionDelegateResponseDataStatus.PaymentPending)]
    [InlineData(SubscriptionDelegateResponseDataStatus.Active)]
    [InlineData(SubscriptionDelegateResponseDataStatus.Expired)]
    [InlineData(SubscriptionDelegateResponseDataStatus.InTrial)]
    [InlineData(SubscriptionDelegateResponseDataStatus.Canceled)]
    [InlineData(SubscriptionDelegateResponseDataStatus.NotStarted)]
    public void Validation_Works(SubscriptionDelegateResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionDelegateResponseDataStatus.PaymentPending)]
    [InlineData(SubscriptionDelegateResponseDataStatus.Active)]
    [InlineData(SubscriptionDelegateResponseDataStatus.Expired)]
    [InlineData(SubscriptionDelegateResponseDataStatus.InTrial)]
    [InlineData(SubscriptionDelegateResponseDataStatus.Canceled)]
    [InlineData(SubscriptionDelegateResponseDataStatus.NotStarted)]
    public void SerializationRoundtrip_Works(SubscriptionDelegateResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionDelegateResponseDataCancelReasonTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.Expired)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.DetachBilling)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.TrialEnded)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.Immediate)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.TrialConverted)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.CustomerArchived)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.AutoCancellationRule)]
    public void Validation_Works(SubscriptionDelegateResponseDataCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataCancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.Expired)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.DetachBilling)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.TrialEnded)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.Immediate)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.TrialConverted)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.CustomerArchived)]
    [InlineData(SubscriptionDelegateResponseDataCancelReason.AutoCancellationRule)]
    public void SerializationRoundtrip_Works(SubscriptionDelegateResponseDataCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataCancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionDelegateResponseDataPaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollectionMethod.None)]
    public void Validation_Works(SubscriptionDelegateResponseDataPaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionDelegateResponseDataPaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(
        SubscriptionDelegateResponseDataPaymentCollectionMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionDelegateResponseDataPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
