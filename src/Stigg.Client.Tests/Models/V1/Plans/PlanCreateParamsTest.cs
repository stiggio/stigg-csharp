using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Units.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PricingType.Free,
            Status = Status.Draft,
        };

        string expectedID = "id";
        string expectedDisplayName = "displayName";
        string expectedProductID = "productId";
        string expectedBillingID = "billingId";
        DefaultTrialConfig expectedDefaultTrialConfig = new()
        {
            Duration = 0,
            Units = Units.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
        };
        string expectedDescription = "description";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";
        ApiEnum<string, PricingType> expectedPricingType = PricingType.Free;
        ApiEnum<string, Status> expectedStatus = Status.Draft;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedProductID, parameters.ProductID);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.Equal(expectedDefaultTrialConfig, parameters.DefaultTrialConfig);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentPlanID, parameters.ParentPlanID);
        Assert.Equal(expectedPricingType, parameters.PricingType);
        Assert.Equal(expectedStatus, parameters.Status);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Units.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            ParentPlanID = "parentPlanId",
            PricingType = PricingType.Free,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Units.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            ParentPlanID = "parentPlanId",
            PricingType = PricingType.Free,

            // Null should be interpreted as omitted for these properties
            Metadata = null,
            Status = null,
        };

        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.Status);
        Assert.False(parameters.RawBodyData.ContainsKey("status"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Status.Draft,
        };

        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.DefaultTrialConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultTrialConfig"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("parentPlanId"));
        Assert.Null(parameters.PricingType);
        Assert.False(parameters.RawBodyData.ContainsKey("pricingType"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Status = Status.Draft,

            BillingID = null,
            DefaultTrialConfig = null,
            Description = null,
            ParentPlanID = null,
            PricingType = null,
        };

        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.DefaultTrialConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("defaultTrialConfig"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentPlanID);
        Assert.True(parameters.RawBodyData.ContainsKey("parentPlanId"));
        Assert.Null(parameters.PricingType);
        Assert.True(parameters.RawBodyData.ContainsKey("pricingType"));
    }

    [Fact]
    public void Url_Works()
    {
        PlanCreateParams parameters = new()
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanCreateParams
        {
            ID = "id",
            DisplayName = "displayName",
            ProductID = "productId",
            BillingID = "billingId",
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = Units.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
            PricingType = PricingType.Free,
            Status = Status.Draft,
        };

        PlanCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class DefaultTrialConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DefaultTrialConfig
        {
            Duration = 0,
            Units = Units.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
        };

        double expectedDuration = 0;
        ApiEnum<string, Units> expectedUnits = Units.Day;
        Budget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        ApiEnum<string, TrialEndBehavior> expectedTrialEndBehavior = TrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedUnits, model.Units);
        Assert.Equal(expectedBudget, model.Budget);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DefaultTrialConfig
        {
            Duration = 0,
            Units = Units.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultTrialConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DefaultTrialConfig
        {
            Duration = 0,
            Units = Units.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DefaultTrialConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDuration = 0;
        ApiEnum<string, Units> expectedUnits = Units.Day;
        Budget expectedBudget = new() { HasSoftLimit = true, Limit = 0 };
        ApiEnum<string, TrialEndBehavior> expectedTrialEndBehavior = TrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedUnits, deserialized.Units);
        Assert.Equal(expectedBudget, deserialized.Budget);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DefaultTrialConfig
        {
            Duration = 0,
            Units = Units.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new DefaultTrialConfig { Duration = 0, Units = Units.Day };

        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new DefaultTrialConfig { Duration = 0, Units = Units.Day };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new DefaultTrialConfig
        {
            Duration = 0,
            Units = Units.Day,

            Budget = null,
            TrialEndBehavior = null,
        };

        Assert.Null(model.Budget);
        Assert.True(model.RawData.ContainsKey("budget"));
        Assert.Null(model.TrialEndBehavior);
        Assert.True(model.RawData.ContainsKey("trialEndBehavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new DefaultTrialConfig
        {
            Duration = 0,
            Units = Units.Day,

            Budget = null,
            TrialEndBehavior = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DefaultTrialConfig
        {
            Duration = 0,
            Units = Units.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = TrialEndBehavior.ConvertToPaid,
        };

        DefaultTrialConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class UnitsTest : TestBase
{
    [Theory]
    [InlineData(Units.Day)]
    [InlineData(Units.Month)]
    public void Validation_Works(Units rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Units> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Units>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Units.Day)]
    [InlineData(Units.Month)]
    public void SerializationRoundtrip_Works(Units rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Units> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Units>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Units>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Units>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Budget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Budget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Budget>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Budget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Budget>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
        Assert.Equal(expectedLimit, deserialized.Limit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Budget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Budget { HasSoftLimit = true, Limit = 0 };

        Budget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class TrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(TrialEndBehavior.ConvertToPaid)]
    [InlineData(TrialEndBehavior.CancelSubscription)]
    public void Validation_Works(TrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(TrialEndBehavior.ConvertToPaid)]
    [InlineData(TrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(TrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, TrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialEndBehavior>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, TrialEndBehavior>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, TrialEndBehavior>>(
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

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Draft)]
    [InlineData(Status.Published)]
    [InlineData(Status.Archived)]
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
    [InlineData(Status.Draft)]
    [InlineData(Status.Published)]
    [InlineData(Status.Archived)]
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
