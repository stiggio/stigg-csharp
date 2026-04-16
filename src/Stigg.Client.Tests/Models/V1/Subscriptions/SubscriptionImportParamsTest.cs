using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
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
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingID = "billingId",
                    BillingPeriod = SubscriptionBillingPeriod.Monthly,
                    Charges =
                    [
                        new()
                        {
                            ID = "id",
                            Quantity = 1,
                            Type = SubscriptionChargeType.Feature,
                        },
                    ],
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
                Addons = [new() { ID = "id", Quantity = 0 }],
                BillingID = "billingId",
                BillingPeriod = SubscriptionBillingPeriod.Monthly,
                Charges =
                [
                    new()
                    {
                        ID = "id",
                        Quantity = 1,
                        Type = SubscriptionChargeType.Feature,
                    },
                ],
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
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingID = "billingId",
                    BillingPeriod = SubscriptionBillingPeriod.Monthly,
                    Charges =
                    [
                        new()
                        {
                            ID = "id",
                            Quantity = 1,
                            Type = SubscriptionChargeType.Feature,
                        },
                    ],
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
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingID = "billingId",
                    BillingPeriod = SubscriptionBillingPeriod.Monthly,
                    Charges =
                    [
                        new()
                        {
                            ID = "id",
                            Quantity = 1,
                            Type = SubscriptionChargeType.Feature,
                        },
                    ],
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
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingID = "billingId",
                    BillingPeriod = SubscriptionBillingPeriod.Monthly,
                    Charges =
                    [
                        new()
                        {
                            ID = "id",
                            Quantity = 1,
                            Type = SubscriptionChargeType.Feature,
                        },
                    ],
                    EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    ResourceID = "resourceId",
                    StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/subscriptions/import"), url)
        );
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
                    Addons = [new() { ID = "id", Quantity = 0 }],
                    BillingID = "billingId",
                    BillingPeriod = SubscriptionBillingPeriod.Monthly,
                    Charges =
                    [
                        new()
                        {
                            ID = "id",
                            Quantity = 1,
                            Type = SubscriptionChargeType.Feature,
                        },
                    ],
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingID = "billingId",
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedCustomerID = "customerId";
        string expectedPlanID = "planId";
        List<SubscriptionAddon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        string expectedBillingID = "billingId";
        ApiEnum<string, SubscriptionBillingPeriod> expectedBillingPeriod =
            SubscriptionBillingPeriod.Monthly;
        List<SubscriptionCharge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 1,
                Type = SubscriptionChargeType.Feature,
            },
        ];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedPlanID, model.PlanID);
        Assert.NotNull(model.Addons);
        Assert.Equal(expectedAddons.Count, model.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], model.Addons[i]);
        }
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedBillingPeriod, model.BillingPeriod);
        Assert.NotNull(model.Charges);
        Assert.Equal(expectedCharges.Count, model.Charges.Count);
        for (int i = 0; i < expectedCharges.Count; i++)
        {
            Assert.Equal(expectedCharges[i], model.Charges[i]);
        }
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingID = "billingId",
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingID = "billingId",
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
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
        List<SubscriptionAddon> expectedAddons = [new() { ID = "id", Quantity = 0 }];
        string expectedBillingID = "billingId";
        ApiEnum<string, SubscriptionBillingPeriod> expectedBillingPeriod =
            SubscriptionBillingPeriod.Monthly;
        List<SubscriptionCharge> expectedCharges =
        [
            new()
            {
                ID = "id",
                Quantity = 1,
                Type = SubscriptionChargeType.Feature,
            },
        ];
        DateTimeOffset expectedEndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedResourceID = "resourceId";
        DateTimeOffset expectedStartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedPlanID, deserialized.PlanID);
        Assert.NotNull(deserialized.Addons);
        Assert.Equal(expectedAddons.Count, deserialized.Addons.Count);
        for (int i = 0; i < expectedAddons.Count; i++)
        {
            Assert.Equal(expectedAddons[i], deserialized.Addons[i]);
        }
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedBillingPeriod, deserialized.BillingPeriod);
        Assert.NotNull(deserialized.Charges);
        Assert.Equal(expectedCharges.Count, deserialized.Charges.Count);
        for (int i = 0; i < expectedCharges.Count; i++)
        {
            Assert.Equal(expectedCharges[i], deserialized.Charges[i]);
        }
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingID = "billingId",
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
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

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.BillingPeriod);
        Assert.False(model.RawData.ContainsKey("billingPeriod"));
        Assert.Null(model.Charges);
        Assert.False(model.RawData.ContainsKey("charges"));
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
            Addons = null,
            BillingPeriod = null,
            Charges = null,
            Metadata = null,
            StartDate = null,
        };

        Assert.Null(model.Addons);
        Assert.False(model.RawData.ContainsKey("addons"));
        Assert.Null(model.BillingPeriod);
        Assert.False(model.RawData.ContainsKey("billingPeriod"));
        Assert.Null(model.Charges);
        Assert.False(model.RawData.ContainsKey("charges"));
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
            Addons = null,
            BillingPeriod = null,
            Charges = null,
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
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
            Addons = [new() { ID = "id", Quantity = 0 }],
            BillingID = "billingId",
            BillingPeriod = SubscriptionBillingPeriod.Monthly,
            Charges =
            [
                new()
                {
                    ID = "id",
                    Quantity = 1,
                    Type = SubscriptionChargeType.Feature,
                },
            ],
            EndDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ResourceID = "resourceId",
            StartDate = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Subscription copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionAddonTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionAddon { ID = "id", Quantity = 0 };

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionAddon { ID = "id", Quantity = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionAddon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionAddon { ID = "id", Quantity = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionAddon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        long expectedQuantity = 0;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionAddon { ID = "id", Quantity = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionAddon { ID = "id", Quantity = 0 };

        SubscriptionAddon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionBillingPeriodTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionBillingPeriod.Monthly)]
    [InlineData(SubscriptionBillingPeriod.Annually)]
    public void Validation_Works(SubscriptionBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionBillingPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionBillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionBillingPeriod.Monthly)]
    [InlineData(SubscriptionBillingPeriod.Annually)]
    public void SerializationRoundtrip_Works(SubscriptionBillingPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionBillingPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionBillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionBillingPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionBillingPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SubscriptionChargeTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SubscriptionCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionChargeType.Feature,
        };

        string expectedID = "id";
        double expectedQuantity = 1;
        ApiEnum<string, SubscriptionChargeType> expectedType = SubscriptionChargeType.Feature;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedQuantity, model.Quantity);
        Assert.Equal(expectedType, model.Type);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SubscriptionCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionChargeType.Feature,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCharge>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SubscriptionCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionChargeType.Feature,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SubscriptionCharge>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedQuantity = 1;
        ApiEnum<string, SubscriptionChargeType> expectedType = SubscriptionChargeType.Feature;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedQuantity, deserialized.Quantity);
        Assert.Equal(expectedType, deserialized.Type);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SubscriptionCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionChargeType.Feature,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SubscriptionCharge
        {
            ID = "id",
            Quantity = 1,
            Type = SubscriptionChargeType.Feature,
        };

        SubscriptionCharge copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SubscriptionChargeTypeTest : TestBase
{
    [Theory]
    [InlineData(SubscriptionChargeType.Feature)]
    [InlineData(SubscriptionChargeType.Credit)]
    public void Validation_Works(SubscriptionChargeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionChargeType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionChargeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SubscriptionChargeType.Feature)]
    [InlineData(SubscriptionChargeType.Credit)]
    public void SerializationRoundtrip_Works(SubscriptionChargeType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SubscriptionChargeType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionChargeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionChargeType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, SubscriptionChargeType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
