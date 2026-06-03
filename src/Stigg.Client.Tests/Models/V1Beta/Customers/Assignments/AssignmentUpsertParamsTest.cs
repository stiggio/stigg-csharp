using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1Beta.Customers.Assignments;

namespace Stigg.Client.Tests.Models.V1Beta.Customers.Assignments;

public class AssignmentUpsertParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new AssignmentUpsertParams
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    CapabilityID = "compute-minutes",
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    UsageLimit = 1000,
                },
                new()
                {
                    CapabilityID = "compute-minutes",
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    UsageLimit = 2000,
                },
            ],
        };

        string expectedID = "id";
        List<Assignment> expectedAssignments =
        [
            new()
            {
                CapabilityID = "compute-minutes",
                EntityID = "workspace-001",
                Cadence = Cadence.Month,
                UsageLimit = 1000,
            },
            new()
            {
                CapabilityID = "compute-minutes",
                EntityID = "workspace-002",
                Cadence = Cadence.Month,
                UsageLimit = 2000,
            },
        ];

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedAssignments.Count, parameters.Assignments.Count);
        for (int i = 0; i < expectedAssignments.Count; i++)
        {
            Assert.Equal(expectedAssignments[i], parameters.Assignments[i]);
        }
    }

    [Fact]
    public void Url_Works()
    {
        AssignmentUpsertParams parameters = new()
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    CapabilityID = "compute-minutes",
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    UsageLimit = 1000,
                },
                new()
                {
                    CapabilityID = "compute-minutes",
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    UsageLimit = 2000,
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(
                new Uri("https://api.stigg.io/api/v1-beta/customers/id/assignments"),
                url
            )
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new AssignmentUpsertParams
        {
            ID = "id",
            Assignments =
            [
                new()
                {
                    CapabilityID = "compute-minutes",
                    EntityID = "workspace-001",
                    Cadence = Cadence.Month,
                    UsageLimit = 1000,
                },
                new()
                {
                    CapabilityID = "compute-minutes",
                    EntityID = "workspace-002",
                    Cadence = Cadence.Month,
                    UsageLimit = 2000,
                },
            ],
        };

        AssignmentUpsertParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AssignmentTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Assignment
        {
            CapabilityID = "capabilityId",
            EntityID = "entityId",
            Cadence = Cadence.Month,
            UsageLimit = 0,
        };

        string expectedCapabilityID = "capabilityId";
        string expectedEntityID = "entityId";
        ApiEnum<string, Cadence> expectedCadence = Cadence.Month;
        double expectedUsageLimit = 0;

        Assert.Equal(expectedCapabilityID, model.CapabilityID);
        Assert.Equal(expectedEntityID, model.EntityID);
        Assert.Equal(expectedCadence, model.Cadence);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Assignment
        {
            CapabilityID = "capabilityId",
            EntityID = "entityId",
            Cadence = Cadence.Month,
            UsageLimit = 0,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Assignment>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Assignment
        {
            CapabilityID = "capabilityId",
            EntityID = "entityId",
            Cadence = Cadence.Month,
            UsageLimit = 0,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Assignment>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCapabilityID = "capabilityId";
        string expectedEntityID = "entityId";
        ApiEnum<string, Cadence> expectedCadence = Cadence.Month;
        double expectedUsageLimit = 0;

        Assert.Equal(expectedCapabilityID, deserialized.CapabilityID);
        Assert.Equal(expectedEntityID, deserialized.EntityID);
        Assert.Equal(expectedCadence, deserialized.Cadence);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Assignment
        {
            CapabilityID = "capabilityId",
            EntityID = "entityId",
            Cadence = Cadence.Month,
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Assignment { CapabilityID = "capabilityId", EntityID = "entityId" };

        Assert.Null(model.Cadence);
        Assert.False(model.RawData.ContainsKey("cadence"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Assignment { CapabilityID = "capabilityId", EntityID = "entityId" };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Assignment
        {
            CapabilityID = "capabilityId",
            EntityID = "entityId",

            // Null should be interpreted as omitted for these properties
            Cadence = null,
            UsageLimit = null,
        };

        Assert.Null(model.Cadence);
        Assert.False(model.RawData.ContainsKey("cadence"));
        Assert.Null(model.UsageLimit);
        Assert.False(model.RawData.ContainsKey("usageLimit"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Assignment
        {
            CapabilityID = "capabilityId",
            EntityID = "entityId",

            // Null should be interpreted as omitted for these properties
            Cadence = null,
            UsageLimit = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Assignment
        {
            CapabilityID = "capabilityId",
            EntityID = "entityId",
            Cadence = Cadence.Month,
            UsageLimit = 0,
        };

        Assignment copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CadenceTest : TestBase
{
    [Theory]
    [InlineData(Cadence.Month)]
    public void Validation_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Cadence.Month)]
    public void SerializationRoundtrip_Works(Cadence rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Cadence> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Cadence>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
