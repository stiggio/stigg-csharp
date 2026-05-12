using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;

namespace Stigg.Client.Tests.Models.V1.Subscriptions;

public class SubscriptionListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new SubscriptionListParams
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CustomerID = "customerId",
            Limit = 1,
            PlanID = "planId",
            PricingType = [PricingType.Free],
            ResourceID = "resourceId",
            Status = [Status.PaymentPending],
        };

        string expectedAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        CreatedAt expectedCreatedAt = new()
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedCustomerID = "customerId";
        long expectedLimit = 1;
        string expectedPlanID = "planId";
        List<ApiEnum<string, PricingType>> expectedPricingType = [PricingType.Free];
        string expectedResourceID = "resourceId";
        List<ApiEnum<string, Status>> expectedStatus = [Status.PaymentPending];

        Assert.Equal(expectedAfter, parameters.After);
        Assert.Equal(expectedBefore, parameters.Before);
        Assert.Equal(expectedCreatedAt, parameters.CreatedAt);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedPlanID, parameters.PlanID);
        Assert.NotNull(parameters.PricingType);
        Assert.Equal(expectedPricingType.Count, parameters.PricingType.Count);
        for (int i = 0; i < expectedPricingType.Count; i++)
        {
            Assert.Equal(expectedPricingType[i], parameters.PricingType[i]);
        }
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.NotNull(parameters.Status);
        Assert.Equal(expectedStatus.Count, parameters.Status.Count);
        for (int i = 0; i < expectedStatus.Count; i++)
        {
            Assert.Equal(expectedStatus[i], parameters.Status[i]);
        }
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams { };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("createdAt"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customerId"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PlanID);
        Assert.False(parameters.RawQueryData.ContainsKey("planId"));
        Assert.Null(parameters.PricingType);
        Assert.False(parameters.RawQueryData.ContainsKey("pricingType"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new SubscriptionListParams
        {
            // Null should be interpreted as omitted for these properties
            After = null,
            Before = null,
            CreatedAt = null,
            CustomerID = null,
            Limit = null,
            PlanID = null,
            PricingType = null,
            ResourceID = null,
            Status = null,
        };

        Assert.Null(parameters.After);
        Assert.False(parameters.RawQueryData.ContainsKey("after"));
        Assert.Null(parameters.Before);
        Assert.False(parameters.RawQueryData.ContainsKey("before"));
        Assert.Null(parameters.CreatedAt);
        Assert.False(parameters.RawQueryData.ContainsKey("createdAt"));
        Assert.Null(parameters.CustomerID);
        Assert.False(parameters.RawQueryData.ContainsKey("customerId"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.PlanID);
        Assert.False(parameters.RawQueryData.ContainsKey("planId"));
        Assert.Null(parameters.PricingType);
        Assert.False(parameters.RawQueryData.ContainsKey("pricingType"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawQueryData.ContainsKey("resourceId"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawQueryData.ContainsKey("status"));
    }

    [Fact]
    public void Url_Works()
    {
        SubscriptionListParams parameters = new()
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117+00:00"),
            },
            CustomerID = "customerId",
            Limit = 1,
            PlanID = "planId",
            PricingType = [PricingType.Free],
            ResourceID = "resourceId",
            Status = [Status.PaymentPending],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri(
                    "https://api.stigg.io/api/v1/subscriptions?after=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&before=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&createdAt%5bgt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5bgte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5blt%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&createdAt%5blte%5d=2019-12-27T18%3a11%3a19.117%2b00%3a00&customerId=customerId&limit=1&planId=planId&pricingType=FREE&resourceId=resourceId&status=PAYMENT_PENDING"
                ),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new SubscriptionListParams
        {
            After = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Before = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            CreatedAt = new()
            {
                Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            CustomerID = "customerId",
            Limit = 1,
            PlanID = "planId",
            PricingType = [PricingType.Free],
            ResourceID = "resourceId",
            Status = [Status.PaymentPending],
        };

        SubscriptionListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CreatedAtTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        DateTimeOffset expectedGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedGt, model.Gt);
        Assert.Equal(expectedGte, model.Gte);
        Assert.Equal(expectedLt, model.Lt);
        Assert.Equal(expectedLte, model.Lte);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CreatedAt>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        DateTimeOffset expectedGt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedGte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedLte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedGt, deserialized.Gt);
        Assert.Equal(expectedGte, deserialized.Gte);
        Assert.Equal(expectedLt, deserialized.Lt);
        Assert.Equal(expectedLte, deserialized.Lte);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new CreatedAt { };

        Assert.Null(model.Gt);
        Assert.False(model.RawData.ContainsKey("gt"));
        Assert.Null(model.Gte);
        Assert.False(model.RawData.ContainsKey("gte"));
        Assert.Null(model.Lt);
        Assert.False(model.RawData.ContainsKey("lt"));
        Assert.Null(model.Lte);
        Assert.False(model.RawData.ContainsKey("lte"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new CreatedAt { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            Gt = null,
            Gte = null,
            Lt = null,
            Lte = null,
        };

        Assert.Null(model.Gt);
        Assert.False(model.RawData.ContainsKey("gt"));
        Assert.Null(model.Gte);
        Assert.False(model.RawData.ContainsKey("gte"));
        Assert.Null(model.Lt);
        Assert.False(model.RawData.ContainsKey("lt"));
        Assert.Null(model.Lte);
        Assert.False(model.RawData.ContainsKey("lte"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new CreatedAt
        {
            // Null should be interpreted as omitted for these properties
            Gt = null,
            Gte = null,
            Lt = null,
            Lte = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CreatedAt
        {
            Gt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Gte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Lte = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CreatedAt copied = new(model);

        Assert.Equal(model, copied);
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

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.PaymentPending)]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    [InlineData(Status.InTrial)]
    [InlineData(Status.Canceled)]
    [InlineData(Status.NotStarted)]
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
    [InlineData(Status.PaymentPending)]
    [InlineData(Status.Active)]
    [InlineData(Status.Expired)]
    [InlineData(Status.InTrial)]
    [InlineData(Status.Canceled)]
    [InlineData(Status.NotStarted)]
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
