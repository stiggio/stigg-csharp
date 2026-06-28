using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers;

namespace Stigg.Client.Tests.Models.V1.Customers;

public class CustomerImportParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerImportParams
        {
            Customers =
            [
                new()
                {
                    ID = "id",
                    Email = "dev@stainless.com",
                    Name = "name",
                    BillingID = "billingId",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    SalesforceID = "salesforceId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            IntegrationID = "integrationId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        List<Customer> expectedCustomers =
        [
            new()
            {
                ID = "id",
                Email = "dev@stainless.com",
                Name = "name",
                BillingID = "billingId",
                Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                PaymentMethodID = "paymentMethodId",
                SalesforceID = "salesforceId",
                UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
            },
        ];
        string expectedIntegrationID = "integrationId";
        string expectedXAccountID = "X-ACCOUNT-ID";
        string expectedXEnvironmentID = "X-ENVIRONMENT-ID";

        Assert.Equal(expectedCustomers.Count, parameters.Customers.Count);
        for (int i = 0; i < expectedCustomers.Count; i++)
        {
            Assert.Equal(expectedCustomers[i], parameters.Customers[i]);
        }
        Assert.Equal(expectedIntegrationID, parameters.IntegrationID);
        Assert.Equal(expectedXAccountID, parameters.XAccountID);
        Assert.Equal(expectedXEnvironmentID, parameters.XEnvironmentID);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerImportParams
        {
            Customers =
            [
                new()
                {
                    ID = "id",
                    Email = "dev@stainless.com",
                    Name = "name",
                    BillingID = "billingId",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    SalesforceID = "salesforceId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        Assert.Null(parameters.IntegrationID);
        Assert.False(parameters.RawBodyData.ContainsKey("integrationId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerImportParams
        {
            Customers =
            [
                new()
                {
                    ID = "id",
                    Email = "dev@stainless.com",
                    Name = "name",
                    BillingID = "billingId",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    SalesforceID = "salesforceId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],

            // Null should be interpreted as omitted for these properties
            IntegrationID = null,
            XAccountID = null,
            XEnvironmentID = null,
        };

        Assert.Null(parameters.IntegrationID);
        Assert.False(parameters.RawBodyData.ContainsKey("integrationId"));
        Assert.Null(parameters.XAccountID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ACCOUNT-ID"));
        Assert.Null(parameters.XEnvironmentID);
        Assert.False(parameters.RawHeaderData.ContainsKey("X-ENVIRONMENT-ID"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerImportParams parameters = new()
        {
            Customers =
            [
                new()
                {
                    ID = "id",
                    Email = "dev@stainless.com",
                    Name = "name",
                    BillingID = "billingId",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    SalesforceID = "salesforceId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.True(
            TestBase.UrisEqual(new Uri("https://edge.api.stigg.io/api/v1/customers/import"), url)
        );
    }

    [Fact]
    public void AddHeadersToRequest_Works()
    {
        HttpRequestMessage requestMessage = new();
        CustomerImportParams parameters = new()
        {
            Customers =
            [
                new()
                {
                    ID = "id",
                    Email = "dev@stainless.com",
                    Name = "name",
                    BillingID = "billingId",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    SalesforceID = "salesforceId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
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
        var parameters = new CustomerImportParams
        {
            Customers =
            [
                new()
                {
                    ID = "id",
                    Email = "dev@stainless.com",
                    Name = "name",
                    BillingID = "billingId",
                    Metadata = new Dictionary<string, string>() { { "foo", "string" } },
                    PaymentMethodID = "paymentMethodId",
                    SalesforceID = "salesforceId",
                    UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                },
            ],
            IntegrationID = "integrationId",
            XAccountID = "X-ACCOUNT-ID",
            XEnvironmentID = "X-ENVIRONMENT-ID",
        };

        CustomerImportParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}

public class CustomerTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",
            BillingID = "billingId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            SalesforceID = "salesforceId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string expectedID = "id";
        string expectedEmail = "dev@stainless.com";
        string expectedName = "name";
        string expectedBillingID = "billingId";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentMethodID = "paymentMethodId";
        string expectedSalesforceID = "salesforceId";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, model.ID);
        Assert.Equal(expectedEmail, model.Email);
        Assert.Equal(expectedName, model.Name);
        Assert.Equal(expectedBillingID, model.BillingID);
        Assert.NotNull(model.Metadata);
        Assert.Equal(expectedMetadata.Count, model.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(model.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, model.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentMethodID, model.PaymentMethodID);
        Assert.Equal(expectedSalesforceID, model.SalesforceID);
        Assert.Equal(expectedUpdatedAt, model.UpdatedAt);
    }

    [Fact]
    public void SerializationRoundtrip_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",
            BillingID = "billingId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            SalesforceID = "salesforceId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string json = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Customer>(json, ModelBase.SerializerOptions);

        Assert.Equal(model, deserialized);
    }

    [Fact]
    public void FieldRoundtripThroughSerialization_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",
            BillingID = "billingId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            SalesforceID = "salesforceId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        string element = JsonSerializer.Serialize(model, ModelBase.SerializerOptions);
        var deserialized = JsonSerializer.Deserialize<Customer>(
            element,
            ModelBase.SerializerOptions
        );
        Assert.NotNull(deserialized);

        string expectedID = "id";
        string expectedEmail = "dev@stainless.com";
        string expectedName = "name";
        string expectedBillingID = "billingId";
        Dictionary<string, string> expectedMetadata = new() { { "foo", "string" } };
        string expectedPaymentMethodID = "paymentMethodId";
        string expectedSalesforceID = "salesforceId";
        DateTimeOffset expectedUpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z");

        Assert.Equal(expectedID, deserialized.ID);
        Assert.Equal(expectedEmail, deserialized.Email);
        Assert.Equal(expectedName, deserialized.Name);
        Assert.Equal(expectedBillingID, deserialized.BillingID);
        Assert.NotNull(deserialized.Metadata);
        Assert.Equal(expectedMetadata.Count, deserialized.Metadata.Count);
        foreach (var item in expectedMetadata)
        {
            Assert.True(deserialized.Metadata.TryGetValue(item.Key, out var value));

            Assert.Equal(value, deserialized.Metadata[item.Key]);
        }
        Assert.Equal(expectedPaymentMethodID, deserialized.PaymentMethodID);
        Assert.Equal(expectedSalesforceID, deserialized.SalesforceID);
        Assert.Equal(expectedUpdatedAt, deserialized.UpdatedAt);
    }

    [Fact]
    public void Validation_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",
            BillingID = "billingId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            SalesforceID = "salesforceId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetAreNotSet_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",
        };

        Assert.Null(model.BillingID);
        Assert.False(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("paymentMethodId"));
        Assert.Null(model.SalesforceID);
        Assert.False(model.RawData.ContainsKey("salesforceId"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesUnsetValidation_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",
        };

        model.Validate();
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullAreNotSet_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            BillingID = null,
            Metadata = null,
            PaymentMethodID = null,
            SalesforceID = null,
            UpdatedAt = null,
        };

        Assert.Null(model.BillingID);
        Assert.False(model.RawData.ContainsKey("billingId"));
        Assert.Null(model.Metadata);
        Assert.False(model.RawData.ContainsKey("metadata"));
        Assert.Null(model.PaymentMethodID);
        Assert.False(model.RawData.ContainsKey("paymentMethodId"));
        Assert.Null(model.SalesforceID);
        Assert.False(model.RawData.ContainsKey("salesforceId"));
        Assert.Null(model.UpdatedAt);
        Assert.False(model.RawData.ContainsKey("updatedAt"));
    }

    [Fact]
    public void OptionalNonNullablePropertiesSetToNullValidation_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",

            // Null should be interpreted as omitted for these properties
            BillingID = null,
            Metadata = null,
            PaymentMethodID = null,
            SalesforceID = null,
            UpdatedAt = null,
        };

        model.Validate();
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var model = new Customer
        {
            ID = "id",
            Email = "dev@stainless.com",
            Name = "name",
            BillingID = "billingId",
            Metadata = new Dictionary<string, string>() { { "foo", "string" } },
            PaymentMethodID = "paymentMethodId",
            SalesforceID = "salesforceId",
            UpdatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
        };

        Customer copied = new(model);

        Assert.Equal(model, copied);
    }
}
