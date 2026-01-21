using System;
using Stigg.Models.V1.Customers;

namespace Stigg.Tests.Models.V1.Customers;

public class CustomerListParamsTest : TestBase
{
    [Fact]
    public void FieldRoundtrip_Works()
    {
        var parameters = new CustomerListParams
        {
            EndingBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            StartingAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        string expectedEndingBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";
        long expectedLimit = 1;
        string expectedStartingAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e";

        Assert.Equal(expectedEndingBefore, parameters.EndingBefore);
        Assert.Equal(expectedLimit, parameters.Limit);
        Assert.Equal(expectedStartingAfter, parameters.StartingAfter);
    }

    [Fact]
    public void OptionalNonNullableParamsUnsetAreNotSet_Works()
    {
        var parameters = new CustomerListParams { };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
    }

    [Fact]
    public void OptionalNonNullableParamsSetToNullAreNotSet_Works()
    {
        var parameters = new CustomerListParams
        {
            // Null should be interpreted as omitted for these properties
            EndingBefore = null,
            Limit = null,
            StartingAfter = null,
        };

        Assert.Null(parameters.EndingBefore);
        Assert.False(parameters.RawQueryData.ContainsKey("endingBefore"));
        Assert.Null(parameters.Limit);
        Assert.False(parameters.RawQueryData.ContainsKey("limit"));
        Assert.Null(parameters.StartingAfter);
        Assert.False(parameters.RawQueryData.ContainsKey("startingAfter"));
    }

    [Fact]
    public void Url_Works()
    {
        CustomerListParams parameters = new()
        {
            EndingBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            StartingAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        var url = parameters.Url(new() { ApiKey = "My API Key" });

        Assert.Equal(
            new Uri(
                "https://api.example.com/api/v1/customers?endingBefore=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e&limit=1&startingAfter=182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e"
            ),
            url
        );
    }

    [Fact]
    public void CopyConstructor_Works()
    {
        var parameters = new CustomerListParams
        {
            EndingBefore = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
            Limit = 1,
            StartingAfter = "182bd5e5-6e1a-4fe4-a799-aa6d9a6ab26e",
        };

        CustomerListParams copied = new(parameters);

        Assert.Equal(parameters, copied);
    }
}
