using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits.AutoRecharge;

namespace Stigg.Client.Tests.Models.V1.Credits.AutoRecharge;

public class AutoRechargeGetAutoRechargeResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AutoRechargeGetAutoRechargeResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
                IsEnabled = true,
                MaxSpendLimit = 0,
                TargetBalance = 0,
                ThresholdType = ThresholdType.CreditAmount,
                ThresholdValue = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Data expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
            IsEnabled = true,
            MaxSpendLimit = 0,
            TargetBalance = 0,
            ThresholdType = ThresholdType.CreditAmount,
            ThresholdValue = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AutoRechargeGetAutoRechargeResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
                IsEnabled = true,
                MaxSpendLimit = 0,
                TargetBalance = 0,
                ThresholdType = ThresholdType.CreditAmount,
                ThresholdValue = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutoRechargeGetAutoRechargeResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AutoRechargeGetAutoRechargeResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
                IsEnabled = true,
                MaxSpendLimit = 0,
                TargetBalance = 0,
                ThresholdType = ThresholdType.CreditAmount,
                ThresholdValue = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AutoRechargeGetAutoRechargeResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
            IsEnabled = true,
            MaxSpendLimit = 0,
            TargetBalance = 0,
            ThresholdType = ThresholdType.CreditAmount,
            ThresholdValue = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AutoRechargeGetAutoRechargeResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
                IsEnabled = true,
                MaxSpendLimit = 0,
                TargetBalance = 0,
                ThresholdType = ThresholdType.CreditAmount,
                ThresholdValue = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AutoRechargeGetAutoRechargeResponse
        {
            Data = new()
            {
                ID = "id",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
                IsEnabled = true,
                MaxSpendLimit = 0,
                TargetBalance = 0,
                ThresholdType = ThresholdType.CreditAmount,
                ThresholdValue = 0,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        AutoRechargeGetAutoRechargeResponse copied = new(model);

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
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
            IsEnabled = true,
            MaxSpendLimit = 0,
            TargetBalance = 0,
            ThresholdType = ThresholdType.CreditAmount,
            ThresholdValue = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        ApiEnum<string, GrantExpirationPeriod> expectedGrantExpirationPeriod =
            GrantExpirationPeriod.V1Month;
        bool expectedIsEnabled = true;
        double expectedMaxSpendLimit = 0;
        double expectedTargetBalance = 0;
        ApiEnum<string, ThresholdType> expectedThresholdType = ThresholdType.CreditAmount;
        double expectedThresholdValue = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedCurrencyID, model.CurrencyID);
        Assert.Equal(expectedCustomerID, model.CustomerID);
        Assert.Equal(expectedGrantExpirationPeriod, model.GrantExpirationPeriod);
        Assert.Equal(expectedIsEnabled, model.IsEnabled);
        Assert.Equal(expectedMaxSpendLimit, model.MaxSpendLimit);
        Assert.Equal(expectedTargetBalance, model.TargetBalance);
        Assert.Equal(expectedThresholdType, model.ThresholdType);
        Assert.Equal(expectedThresholdValue, model.ThresholdValue);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
            IsEnabled = true,
            MaxSpendLimit = 0,
            TargetBalance = 0,
            ThresholdType = ThresholdType.CreditAmount,
            ThresholdValue = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
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
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
            IsEnabled = true,
            MaxSpendLimit = 0,
            TargetBalance = 0,
            ThresholdType = ThresholdType.CreditAmount,
            ThresholdValue = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        ApiEnum<string, GrantExpirationPeriod> expectedGrantExpirationPeriod =
            GrantExpirationPeriod.V1Month;
        bool expectedIsEnabled = true;
        double expectedMaxSpendLimit = 0;
        double expectedTargetBalance = 0;
        ApiEnum<string, ThresholdType> expectedThresholdType = ThresholdType.CreditAmount;
        double expectedThresholdValue = 0;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedCurrencyID, deserialized.CurrencyID);
        Assert.Equal(expectedCustomerID, deserialized.CustomerID);
        Assert.Equal(expectedGrantExpirationPeriod, deserialized.GrantExpirationPeriod);
        Assert.Equal(expectedIsEnabled, deserialized.IsEnabled);
        Assert.Equal(expectedMaxSpendLimit, deserialized.MaxSpendLimit);
        Assert.Equal(expectedTargetBalance, deserialized.TargetBalance);
        Assert.Equal(expectedThresholdType, deserialized.ThresholdType);
        Assert.Equal(expectedThresholdValue, deserialized.ThresholdValue);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
            IsEnabled = true,
            MaxSpendLimit = 0,
            TargetBalance = 0,
            ThresholdType = ThresholdType.CreditAmount,
            ThresholdValue = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            ID = "id",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            GrantExpirationPeriod = GrantExpirationPeriod.V1Month,
            IsEnabled = true,
            MaxSpendLimit = 0,
            TargetBalance = 0,
            ThresholdType = ThresholdType.CreditAmount,
            ThresholdValue = 0,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class GrantExpirationPeriodTest : TestBase
{
    [Theory]
    [InlineData(GrantExpirationPeriod.V1Month)]
    [InlineData(GrantExpirationPeriod.V1Year)]
    public void Validation_Works(GrantExpirationPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantExpirationPeriod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantExpirationPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantExpirationPeriod.V1Month)]
    [InlineData(GrantExpirationPeriod.V1Year)]
    public void SerializationRoundtrip_Works(GrantExpirationPeriod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantExpirationPeriod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantExpirationPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantExpirationPeriod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantExpirationPeriod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class ThresholdTypeTest : TestBase
{
    [Theory]
    [InlineData(ThresholdType.CreditAmount)]
    [InlineData(ThresholdType.DollarAmount)]
    public void Validation_Works(ThresholdType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThresholdType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThresholdType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(ThresholdType.CreditAmount)]
    [InlineData(ThresholdType.DollarAmount)]
    public void SerializationRoundtrip_Works(ThresholdType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, ThresholdType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThresholdType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, ThresholdType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, ThresholdType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
