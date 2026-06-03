using System;
using Stigg.Client.Core;
using Stigg.Client.Services.V1Beta;

namespace Stigg.Client.Services;

/// <inheritdoc/>
public sealed class V1BetaService : IV1BetaService
{
    readonly Lazy<IV1BetaServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV1BetaServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IV1BetaService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1BetaService(this._client.WithOptions(modifier));
    }

    public V1BetaService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V1BetaServiceWithRawResponse(client.WithRawResponse));
        _customers = new(() => new CustomerService(client));
        _entityTypes = new(() => new EntityTypeService(client));
    }

    readonly Lazy<ICustomerService> _customers;
    public ICustomerService Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<IEntityTypeService> _entityTypes;
    public IEntityTypeService EntityTypes
    {
        get { return _entityTypes.Value; }
    }
}

/// <inheritdoc/>
public sealed class V1BetaServiceWithRawResponse : IV1BetaServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV1BetaServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1BetaServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V1BetaServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _customers = new(() => new CustomerServiceWithRawResponse(client));
        _entityTypes = new(() => new EntityTypeServiceWithRawResponse(client));
    }

    readonly Lazy<ICustomerServiceWithRawResponse> _customers;
    public ICustomerServiceWithRawResponse Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<IEntityTypeServiceWithRawResponse> _entityTypes;
    public IEntityTypeServiceWithRawResponse EntityTypes
    {
        get { return _entityTypes.Value; }
    }
}
