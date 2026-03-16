# Stigg C# API Library

The Stigg C# SDK provides convenient access to the Stigg REST API from applications written in C#.

It is generated with [Stainless](https://www.stainless.com/).

## Installation

Install the package from [NuGet](https://www.nuget.org/packages/Stigg.Client):

```bash
dotnet add package Stigg.Client
```

## Requirements

This library requires .NET Standard 2.0 or later.

## Usage

See the [`examples`](examples) directory for complete and runnable examples.

```csharp
using System;
using Stigg.Client;
using Stigg.Client.Models.V1.Customers;

StiggClient client = new();

CustomerRetrieveParams parameters = new() { ID = "REPLACE_ME" };

var customerResponse = await client.V1.Customers.Retrieve(parameters);

Console.WriteLine(customerResponse);
```

## Client configuration

Configure the client using environment variables:

```csharp
using Stigg.Client;

// Configured using the STIGG_API_KEY and STIGG_BASE_URL environment variables
StiggClient client = new();
```

Or manually:

```csharp
using Stigg.Client;

StiggClient client = new() { ApiKey = "My API Key" };
```

Or using a combination of the two approaches.

See this table for the available options:

| Property  | Environment variable | Required | Default value            |
| --------- | -------------------- | -------- | ------------------------ |
| `ApiKey`  | `STIGG_API_KEY`      | true     | -                        |
| `BaseUrl` | `STIGG_BASE_URL`     | true     | `"https://api.stigg.io"` |

### Modifying configuration

To temporarily use a modified client configuration, while reusing the same connection and thread pools, call `WithOptions` on any client or service:

```csharp
using System;

var customerResponse = await client
    .WithOptions(options =>
        options with
        {
            BaseUrl = "https://example.com",
            Timeout = TimeSpan.FromSeconds(42),
        }
    )
    .V1.Customers.Retrieve(parameters);

Console.WriteLine(customerResponse);
```

Using a [`with` expression](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/operators/with-expression) makes it easy to construct the modified options.

The `WithOptions` method does not affect the original client or service.

## Requests and responses

To send a request to the Stigg API, build an instance of some `Params` class and pass it to the corresponding client method. When the response is received, it will be deserialized into an instance of a C# class.

For example, `client.V1.Customers.Retrieve` should be called with an instance of `CustomerRetrieveParams`, and it will return an instance of `Task<CustomerResponse>`.

## Raw responses

The SDK defines methods that deserialize responses into instances of C# classes. However, these methods don't provide access to the response headers, status code, or the raw response body.

To access this data, prefix any HTTP method call on a client or service with `WithRawResponse`:

```csharp
var response = await client.WithRawResponse.V1.Customers.Retrieve(parameters);
var statusCode = response.StatusCode;
var headers = response.Headers;
```

The raw `HttpResponseMessage` can also be accessed through the `RawMessage` property.

For non-streaming responses, you can deserialize the response into an instance of a C# class if needed:

```csharp
using System;
using Stigg.Client.Models.V1.Customers;

var response = await client.WithRawResponse.V1.Customers.Retrieve(parameters);
CustomerResponse deserialized = await response.Deserialize();
Console.WriteLine(deserialized);
```

## Error handling

The SDK throws custom unchecked exception types:

- `StiggApiException`: Base class for API errors. See this table for which exception subclass is thrown for each HTTP status code:

| Status | Exception                            |
| ------ | ------------------------------------ |
| 400    | `StiggBadRequestException`           |
| 401    | `StiggUnauthorizedException`         |
| 403    | `StiggForbiddenException`            |
| 404    | `StiggNotFoundException`             |
| 422    | `StiggUnprocessableEntityException`  |
| 429    | `StiggRateLimitException`            |
| 5xx    | `Stigg5xxException`                  |
| others | `StiggUnexpectedStatusCodeException` |

Additionally, all 4xx errors inherit from `Stigg4xxException`.

- `StiggIOException`: I/O networking errors.

- `StiggInvalidDataException`: Failure to interpret successfully parsed data. For example, when accessing a property that's supposed to be required, but the API unexpectedly omitted it from the response.

- `StiggException`: Base class for all exceptions.

## Pagination

The SDK defines methods that return a paginated lists of results. It provides convenient ways to access the results either one page at a time or item-by-item across all pages.

### Auto-pagination

To iterate through all results across all pages, use the `Paginate` method, which automatically fetches more pages as needed. The method returns an [`IAsyncEnumerable`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.iasyncenumerable-1):

```csharp
using System;

var page = await client.V1.Customers.List(parameters);
await foreach (var item in page.Paginate())
{
    Console.WriteLine(item);
}
```

### Manual pagination

To access individual page items and manually request the next page, use the `Items` property, and `HasNext` and `Next` methods:

```csharp
using System;

var page = await client.V1.Customers.List();
while (true)
{
    foreach (var item in page.Items)
    {
        Console.WriteLine(item);
    }
    if (!page.HasNext())
    {
        break;
    }
    page = await page.Next();
}
```

## Network options

### Retries

The SDK automatically retries 2 times by default, with a short exponential backoff between requests.

Only the following error types are retried:

- Connection errors (for example, due to a network connectivity problem)
- 408 Request Timeout
- 409 Conflict
- 429 Rate Limit
- 5xx Internal

The API may also explicitly instruct the SDK to retry or not retry a request.

To set a custom number of retries, configure the client using the `MaxRetries` method:

```csharp
using Stigg.Client;

StiggClient client = new() { MaxRetries = 3 };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var customerResponse = await client
    .WithOptions(options =>
        options with { MaxRetries = 3 }
    )
    .V1.Customers.Retrieve(parameters);

Console.WriteLine(customerResponse);
```

### Timeouts

Requests time out after 1 minute by default.

To set a custom timeout, configure the client using the `Timeout` option:

```csharp
using System;
using Stigg.Client;

StiggClient client = new() { Timeout = TimeSpan.FromSeconds(42) };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var customerResponse = await client
    .WithOptions(options =>
        options with { Timeout = TimeSpan.FromSeconds(42) }
    )
    .V1.Customers.Retrieve(parameters);

Console.WriteLine(customerResponse);
```

### Proxies

To route requests through a proxy, configure your client with a custom [`HttpClient`](https://learn.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=net-10.0):

```csharp
using System.Net;
using System.Net.Http;
using Stigg.Client;

var httpClient = new HttpClient
(
    new HttpClientHandler
    {
        Proxy = new WebProxy("https://example.com:8080")
    }
);

StiggClient client = new() { HttpClient = httpClient };
```

## Undocumented API functionality

The SDK is typed for convenient usage of the documented API. However, it also supports working with undocumented or not yet supported parts of the API.

### Parameters

To set undocumented parameters, a constructor exists that accepts dictionaries for additional header, query, and body values. If the method type doesn't support request bodies (e.g. `GET` requests), the constructor will only accept a header and query dictionary.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Models.V1.Customers;

CustomerRetrieveParams parameters = new
(
    rawHeaderData: new Dictionary<string, JsonElement>()
    {
        { "Custom-Header", JsonSerializer.SerializeToElement(42) }
    },

    rawQueryData: new Dictionary<string, JsonElement>()
    {
        { "custom_query_param", JsonSerializer.SerializeToElement(42) }
    }
)
{
    // Documented properties can still be added here.
    // In case of conflict, these parameters take precedence over the custom parameters.
    ID = "x"
};
```

The raw parameters can also be accessed through the `RawHeaderData`, `RawQueryData`, and `RawBodyData` (if available) properties.

This can also be used to set a documented parameter to an undocumented or not yet supported _value_, as long as the parameter is optional. If the parameter is required, omitting its `init` property will result in a compile-time error. To work around this, the `FromRawUnchecked` method can be used:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Models.V1.Customers;

var parameters = CustomerImportParams.FromRawUnchecked
(

    rawHeaderData: new Dictionary<string, JsonElement>(),
    rawQueryData: new Dictionary<string, JsonElement>(),
    rawBodyData: new Dictionary<string, JsonElement>
    {
        {
            "customers",
            JsonSerializer.SerializeToElement("custom value")
        }
    }
);
```

### Nested Parameters

Undocumented properties, or undocumented values of documented properties, on nested parameters can be set similarly, using a dictionary in the constructor of the nested parameter.

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Models.V1.Customers;

CustomerUpdateParams parameters = new()
{
    Passthrough = new
    (
        new Dictionary<string, JsonElement>
        {
            { "custom_nested_param", JsonSerializer.SerializeToElement(42) }
        }
    )
};
```

Required properties on the nested parameter can also be changed or omitted using the `FromRawUnchecked` method:

```csharp
using System.Collections.Generic;
using System.Text.Json;
using Stigg.Client.Models.V1.Customers;

CustomerUpdateParams parameters = new()
{
    Passthrough = Passthrough.FromRawUnchecked
    (
        new Dictionary<string, JsonElement>
        {
            { "required_property", JsonSerializer.SerializeToElement("custom value") }
        }
    )
};
```

### Response properties

To access undocumented response properties, the `RawData` property can be used:

```csharp
using System.Text.Json;

var response = client.V1.Customers.Retrieve(parameters)
if (response.RawData.TryGetValue("my_custom_key", out JsonElement value))
{
    // Do something with `value`
}
```

`RawData` is a `IReadonlyDictionary<string, JsonElement>`. It holds the full data received from the API server.

### Response validation

In rare cases, the API may return a response that doesn't match the expected type. For example, the SDK may expect a property to contain a `string`, but the API could return something else.

By default, the SDK will not throw an exception in this case. It will throw `StiggInvalidDataException` only if you directly access the property.

If you would prefer to check that the response is completely well-typed upfront, then either call `Validate`:

```csharp
var customerResponse = client.V1.Customers.Retrieve(parameters);
customerResponse.Validate();
```

Or configure the client using the `ResponseValidation` option:

```csharp
using Stigg.Client;

StiggClient client = new() { ResponseValidation = true };
```

Or configure a single method call using [`WithOptions`](#modifying-configuration):

```csharp
using System;

var customerResponse = await client
    .WithOptions(options =>
        options with { ResponseValidation = true }
    )
    .V1.Customers.Retrieve(parameters);

Console.WriteLine(customerResponse);
```

## Semantic versioning

This package generally follows [SemVer](https://semver.org/spec/v2.0.0.html) conventions, though certain backwards-incompatible changes may be released as minor versions:

1. Changes to library internals which are technically public but not intended or documented for external use. _(Please open a GitHub issue to let us know if you are relying on such internals.)_
2. Changes that we do not expect to impact the vast majority of users in practice.

We take backwards-compatibility seriously and work hard to ensure you can rely on a smooth upgrade experience.

We are keen for your feedback; please open an [issue](https://www.github.com/stiggio/stigg-csharp/issues) with questions, bugs, or suggestions.
