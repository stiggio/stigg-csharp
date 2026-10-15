using System;
using Stigg.Client.Core;
using Stigg.Client.Services.V2;

namespace Stigg.Client.Services;

/// <inheritdoc/>
public sealed class V2Service : IV2Service
{
    readonly Lazy<IV2ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV2ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IV2Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V2Service(this._client.WithOptions(modifier));
    }

    public V2Service(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V2ServiceWithRawResponse(client.WithRawResponse));
        _usage = new(() => new UsageService(client));
    }

    readonly Lazy<IUsageService> _usage;
    public IUsageService Usage
    {
        get { return _usage.Value; }
    }
}

/// <inheritdoc/>
public sealed class V2ServiceWithRawResponse : IV2ServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV2ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V2ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V2ServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _usage = new(() => new UsageServiceWithRawResponse(client));
    }

    readonly Lazy<IUsageServiceWithRawResponse> _usage;
    public IUsageServiceWithRawResponse Usage
    {
        get { return _usage.Value; }
    }
}
