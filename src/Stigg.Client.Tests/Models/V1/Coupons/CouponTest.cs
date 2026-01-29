using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Coupons = Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Tests.Models.V1.Coupons;

public class CouponTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Coupons::Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = Coupons::Source.Stigg,
                Status = Coupons::Status.Active,
                Type = Coupons::Type.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Coupons::Data expectedData = new()
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = Coupons::Source.Stigg,
            Status = Coupons::Status.Active,
            Type = Coupons::Type.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Coupons::Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = Coupons::Source.Stigg,
                Status = Coupons::Status.Active,
                Type = Coupons::Type.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupons::Coupon>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Coupons::Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = Coupons::Source.Stigg,
                Status = Coupons::Status.Active,
                Type = Coupons::Type.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupons::Coupon>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        Coupons::Data expectedData = new()
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = Coupons::Source.Stigg,
            Status = Coupons::Status.Active,
            Type = Coupons::Type.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Coupons::Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = Coupons::Source.Stigg,
                Status = Coupons::Status.Active,
                Type = Coupons::Type.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Coupons::Coupon
        {
            Data = new()
            {
                ID = "id",
                AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = Coupons::Source.Stigg,
                Status = Coupons::Status.Active,
                Type = Coupons::Type.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        Coupons::Coupon copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Coupons::Data
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = Coupons::Source.Stigg,
            Status = Coupons::Status.Active,
            Type = Coupons::Type.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<Coupons::DataAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        double expectedDurationInMonths = 0;
        string expectedName = "name";
        double expectedPercentOff = 0;
        ApiEnum<string, Coupons::Source> expectedSource = Coupons::Source.Stigg;
        ApiEnum<string, Coupons::Status> expectedStatus = Coupons::Status.Active;
        ApiEnum<string, Coupons::Type> expectedType = Coupons::Type.Fixed;
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
        var model = new Coupons::Data
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = Coupons::Source.Stigg,
            Status = Coupons::Status.Active,
            Type = Coupons::Type.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupons::Data>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Coupons::Data
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = Coupons::Source.Stigg,
            Status = Coupons::Status.Active,
            Type = Coupons::Type.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupons::Data>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<Coupons::DataAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        double expectedDurationInMonths = 0;
        string expectedName = "name";
        double expectedPercentOff = 0;
        ApiEnum<string, Coupons::Source> expectedSource = Coupons::Source.Stigg;
        ApiEnum<string, Coupons::Status> expectedStatus = Coupons::Status.Active;
        ApiEnum<string, Coupons::Type> expectedType = Coupons::Type.Fixed;
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
        var model = new Coupons::Data
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = Coupons::Source.Stigg,
            Status = Coupons::Status.Active,
            Type = Coupons::Type.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Coupons::Data
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Coupons::DataAmountsOffCurrency.Usd }],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = Coupons::Source.Stigg,
            Status = Coupons::Status.Active,
            Type = Coupons::Type.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Coupons::Data copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Coupons::DataAmountsOff
        {
            Amount = 0,
            Currency = Coupons::DataAmountsOffCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, Coupons::DataAmountsOffCurrency> expectedCurrency =
            Coupons::DataAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Coupons::DataAmountsOff
        {
            Amount = 0,
            Currency = Coupons::DataAmountsOffCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupons::DataAmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Coupons::DataAmountsOff
        {
            Amount = 0,
            Currency = Coupons::DataAmountsOffCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Coupons::DataAmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Coupons::DataAmountsOffCurrency> expectedCurrency =
            Coupons::DataAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Coupons::DataAmountsOff
        {
            Amount = 0,
            Currency = Coupons::DataAmountsOffCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Coupons::DataAmountsOff
        {
            Amount = 0,
            Currency = Coupons::DataAmountsOffCurrency.Usd,
        };

        Coupons::DataAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class DataAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(Coupons::DataAmountsOffCurrency.Usd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Aed)]
    [InlineData(Coupons::DataAmountsOffCurrency.All)]
    [InlineData(Coupons::DataAmountsOffCurrency.Amd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ang)]
    [InlineData(Coupons::DataAmountsOffCurrency.Aud)]
    [InlineData(Coupons::DataAmountsOffCurrency.Awg)]
    [InlineData(Coupons::DataAmountsOffCurrency.Azn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bam)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bbd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bdt)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bgn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bif)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bmd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bnd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bsd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bwp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Byn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bzd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Brl)]
    [InlineData(Coupons::DataAmountsOffCurrency.Cad)]
    [InlineData(Coupons::DataAmountsOffCurrency.Cdf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Chf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Cny)]
    [InlineData(Coupons::DataAmountsOffCurrency.Czk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Dkk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Dop)]
    [InlineData(Coupons::DataAmountsOffCurrency.Dzd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Egp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Etb)]
    [InlineData(Coupons::DataAmountsOffCurrency.Eur)]
    [InlineData(Coupons::DataAmountsOffCurrency.Fjd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gbp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gel)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gip)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gmd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gyd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Hkd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Hrk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Htg)]
    [InlineData(Coupons::DataAmountsOffCurrency.Idr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ils)]
    [InlineData(Coupons::DataAmountsOffCurrency.Inr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Isk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Jmd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Jpy)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kes)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kgs)]
    [InlineData(Coupons::DataAmountsOffCurrency.Khr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kmf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Krw)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kyd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kzt)]
    [InlineData(Coupons::DataAmountsOffCurrency.Lbp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Lkr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Lrd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Lsl)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mad)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mdl)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mga)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mkd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mmk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mnt)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mop)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mro)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mvr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mwk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mxn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Myr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mzn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Nad)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ngn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Nok)]
    [InlineData(Coupons::DataAmountsOffCurrency.Npr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Nzd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Pgk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Php)]
    [InlineData(Coupons::DataAmountsOffCurrency.Pkr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Pln)]
    [InlineData(Coupons::DataAmountsOffCurrency.Qar)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ron)]
    [InlineData(Coupons::DataAmountsOffCurrency.Rsd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Rub)]
    [InlineData(Coupons::DataAmountsOffCurrency.Rwf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sar)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sbd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Scr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sek)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sgd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sle)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sll)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sos)]
    [InlineData(Coupons::DataAmountsOffCurrency.Szl)]
    [InlineData(Coupons::DataAmountsOffCurrency.Thb)]
    [InlineData(Coupons::DataAmountsOffCurrency.Tjs)]
    [InlineData(Coupons::DataAmountsOffCurrency.Top)]
    [InlineData(Coupons::DataAmountsOffCurrency.Try)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ttd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Tzs)]
    [InlineData(Coupons::DataAmountsOffCurrency.Uah)]
    [InlineData(Coupons::DataAmountsOffCurrency.Uzs)]
    [InlineData(Coupons::DataAmountsOffCurrency.Vnd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Vuv)]
    [InlineData(Coupons::DataAmountsOffCurrency.Wst)]
    [InlineData(Coupons::DataAmountsOffCurrency.Xaf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Xcd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Yer)]
    [InlineData(Coupons::DataAmountsOffCurrency.Zar)]
    [InlineData(Coupons::DataAmountsOffCurrency.Zmw)]
    [InlineData(Coupons::DataAmountsOffCurrency.Clp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Djf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gnf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ugx)]
    [InlineData(Coupons::DataAmountsOffCurrency.Pyg)]
    [InlineData(Coupons::DataAmountsOffCurrency.Xof)]
    [InlineData(Coupons::DataAmountsOffCurrency.Xpf)]
    public void Validation_Works(Coupons::DataAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::DataAmountsOffCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::DataAmountsOffCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Coupons::DataAmountsOffCurrency.Usd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Aed)]
    [InlineData(Coupons::DataAmountsOffCurrency.All)]
    [InlineData(Coupons::DataAmountsOffCurrency.Amd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ang)]
    [InlineData(Coupons::DataAmountsOffCurrency.Aud)]
    [InlineData(Coupons::DataAmountsOffCurrency.Awg)]
    [InlineData(Coupons::DataAmountsOffCurrency.Azn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bam)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bbd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bdt)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bgn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bif)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bmd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bnd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bsd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bwp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Byn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Bzd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Brl)]
    [InlineData(Coupons::DataAmountsOffCurrency.Cad)]
    [InlineData(Coupons::DataAmountsOffCurrency.Cdf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Chf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Cny)]
    [InlineData(Coupons::DataAmountsOffCurrency.Czk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Dkk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Dop)]
    [InlineData(Coupons::DataAmountsOffCurrency.Dzd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Egp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Etb)]
    [InlineData(Coupons::DataAmountsOffCurrency.Eur)]
    [InlineData(Coupons::DataAmountsOffCurrency.Fjd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gbp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gel)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gip)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gmd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gyd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Hkd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Hrk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Htg)]
    [InlineData(Coupons::DataAmountsOffCurrency.Idr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ils)]
    [InlineData(Coupons::DataAmountsOffCurrency.Inr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Isk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Jmd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Jpy)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kes)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kgs)]
    [InlineData(Coupons::DataAmountsOffCurrency.Khr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kmf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Krw)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kyd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Kzt)]
    [InlineData(Coupons::DataAmountsOffCurrency.Lbp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Lkr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Lrd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Lsl)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mad)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mdl)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mga)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mkd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mmk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mnt)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mop)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mro)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mvr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mwk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mxn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Myr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Mzn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Nad)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ngn)]
    [InlineData(Coupons::DataAmountsOffCurrency.Nok)]
    [InlineData(Coupons::DataAmountsOffCurrency.Npr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Nzd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Pgk)]
    [InlineData(Coupons::DataAmountsOffCurrency.Php)]
    [InlineData(Coupons::DataAmountsOffCurrency.Pkr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Pln)]
    [InlineData(Coupons::DataAmountsOffCurrency.Qar)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ron)]
    [InlineData(Coupons::DataAmountsOffCurrency.Rsd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Rub)]
    [InlineData(Coupons::DataAmountsOffCurrency.Rwf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sar)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sbd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Scr)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sek)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sgd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sle)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sll)]
    [InlineData(Coupons::DataAmountsOffCurrency.Sos)]
    [InlineData(Coupons::DataAmountsOffCurrency.Szl)]
    [InlineData(Coupons::DataAmountsOffCurrency.Thb)]
    [InlineData(Coupons::DataAmountsOffCurrency.Tjs)]
    [InlineData(Coupons::DataAmountsOffCurrency.Top)]
    [InlineData(Coupons::DataAmountsOffCurrency.Try)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ttd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Tzs)]
    [InlineData(Coupons::DataAmountsOffCurrency.Uah)]
    [InlineData(Coupons::DataAmountsOffCurrency.Uzs)]
    [InlineData(Coupons::DataAmountsOffCurrency.Vnd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Vuv)]
    [InlineData(Coupons::DataAmountsOffCurrency.Wst)]
    [InlineData(Coupons::DataAmountsOffCurrency.Xaf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Xcd)]
    [InlineData(Coupons::DataAmountsOffCurrency.Yer)]
    [InlineData(Coupons::DataAmountsOffCurrency.Zar)]
    [InlineData(Coupons::DataAmountsOffCurrency.Zmw)]
    [InlineData(Coupons::DataAmountsOffCurrency.Clp)]
    [InlineData(Coupons::DataAmountsOffCurrency.Djf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Gnf)]
    [InlineData(Coupons::DataAmountsOffCurrency.Ugx)]
    [InlineData(Coupons::DataAmountsOffCurrency.Pyg)]
    [InlineData(Coupons::DataAmountsOffCurrency.Xof)]
    [InlineData(Coupons::DataAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(Coupons::DataAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::DataAmountsOffCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Coupons::DataAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::DataAmountsOffCurrency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, Coupons::DataAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class SourceTest : TestBase
{
    [Theory]
    [InlineData(Coupons::Source.Stigg)]
    [InlineData(Coupons::Source.StiggAdhoc)]
    [InlineData(Coupons::Source.Stripe)]
    public void Validation_Works(Coupons::Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::Source> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Coupons::Source.Stigg)]
    [InlineData(Coupons::Source.StiggAdhoc)]
    [InlineData(Coupons::Source.Stripe)]
    public void SerializationRoundtrip_Works(Coupons::Source rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::Source> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Source>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Source>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class StatusTest : TestBase
{
    [Theory]
    [InlineData(Coupons::Status.Active)]
    [InlineData(Coupons::Status.Archived)]
    public void Validation_Works(Coupons::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::Status> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Coupons::Status.Active)]
    [InlineData(Coupons::Status.Archived)]
    public void SerializationRoundtrip_Works(Coupons::Status rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::Status> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Status>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Status>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class TypeTest : TestBase
{
    [Theory]
    [InlineData(Coupons::Type.Fixed)]
    [InlineData(Coupons::Type.Percentage)]
    public void Validation_Works(Coupons::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::Type> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Coupons::Type.Fixed)]
    [InlineData(Coupons::Type.Percentage)]
    public void SerializationRoundtrip_Works(Coupons::Type rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Coupons::Type> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Type>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Coupons::Type>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
