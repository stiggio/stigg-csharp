using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons;

namespace Stigg.Client.Tests.Models.V1.Events.Addons;

public class SetPackagePricingResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingResponse
        {
            Data = new() { ID = "id", PricingType = SetPackagePricingResponseDataPricingType.Free },
        };

        SetPackagePricingResponseData expectedData = new()
        {
            ID = "id",
            PricingType = SetPackagePricingResponseDataPricingType.Free,
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingResponse
        {
            Data = new() { ID = "id", PricingType = SetPackagePricingResponseDataPricingType.Free },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingResponse
        {
            Data = new() { ID = "id", PricingType = SetPackagePricingResponseDataPricingType.Free },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        SetPackagePricingResponseData expectedData = new()
        {
            ID = "id",
            PricingType = SetPackagePricingResponseDataPricingType.Free,
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingResponse
        {
            Data = new() { ID = "id", PricingType = SetPackagePricingResponseDataPricingType.Free },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SetPackagePricingResponse
        {
            Data = new() { ID = "id", PricingType = SetPackagePricingResponseDataPricingType.Free },
        };

        SetPackagePricingResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new SetPackagePricingResponseData
        {
            ID = "id",
            PricingType = SetPackagePricingResponseDataPricingType.Free,
        };

        string expectedID = "id";
        ApiEnum<string, SetPackagePricingResponseDataPricingType> expectedPricingType =
            SetPackagePricingResponseDataPricingType.Free;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedPricingType, model.PricingType);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new SetPackagePricingResponseData
        {
            ID = "id",
            PricingType = SetPackagePricingResponseDataPricingType.Free,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new SetPackagePricingResponseData
        {
            ID = "id",
            PricingType = SetPackagePricingResponseDataPricingType.Free,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<SetPackagePricingResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        ApiEnum<string, SetPackagePricingResponseDataPricingType> expectedPricingType =
            SetPackagePricingResponseDataPricingType.Free;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedPricingType, deserialized.PricingType);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new SetPackagePricingResponseData
        {
            ID = "id",
            PricingType = SetPackagePricingResponseDataPricingType.Free,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new SetPackagePricingResponseData
        {
            ID = "id",
            PricingType = SetPackagePricingResponseDataPricingType.Free,
        };

        SetPackagePricingResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class SetPackagePricingResponseDataPricingTypeTest : TestBase
{
    [Theory]
    [InlineData(SetPackagePricingResponseDataPricingType.Free)]
    [InlineData(SetPackagePricingResponseDataPricingType.Paid)]
    [InlineData(SetPackagePricingResponseDataPricingType.Custom)]
    public void Validation_Works(SetPackagePricingResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingResponseDataPricingType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(SetPackagePricingResponseDataPricingType.Free)]
    [InlineData(SetPackagePricingResponseDataPricingType.Paid)]
    [InlineData(SetPackagePricingResponseDataPricingType.Custom)]
    public void SerializationRoundtrip_Works(SetPackagePricingResponseDataPricingType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, SetPackagePricingResponseDataPricingType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingResponseDataPricingType>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, SetPackagePricingResponseDataPricingType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
