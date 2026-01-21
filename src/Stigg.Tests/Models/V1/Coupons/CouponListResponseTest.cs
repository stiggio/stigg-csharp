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
            Data =
            [
                new()
                {
                    ID = "id",
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = CouponListResponseDataAmountsOffCurrency.Usd,
                        },
                    ],
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Description = "description",
                    DurationInMonths = 0,
                    Name = "name",
                    PercentOff = 0,
                    Source = CouponListResponseDataSource.Stigg,
                    Status = CouponListResponseDataStatus.Active,
                    Type = CouponListResponseDataType.Fixed,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        List<CouponListResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                AmountsOff =
                [
                    new() { Amount = 0, Currency = CouponListResponseDataAmountsOffCurrency.Usd },
                ],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = CouponListResponseDataSource.Stigg,
                Status = CouponListResponseDataStatus.Active,
                Type = CouponListResponseDataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedData.Count, model.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], model.Data[i]);
        }
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CouponListResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = CouponListResponseDataAmountsOffCurrency.Usd,
                        },
                    ],
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Description = "description",
                    DurationInMonths = 0,
                    Name = "name",
                    PercentOff = 0,
                    Source = CouponListResponseDataSource.Stigg,
                    Status = CouponListResponseDataStatus.Active,
                    Type = CouponListResponseDataType.Fixed,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
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
            Data =
            [
                new()
                {
                    ID = "id",
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = CouponListResponseDataAmountsOffCurrency.Usd,
                        },
                    ],
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Description = "description",
                    DurationInMonths = 0,
                    Name = "name",
                    PercentOff = 0,
                    Source = CouponListResponseDataSource.Stigg,
                    Status = CouponListResponseDataStatus.Active,
                    Type = CouponListResponseDataType.Fixed,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponse>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        List<CouponListResponseData> expectedData =
        [
            new()
            {
                ID = "id",
                AmountsOff =
                [
                    new() { Amount = 0, Currency = CouponListResponseDataAmountsOffCurrency.Usd },
                ],
                BillingID = "billingId",
                BillingLinkUrl = "billingLinkUrl",
                CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                Description = "description",
                DurationInMonths = 0,
                Name = "name",
                PercentOff = 0,
                Source = CouponListResponseDataSource.Stigg,
                Status = CouponListResponseDataStatus.Active,
                Type = CouponListResponseDataType.Fixed,
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];

        Assert.Equal(expectedData.Count, deserialized.Data.Count);
        for (int i = 0; i < expectedData.Count; i++)
        {
            Assert.Equal(expectedData[i], deserialized.Data[i]);
        }
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CouponListResponse
        {
            Data =
            [
                new()
                {
                    ID = "id",
                    AmountsOff =
                    [
                        new()
                        {
                            Amount = 0,
                            Currency = CouponListResponseDataAmountsOffCurrency.Usd,
                        },
                    ],
                    BillingID = "billingId",
                    BillingLinkUrl = "billingLinkUrl",
                    CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                    CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
                    Description = "description",
                    DurationInMonths = 0,
                    Name = "name",
                    PercentOff = 0,
                    Source = CouponListResponseDataSource.Stigg,
                    Status = CouponListResponseDataStatus.Active,
                    Type = CouponListResponseDataType.Fixed,
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        model.Validate();
    }
}

public class CouponListResponseDataTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponListResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseDataSource.Stigg,
            Status = CouponListResponseDataStatus.Active,
            Type = CouponListResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        List<CouponListResponseDataAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = CouponListResponseDataAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";
        double expectedDurationInMonths = 0;
        string expectedName = "name";
        double expectedPercentOff = 0;
        ApiEnum<string, CouponListResponseDataSource> expectedSource =
            CouponListResponseDataSource.Stigg;
        ApiEnum<string, CouponListResponseDataStatus> expectedStatus =
            CouponListResponseDataStatus.Active;
        ApiEnum<string, CouponListResponseDataType> expectedType = CouponListResponseDataType.Fixed;
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
        Assert.Equal(expectedCursorID, model.CursorID);
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
        var model = new CouponListResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseDataSource.Stigg,
            Status = CouponListResponseDataStatus.Active,
            Type = CouponListResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponseData>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponListResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseDataSource.Stigg,
            Status = CouponListResponseDataStatus.Active,
            Type = CouponListResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponseData>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        List<CouponListResponseDataAmountsOff> expectedAmountsOff =
        [
            new() { Amount = 0, Currency = CouponListResponseDataAmountsOffCurrency.Usd },
        ];
        string expectedBillingID = "billingId";
        string expectedBillingLinkUrl = "billingLinkUrl";
        DateTimeOffset expectedCreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        string expectedCursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        string expectedDescription = "description";
        double expectedDurationInMonths = 0;
        string expectedName = "name";
        double expectedPercentOff = 0;
        ApiEnum<string, CouponListResponseDataSource> expectedSource =
            CouponListResponseDataSource.Stigg;
        ApiEnum<string, CouponListResponseDataStatus> expectedStatus =
            CouponListResponseDataStatus.Active;
        ApiEnum<string, CouponListResponseDataType> expectedType = CouponListResponseDataType.Fixed;
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
        Assert.Equal(expectedCursorID, deserialized.CursorID);
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
        var model = new CouponListResponseData
        {
            ID = "id",
            AmountsOff =
            [
                new() { Amount = 0, Currency = CouponListResponseDataAmountsOffCurrency.Usd },
            ],
            BillingID = "billingId",
            BillingLinkUrl = "billingLinkUrl",
            CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            CursorID = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Description = "description",
            DurationInMonths = 0,
            Name = "name",
            PercentOff = 0,
            Source = CouponListResponseDataSource.Stigg,
            Status = CouponListResponseDataStatus.Active,
            Type = CouponListResponseDataType.Fixed,
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }
}

public class CouponListResponseDataAmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new CouponListResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseDataAmountsOffCurrency.Usd,
        };

        double expectedAmount = 0;
        ApiEnum<string, CouponListResponseDataAmountsOffCurrency> expectedCurrency =
            CouponListResponseDataAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new CouponListResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseDataAmountsOffCurrency.Usd,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponseDataAmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new CouponListResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseDataAmountsOffCurrency.Usd,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<CouponListResponseDataAmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, CouponListResponseDataAmountsOffCurrency> expectedCurrency =
            CouponListResponseDataAmountsOffCurrency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new CouponListResponseDataAmountsOff
        {
            Amount = 0,
            Currency = CouponListResponseDataAmountsOffCurrency.Usd,
        };

        model.Validate();
    }
}

