using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Stigg.Client.Models.V1.Credits.Consumption;

namespace Stigg.Client.Tests.Services.V1.Credits;

public class ConsumptionServiceTest : TestBase
{
    [Fact(Skip = "Mock server tests are disabled")]
    public async Task Consume_Works()
    {
        var response = await this.client.V1.Credits.Consumption.Consume(
            new()
            {
                Amount = 1,
                CurrencyID = "currencyId",
                CustomerID = "customerId",
                IdempotencyKey = "x",
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }

    [Fact(Skip = "Mock server tests are disabled")]
    public async Task ConsumeAsync_Works()
    {
        var response = await this.client.V1.Credits.Consumption.ConsumeAsync(
            new()
            {
                Consumptions =
                [
                    new()
                    {
                        Amount = 1,
                        CurrencyID = "currencyId",
                        CustomerID = "customerId",
                        IdempotencyKey = "x",
                        CreatedAt = DateTimeOffset.Parse("2019-12-27T18:11:19.117Z"),
                        Dimensions = new Dictionary<
                            string,
                            ConsumptionConsumeAsyncParamsConsumptionDimension
                        >()
                        {
                            { "foo", "string" },
                        },
                        ResourceID = "resourceId",
                    },
                ],
            },
            TestContext.Current.CancellationToken
        );
        response.Validate();
    }
}
