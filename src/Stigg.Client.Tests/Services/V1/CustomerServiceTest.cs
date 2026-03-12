using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stigg.Client.Tests.Services.V1;

public class CustomerServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Retrieve_Works()
    {
        var customerResponse = await this.client.V1.Customers.Retrieve(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Update_Works()
    {
        var customerResponse = await this.client.V1.Customers.Update(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task List_Works()
    {
        var page = await this.client.V1.Customers.List(
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Archive_Works()
    {
        var customerResponse = await this.client.V1.Customers.Archive(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Import_Works()
    {
        var response = await this.client.V1.Customers.Import(
            new()
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
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ListResources_Works()
    {
        var page = await this.client.V1.Customers.ListResources(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        page.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Provision_Works()
    {
        var customerResponse = await this.client.V1.Customers.Provision(
            new() { ID = "id" },
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Unarchive_Works()
    {
        var customerResponse = await this.client.V1.Customers.Unarchive(
            "x",
            new(),
            TestContext.Current.CancellationToken
        );
        customerResponse.Validate();
    }
}
