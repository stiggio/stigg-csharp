using System;
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Tests.Models.V1.Coupons;

public class CouponCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CouponCreateParams
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
        };

        string expectedID = "id";
        List<AmountsOff> expectedAmountsOff = [new() { Amount = 0, Currency = Currency.Usd }];
        string expectedDescription = "description";
        long expectedDurationInMonths = 1;
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedName = "name";
        long expectedPercentOff = 1;

        Assert.Equal(expectedID, parameters.ID);
        Assert.NotNull(parameters.AmountsOff);
        Assert.Equal(expectedAmountsOff.Count, parameters.AmountsOff.Count);
        for (int i = 0; i < expectedAmountsOff.Count; i++)
        {
            Assert.Equal(expectedAmountsOff[i], parameters.AmountsOff[i]);
        }
        Assert.Equal(expectedDescription, parameters.Description);
        Assert.Equal(expectedDurationInMonths, parameters.DurationInMonths);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedName, parameters.Name);
        Assert.Equal(expectedPercentOff, parameters.PercentOff);
    }

    [Fact]
    public void Url_Works()
    {
        CouponCreateParams parameters = new()
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(new Uri("https://api.stigg.io/api/v1/coupons"), url);
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CouponCreateParams
        {
            ID = "id",
            AmountsOff = [new() { Amount = 0, Currency = Currency.Usd }],
            Description = "description",
            DurationInMonths = 1,
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            Name = "name",
            PercentOff = 1,
        };

        CouponCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class AmountsOffTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new AmountsOff { Amount = 0, Currency = Currency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new AmountsOff { Amount = 0, Currency = Currency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AmountsOff>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new AmountsOff { Amount = 0, Currency = Currency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<AmountsOff>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new AmountsOff { Amount = 0, Currency = Currency.Usd };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new AmountsOff { Amount = 0, Currency = Currency.Usd };

        AmountsOff copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CurrencyTest : TestBase
{
    [Theory]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Ang)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Cdf)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Hrk)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Isk)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mro)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sll)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Tjs)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Xaf)]
    [InlineData(Currency.Xcd)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Zmw)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Xof)]
    [InlineData(Currency.Xpf)]
    public void Validation_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(Currency.Usd)]
    [InlineData(Currency.Aed)]
    [InlineData(Currency.All)]
    [InlineData(Currency.Amd)]
    [InlineData(Currency.Ang)]
    [InlineData(Currency.Aud)]
    [InlineData(Currency.Awg)]
    [InlineData(Currency.Azn)]
    [InlineData(Currency.Bam)]
    [InlineData(Currency.Bbd)]
    [InlineData(Currency.Bdt)]
    [InlineData(Currency.Bgn)]
    [InlineData(Currency.Bif)]
    [InlineData(Currency.Bmd)]
    [InlineData(Currency.Bnd)]
    [InlineData(Currency.Bsd)]
    [InlineData(Currency.Bwp)]
    [InlineData(Currency.Byn)]
    [InlineData(Currency.Bzd)]
    [InlineData(Currency.Brl)]
    [InlineData(Currency.Cad)]
    [InlineData(Currency.Cdf)]
    [InlineData(Currency.Chf)]
    [InlineData(Currency.Cny)]
    [InlineData(Currency.Czk)]
    [InlineData(Currency.Dkk)]
    [InlineData(Currency.Dop)]
    [InlineData(Currency.Dzd)]
    [InlineData(Currency.Egp)]
    [InlineData(Currency.Etb)]
    [InlineData(Currency.Eur)]
    [InlineData(Currency.Fjd)]
    [InlineData(Currency.Gbp)]
    [InlineData(Currency.Gel)]
    [InlineData(Currency.Gip)]
    [InlineData(Currency.Gmd)]
    [InlineData(Currency.Gyd)]
    [InlineData(Currency.Hkd)]
    [InlineData(Currency.Hrk)]
    [InlineData(Currency.Htg)]
    [InlineData(Currency.Idr)]
    [InlineData(Currency.Ils)]
    [InlineData(Currency.Inr)]
    [InlineData(Currency.Isk)]
    [InlineData(Currency.Jmd)]
    [InlineData(Currency.Jpy)]
    [InlineData(Currency.Kes)]
    [InlineData(Currency.Kgs)]
    [InlineData(Currency.Khr)]
    [InlineData(Currency.Kmf)]
    [InlineData(Currency.Krw)]
    [InlineData(Currency.Kyd)]
    [InlineData(Currency.Kzt)]
    [InlineData(Currency.Lbp)]
    [InlineData(Currency.Lkr)]
    [InlineData(Currency.Lrd)]
    [InlineData(Currency.Lsl)]
    [InlineData(Currency.Mad)]
    [InlineData(Currency.Mdl)]
    [InlineData(Currency.Mga)]
    [InlineData(Currency.Mkd)]
    [InlineData(Currency.Mmk)]
    [InlineData(Currency.Mnt)]
    [InlineData(Currency.Mop)]
    [InlineData(Currency.Mro)]
    [InlineData(Currency.Mvr)]
    [InlineData(Currency.Mwk)]
    [InlineData(Currency.Mxn)]
    [InlineData(Currency.Myr)]
    [InlineData(Currency.Mzn)]
    [InlineData(Currency.Nad)]
    [InlineData(Currency.Ngn)]
    [InlineData(Currency.Nok)]
    [InlineData(Currency.Npr)]
    [InlineData(Currency.Nzd)]
    [InlineData(Currency.Pgk)]
    [InlineData(Currency.Php)]
    [InlineData(Currency.Pkr)]
    [InlineData(Currency.Pln)]
    [InlineData(Currency.Qar)]
    [InlineData(Currency.Ron)]
    [InlineData(Currency.Rsd)]
    [InlineData(Currency.Rub)]
    [InlineData(Currency.Rwf)]
    [InlineData(Currency.Sar)]
    [InlineData(Currency.Sbd)]
    [InlineData(Currency.Scr)]
    [InlineData(Currency.Sek)]
    [InlineData(Currency.Sgd)]
    [InlineData(Currency.Sle)]
    [InlineData(Currency.Sll)]
    [InlineData(Currency.Sos)]
    [InlineData(Currency.Szl)]
    [InlineData(Currency.Thb)]
    [InlineData(Currency.Tjs)]
    [InlineData(Currency.Top)]
    [InlineData(Currency.Try)]
    [InlineData(Currency.Ttd)]
    [InlineData(Currency.Tzs)]
    [InlineData(Currency.Uah)]
    [InlineData(Currency.Uzs)]
    [InlineData(Currency.Vnd)]
    [InlineData(Currency.Vuv)]
    [InlineData(Currency.Wst)]
    [InlineData(Currency.Xaf)]
    [InlineData(Currency.Xcd)]
    [InlineData(Currency.Yer)]
    [InlineData(Currency.Zar)]
    [InlineData(Currency.Zmw)]
    [InlineData(Currency.Clp)]
    [InlineData(Currency.Djf)]
    [InlineData(Currency.Gnf)]
    [InlineData(Currency.Ugx)]
    [InlineData(Currency.Pyg)]
    [InlineData(Currency.Xof)]
    [InlineData(Currency.Xpf)]
    public void SerializationRoundtrip_Works(Currency rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, Currency> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, Currency>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
