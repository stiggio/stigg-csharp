using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Coupons;

namespace Stigg.Tests.Models.V1.Coupons;

public class CouponRetrieveResponseTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
                    },
                ],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = CouponRetrieveResponseDataSource.Stigg,
                Status = CouponRetrieveResponseDataStatus.Active,
                Type = CouponRetrieveResponseDataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        CouponRetrieveResponseData expectedData = new()
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponRetrieveResponseDataSource.Stigg,
            Status = CouponRetrieveResponseDataStatus.Active,
            Type = CouponRetrieveResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, model.Data);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CouponRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
                    },
                ],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = CouponRetrieveResponseDataSource.Stigg,
                Status = CouponRetrieveResponseDataStatus.Active,
                Type = CouponRetrieveResponseDataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponRetrieveResponse>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
                    },
                ],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = CouponRetrieveResponseDataSource.Stigg,
                Status = CouponRetrieveResponseDataStatus.Active,
                Type = CouponRetrieveResponseDataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponRetrieveResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        CouponRetrieveResponseData expectedData = new()
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponRetrieveResponseDataSource.Stigg,
            Status = CouponRetrieveResponseDataStatus.Active,
            Type = CouponRetrieveResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Assert.Equal(expectedData, deserialized.Data);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CouponRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
                    },
                ],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = CouponRetrieveResponseDataSource.Stigg,
                Status = CouponRetrieveResponseDataStatus.Active,
                Type = CouponRetrieveResponseDataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CouponRetrieveResponse
        {
            Data = new()
            {
                ID = "id",
                AmountsOff =
                [
                    new()
                    {
                        Amount = 0,
                        Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
                    },
                ],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = CouponRetrieveResponseDataSource.Stigg,
                Status = CouponRetrieveResponseDataStatus.Active,
                Type = CouponRetrieveResponseDataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        };

        CouponRetrieveResponse copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CouponRetrieveResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponRetrieveResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponRetrieveResponseDataSource.Stigg,
            Status = CouponRetrieveResponseDataStatus.Active,
            Type = CouponRetrieveResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<CouponRetrieveResponseDataAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        double expectedDurationInMonths = 0;
        string expectedName = "name";
        double expectedPercentOff = 0;
        ApiEnum<string, CouponRetrieveResponseDataSource> expectedSource =
            CouponRetrieveResponseDataSource.Stigg;
        ApiEnum<string, CouponRetrieveResponseDataStatus> expectedStatus =
            CouponRetrieveResponseDataStatus.Active;
        ApiEnum<string, CouponRetrieveResponseDataType> expectedType =
            CouponRetrieveResponseDataType.Fixed;
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
        var model = new CouponRetrieveResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponRetrieveResponseDataSource.Stigg,
            Status = CouponRetrieveResponseDataStatus.Active,
            Type = CouponRetrieveResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponRetrieveResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponRetrieveResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponRetrieveResponseDataSource.Stigg,
            Status = CouponRetrieveResponseDataStatus.Active,
            Type = CouponRetrieveResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponRetrieveResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<CouponRetrieveResponseDataAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedDescription = "description";
        double expectedDurationInMonths = 0;
        string expectedName = "name";
        double expectedPercentOff = 0;
        ApiEnum<string, CouponRetrieveResponseDataSource> expectedSource =
            CouponRetrieveResponseDataSource.Stigg;
        ApiEnum<string, CouponRetrieveResponseDataStatus> expectedStatus =
            CouponRetrieveResponseDataStatus.Active;
        ApiEnum<string, CouponRetrieveResponseDataType> expectedType =
            CouponRetrieveResponseDataType.Fixed;
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
        var model = new CouponRetrieveResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponRetrieveResponseDataSource.Stigg,
            Status = CouponRetrieveResponseDataStatus.Active,
            Type = CouponRetrieveResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CouponRetrieveResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponRetrieveResponseDataSource.Stigg,
            Status = CouponRetrieveResponseDataStatus.Active,
            Type = CouponRetrieveResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        CouponRetrieveResponseData copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CouponRetrieveResponseDataAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponRetrieveResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency> expectedCurrency =
            CouponRetrieveResponseDataAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CouponRetrieveResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponRetrieveResponseDataAmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponRetrieveResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponRetrieveResponseDataAmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency> expectedCurrency =
            CouponRetrieveResponseDataAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CouponRetrieveResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new CouponRetrieveResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponRetrieveResponseDataAmountsOffCurrency.Usd,
        };

        CouponRetrieveResponseDataAmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CouponRetrieveResponseDataAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Usd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Aed)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.All)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Amd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ang)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Aud)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Awg)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Azn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bam)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bbd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bdt)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bgn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bif)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bmd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bnd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bsd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bwp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Byn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bzd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Brl)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Cad)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Cdf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Chf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Cny)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Czk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Dkk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Dop)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Dzd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Egp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Etb)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Eur)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Fjd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gbp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gel)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gip)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gmd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gyd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Hkd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Hrk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Htg)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Idr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ils)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Inr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Isk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Jmd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Jpy)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kes)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kgs)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Khr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kmf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Krw)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kyd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kzt)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Lbp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Lkr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Lrd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Lsl)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mad)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mdl)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mga)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mkd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mmk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mnt)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mop)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mro)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mvr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mwk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mxn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Myr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mzn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Nad)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ngn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Nok)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Npr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Nzd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Pgk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Php)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Pkr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Pln)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Qar)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ron)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Rsd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Rub)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Rwf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sar)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sbd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Scr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sek)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sgd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sle)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sll)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sos)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Szl)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Thb)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Tjs)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Top)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Try)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ttd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Tzs)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Uah)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Uzs)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Vnd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Vuv)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Wst)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Xaf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Xcd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Yer)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Zar)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Zmw)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Clp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Djf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gnf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ugx)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Pyg)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Xof)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Xpf)]
    public void Validation_Works(CouponRetrieveResponseDataAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Usd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Aed)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.All)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Amd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ang)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Aud)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Awg)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Azn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bam)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bbd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bdt)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bgn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bif)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bmd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bnd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bsd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bwp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Byn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Bzd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Brl)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Cad)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Cdf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Chf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Cny)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Czk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Dkk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Dop)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Dzd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Egp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Etb)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Eur)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Fjd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gbp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gel)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gip)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gmd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gyd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Hkd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Hrk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Htg)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Idr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ils)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Inr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Isk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Jmd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Jpy)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kes)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kgs)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Khr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kmf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Krw)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kyd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Kzt)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Lbp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Lkr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Lrd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Lsl)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mad)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mdl)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mga)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mkd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mmk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mnt)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mop)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mro)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mvr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mwk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mxn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Myr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Mzn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Nad)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ngn)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Nok)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Npr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Nzd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Pgk)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Php)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Pkr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Pln)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Qar)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ron)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Rsd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Rub)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Rwf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sar)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sbd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Scr)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sek)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sgd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sle)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sll)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Sos)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Szl)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Thb)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Tjs)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Top)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Try)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ttd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Tzs)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Uah)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Uzs)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Vnd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Vuv)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Wst)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Xaf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Xcd)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Yer)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Zar)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Zmw)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Clp)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Djf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Gnf)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Ugx)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Pyg)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Xof)]
    [InlineData(CouponRetrieveResponseDataAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(CouponRetrieveResponseDataAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CouponRetrieveResponseDataSourceTest : TestBase
{
    [Theory]
    [InlineData(CouponRetrieveResponseDataSource.Stigg)]
    [InlineData(CouponRetrieveResponseDataSource.StiggAdhoc)]
    [InlineData(CouponRetrieveResponseDataSource.Stripe)]
    public void Validation_Works(CouponRetrieveResponseDataSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponRetrieveResponseDataSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponRetrieveResponseDataSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponRetrieveResponseDataSource.Stigg)]
    [InlineData(CouponRetrieveResponseDataSource.StiggAdhoc)]
    [InlineData(CouponRetrieveResponseDataSource.Stripe)]
    public void SerializationRoundtrip_Works(CouponRetrieveResponseDataSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponRetrieveResponseDataSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponRetrieveResponseDataSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CouponRetrieveResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(CouponRetrieveResponseDataStatus.Active)]
    [InlineData(CouponRetrieveResponseDataStatus.Archived)]
    public void Validation_Works(CouponRetrieveResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponRetrieveResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponRetrieveResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponRetrieveResponseDataStatus.Active)]
    [InlineData(CouponRetrieveResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(CouponRetrieveResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponRetrieveResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponRetrieveResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CouponRetrieveResponseDataTypeTest : TestBase
{
    [Theory]
    [InlineData(CouponRetrieveResponseDataType.Fixed)]
    [InlineData(CouponRetrieveResponseDataType.Percentage)]
    public void Validation_Works(CouponRetrieveResponseDataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponRetrieveResponseDataType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponRetrieveResponseDataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponRetrieveResponseDataType.Fixed)]
    [InlineData(CouponRetrieveResponseDataType.Percentage)]
    public void SerializationRoundtrip_Works(CouponRetrieveResponseDataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponRetrieveResponseDataType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponRetrieveResponseDataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponRetrieveResponseDataType>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}
