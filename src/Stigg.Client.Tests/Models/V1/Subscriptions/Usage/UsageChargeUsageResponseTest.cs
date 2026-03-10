using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions.Usage;

namespace Stigg.Client.Tests.Models.V1.Subscriptions.Usage;

public class UsageChargeUsageResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageChargeUsageResponse
        {
            Data = new()
            {
                InvoiceBillingID = "invoiceBillingId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscriptionId",
                UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
            },
        };

        Data expectedData = new()
        {
            InvoiceBillingID = "invoiceBillingId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscriptionId",
            UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageChargeUsageResponse
        {
            Data = new()
            {
                InvoiceBillingID = "invoiceBillingId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscriptionId",
                UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageChargeUsageResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageChargeUsageResponse
        {
            Data = new()
            {
                InvoiceBillingID = "invoiceBillingId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscriptionId",
                UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageChargeUsageResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            InvoiceBillingID = "invoiceBillingId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscriptionId",
            UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageChargeUsageResponse
        {
            Data = new()
            {
                InvoiceBillingID = "invoiceBillingId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscriptionId",
                UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageChargeUsageResponse
        {
            Data = new()
            {
                InvoiceBillingID = "invoiceBillingId",
                PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                SubscriptionID = "subscriptionId",
                UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
            },
        };

        UsageChargeUsageResponse copied = new(model);

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
            InvoiceBillingID = "invoiceBillingId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscriptionId",
            UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
        };

        string expectedInvoiceBillingID = "invoiceBillingId";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSubscriptionID = "subscriptionId";
        List<UsageCharged> expectedUsageCharged =
        [
            new() { FeatureID = "featureId", UsageAmount = 0 },
        ];

        Assert.Equal(expectedInvoiceBillingID, model.InvoiceBillingID);
        Assert.Equal(expectedPeriodEnd, model.PeriodEnd);
        Assert.Equal(expectedPeriodStart, model.PeriodStart);
        Assert.Equal(expectedSubscriptionID, model.SubscriptionID);
        Assert.Equal(expectedUsageCharged.Count, model.UsageCharged.Count);
        for (int i = 0; i < expectedUsageCharged.Count; i++)
        {
            Assert.Equal(expectedUsageCharged[i], model.UsageCharged[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            InvoiceBillingID = "invoiceBillingId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscriptionId",
            UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
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
            InvoiceBillingID = "invoiceBillingId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscriptionId",
            UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedInvoiceBillingID = "invoiceBillingId";
        DateTimeOffset expectedPeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedPeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedSubscriptionID = "subscriptionId";
        List<UsageCharged> expectedUsageCharged =
        [
            new() { FeatureID = "featureId", UsageAmount = 0 },
        ];

        Assert.Equal(expectedInvoiceBillingID, deserialized.InvoiceBillingID);
        Assert.Equal(expectedPeriodEnd, deserialized.PeriodEnd);
        Assert.Equal(expectedPeriodStart, deserialized.PeriodStart);
        Assert.Equal(expectedSubscriptionID, deserialized.SubscriptionID);
        Assert.Equal(expectedUsageCharged.Count, deserialized.UsageCharged.Count);
        for (int i = 0; i < expectedUsageCharged.Count; i++)
        {
            Assert.Equal(expectedUsageCharged[i], deserialized.UsageCharged[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            InvoiceBillingID = "invoiceBillingId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscriptionId",
            UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            InvoiceBillingID = "invoiceBillingId",
            PeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            PeriodStart = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            SubscriptionID = "subscriptionId",
            UsageCharged = [new() { FeatureID = "featureId", UsageAmount = 0 }],
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UsageChargedTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new UsageCharged { FeatureID = "featureId", UsageAmount = 0 };

        string expectedFeatureID = "featureId";
        double expectedUsageAmount = 0;

        Assert.Equal(expectedFeatureID, model.FeatureID);
        Assert.Equal(expectedUsageAmount, model.UsageAmount);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new UsageCharged { FeatureID = "featureId", UsageAmount = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageCharged>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new UsageCharged { FeatureID = "featureId", UsageAmount = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<UsageCharged>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedFeatureID = "featureId";
        double expectedUsageAmount = 0;

        Assert.Equal(expectedFeatureID, deserialized.FeatureID);
        Assert.Equal(expectedUsageAmount, deserialized.UsageAmount);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new UsageCharged { FeatureID = "featureId", UsageAmount = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new UsageCharged { FeatureID = "featureId", UsageAmount = 0 };

        UsageCharged copied = new(model);

        Assert.Equal(model, copied);
    }
}
