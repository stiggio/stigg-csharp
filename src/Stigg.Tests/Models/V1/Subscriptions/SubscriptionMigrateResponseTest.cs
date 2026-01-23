using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Subscriptions;

namespace Stigg.Tests.Models.V1.Subscriptions;

public class SubscriptionMigrateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionMigrateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionMigrateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        SubscriptionMigrateResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionMigrateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionMigrateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionMigrateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionMigrateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionMigrateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionMigrateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SubscriptionMigrateResponseData expectedData = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionMigrateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionMigrateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionMigrateResponse
        {
            Data = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = SubscriptionMigrateResponseDataPricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod =
                    SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        SubscriptionMigrateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionMigrateResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<
            string,
            SubscriptionMigrateResponseDataPaymentCollection
        > expectedPaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionMigrateResponseDataPricingType> expectedPricingType =
            SubscriptionMigrateResponseDataPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionMigrateResponseDataStatus> expectedStatus =
            SubscriptionMigrateResponseDataStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionMigrateResponseDataCancelReason> expectedCancelReason =
            SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade;
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
            SubscriptionMigrateResponseDataPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge;
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
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionMigrateResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionMigrateResponseData>(
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
            SubscriptionMigrateResponseDataPaymentCollection
        > expectedPaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, SubscriptionMigrateResponseDataPricingType> expectedPricingType =
            SubscriptionMigrateResponseDataPricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionMigrateResponseDataStatus> expectedStatus =
            SubscriptionMigrateResponseDataStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionMigrateResponseDataCancelReason> expectedCancelReason =
            SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade;
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
            SubscriptionMigrateResponseDataPaymentCollectionMethod
        > expectedPaymentCollectionMethod =
            SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge;
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
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
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
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
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
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
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
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
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
        var model = new SubscriptionMigrateResponseData
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = SubscriptionMigrateResponseDataPaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = SubscriptionMigrateResponseDataPricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionMigrateResponseDataStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        SubscriptionMigrateResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionMigrateResponseDataPaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollection.NotRequired)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollection.Processing)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollection.Failed)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollection.ActionRequired)]
    public void Validation_Works(SubscriptionMigrateResponseDataPaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollection.NotRequired)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollection.Processing)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollection.Failed)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(
        SubscriptionMigrateResponseDataPaymentCollection rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollection>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollection>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionMigrateResponseDataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionMigrateResponseDataPricingType.Free)]
    [InlineData(SubscriptionMigrateResponseDataPricingType.Paid)]
    [InlineData(SubscriptionMigrateResponseDataPricingType.Custom)]
    public void Validation_Works(SubscriptionMigrateResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionMigrateResponseDataPricingType.Free)]
    [InlineData(SubscriptionMigrateResponseDataPricingType.Paid)]
    [InlineData(SubscriptionMigrateResponseDataPricingType.Custom)]
    public void SerializationRoundtrip_Works(SubscriptionMigrateResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionMigrateResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionMigrateResponseDataStatus.PaymentPending)]
    [InlineData(SubscriptionMigrateResponseDataStatus.Active)]
    [InlineData(SubscriptionMigrateResponseDataStatus.Expired)]
    [InlineData(SubscriptionMigrateResponseDataStatus.InTrial)]
    [InlineData(SubscriptionMigrateResponseDataStatus.Canceled)]
    [InlineData(SubscriptionMigrateResponseDataStatus.NotStarted)]
    public void Validation_Works(SubscriptionMigrateResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionMigrateResponseDataStatus.PaymentPending)]
    [InlineData(SubscriptionMigrateResponseDataStatus.Active)]
    [InlineData(SubscriptionMigrateResponseDataStatus.Expired)]
    [InlineData(SubscriptionMigrateResponseDataStatus.InTrial)]
    [InlineData(SubscriptionMigrateResponseDataStatus.Canceled)]
    [InlineData(SubscriptionMigrateResponseDataStatus.NotStarted)]
    public void SerializationRoundtrip_Works(SubscriptionMigrateResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataStatus>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionMigrateResponseDataCancelReasonTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.Expired)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.DetachBilling)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.TrialEnded)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.Immediate)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.TrialConverted)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.CustomerArchived)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.AutoCancellationRule)]
    public void Validation_Works(SubscriptionMigrateResponseDataCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataCancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.UpgradeOrDowngrade)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.CancelledByBilling)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.Expired)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.DetachBilling)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.TrialEnded)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.Immediate)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.TrialConverted)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.PendingPaymentExpired)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.ScheduledCancellation)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.CustomerArchived)]
    [InlineData(SubscriptionMigrateResponseDataCancelReason.AutoCancellationRule)]
    public void SerializationRoundtrip_Works(SubscriptionMigrateResponseDataCancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataCancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataCancelReason>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataCancelReason>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionMigrateResponseDataPaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollectionMethod.None)]
    public void Validation_Works(SubscriptionMigrateResponseDataPaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollectionMethod.Charge)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollectionMethod.Invoice)]
    [InlineData(SubscriptionMigrateResponseDataPaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(
        SubscriptionMigrateResponseDataPaymentCollectionMethod rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollectionMethod>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SubscriptionMigrateResponseDataPaymentCollectionMethod>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
