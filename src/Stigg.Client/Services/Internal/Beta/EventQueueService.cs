using System;
using Stigg.Client.Core;

namespace Stigg.Client.Services.Internal.Beta;

/// <inheritdoc/>
public sealed class EventQueueService : IEventQueueService
{
    readonly Lazy<IEventQueueServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEventQueueServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IEventQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EventQueueService(this._client.WithOptions(modifier));
    }

    public EventQueueService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EventQueueServiceWithRawResponse(client.WithRawResponse));
    }
}

/// <inheritdoc/>
public sealed class EventQueueServiceWithRawResponse : IEventQueueServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEventQueueServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EventQueueServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EventQueueServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }
}
