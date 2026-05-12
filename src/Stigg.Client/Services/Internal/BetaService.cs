using System;
using Stigg.Client.Core;
using Stigg.Client.Services.Internal.Beta;

namespace Stigg.Client.Services.Internal;

/// <inheritdoc/>
public sealed class BetaService : IBetaService
{
    readonly Lazy<IBetaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IBetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaService(this._client.WithOptions(modifier));
    }

    public BetaService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new BetaServiceWithRawResponse(client.WithRawResponse));
        _eventQueues = new(() => new EventQueueService(client));
    }

    readonly Lazy<IEventQueueService> _eventQueues;
    public IEventQueueService EventQueues
    {
        get { return _eventQueues.Value; }
    }
}

/// <inheritdoc/>
public sealed class BetaServiceWithRawResponse : IBetaServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IBetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new BetaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public BetaServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _eventQueues = new(() => new EventQueueServiceWithRawResponse(client));
    }

    readonly Lazy<IEventQueueServiceWithRawResponse> _eventQueues;
    public IEventQueueServiceWithRawResponse EventQueues
    {
        get { return _eventQueues.Value; }
    }
}
