using System;
using Stigg.Client.Core;
using Beta = Stigg.Client.Services.V1.Events.Beta;

namespace Stigg.Client.Services.V1.Events;

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
        _customers = new(() => new Beta::CustomerService(client));
        _entityTypes = new(() => new Beta::EntityTypeService(client));
    }

    readonly Lazy<Beta::ICustomerService> _customers;
    public Beta::ICustomerService Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<Beta::IEntityTypeService> _entityTypes;
    public Beta::IEntityTypeService EntityTypes
    {
        get { return _entityTypes.Value; }
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

        _customers = new(() => new Beta::CustomerServiceWithRawResponse(client));
        _entityTypes = new(() => new Beta::EntityTypeServiceWithRawResponse(client));
    }

    readonly Lazy<Beta::ICustomerServiceWithRawResponse> _customers;
    public Beta::ICustomerServiceWithRawResponse Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<Beta::IEntityTypeServiceWithRawResponse> _entityTypes;
    public Beta::IEntityTypeServiceWithRawResponse EntityTypes
    {
        get { return _entityTypes.Value; }
    }
}
