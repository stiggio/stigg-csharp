using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionImportParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionImportParams
        {
            Subscriptions =
            [
                new()
                {
                    ID = "id",
                    CustomerID = "customerId",
                    PlanID = "planId",
                    BillingID = "billingId",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            IntegrationID = "integrationId",
        };

        List<Subscription> expectedSubscriptions =
        [
            new()
            {
                ID = "id",
                CustomerID = "customerId",
                PlanID = "planId",
                BillingID = "billingId",
                EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                ResourceID = "resourceId",
                StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedIntegrationID = "integrationId";

        Assert.Equal(expectedSubscriptions.Count, parameters.Subscriptions.Count);
        for (int i = 0; i < expectedSubscriptions.Count; i++)
        {
            Assert.Equal(expectedSubscriptions[i], parameters.Subscriptions[i]);
        }
        Assert.Equal(expectedIntegrationID, parameters.IntegrationID);
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionImportParams
        {
            Subscriptions =
            [
                new()
                {
                    ID = "id",
                    CustomerID = "customerId",
                    PlanID = "planId",
                    BillingID = "billingId",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Null(parameters.IntegrationID);
        Assert.False(parameters.RawBodyData.ContainsKey("integrationId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new SubscriptionImportParams
        {
            Subscriptions =
            [
                new()
                {
                    ID = "id",
                    CustomerID = "customerId",
                    PlanID = "planId",
                    BillingID = "billingId",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            IntegrationID = null,
        };

        Assert.Null(parameters.IntegrationID);
        Assert.True(parameters.RawBodyData.ContainsKey("integrationId"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionImportParams parameters = new()
        {
            Subscriptions =
            [
                new()
                {
                    ID = "id",
                    CustomerID = "customerId",
                    PlanID = "planId",
                    BillingID = "billingId",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.example.com/api/v1/subscriptions/import"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionImportParams
        {
            Subscriptions =
            [
                new()
                {
                    ID = "id",
                    CustomerID = "customerId",
                    PlanID = "planId",
                    BillingID = "billingId",
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            IntegrationID = "integrationId",
        };

        SubscriptionImportParams copied = new(parameters);

        Assert.Equal(parameters, copied);
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
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedEndDate, model.EndDate);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedResourceID, model.ResourceID);
        Assert.Equal(expectedStartDate, model.StartDate);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Subscription>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        string expectedBillingID = "billingId";
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedEndDate, deserialized.EndDate);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
        Assert.Equal(expectedStartDate, deserialized.StartDate);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            StartDate = null,
        };

        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.StartDate);
        Assert.False(model.RawData.ContainsKey("startDate"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ResourceID = "resourceId",

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            StartDate = null,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.BillingID);
        Assert.False(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.EndDate);
        Assert.False(model.RawData.ContainsKey("endDate"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            BillingID = null,
            EndDate = null,
            ResourceID = null,
        };

        Assert.Null(model.BillingID);
        Assert.True(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.EndDate);
        Assert.True(model.RawData.ContainsKey("endDate"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            BillingID = null,
            EndDate = null,
            ResourceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Subscription
        {
            ID = "id",
            CustomerID = "customerId",
            PlanID = "planId",
            BillingID = "billingId",
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}
