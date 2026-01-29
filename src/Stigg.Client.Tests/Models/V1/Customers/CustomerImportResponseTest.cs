using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerImportResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerImportResponse { Data = new(["string"]) };

        CustomerImportResponseData expectedData = new(["string"]);

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerImportResponse { Data = new(["string"]) };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerImportResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerImportResponse { Data = new(["string"]) };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerImportResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CustomerImportResponseData expectedData = new(["string"]);

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerImportResponse { Data = new(["string"]) };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerImportResponse { Data = new(["string"]) };

        CustomerImportResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CustomerImportResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CustomerImportResponseData { NewCustomers = ["string"] };

        List<string> expectedNewCustomers = ["string"];

        Assert.Equal(expectedNewCustomers.Count, model.NewCustomers.Count);
        for (int i = 0; i < expectedNewCustomers.Count; i++)
        {
            Assert.Equal(expectedNewCustomers[i], model.NewCustomers[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CustomerImportResponseData { NewCustomers = ["string"] };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerImportResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CustomerImportResponseData { NewCustomers = ["string"] };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CustomerImportResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<string> expectedNewCustomers = ["string"];

        Assert.Equal(expectedNewCustomers.Count, deserialized.NewCustomers.Count);
        for (int i = 0; i < expectedNewCustomers.Count; i++)
        {
            Assert.Equal(expectedNewCustomers[i], deserialized.NewCustomers[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CustomerImportResponseData { NewCustomers = ["string"] };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CustomerImportResponseData { NewCustomers = ["string"] };

        CustomerImportResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}
