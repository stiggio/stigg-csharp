using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans;

namespace Stigg.Client.Tests.Models.V1.Plans;

public class PlanPublishParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new PlanPublishParams
        {
            ID = "x",
            MigrationType = MigrationType.NewCustomers,
        };

        string expectedID = "x";
        ApiEnum<string, MigrationType> expectedMigrationType = MigrationType.NewCustomers;

        Assert.Equal(expectedID, parameters.ID);
        Assert.Equal(expectedMigrationType, parameters.MigrationType);
    }

    [Fact]
    public void Url_Works()
    {
        PlanPublishParams parameters = new()
        {
            ID = "x",
            MigrationType = MigrationType.NewCustomers,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/plans/x/publish"), url)
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new PlanPublishParams
        {
            ID = "x",
            MigrationType = MigrationType.NewCustomers,
        };

        PlanPublishParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class MigrationTypeTest : TestBase
{
    [Theory]
    [InlineData(MigrationType.NewCustomers)]
    [InlineData(MigrationType.AllCustomers)]
    public void Validation_Works(MigrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MigrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(MigrationType.NewCustomers)]
    [InlineData(MigrationType.AllCustomers)]
    public void SerializationRoundtrip_Works(MigrationType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, MigrationType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MigrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, MigrationType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, MigrationType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
