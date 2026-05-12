using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Tests.Models.V1.Coupons;

public class CouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 1,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                PercentOff = 1,
                Source = Source.Stigg,
                Status = DataStatus.Active,
                Type = DataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Data expectedData = new()
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
            Source = Source.Stigg,
            Status = DataStatus.Active,
            Type = DataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 1,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                PercentOff = 1,
                Source = Source.Stigg,
                Status = DataStatus.Active,
                Type = DataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupon>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 1,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                PercentOff = 1,
                Source = Source.Stigg,
                Status = DataStatus.Active,
                Type = DataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupon>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        Data expectedData = new()
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
            Source = Source.Stigg,
            Status = DataStatus.Active,
            Type = DataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 1,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                PercentOff = 1,
                Source = Source.Stigg,
                Status = DataStatus.Active,
                Type = DataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 1,
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                Name = "name",
                PercentOff = 1,
                Source = Source.Stigg,
                Status = DataStatus.Active,
                Type = DataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Coupon copied = new(model);

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
            AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
            Source = Source.Stigg,
            Status = DataStatus.Active,
            Type = DataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<DataAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        long expectedDurationInMonths = 1;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        long expectedPercentOff = 1;
        ApiEnum<string, Source> expectedSource = Source.Stigg;
        ApiEnum<string, DataStatus> expectedStatus = DataStatus.Active;
        ApiEnum<string, DataType> expectedType = DataType.Fixed;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.NotNull(model.AmountsOff);
        Assert.Equal(expectedAmountsOff.Count, model.AmountsOff.Count);
        for (int i = 0; i < expectedAmountsOff.Count; i++)
        {
            Assert.Equal(expectedAmountsOff[i], model.AmountsOff[i]);
        }
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.Equal(expectedBillingLinkUrl, model.BillingLinkUrl);
        Assert.Equal(expectedCreatedAt, model.CreatedAt);
        Assert.Equal(expectedDescription, model.Description);
        Assert.Equal(expectedDurationInMonths, model.DurationInMonths);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedPercentOff, model.PercentOff);
        Assert.Equal(expectedSource, model.Source);
        Assert.Equal(expectedStatus, model.Status);
        Assert.Equal(expectedType, model.Type);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Data
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
            Source = Source.Stigg,
            Status = DataStatus.Active,
            Type = DataType.Fixed,
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
            AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
            Source = Source.Stigg,
            Status = DataStatus.Active,
            Type = DataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Data>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<DataAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        long expectedDurationInMonths = 1;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        long expectedPercentOff = 1;
        ApiEnum<string, Source> expectedSource = Source.Stigg;
        ApiEnum<string, DataStatus> expectedStatus = DataStatus.Active;
        ApiEnum<string, DataType> expectedType = DataType.Fixed;
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.NotNull(deserialized.AmountsOff);
        Assert.Equal(expectedAmountsOff.Count, deserialized.AmountsOff.Count);
        for (int i = 0; i < expectedAmountsOff.Count; i++)
        {
            Assert.Equal(expectedAmountsOff[i], deserialized.AmountsOff[i]);
        }
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.Equal(expectedBillingLinkUrl, deserialized.BillingLinkUrl);
        Assert.Equal(expectedCreatedAt, deserialized.CreatedAt);
        Assert.Equal(expectedDescription, deserialized.Description);
        Assert.Equal(expectedDurationInMonths, deserialized.DurationInMonths);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedPercentOff, deserialized.PercentOff);
        Assert.Equal(expectedSource, deserialized.Source);
        Assert.Equal(expectedStatus, deserialized.Status);
        Assert.Equal(expectedType, deserialized.Type);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Data
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
            Source = Source.Stigg,
            Status = DataStatus.Active,
            Type = DataType.Fixed,
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
            AmountsOff = [new() { Amount = 0, Currency = DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
            Source = Source.Stigg,
            Status = DataStatus.Active,
            Type = DataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new DataAmountsOff { Amount = 0, Currency = DataAmountsOffCurrency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, DataAmountsOffCurrency> expectedCurrency = DataAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new DataAmountsOff { Amount = 0, Currency = DataAmountsOffCurrency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataAmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new DataAmountsOff { Amount = 0, Currency = DataAmountsOffCurrency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<DataAmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, DataAmountsOffCurrency> expectedCurrency = DataAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new DataAmountsOff { Amount = 0, Currency = DataAmountsOffCurrency.Usd };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new DataAmountsOff { Amount = 0, Currency = DataAmountsOffCurrency.Usd };

        DataAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(DataAmountsOffCurrency.Usd)]
    [InlineData(DataAmountsOffCurrency.Aed)]
    [InlineData(DataAmountsOffCurrency.All)]
    [InlineData(DataAmountsOffCurrency.Amd)]
    [InlineData(DataAmountsOffCurrency.Ang)]
    [InlineData(DataAmountsOffCurrency.Aud)]
    [InlineData(DataAmountsOffCurrency.Awg)]
    [InlineData(DataAmountsOffCurrency.Azn)]
    [InlineData(DataAmountsOffCurrency.Bam)]
    [InlineData(DataAmountsOffCurrency.Bbd)]
    [InlineData(DataAmountsOffCurrency.Bdt)]
    [InlineData(DataAmountsOffCurrency.Bgn)]
    [InlineData(DataAmountsOffCurrency.Bif)]
    [InlineData(DataAmountsOffCurrency.Bmd)]
    [InlineData(DataAmountsOffCurrency.Bnd)]
    [InlineData(DataAmountsOffCurrency.Bsd)]
    [InlineData(DataAmountsOffCurrency.Bwp)]
    [InlineData(DataAmountsOffCurrency.Byn)]
    [InlineData(DataAmountsOffCurrency.Bzd)]
    [InlineData(DataAmountsOffCurrency.Brl)]
    [InlineData(DataAmountsOffCurrency.Cad)]
    [InlineData(DataAmountsOffCurrency.Cdf)]
    [InlineData(DataAmountsOffCurrency.Chf)]
    [InlineData(DataAmountsOffCurrency.Cny)]
    [InlineData(DataAmountsOffCurrency.Czk)]
    [InlineData(DataAmountsOffCurrency.Dkk)]
    [InlineData(DataAmountsOffCurrency.Dop)]
    [InlineData(DataAmountsOffCurrency.Dzd)]
    [InlineData(DataAmountsOffCurrency.Egp)]
    [InlineData(DataAmountsOffCurrency.Etb)]
    [InlineData(DataAmountsOffCurrency.Eur)]
    [InlineData(DataAmountsOffCurrency.Fjd)]
    [InlineData(DataAmountsOffCurrency.Gbp)]
    [InlineData(DataAmountsOffCurrency.Gel)]
    [InlineData(DataAmountsOffCurrency.Gip)]
    [InlineData(DataAmountsOffCurrency.Gmd)]
    [InlineData(DataAmountsOffCurrency.Gyd)]
    [InlineData(DataAmountsOffCurrency.Hkd)]
    [InlineData(DataAmountsOffCurrency.Hrk)]
    [InlineData(DataAmountsOffCurrency.Htg)]
    [InlineData(DataAmountsOffCurrency.Idr)]
    [InlineData(DataAmountsOffCurrency.Ils)]
    [InlineData(DataAmountsOffCurrency.Inr)]
    [InlineData(DataAmountsOffCurrency.Isk)]
    [InlineData(DataAmountsOffCurrency.Jmd)]
    [InlineData(DataAmountsOffCurrency.Jpy)]
    [InlineData(DataAmountsOffCurrency.Kes)]
    [InlineData(DataAmountsOffCurrency.Kgs)]
    [InlineData(DataAmountsOffCurrency.Khr)]
    [InlineData(DataAmountsOffCurrency.Kmf)]
    [InlineData(DataAmountsOffCurrency.Krw)]
    [InlineData(DataAmountsOffCurrency.Kyd)]
    [InlineData(DataAmountsOffCurrency.Kzt)]
    [InlineData(DataAmountsOffCurrency.Lbp)]
    [InlineData(DataAmountsOffCurrency.Lkr)]
    [InlineData(DataAmountsOffCurrency.Lrd)]
    [InlineData(DataAmountsOffCurrency.Lsl)]
    [InlineData(DataAmountsOffCurrency.Mad)]
    [InlineData(DataAmountsOffCurrency.Mdl)]
    [InlineData(DataAmountsOffCurrency.Mga)]
    [InlineData(DataAmountsOffCurrency.Mkd)]
    [InlineData(DataAmountsOffCurrency.Mmk)]
    [InlineData(DataAmountsOffCurrency.Mnt)]
    [InlineData(DataAmountsOffCurrency.Mop)]
    [InlineData(DataAmountsOffCurrency.Mro)]
    [InlineData(DataAmountsOffCurrency.Mvr)]
    [InlineData(DataAmountsOffCurrency.Mwk)]
    [InlineData(DataAmountsOffCurrency.Mxn)]
    [InlineData(DataAmountsOffCurrency.Myr)]
    [InlineData(DataAmountsOffCurrency.Mzn)]
    [InlineData(DataAmountsOffCurrency.Nad)]
    [InlineData(DataAmountsOffCurrency.Ngn)]
    [InlineData(DataAmountsOffCurrency.Nok)]
    [InlineData(DataAmountsOffCurrency.Npr)]
    [InlineData(DataAmountsOffCurrency.Nzd)]
    [InlineData(DataAmountsOffCurrency.Pgk)]
    [InlineData(DataAmountsOffCurrency.Php)]
    [InlineData(DataAmountsOffCurrency.Pkr)]
    [InlineData(DataAmountsOffCurrency.Pln)]
    [InlineData(DataAmountsOffCurrency.Qar)]
    [InlineData(DataAmountsOffCurrency.Ron)]
    [InlineData(DataAmountsOffCurrency.Rsd)]
    [InlineData(DataAmountsOffCurrency.Rub)]
    [InlineData(DataAmountsOffCurrency.Rwf)]
    [InlineData(DataAmountsOffCurrency.Sar)]
    [InlineData(DataAmountsOffCurrency.Sbd)]
    [InlineData(DataAmountsOffCurrency.Scr)]
    [InlineData(DataAmountsOffCurrency.Sek)]
    [InlineData(DataAmountsOffCurrency.Sgd)]
    [InlineData(DataAmountsOffCurrency.Sle)]
    [InlineData(DataAmountsOffCurrency.Sll)]
    [InlineData(DataAmountsOffCurrency.Sos)]
    [InlineData(DataAmountsOffCurrency.Szl)]
    [InlineData(DataAmountsOffCurrency.Thb)]
    [InlineData(DataAmountsOffCurrency.Tjs)]
    [InlineData(DataAmountsOffCurrency.Top)]
    [InlineData(DataAmountsOffCurrency.Try)]
    [InlineData(DataAmountsOffCurrency.Ttd)]
    [InlineData(DataAmountsOffCurrency.Tzs)]
    [InlineData(DataAmountsOffCurrency.Uah)]
    [InlineData(DataAmountsOffCurrency.Uzs)]
    [InlineData(DataAmountsOffCurrency.Vnd)]
    [InlineData(DataAmountsOffCurrency.Vuv)]
    [InlineData(DataAmountsOffCurrency.Wst)]
    [InlineData(DataAmountsOffCurrency.Xaf)]
    [InlineData(DataAmountsOffCurrency.Xcd)]
    [InlineData(DataAmountsOffCurrency.Yer)]
    [InlineData(DataAmountsOffCurrency.Zar)]
    [InlineData(DataAmountsOffCurrency.Zmw)]
    [InlineData(DataAmountsOffCurrency.Clp)]
    [InlineData(DataAmountsOffCurrency.Djf)]
    [InlineData(DataAmountsOffCurrency.Gnf)]
    [InlineData(DataAmountsOffCurrency.Ugx)]
    [InlineData(DataAmountsOffCurrency.Pyg)]
    [InlineData(DataAmountsOffCurrency.Xof)]
    [InlineData(DataAmountsOffCurrency.Xpf)]
    public void Validation_Works(DataAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataAmountsOffCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataAmountsOffCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataAmountsOffCurrency.Usd)]
    [InlineData(DataAmountsOffCurrency.Aed)]
    [InlineData(DataAmountsOffCurrency.All)]
    [InlineData(DataAmountsOffCurrency.Amd)]
    [InlineData(DataAmountsOffCurrency.Ang)]
    [InlineData(DataAmountsOffCurrency.Aud)]
    [InlineData(DataAmountsOffCurrency.Awg)]
    [InlineData(DataAmountsOffCurrency.Azn)]
    [InlineData(DataAmountsOffCurrency.Bam)]
    [InlineData(DataAmountsOffCurrency.Bbd)]
    [InlineData(DataAmountsOffCurrency.Bdt)]
    [InlineData(DataAmountsOffCurrency.Bgn)]
    [InlineData(DataAmountsOffCurrency.Bif)]
    [InlineData(DataAmountsOffCurrency.Bmd)]
    [InlineData(DataAmountsOffCurrency.Bnd)]
    [InlineData(DataAmountsOffCurrency.Bsd)]
    [InlineData(DataAmountsOffCurrency.Bwp)]
    [InlineData(DataAmountsOffCurrency.Byn)]
    [InlineData(DataAmountsOffCurrency.Bzd)]
    [InlineData(DataAmountsOffCurrency.Brl)]
    [InlineData(DataAmountsOffCurrency.Cad)]
    [InlineData(DataAmountsOffCurrency.Cdf)]
    [InlineData(DataAmountsOffCurrency.Chf)]
    [InlineData(DataAmountsOffCurrency.Cny)]
    [InlineData(DataAmountsOffCurrency.Czk)]
    [InlineData(DataAmountsOffCurrency.Dkk)]
    [InlineData(DataAmountsOffCurrency.Dop)]
    [InlineData(DataAmountsOffCurrency.Dzd)]
    [InlineData(DataAmountsOffCurrency.Egp)]
    [InlineData(DataAmountsOffCurrency.Etb)]
    [InlineData(DataAmountsOffCurrency.Eur)]
    [InlineData(DataAmountsOffCurrency.Fjd)]
    [InlineData(DataAmountsOffCurrency.Gbp)]
    [InlineData(DataAmountsOffCurrency.Gel)]
    [InlineData(DataAmountsOffCurrency.Gip)]
    [InlineData(DataAmountsOffCurrency.Gmd)]
    [InlineData(DataAmountsOffCurrency.Gyd)]
    [InlineData(DataAmountsOffCurrency.Hkd)]
    [InlineData(DataAmountsOffCurrency.Hrk)]
    [InlineData(DataAmountsOffCurrency.Htg)]
    [InlineData(DataAmountsOffCurrency.Idr)]
    [InlineData(DataAmountsOffCurrency.Ils)]
    [InlineData(DataAmountsOffCurrency.Inr)]
    [InlineData(DataAmountsOffCurrency.Isk)]
    [InlineData(DataAmountsOffCurrency.Jmd)]
    [InlineData(DataAmountsOffCurrency.Jpy)]
    [InlineData(DataAmountsOffCurrency.Kes)]
    [InlineData(DataAmountsOffCurrency.Kgs)]
    [InlineData(DataAmountsOffCurrency.Khr)]
    [InlineData(DataAmountsOffCurrency.Kmf)]
    [InlineData(DataAmountsOffCurrency.Krw)]
    [InlineData(DataAmountsOffCurrency.Kyd)]
    [InlineData(DataAmountsOffCurrency.Kzt)]
    [InlineData(DataAmountsOffCurrency.Lbp)]
    [InlineData(DataAmountsOffCurrency.Lkr)]
    [InlineData(DataAmountsOffCurrency.Lrd)]
    [InlineData(DataAmountsOffCurrency.Lsl)]
    [InlineData(DataAmountsOffCurrency.Mad)]
    [InlineData(DataAmountsOffCurrency.Mdl)]
    [InlineData(DataAmountsOffCurrency.Mga)]
    [InlineData(DataAmountsOffCurrency.Mkd)]
    [InlineData(DataAmountsOffCurrency.Mmk)]
    [InlineData(DataAmountsOffCurrency.Mnt)]
    [InlineData(DataAmountsOffCurrency.Mop)]
    [InlineData(DataAmountsOffCurrency.Mro)]
    [InlineData(DataAmountsOffCurrency.Mvr)]
    [InlineData(DataAmountsOffCurrency.Mwk)]
    [InlineData(DataAmountsOffCurrency.Mxn)]
    [InlineData(DataAmountsOffCurrency.Myr)]
    [InlineData(DataAmountsOffCurrency.Mzn)]
    [InlineData(DataAmountsOffCurrency.Nad)]
    [InlineData(DataAmountsOffCurrency.Ngn)]
    [InlineData(DataAmountsOffCurrency.Nok)]
    [InlineData(DataAmountsOffCurrency.Npr)]
    [InlineData(DataAmountsOffCurrency.Nzd)]
    [InlineData(DataAmountsOffCurrency.Pgk)]
    [InlineData(DataAmountsOffCurrency.Php)]
    [InlineData(DataAmountsOffCurrency.Pkr)]
    [InlineData(DataAmountsOffCurrency.Pln)]
    [InlineData(DataAmountsOffCurrency.Qar)]
    [InlineData(DataAmountsOffCurrency.Ron)]
    [InlineData(DataAmountsOffCurrency.Rsd)]
    [InlineData(DataAmountsOffCurrency.Rub)]
    [InlineData(DataAmountsOffCurrency.Rwf)]
    [InlineData(DataAmountsOffCurrency.Sar)]
    [InlineData(DataAmountsOffCurrency.Sbd)]
    [InlineData(DataAmountsOffCurrency.Scr)]
    [InlineData(DataAmountsOffCurrency.Sek)]
    [InlineData(DataAmountsOffCurrency.Sgd)]
    [InlineData(DataAmountsOffCurrency.Sle)]
    [InlineData(DataAmountsOffCurrency.Sll)]
    [InlineData(DataAmountsOffCurrency.Sos)]
    [InlineData(DataAmountsOffCurrency.Szl)]
    [InlineData(DataAmountsOffCurrency.Thb)]
    [InlineData(DataAmountsOffCurrency.Tjs)]
    [InlineData(DataAmountsOffCurrency.Top)]
    [InlineData(DataAmountsOffCurrency.Try)]
    [InlineData(DataAmountsOffCurrency.Ttd)]
    [InlineData(DataAmountsOffCurrency.Tzs)]
    [InlineData(DataAmountsOffCurrency.Uah)]
    [InlineData(DataAmountsOffCurrency.Uzs)]
    [InlineData(DataAmountsOffCurrency.Vnd)]
    [InlineData(DataAmountsOffCurrency.Vuv)]
    [InlineData(DataAmountsOffCurrency.Wst)]
    [InlineData(DataAmountsOffCurrency.Xaf)]
    [InlineData(DataAmountsOffCurrency.Xcd)]
    [InlineData(DataAmountsOffCurrency.Yer)]
    [InlineData(DataAmountsOffCurrency.Zar)]
    [InlineData(DataAmountsOffCurrency.Zmw)]
    [InlineData(DataAmountsOffCurrency.Clp)]
    [InlineData(DataAmountsOffCurrency.Djf)]
    [InlineData(DataAmountsOffCurrency.Gnf)]
    [InlineData(DataAmountsOffCurrency.Ugx)]
    [InlineData(DataAmountsOffCurrency.Pyg)]
    [InlineData(DataAmountsOffCurrency.Xof)]
    [InlineData(DataAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(DataAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataAmountsOffCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataAmountsOffCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataAmountsOffCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataAmountsOffCurrency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Source.Stigg)]
    [InlineData(Source.StiggAdhoc)]
    [InlineData(Source.Stripe)]
    public void Validation_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Source.Stigg)]
    [InlineData(Source.StiggAdhoc)]
    [InlineData(Source.Stripe)]
    public void SerializationRoundtrip_Works(Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataStatusTest : TestBase
{
    [Theory]
    [InlineData(DataStatus.Active)]
    [InlineData(DataStatus.Archived)]
    public void Validation_Works(DataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataStatus.Active)]
    [InlineData(DataStatus.Archived)]
    public void SerializationRoundtrip_Works(DataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class DataTypeTest : TestBase
{
    [Theory]
    [InlineData(DataType.Fixed)]
    [InlineData(DataType.Percentage)]
    public void Validation_Works(DataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(DataType.Fixed)]
    [InlineData(DataType.Percentage)]
    public void SerializationRoundtrip_Works(DataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, DataType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, DataType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
