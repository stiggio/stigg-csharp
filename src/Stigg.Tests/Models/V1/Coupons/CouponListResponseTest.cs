using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Coupons;

namespace Stigg.Tests.Models.V1.Coupons;

public class CouponListResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponListResponse
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseSource.Stigg,
            Status = CouponListResponseStatus.Active,
            Type = CouponListResponseType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<CouponListResponseAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = CouponListResponseAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        double expectedDurationInMonths = 0;
        string expectedName = "name";
        double expectedPercentOff = 0;
        ApiEnum<string, CouponListResponseSource> expectedSource = CouponListResponseSource.Stigg;
        ApiEnum<string, CouponListResponseStatus> expectedStatus = CouponListResponseStatus.Active;
        ApiEnum<string, CouponListResponseType> expectedType = CouponListResponseType.Fixed;
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
        var model = new CouponListResponse
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseSource.Stigg,
            Status = CouponListResponseStatus.Active,
            Type = CouponListResponseType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponListResponse
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseSource.Stigg,
            Status = CouponListResponseStatus.Active,
            Type = CouponListResponseType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<CouponListResponseAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = CouponListResponseAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        double expectedDurationInMonths = 0;
        string expectedName = "name";
        double expectedPercentOff = 0;
        ApiEnum<string, CouponListResponseSource> expectedSource = CouponListResponseSource.Stigg;
        ApiEnum<string, CouponListResponseStatus> expectedStatus = CouponListResponseStatus.Active;
        ApiEnum<string, CouponListResponseType> expectedType = CouponListResponseType.Fixed;
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
        var model = new CouponListResponse
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseSource.Stigg,
            Status = CouponListResponseStatus.Active,
            Type = CouponListResponseType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CouponListResponse
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseSource.Stigg,
            Status = CouponListResponseStatus.Active,
            Type = CouponListResponseType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CouponListResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CouponListResponseAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponListResponseAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseAmountsOffCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, CouponListResponseAmountsOffCurrency> expectedCurrency =
            CouponListResponseAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CouponListResponseAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseAmountsOffCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponseAmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponListResponseAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseAmountsOffCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponseAmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, CouponListResponseAmountsOffCurrency> expectedCurrency =
            CouponListResponseAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CouponListResponseAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseAmountsOffCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CouponListResponseAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseAmountsOffCurrency.Usd,
        };

        CouponListResponseAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CouponListResponseAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CouponListResponseAmountsOffCurrency.Usd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Aed)]
    [InlineData(CouponListResponseAmountsOffCurrency.All)]
    [InlineData(CouponListResponseAmountsOffCurrency.Amd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ang)]
    [InlineData(CouponListResponseAmountsOffCurrency.Aud)]
    [InlineData(CouponListResponseAmountsOffCurrency.Awg)]
    [InlineData(CouponListResponseAmountsOffCurrency.Azn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bam)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bbd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bdt)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bgn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bif)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bmd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bnd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bsd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bwp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Byn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bzd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Brl)]
    [InlineData(CouponListResponseAmountsOffCurrency.Cad)]
    [InlineData(CouponListResponseAmountsOffCurrency.Cdf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Chf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Cny)]
    [InlineData(CouponListResponseAmountsOffCurrency.Czk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Dkk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Dop)]
    [InlineData(CouponListResponseAmountsOffCurrency.Dzd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Egp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Etb)]
    [InlineData(CouponListResponseAmountsOffCurrency.Eur)]
    [InlineData(CouponListResponseAmountsOffCurrency.Fjd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gbp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gel)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gip)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gmd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gyd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Hkd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Hrk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Htg)]
    [InlineData(CouponListResponseAmountsOffCurrency.Idr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ils)]
    [InlineData(CouponListResponseAmountsOffCurrency.Inr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Isk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Jmd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Jpy)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kes)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kgs)]
    [InlineData(CouponListResponseAmountsOffCurrency.Khr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kmf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Krw)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kyd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kzt)]
    [InlineData(CouponListResponseAmountsOffCurrency.Lbp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Lkr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Lrd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Lsl)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mad)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mdl)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mga)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mkd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mmk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mnt)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mop)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mro)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mvr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mwk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mxn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Myr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mzn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Nad)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ngn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Nok)]
    [InlineData(CouponListResponseAmountsOffCurrency.Npr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Nzd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Pgk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Php)]
    [InlineData(CouponListResponseAmountsOffCurrency.Pkr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Pln)]
    [InlineData(CouponListResponseAmountsOffCurrency.Qar)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ron)]
    [InlineData(CouponListResponseAmountsOffCurrency.Rsd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Rub)]
    [InlineData(CouponListResponseAmountsOffCurrency.Rwf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sar)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sbd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Scr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sek)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sgd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sle)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sll)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sos)]
    [InlineData(CouponListResponseAmountsOffCurrency.Szl)]
    [InlineData(CouponListResponseAmountsOffCurrency.Thb)]
    [InlineData(CouponListResponseAmountsOffCurrency.Tjs)]
    [InlineData(CouponListResponseAmountsOffCurrency.Top)]
    [InlineData(CouponListResponseAmountsOffCurrency.Try)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ttd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Tzs)]
    [InlineData(CouponListResponseAmountsOffCurrency.Uah)]
    [InlineData(CouponListResponseAmountsOffCurrency.Uzs)]
    [InlineData(CouponListResponseAmountsOffCurrency.Vnd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Vuv)]
    [InlineData(CouponListResponseAmountsOffCurrency.Wst)]
    [InlineData(CouponListResponseAmountsOffCurrency.Xaf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Xcd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Yer)]
    [InlineData(CouponListResponseAmountsOffCurrency.Zar)]
    [InlineData(CouponListResponseAmountsOffCurrency.Zmw)]
    [InlineData(CouponListResponseAmountsOffCurrency.Clp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Djf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gnf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ugx)]
    [InlineData(CouponListResponseAmountsOffCurrency.Pyg)]
    [InlineData(CouponListResponseAmountsOffCurrency.Xof)]
    [InlineData(CouponListResponseAmountsOffCurrency.Xpf)]
    public void Validation_Works(CouponListResponseAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseAmountsOffCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponListResponseAmountsOffCurrency.Usd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Aed)]
    [InlineData(CouponListResponseAmountsOffCurrency.All)]
    [InlineData(CouponListResponseAmountsOffCurrency.Amd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ang)]
    [InlineData(CouponListResponseAmountsOffCurrency.Aud)]
    [InlineData(CouponListResponseAmountsOffCurrency.Awg)]
    [InlineData(CouponListResponseAmountsOffCurrency.Azn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bam)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bbd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bdt)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bgn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bif)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bmd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bnd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bsd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bwp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Byn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Bzd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Brl)]
    [InlineData(CouponListResponseAmountsOffCurrency.Cad)]
    [InlineData(CouponListResponseAmountsOffCurrency.Cdf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Chf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Cny)]
    [InlineData(CouponListResponseAmountsOffCurrency.Czk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Dkk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Dop)]
    [InlineData(CouponListResponseAmountsOffCurrency.Dzd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Egp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Etb)]
    [InlineData(CouponListResponseAmountsOffCurrency.Eur)]
    [InlineData(CouponListResponseAmountsOffCurrency.Fjd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gbp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gel)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gip)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gmd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gyd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Hkd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Hrk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Htg)]
    [InlineData(CouponListResponseAmountsOffCurrency.Idr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ils)]
    [InlineData(CouponListResponseAmountsOffCurrency.Inr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Isk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Jmd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Jpy)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kes)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kgs)]
    [InlineData(CouponListResponseAmountsOffCurrency.Khr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kmf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Krw)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kyd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Kzt)]
    [InlineData(CouponListResponseAmountsOffCurrency.Lbp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Lkr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Lrd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Lsl)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mad)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mdl)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mga)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mkd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mmk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mnt)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mop)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mro)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mvr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mwk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mxn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Myr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Mzn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Nad)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ngn)]
    [InlineData(CouponListResponseAmountsOffCurrency.Nok)]
    [InlineData(CouponListResponseAmountsOffCurrency.Npr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Nzd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Pgk)]
    [InlineData(CouponListResponseAmountsOffCurrency.Php)]
    [InlineData(CouponListResponseAmountsOffCurrency.Pkr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Pln)]
    [InlineData(CouponListResponseAmountsOffCurrency.Qar)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ron)]
    [InlineData(CouponListResponseAmountsOffCurrency.Rsd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Rub)]
    [InlineData(CouponListResponseAmountsOffCurrency.Rwf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sar)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sbd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Scr)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sek)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sgd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sle)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sll)]
    [InlineData(CouponListResponseAmountsOffCurrency.Sos)]
    [InlineData(CouponListResponseAmountsOffCurrency.Szl)]
    [InlineData(CouponListResponseAmountsOffCurrency.Thb)]
    [InlineData(CouponListResponseAmountsOffCurrency.Tjs)]
    [InlineData(CouponListResponseAmountsOffCurrency.Top)]
    [InlineData(CouponListResponseAmountsOffCurrency.Try)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ttd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Tzs)]
    [InlineData(CouponListResponseAmountsOffCurrency.Uah)]
    [InlineData(CouponListResponseAmountsOffCurrency.Uzs)]
    [InlineData(CouponListResponseAmountsOffCurrency.Vnd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Vuv)]
    [InlineData(CouponListResponseAmountsOffCurrency.Wst)]
    [InlineData(CouponListResponseAmountsOffCurrency.Xaf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Xcd)]
    [InlineData(CouponListResponseAmountsOffCurrency.Yer)]
    [InlineData(CouponListResponseAmountsOffCurrency.Zar)]
    [InlineData(CouponListResponseAmountsOffCurrency.Zmw)]
    [InlineData(CouponListResponseAmountsOffCurrency.Clp)]
    [InlineData(CouponListResponseAmountsOffCurrency.Djf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Gnf)]
    [InlineData(CouponListResponseAmountsOffCurrency.Ugx)]
    [InlineData(CouponListResponseAmountsOffCurrency.Pyg)]
    [InlineData(CouponListResponseAmountsOffCurrency.Xof)]
    [InlineData(CouponListResponseAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(CouponListResponseAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseAmountsOffCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CouponListResponseSourceTest : TestBase
{
    [Theory]
    [InlineData(CouponListResponseSource.Stigg)]
    [InlineData(CouponListResponseSource.StiggAdhoc)]
    [InlineData(CouponListResponseSource.Stripe)]
    public void Validation_Works(CouponListResponseSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponListResponseSource.Stigg)]
    [InlineData(CouponListResponseSource.StiggAdhoc)]
    [InlineData(CouponListResponseSource.Stripe)]
    public void SerializationRoundtrip_Works(CouponListResponseSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseSource>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CouponListResponseStatusTest : TestBase
{
    [Theory]
    [InlineData(CouponListResponseStatus.Active)]
    [InlineData(CouponListResponseStatus.Archived)]
    public void Validation_Works(CouponListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponListResponseStatus.Active)]
    [InlineData(CouponListResponseStatus.Archived)]
    public void SerializationRoundtrip_Works(CouponListResponseStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseStatus>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class CouponListResponseTypeTest : TestBase
{
    [Theory]
    [InlineData(CouponListResponseType.Fixed)]
    [InlineData(CouponListResponseType.Percentage)]
    public void Validation_Works(CouponListResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponListResponseType.Fixed)]
    [InlineData(CouponListResponseType.Percentage)]
    public void SerializationRoundtrip_Works(CouponListResponseType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
