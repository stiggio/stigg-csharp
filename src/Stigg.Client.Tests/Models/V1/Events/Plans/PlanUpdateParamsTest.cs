using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Tests.Models.V1.Events.Plans;

public class PlanUpdateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
        };

        string expectedID = "x";
        string expectedBillingID = "billingId";
        List<string> expectedCompatibleAddonIds = ["string"];
        PlanUpdateParamsDefaultTrialConfig expectedDefaultTrialConfig = new()
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };
        string expectedDescription = "description";
        string expectedDisplayName = "displayName";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedParentPlanID = "parentPlanId";

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedBillingID, parameters.BillingID);
        Assert.NotNull(parameters.CompatibleAddonIds);
        Assert.Equal(expectedCompatibleAddonIds.Count, parameters.CompatibleAddonIds.Count);
        for (int i = 0; i < expectedCompatibleAddonIds.Count; i++)
        {
            Assert.Equal(expectedCompatibleAddonIds[i], parameters.CompatibleAddonIds[i]);
        }
        Assert.Equal(expectedDefaultTrialConfig, parameters.DefaultTrialConfig);
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedParentPlanID, parameters.ParentPlanID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            ParentPlanID = "parentPlanId",
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            ParentPlanID = "parentPlanId",

            // Null should be interpreted as omitted for these properties
            DisplayName = null,
            Metadata = null,
        };

        Assert.Null(parameters.DisplayName);
        Assert.False(parameters.RawBodyData.ContainsKey("displayName"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
    }

    [Fact]
    public void OptionalNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
        };

        Assert.Null(parameters.BillingID);
        Assert.False(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CompatibleAddonIds);
        Assert.False(parameters.RawBodyData.ContainsKey("compatibleAddonIds"));
        Assert.Null(parameters.DefaultTrialConfig);
        Assert.False(parameters.RawBodyData.ContainsKey("defaultTrialConfig"));
        Assert.Null(parameters.Description);
        Assert.False(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentPlanID);
        Assert.False(parameters.RawBodyData.ContainsKey("parentPlanId"));
    }

    [Fact]
    public void OptionalNullableParamsSetToNullAreSetToNull_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },

            BillingID = null,
            CompatibleAddonIds = null,
            DefaultTrialConfig = null,
            Description = null,
            ParentPlanID = null,
        };

        Assert.Null(parameters.BillingID);
        Assert.True(parameters.RawBodyData.ContainsKey("billingId"));
        Assert.Null(parameters.CompatibleAddonIds);
        Assert.True(parameters.RawBodyData.ContainsKey("compatibleAddonIds"));
        Assert.Null(parameters.DefaultTrialConfig);
        Assert.True(parameters.RawBodyData.ContainsKey("defaultTrialConfig"));
        Assert.Null(parameters.Description);
        Assert.True(parameters.RawBodyData.ContainsKey("description"));
        Assert.Null(parameters.ParentPlanID);
        Assert.True(parameters.RawBodyData.ContainsKey("parentPlanId"));
    }

    [Fact]
    public void Url_Works()
    {
        PlanUpdateParams parameters = new() { ID = "x" };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/plans/x"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanUpdateParams
        {
            ID = "x",
            BillingID = "billingId",
            CompatibleAddonIds = ["string"],
            DefaultTrialConfig = new()
            {
                Duration = 0,
                Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
                Budget = new() { HasSoftLimit = true, Limit = 0 },
                TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
            },
            Description = "description",
            DisplayName = "displayName",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            ParentPlanID = "parentPlanId",
        };

        PlanUpdateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class PlanUpdateParamsDefaultTrialConfigTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        double expectedDuration = 0;
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> expectedUnits =
            PlanUpdateParamsDefaultTrialConfigUnits.Day;
        PlanUpdateParamsDefaultTrialConfigBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        ApiEnum<
            string,
            PlanUpdateParamsDefaultTrialConfigTrialEndBehavior
        > expectedTrialEndBehavior =
            PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, model.Duration);
        Assert.Equal(expectedUnits, model.Units);
        Assert.Equal(expectedBudget, model.Budget);
        Assert.Equal(expectedTrialEndBehavior, model.TrialEndBehavior);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanUpdateParamsDefaultTrialConfig>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanUpdateParamsDefaultTrialConfig>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedDuration = 0;
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> expectedUnits =
            PlanUpdateParamsDefaultTrialConfigUnits.Day;
        PlanUpdateParamsDefaultTrialConfigBudget expectedBudget = new()
        {
            HasSoftLimit = true,
            Limit = 0,
        };
        ApiEnum<
            string,
            PlanUpdateParamsDefaultTrialConfigTrialEndBehavior
        > expectedTrialEndBehavior =
            PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid;

        Assert.Equal(expectedDuration, deserialized.Duration);
        Assert.Equal(expectedUnits, deserialized.Units);
        Assert.Equal(expectedBudget, deserialized.Budget);
        Assert.Equal(expectedTrialEndBehavior, deserialized.TrialEndBehavior);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
        };

        Assert.Null(model.Budget);
        Assert.False(model.RawData.ContainsKey("budget"));
        Assert.Null(model.TrialEndBehavior);
        Assert.False(model.RawData.ContainsKey("trialEndBehavior"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,

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
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,

            Budget = null,
            TrialEndBehavior = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfig
        {
            Duration = 0,
            Units = PlanUpdateParamsDefaultTrialConfigUnits.Day,
            Budget = new() { HasSoftLimit = true, Limit = 0 },
            TrialEndBehavior = PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid,
        };

        PlanUpdateParamsDefaultTrialConfig copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanUpdateParamsDefaultTrialConfigUnitsTest : TestBase
{
    [Theory]
    [InlineData(PlanUpdateParamsDefaultTrialConfigUnits.Day)]
    [InlineData(PlanUpdateParamsDefaultTrialConfigUnits.Month)]
    public void Validation_Works(PlanUpdateParamsDefaultTrialConfigUnits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanUpdateParamsDefaultTrialConfigUnits.Day)]
    [InlineData(PlanUpdateParamsDefaultTrialConfigUnits.Month)]
    public void SerializationRoundtrip_Works(PlanUpdateParamsDefaultTrialConfigUnits rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigUnits>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class PlanUpdateParamsDefaultTrialConfigBudgetTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, model.HasSoftLimit);
        Assert.Equal(expectedLimit, model.Limit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanUpdateParamsDefaultTrialConfigBudget>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<PlanUpdateParamsDefaultTrialConfigBudget>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        bool expectedHasSoftLimit = true;
        double expectedLimit = 0;

        Assert.Equal(expectedHasSoftLimit, deserialized.HasSoftLimit);
        Assert.Equal(expectedLimit, deserialized.Limit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new PlanUpdateParamsDefaultTrialConfigBudget { HasSoftLimit = true, Limit = 0 };

        PlanUpdateParamsDefaultTrialConfigBudget copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class PlanUpdateParamsDefaultTrialConfigTrialEndBehaviorTest : TestBase
{
    [Theory]
    [InlineData(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid)]
    [InlineData(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.CancelSubscription)]
    public void Validation_Works(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.ConvertToPaid)]
    [InlineData(PlanUpdateParamsDefaultTrialConfigTrialEndBehavior.CancelSubscription)]
    public void SerializationRoundtrip_Works(
        PlanUpdateParamsDefaultTrialConfigTrialEndBehavior rawValue
    )
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, PlanUpdateParamsDefaultTrialConfigTrialEndBehavior>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
