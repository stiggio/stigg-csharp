using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.Consumption;

namespace Stigg.Client.Tests.Models.V1.Credits.Consumption;

public class ConsumptionConsumeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                ResourceID = "resourceId",
            },
        };

        Data expectedData = new()
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                ResourceID = "resourceId",
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumptionConsumeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                ResourceID = "resourceId",
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ConsumptionConsumeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                ResourceID = "resourceId",
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ConsumptionConsumeResponse
        {
            Data = new()
            {
                Amount = 0,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                ResourceID = "resourceId",
            },
        };

        ConsumptionConsumeResponse copied = new(model);

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
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
        };

        double expectedAmount = 0;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Credit expectedCredit = new()
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedCredit, model.Credit);
        Assert.Equal(expectedResourceID, model.ResourceID);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
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
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Credit expectedCredit = new()
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        string expectedResourceID = "resourceId";

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedCredit, deserialized.Credit);
        Assert.Equal(expectedResourceID, deserialized.ResourceID);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Null(model.Credit);
        Assert.False(model.RawData.ContainsKey("credit"));
        Assert.Null(model.ResourceID);
        Assert.False(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Credit = null,
            ResourceID = null,
        };

        Assert.Null(model.Credit);
        Assert.True(model.RawData.ContainsKey("credit"));
        Assert.Null(model.ResourceID);
        Assert.True(model.RawData.ContainsKey("resourceId"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),

            Credit = null,
            ResourceID = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            ResourceID = "resourceId",
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CreditTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedCurrencyID = "currencyId";
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCurrentUsage, model.CurrentUsage);
        Assert.Equal(expectedTimestamp, model.Timestamp);
        Assert.Equal(expectedUsageLimit, model.UsageLimit);
        Assert.Equal(expectedUsagePeriodEnd, model.UsagePeriodEnd);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Credit>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedCurrencyID = "currencyId";
        double expectedCurrentUsage = 0;
        DateTimeOffset expectedTimestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        double expectedUsageLimit = 0;
        DateTimeOffset expectedUsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCurrentUsage, deserialized.CurrentUsage);
        Assert.Equal(expectedTimestamp, deserialized.Timestamp);
        Assert.Equal(expectedUsageLimit, deserialized.UsageLimit);
        Assert.Equal(expectedUsagePeriodEnd, deserialized.UsagePeriodEnd);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        Assert.Null(model.UsagePeriodEnd);
        Assert.False(model.RawData.ContainsKey("usagePeriodEnd"));
    }

    [Fact]
    public void OptionalNullablePropertiesUnsetValidation_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullAreSetToNull_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,

            UsagePeriodEnd = null,
        };

        Assert.Null(model.UsagePeriodEnd);
        Assert.True(model.RawData.ContainsKey("usagePeriodEnd"));
    }

    [Fact]
    public void OptionalNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,

            UsagePeriodEnd = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Credit
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Credit copied = new(model);

        Assert.Equal(model, copied);
    }
}
