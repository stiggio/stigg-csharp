using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Subscriptions;

namespace Stigg.Tests.Models.V1.Subscriptions;

public class SubscriptionCreateResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
        };

        Data expectedData = new()
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCreateResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCreateResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionCreateResponse
        {
            Data = new()
            {
                ID = "id",
                Status = Status.Success,
                CheckoutBillingID = "checkoutBillingId",
                CheckoutUrl = "checkoutUrl",
                IsScheduled = true,
                Subscription = new()
                {
                    ID = "id",
                    BillingID = "billingId",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CustomerID = "customerId",
                    PaymentCollection = PaymentCollection.NotRequired,
                    PlanID = "planId",
                    PricingType = PricingType.Free,
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = SubscriptionStatus.PaymentPending,
                    CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CancelReason = CancelReason.UpgradeOrDowngrade,
                    CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PayingCustomerID = "payingCustomerId",
                    PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                    ResourceID = "resourceId",
                    TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            },
        };

        SubscriptionCreateResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Success;
        string expectedCheckoutBillingID = "checkoutBillingId";
        string expectedCheckoutUrl = "checkoutUrl";
        bool expectedIsScheduled = true;
        Subscription expectedSubscription = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedCheckoutBillingID, model.CheckoutBillingID);
        Assert.Equal(expectedCheckoutUrl, model.CheckoutUrl);
        Assert.Equal(expectedIsScheduled, model.IsScheduled);
        Assert.Equal(expectedSubscription, model.Subscription);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, Status> expectedStatus = Status.Success;
        string expectedCheckoutBillingID = "checkoutBillingId";
        string expectedCheckoutUrl = "checkoutUrl";
        bool expectedIsScheduled = true;
        Subscription expectedSubscription = new()
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedCheckoutBillingID, deserialized.CheckoutBillingID);
        Assert.Equal(expectedCheckoutUrl, deserialized.CheckoutUrl);
        Assert.Equal(expectedIsScheduled, deserialized.IsScheduled);
        Assert.Equal(expectedSubscription, deserialized.Subscription);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
        };

        Assert.Null(model.IsScheduled);
        Assert.False(model.RawData.ContainsKey("isScheduled"));
        Assert.Null(model.Subscription);
        Assert.False(model.RawData.ContainsKey("subscription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",

            // Null should be interpreted as omitted for these properties
            IsScheduled = null,
            Subscription = null,
        };

        Assert.Null(model.IsScheduled);
        Assert.False(model.RawData.ContainsKey("isScheduled"));
        Assert.Null(model.Subscription);
        Assert.False(model.RawData.ContainsKey("subscription"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",

            // Null should be interpreted as omitted for these properties
            IsScheduled = null,
            Subscription = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Assert.Null(model.CheckoutBillingID);
        Assert.False(model.RawData.ContainsKey("checkoutBillingId"));
        Assert.Null(model.CheckoutUrl);
        Assert.False(model.RawData.ContainsKey("checkoutUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            CheckoutBillingID = null,
            CheckoutUrl = null,
        };

        Assert.Null(model.CheckoutBillingID);
        Assert.True(model.RawData.ContainsKey("checkoutBillingId"));
        Assert.Null(model.CheckoutUrl);
        Assert.True(model.RawData.ContainsKey("checkoutUrl"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },

            CheckoutBillingID = null,
            CheckoutUrl = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "id",
            Status = Status.Success,
            CheckoutBillingID = "checkoutBillingId",
            CheckoutUrl = "checkoutUrl",
            IsScheduled = true,
            Subscription = new()
            {
                ID = "id",
                BillingID = "billingId",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CustomerID = "customerId",
                PaymentCollection = PaymentCollection.NotRequired,
                PlanID = "planId",
                PricingType = PricingType.Free,
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = SubscriptionStatus.PaymentPending,
                CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CancelReason = CancelReason.UpgradeOrDowngrade,
                CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PayingCustomerID = "payingCustomerId",
                PaymentCollectionMethod = PaymentCollectionMethod.Charge,
                ResourceID = "resourceId",
                TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Success)]
    [InlineData(Status.PaymentRequired)]
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
    [InlineData(Status.Success)]
    [InlineData(Status.PaymentRequired)]
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

public class SubscriptionTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<string, PaymentCollection> expectedPaymentCollection =
            PaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, PricingType> expectedPricingType = PricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CancelReason> expectedCancelReason = CancelReason.UpgradeOrDowngrade;
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
        ApiEnum<string, PaymentCollectionMethod> expectedPaymentCollectionMethod =
            PaymentCollectionMethod.Charge;
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
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCustomerID = "customerId";
        ApiEnum<string, PaymentCollection> expectedPaymentCollection =
            PaymentCollection.NotRequired;
        string expectedPlanID = "planId";
        ApiEnum<string, PricingType> expectedPricingType = PricingType.Free;
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, SubscriptionStatus> expectedStatus = SubscriptionStatus.PaymentPending;
        DateTimeOffset expectedCancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, CancelReason> expectedCancelReason = CancelReason.UpgradeOrDowngrade;
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
        ApiEnum<string, PaymentCollectionMethod> expectedPaymentCollectionMethod =
            PaymentCollectionMethod.Charge;
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
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
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
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
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
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
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
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
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
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
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
        var model = new Subscription
        {
            ID = "id",
            BillingID = "billingId",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CustomerID = "customerId",
            PaymentCollection = PaymentCollection.NotRequired,
            PlanID = "planId",
            PricingType = PricingType.Free,
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = SubscriptionStatus.PaymentPending,
            CancellationDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CancelReason = CancelReason.UpgradeOrDowngrade,
            CurrentBillingPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrentBillingPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EffectiveEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PayingCustomerID = "payingCustomerId",
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            ResourceID = "resourceId",
            TrialEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PaymentCollectionTest : TestBase
{
    [Theory]
    [InlineData(PaymentCollection.NotRequired)]
    [InlineData(PaymentCollection.Processing)]
    [InlineData(PaymentCollection.Failed)]
    [InlineData(PaymentCollection.ActionRequired)]
    public void Validation_Works(PaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollection> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentCollection.NotRequired)]
    [InlineData(PaymentCollection.Processing)]
    [InlineData(PaymentCollection.Failed)]
    [InlineData(PaymentCollection.ActionRequired)]
    public void SerializationRoundtrip_Works(PaymentCollection rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollection> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollection>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PricingTypeTest : TestBase
{
    [Theory]
    [InlineData(PricingType.Free)]
    [InlineData(PricingType.Paid)]
    [InlineData(PricingType.Custom)]
    public void Validation_Works(PricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PricingType.Free)]
    [InlineData(PricingType.Paid)]
    [InlineData(PricingType.Custom)]
    public void SerializationRoundtrip_Works(PricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PricingType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionStatusTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionStatus.PaymentPending)]
    [InlineData(SubscriptionStatus.Active)]
    [InlineData(SubscriptionStatus.Expired)]
    [InlineData(SubscriptionStatus.InTrial)]
    [InlineData(SubscriptionStatus.Canceled)]
    [InlineData(SubscriptionStatus.NotStarted)]
    public void Validation_Works(SubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionStatus.PaymentPending)]
    [InlineData(SubscriptionStatus.Active)]
    [InlineData(SubscriptionStatus.Expired)]
    [InlineData(SubscriptionStatus.InTrial)]
    [InlineData(SubscriptionStatus.Canceled)]
    [InlineData(SubscriptionStatus.NotStarted)]
    public void SerializationRoundtrip_Works(SubscriptionStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CancelReasonTest : TestBase
{
    [Theory]
    [InlineData(CancelReason.UpgradeOrDowngrade)]
    [InlineData(CancelReason.CancelledByBilling)]
    [InlineData(CancelReason.Expired)]
    [InlineData(CancelReason.DetachBilling)]
    [InlineData(CancelReason.TrialEnded)]
    [InlineData(CancelReason.Immediate)]
    [InlineData(CancelReason.TrialConverted)]
    [InlineData(CancelReason.PendingPaymentExpired)]
    [InlineData(CancelReason.ScheduledCancellation)]
    [InlineData(CancelReason.CustomerArchived)]
    [InlineData(CancelReason.AutoCancellationRule)]
    public void Validation_Works(CancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancelReason> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CancelReason.UpgradeOrDowngrade)]
    [InlineData(CancelReason.CancelledByBilling)]
    [InlineData(CancelReason.Expired)]
    [InlineData(CancelReason.DetachBilling)]
    [InlineData(CancelReason.TrialEnded)]
    [InlineData(CancelReason.Immediate)]
    [InlineData(CancelReason.TrialConverted)]
    [InlineData(CancelReason.PendingPaymentExpired)]
    [InlineData(CancelReason.ScheduledCancellation)]
    [InlineData(CancelReason.CustomerArchived)]
    [InlineData(CancelReason.AutoCancellationRule)]
    public void SerializationRoundtrip_Works(CancelReason rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CancelReason> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CancelReason>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class PaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(PaymentCollectionMethod.Charge)]
    [InlineData(PaymentCollectionMethod.Invoice)]
    [InlineData(PaymentCollectionMethod.None)]
    public void Validation_Works(PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentCollectionMethod.Charge)]
    [InlineData(PaymentCollectionMethod.Invoice)]
    [InlineData(PaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
