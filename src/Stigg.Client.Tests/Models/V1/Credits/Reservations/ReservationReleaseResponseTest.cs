using System;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits.Reservations;

namespace Stigg.Client.Tests.Models.V1.Credits.Reservations;

public class ReservationReleaseResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new ReservationReleaseResponse
        {
            Data = new()
            {
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Reservation = new()
                {
                    ID = "id",
                    Amount = 1,
                    ConsumedAmount = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                },
            },
        };

        Data expectedData = new()
        {
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Reservation = new()
            {
                ID = "id",
                Amount = 1,
                ConsumedAmount = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
            },
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new ReservationReleaseResponse
        {
            Data = new()
            {
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Reservation = new()
                {
                    ID = "id",
                    Amount = 1,
                    ConsumedAmount = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                },
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReservationReleaseResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new ReservationReleaseResponse
        {
            Data = new()
            {
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Reservation = new()
                {
                    ID = "id",
                    Amount = 1,
                    ConsumedAmount = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                },
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ReservationReleaseResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Reservation = new()
            {
                ID = "id",
                Amount = 1,
                ConsumedAmount = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
            },
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new ReservationReleaseResponse
        {
            Data = new()
            {
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Reservation = new()
                {
                    ID = "id",
                    Amount = 1,
                    ConsumedAmount = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                },
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new ReservationReleaseResponse
        {
            Data = new()
            {
                Credit = new()
                {
                    CurrencyID = "currencyId",
                    CurrentUsage = 0,
                    Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    UsageLimit = 0,
                    UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
                Reservation = new()
                {
                    ID = "id",
                    Amount = 1,
                    ConsumedAmount = 0,
                    ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    Status = Status.Active,
                },
            },
        };

        ReservationReleaseResponse copied = new(model);

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
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Reservation = new()
            {
                ID = "id",
                Amount = 1,
                ConsumedAmount = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
            },
        };

        Credit expectedCredit = new()
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Reservation expectedReservation = new()
        {
            ID = "id",
            Amount = 1,
            ConsumedAmount = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
        };

        Assert.Equal(expectedCredit, model.Credit);
        Assert.Equal(expectedReservation, model.Reservation);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Reservation = new()
            {
                ID = "id",
                Amount = 1,
                ConsumedAmount = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
            },
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
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Reservation = new()
            {
                ID = "id",
                Amount = 1,
                ConsumedAmount = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Credit expectedCredit = new()
        {
            CurrencyID = "currencyId",
            CurrentUsage = 0,
            Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            UsageLimit = 0,
            UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };
        Reservation expectedReservation = new()
        {
            ID = "id",
            Amount = 1,
            ConsumedAmount = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
        };

        Assert.Equal(expectedCredit, deserialized.Credit);
        Assert.Equal(expectedReservation, deserialized.Reservation);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Reservation = new()
            {
                ID = "id",
                Amount = 1,
                ConsumedAmount = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Data
        {
            Credit = new()
            {
                CurrencyID = "currencyId",
                CurrentUsage = 0,
                Timestamp = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                UsageLimit = 0,
                UsagePeriodEnd = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
            Reservation = new()
            {
                ID = "id",
                Amount = 1,
                ConsumedAmount = 0,
                ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Status = Status.Active,
            },
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

public class ReservationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Reservation
        {
            ID = "id",
            Amount = 1,
            ConsumedAmount = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
        };

        string expectedID = "id";
        double expectedAmount = 1;
        double expectedConsumedAmount = 0;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedConsumedAmount, model.ConsumedAmount);
        Assert.Equal(expectedExpiresAt, model.ExpiresAt);
        Assert.Equal(expectedStatus, model.Status);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Reservation
        {
            ID = "id",
            Amount = 1,
            ConsumedAmount = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Reservation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Reservation
        {
            ID = "id",
            Amount = 1,
            ConsumedAmount = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Reservation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        double expectedAmount = 1;
        double expectedConsumedAmount = 0;
        DateTimeOffset expectedExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        ApiEnum<string, Status> expectedStatus = Status.Active;

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedConsumedAmount, deserialized.ConsumedAmount);
        Assert.Equal(expectedExpiresAt, deserialized.ExpiresAt);
        Assert.Equal(expectedStatus, deserialized.Status);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Reservation
        {
            ID = "id",
            Amount = 1,
            ConsumedAmount = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Reservation
        {
            ID = "id",
            Amount = 1,
            ConsumedAmount = 0,
            ExpiresAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Status = Status.Active,
        };

        Reservation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Status.Active)]
    [InlineData(Status.Released)]
    [InlineData(Status.Expired)]
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
    [InlineData(Status.Active)]
    [InlineData(Status.Released)]
    [InlineData(Status.Expired)]
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
