using System;
using Stigg.Client.Core;
using Stigg.Client.Services.V1Beta.Customers;

namespace Stigg.Client.Services.V1Beta;

/// <inheritdoc/>
public sealed class CustomerService : ICustomerService
{
    readonly Lazy<ICustomerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerService(this._client.WithOptions(modifier));
    }

    public CustomerService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CustomerServiceWithRawResponse(client.WithRawResponse));
        _entitlements = new(() => new EntitlementService(client));
        _entities = new(() => new EntityService(client));
        _assignments = new(() => new AssignmentService(client));
    }

    readonly Lazy<IEntitlementService> _entitlements;
    public IEntitlementService Entitlements
    {
        get { return _entitlements.Value; }
    }

    readonly Lazy<IEntityService> _entities;
    public IEntityService Entities
    {
        get { return _entities.Value; }
    }

    readonly Lazy<IAssignmentService> _assignments;
    public IAssignmentService Assignments
    {
        get { return _assignments.Value; }
    }
}

/// <inheritdoc/>
public sealed class CustomerServiceWithRawResponse : ICustomerServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomerServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _entitlements = new(() => new EntitlementServiceWithRawResponse(client));
        _entities = new(() => new EntityServiceWithRawResponse(client));
        _assignments = new(() => new AssignmentServiceWithRawResponse(client));
    }

    readonly Lazy<IEntitlementServiceWithRawResponse> _entitlements;
    public IEntitlementServiceWithRawResponse Entitlements
    {
        get { return _entitlements.Value; }
    }

    readonly Lazy<IEntityServiceWithRawResponse> _entities;
    public IEntityServiceWithRawResponse Entities
    {
        get { return _entities.Value; }
    }

    readonly Lazy<IAssignmentServiceWithRawResponse> _assignments;
    public IAssignmentServiceWithRawResponse Assignments
    {
        get { return _assignments.Value; }
    }
}