public class CouponListResponseDataAmountsOffCurrencyTest : TestBase
{
    [Theory]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Usd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Aed)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.All)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Amd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ang)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Aud)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Awg)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Azn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bam)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bbd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bdt)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bgn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bif)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bmd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bnd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bsd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bwp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Byn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bzd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Brl)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Cad)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Cdf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Chf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Cny)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Czk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Dkk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Dop)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Dzd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Egp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Etb)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Eur)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Fjd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gbp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gel)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gip)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gmd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gyd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Hkd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Hrk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Htg)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Idr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ils)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Inr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Isk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Jmd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Jpy)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kes)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kgs)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Khr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kmf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Krw)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kyd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kzt)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Lbp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Lkr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Lrd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Lsl)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mad)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mdl)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mga)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mkd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mmk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mnt)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mop)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mro)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mvr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mwk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mxn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Myr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mzn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Nad)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ngn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Nok)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Npr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Nzd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Pgk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Php)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Pkr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Pln)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Qar)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ron)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Rsd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Rub)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Rwf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sar)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sbd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Scr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sek)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sgd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sle)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sll)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sos)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Szl)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Thb)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Tjs)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Top)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Try)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ttd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Tzs)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Uah)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Uzs)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Vnd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Vuv)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Wst)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Xaf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Xcd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Yer)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Zar)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Zmw)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Clp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Djf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gnf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ugx)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Pyg)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Xof)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Xpf)]
    public void Validation_Works(CouponListResponseDataAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseDataAmountsOffCurrency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseDataAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Usd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Aed)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.All)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Amd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ang)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Aud)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Awg)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Azn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bam)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bbd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bdt)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bgn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bif)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bmd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bnd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bsd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bwp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Byn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Bzd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Brl)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Cad)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Cdf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Chf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Cny)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Czk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Dkk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Dop)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Dzd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Egp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Etb)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Eur)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Fjd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gbp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gel)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gip)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gmd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gyd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Hkd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Hrk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Htg)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Idr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ils)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Inr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Isk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Jmd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Jpy)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kes)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kgs)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Khr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kmf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Krw)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kyd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Kzt)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Lbp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Lkr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Lrd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Lsl)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mad)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mdl)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mga)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mkd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mmk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mnt)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mop)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mro)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mvr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mwk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mxn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Myr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Mzn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Nad)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ngn)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Nok)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Npr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Nzd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Pgk)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Php)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Pkr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Pln)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Qar)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ron)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Rsd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Rub)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Rwf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sar)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sbd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Scr)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sek)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sgd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sle)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sll)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Sos)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Szl)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Thb)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Tjs)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Top)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Try)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ttd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Tzs)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Uah)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Uzs)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Vnd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Vuv)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Wst)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Xaf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Xcd)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Yer)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Zar)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Zmw)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Clp)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Djf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Gnf)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Ugx)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Pyg)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Xof)]
    [InlineData(CouponListResponseDataAmountsOffCurrency.Xpf)]
    public void SerializationRoundtrip_Works(CouponListResponseDataAmountsOffCurrency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseDataAmountsOffCurrency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseDataAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseDataAmountsOffCurrency>
        >(JsonSerializer.SerializeToElement("invalid value"), ModelBase.SerializerOptions);
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseDataAmountsOffCurrency>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CouponListResponseDataSourceTest : TestBase
{
    [Theory]
    [InlineData(CouponListResponseDataSource.Stigg)]
    [InlineData(CouponListResponseDataSource.StiggAdhoc)]
    [InlineData(CouponListResponseDataSource.Stripe)]
    public void Validation_Works(CouponListResponseDataSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseDataSource> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseDataSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponListResponseDataSource.Stigg)]
    [InlineData(CouponListResponseDataSource.StiggAdhoc)]
    [InlineData(CouponListResponseDataSource.Stripe)]
    public void SerializationRoundtrip_Works(CouponListResponseDataSource rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseDataSource> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseDataSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseDataSource>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseDataSource>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CouponListResponseDataStatusTest : TestBase
{
    [Theory]
    [InlineData(CouponListResponseDataStatus.Active)]
    [InlineData(CouponListResponseDataStatus.Archived)]
    public void Validation_Works(CouponListResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseDataStatus> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponListResponseDataStatus.Active)]
    [InlineData(CouponListResponseDataStatus.Archived)]
    public void SerializationRoundtrip_Works(CouponListResponseDataStatus rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseDataStatus> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseDataStatus>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<
            ApiEnum<string, CouponListResponseDataStatus>
        >(json, ModelBase.SerializerOptions);

        Assert.Equal(value, deserialized);
    }
}

public class CouponListResponseDataTypeTest : TestBase
{
    [Theory]
    [InlineData(CouponListResponseDataType.Fixed)]
    [InlineData(CouponListResponseDataType.Percentage)]
    public void Validation_Works(CouponListResponseDataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseDataType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseDataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(CouponListResponseDataType.Fixed)]
    [InlineData(CouponListResponseDataType.Percentage)]
    public void SerializationRoundtrip_Works(CouponListResponseDataType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, CouponListResponseDataType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseDataType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseDataType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, CouponListResponseDataType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
