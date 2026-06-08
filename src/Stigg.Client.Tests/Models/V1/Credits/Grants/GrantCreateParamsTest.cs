using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits.Grants;

namespace Stigg.Client.Tests.Models.V1.Credits.Grants;

public class GrantCreateParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new GrantCreateParams
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            DisplayName = "displayName",
            GrantType = GrantType.Paid,
            AwaitPaymentConfirmation = true,
            BillingInformation = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                InvoiceDaysUntilDue = 0,
                IsInvoicePaid = true,
            },
            Comment = "comment",
            Cost = new() { Amount = 0, Currency = Currency.Usd },
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            Priority = 0,
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        double expectedAmount = 0;
        string expectedCurrencyID = "currencyId";
        string expectedCustomerID = "customerId";
        string expectedDisplayName = "displayName";
        ApiEnum<string, GrantType> expectedGrantType = GrantType.Paid;
        bool expectedAwaitPaymentConfirmation = true;
        BillingInformation expectedBillingInformation = new()
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsInvoicePaid = true,
        };
        string expectedComment = "comment";
        Cost expectedCost = new() { Amount = 0, Currency = Currency.Usd };
        DateTimeOffset expectedEffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        DateTimeOffset expectedExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        ApiEnum<string, PaymentCollectionMethod> expectedPaymentCollectionMethod =
            PaymentCollectionMethod.Charge;
        long expectedPriority = 0;
        string expectedResourceID = "resourceId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedAmount, parameters.Amount);
        Assert.Equal(expectedCurrencyID, parameters.CurrencyID);
        Assert.Equal(expectedCustomerID, parameters.CustomerID);
        Assert.Equal(expectedDisplayName, parameters.DisplayName);
        Assert.Equal(expectedGrantType, parameters.GrantType);
        Assert.Equal(expectedAwaitPaymentConfirmation, parameters.AwaitPaymentConfirmation);
        Assert.Equal(expectedBillingInformation, parameters.BillingInformation);
        Assert.Equal(expectedComment, parameters.Comment);
        Assert.Equal(expectedCost, parameters.Cost);
        Assert.Equal(expectedEffectiveAt, parameters.EffectiveAt);
        Assert.Equal(expectedExpireAt, parameters.ExpireAt);
        Assert.NotNull(parameters.Metadata);
        Assert.Equal(expectedMetadata.Count, parameters.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(parameters.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, parameters.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentCollectionMethod, parameters.PaymentCollectionMethod);
        Assert.Equal(expectedPriority, parameters.Priority);
        Assert.Equal(expectedResourceID, parameters.ResourceID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new GrantCreateParams
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            DisplayName = "displayName",
            GrantType = GrantType.Paid,
        };

        Assert.Null(parameters.AwaitPaymentConfirmation);
        Assert.False(parameters.RawBodyData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(parameters.BillingInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("billingInformation"));
        Assert.Null(parameters.Comment);
        Assert.False(parameters.RawBodyData.ContainsKey("comment"));
        Assert.Null(parameters.Cost);
        Assert.False(parameters.RawBodyData.ContainsKey("cost"));
        Assert.Null(parameters.EffectiveAt);
        Assert.False(parameters.RawBodyData.ContainsKey("effectiveAt"));
        Assert.Null(parameters.ExpireAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expireAt"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentCollectionMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new GrantCreateParams
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            DisplayName = "displayName",
            GrantType = GrantType.Paid,

            // Null should be interpreted as omitted for these properties
            AwaitPaymentConfirmation = null,
            BillingInformation = null,
            Comment = null,
            Cost = null,
            EffectiveAt = null,
            ExpireAt = null,
            Metadata = null,
            PaymentCollectionMethod = null,
            Priority = null,
            ResourceID = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.AwaitPaymentConfirmation);
        Assert.False(parameters.RawBodyData.ContainsKey("awaitPaymentConfirmation"));
        Assert.Null(parameters.BillingInformation);
        Assert.False(parameters.RawBodyData.ContainsKey("billingInformation"));
        Assert.Null(parameters.Comment);
        Assert.False(parameters.RawBodyData.ContainsKey("comment"));
        Assert.Null(parameters.Cost);
        Assert.False(parameters.RawBodyData.ContainsKey("cost"));
        Assert.Null(parameters.EffectiveAt);
        Assert.False(parameters.RawBodyData.ContainsKey("effectiveAt"));
        Assert.Null(parameters.ExpireAt);
        Assert.False(parameters.RawBodyData.ContainsKey("expireAt"));
        Assert.Null(parameters.Metadata);
        Assert.False(parameters.RawBodyData.ContainsKey("metadata"));
        Assert.Null(parameters.PaymentCollectionMethod);
        Assert.False(parameters.RawBodyData.ContainsKey("paymentCollectionMethod"));
        Assert.Null(parameters.Priority);
        Assert.False(parameters.RawBodyData.ContainsKey("priority"));
        Assert.Null(parameters.ResourceID);
        Assert.False(parameters.RawBodyData.ContainsKey("resourceId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        GrantCreateParams parameters = new()
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            DisplayName = "displayName",
            GrantType = GrantType.Paid,
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(TestBase.UrisEqual(new Uri("https://api.stigg.io/api/v1/credits/grants"), url));
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        GrantCreateParams parameters = new()
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            DisplayName = "displayName",
            GrantType = GrantType.Paid,
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        parameters.AddHeadersToRequest(requestMessage, new() { ApiKey = "My API Key" });

        Assert.Equal(["X-ACCOUNT-ID"], requestMessage.Headers.GetValues("X-ACCOUNT-ID"));
        Assert.Equal(["X-ENVIRONMENT-ID"], requestMessage.Headers.GetValues("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new GrantCreateParams
        {
            Amount = 0,
            CurrencyID = "currencyId",
            CustomerID = "customerId",
            DisplayName = "displayName",
            GrantType = GrantType.Paid,
            AwaitPaymentConfirmation = true,
            BillingInformation = new()
            {
                BillingAddress = new()
                {
                    City = "city",
                    Country = "country",
                    Line1 = "line1",
                    Line2 = "line2",
                    PostalCode = "postalCode",
                    State = "state",
                },
                InvoiceDaysUntilDue = 0,
                IsInvoicePaid = true,
            },
            Comment = "comment",
            Cost = new() { Amount = 0, Currency = Currency.Usd },
            EffectiveAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            ExpireAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentCollectionMethod = PaymentCollectionMethod.Charge,
            Priority = 0,
            ResourceID = "resourceId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        GrantCreateParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class GrantTypeTest : TestBase
{
    [Theory]
    [InlineData(GrantType.Paid)]
    [InlineData(GrantType.Promotional)]
    public void Validation_Works(GrantType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantType> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(GrantType.Paid)]
    [InlineData(GrantType.Promotional)]
    public void SerializationRoundtrip_Works(GrantType rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, GrantType> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, GrantType>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, GrantType>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}

public class BillingInformationTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsInvoicePaid = true,
        };

        BillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        double expectedInvoiceDaysUntilDue = 0;
        bool expectedIsInvoicePaid = true;

        Assert.Equal(expectedBillingAddress, model.BillingAddress);
        Assert.Equal(expectedInvoiceDaysUntilDue, model.InvoiceDaysUntilDue);
        Assert.Equal(expectedIsInvoicePaid, model.IsInvoicePaid);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsInvoicePaid = true,
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingInformation>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsInvoicePaid = true,
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingInformation>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        BillingAddress expectedBillingAddress = new()
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };
        double expectedInvoiceDaysUntilDue = 0;
        bool expectedIsInvoicePaid = true;

        Assert.Equal(expectedBillingAddress, deserialized.BillingAddress);
        Assert.Equal(expectedInvoiceDaysUntilDue, deserialized.InvoiceDaysUntilDue);
        Assert.Equal(expectedIsInvoicePaid, deserialized.IsInvoicePaid);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsInvoicePaid = true,
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingInformation { };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.InvoiceDaysUntilDue);
        Assert.False(model.RawData.ContainsKey("invoiceDaysUntilDue"));
        Assert.Null(model.IsInvoicePaid);
        Assert.False(model.RawData.ContainsKey("isInvoicePaid"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingInformation { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BillingInformation
        {
            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            InvoiceDaysUntilDue = null,
            IsInvoicePaid = null,
        };

        Assert.Null(model.BillingAddress);
        Assert.False(model.RawData.ContainsKey("billingAddress"));
        Assert.Null(model.InvoiceDaysUntilDue);
        Assert.False(model.RawData.ContainsKey("invoiceDaysUntilDue"));
        Assert.Null(model.IsInvoicePaid);
        Assert.False(model.RawData.ContainsKey("isInvoicePaid"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingInformation
        {
            // Null should be interpreted as omitted for these properties
            BillingAddress = null,
            InvoiceDaysUntilDue = null,
            IsInvoicePaid = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingInformation
        {
            BillingAddress = new()
            {
                City = "city",
                Country = "country",
                Line1 = "line1",
                Line2 = "line2",
                PostalCode = "postalCode",
                State = "state",
            },
            InvoiceDaysUntilDue = 0,
            IsInvoicePaid = true,
        };

        BillingInformation copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class BillingAddressTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, model.City);
        Assert.Equal(expectedCountry, model.Country);
        Assert.Equal(expectedLine1, model.Line1);
        Assert.Equal(expectedLine2, model.Line2);
        Assert.Equal(expectedPostalCode, model.PostalCode);
        Assert.Equal(expectedState, model.State);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<BillingAddress>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedCity = "city";
        string expectedCountry = "country";
        string expectedLine1 = "line1";
        string expectedLine2 = "line2";
        string expectedPostalCode = "postalCode";
        string expectedState = "state";

        Assert.Equal(expectedCity, deserialized.City);
        Assert.Equal(expectedCountry, deserialized.Country);
        Assert.Equal(expectedLine1, deserialized.Line1);
        Assert.Equal(expectedLine2, deserialized.Line2);
        Assert.Equal(expectedPostalCode, deserialized.PostalCode);
        Assert.Equal(expectedState, deserialized.State);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new BillingAddress { };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new BillingAddress { };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new BillingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        Assert.Null(model.City);
        Assert.False(model.RawData.ContainsKey("city"));
        Assert.Null(model.Country);
        Assert.False(model.RawData.ContainsKey("country"));
        Assert.Null(model.Line1);
        Assert.False(model.RawData.ContainsKey("line1"));
        Assert.Null(model.Line2);
        Assert.False(model.RawData.ContainsKey("line2"));
        Assert.Null(model.PostalCode);
        Assert.False(model.RawData.ContainsKey("postalCode"));
        Assert.Null(model.State);
        Assert.False(model.RawData.ContainsKey("state"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new BillingAddress
        {
            // Null should be interpreted as omitted for these properties
            City = null,
            Country = null,
            Line1 = null,
            Line2 = null,
            PostalCode = null,
            State = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new BillingAddress
        {
            City = "city",
            Country = "country",
            Line1 = "line1",
            Line2 = "line2",
            PostalCode = "postalCode",
            State = "state",
        };

        BillingAddress copied = new(model);

        Assert.Equal(model, copied);
    }
}

public class CostTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Cost { Amount = 0, Currency = Currency.Usd };

        double expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;

        Assert.Equal(expectedAmount, model.Amount);
        Assert.Equal(expectedCurrency, model.Currency);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Cost { Amount = 0, Currency = Currency.Usd };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cost>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Cost { Amount = 0, Currency = Currency.Usd };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Cost>(element, ModelBase.SerializerOptions);
        Assert.NotNull(deserialized);

        double expectedAmount = 0;
        ApiEnum<string, Currency> expectedCurrency = Currency.Usd;

        Assert.Equal(expectedAmount, deserialized.Amount);
        Assert.Equal(expectedCurrency, deserialized.Currency);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Cost { Amount = 0, Currency = Currency.Usd };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Cost { Amount = 0, Currency = Currency.Usd };

        Cost copied = new(model);

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

public class PaymentCollectionMethodTest : TestBase
{
    [Theory]
    [InlineData(PaymentCollectionMethod.Charge)]
    [InlineData(PaymentCollectionMethod.Invoice)]
    [InlineData(PaymentCollectionMethod.None)]
    public void Validation_Works(PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollectionMethod> value = rawValue;
        value.Validate();
    }

    [Fact]
    public void InvalidEnumValidationThrows_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );

        Assert.NotNull(value);
        Assert.Throws<StiggInvalidDataException>(() => value.Validate());
    }

    [Theory]
    [InlineData(PaymentCollectionMethod.Charge)]
    [InlineData(PaymentCollectionMethod.Invoice)]
    [InlineData(PaymentCollectionMethod.None)]
    public void SerializationRoundtrip_Works(PaymentCollectionMethod rawValue)
    {
        // force implicit conversion because Theory can't do that for us
        ApiEnum<string, PaymentCollectionMethod> value = rawValue;

        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }

    [Fact]
    public void InvalidEnumSerializationRoundtrip_Works()
    {
        var value = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            JsonSerializer.SerializeToElement("invalid value"),
            ModelBase.SerializerOptions
        );
        string json = JsonSerializer.Serialize(value, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<ApiEnum<string, PaymentCollectionMethod>>(
            json,
            ModelBase.SerializerOptions
        );

        Assert.Equal(value, deserialized);
    }
}
