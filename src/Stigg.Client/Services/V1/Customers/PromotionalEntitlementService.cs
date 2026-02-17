using System;
using Stigg.Client.Core;

namespace Stigg.Client.Services.V1.Customers;

/// <inheritdoc/>
public sealed class PromotionalEntitlementService : IPromotionalEntitlementService
{
    readonly Lazy<IPromotionalEntitlementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPromotionalEntitlementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IPromotionalEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PromotionalEntitlementService(this._client.WithOptions(modifier));
    }

    public PromotionalEntitlementService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PromotionalEntitlementServiceWithRawResponse(client.WithRawResponse)
        );
    }
}

/// <inheritdoc/>
public sealed class PromotionalEntitlementServiceWithRawResponse
    : IPromotionalEntitlementServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPromotionalEntitlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PromotionalEntitlementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PromotionalEntitlementServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }
}
