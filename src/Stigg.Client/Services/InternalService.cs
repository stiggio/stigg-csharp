using System;
using Stigg.Client.Core;
using Stigg.Client.Services.Internal;

namespace Stigg.Client.Services;

/// <inheritdoc/>
public sealed class InternalService : IInternalService
{
    readonly Lazy<IInternalServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IInternalServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IInternalService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InternalService(this._client.WithOptions(modifier));
    }

    public InternalService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new InternalServiceWithRawResponse(client.WithRawResponse));
        _beta = new(() => new BetaService(client));
    }

    readonly Lazy<IBetaService> _beta;
    public IBetaService Beta
    {
        get { return _beta.Value; }
    }
}

/// <inheritdoc/>
public sealed class InternalServiceWithRawResponse : IInternalServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IInternalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new InternalServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public InternalServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _beta = new(() => new BetaServiceWithRawResponse(client));
    }

    readonly Lazy<IBetaServiceWithRawResponse> _beta;
    public IBetaServiceWithRawResponse Beta
    {
        get { return _beta.Value; }
    }
}
