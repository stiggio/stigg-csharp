using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Core;
using Stigg.Models.V1;
using Stigg.Services.V1;

namespace Stigg.Services;

/// <inheritdoc/>
public sealed class V1Service : IV1Service
{
    readonly Lazy<IV1ServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1Service(this._client.WithOptions(modifier));
    }

    public V1Service(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new V1ServiceWithRawResponse(client.WithRawResponse));
        _customers = new(() => new CustomerService(client));
        _subscriptions = new(() => new SubscriptionService(client));
        _coupons = new(() => new CouponService(client));
    }

    readonly Lazy<ICustomerService> _customers;
    public ICustomerService Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<ISubscriptionService> _subscriptions;
    public ISubscriptionService Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    readonly Lazy<ICouponService> _coupons;
    public ICouponService Coupons
    {
        get { return _coupons.Value; }
    }

    /// <inheritdoc/>
    public async Task<V1CreateEventResponse> CreateEvent(
        V1CreateEventParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateEvent(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<V1CreateUsageResponse> CreateUsage(
        V1CreateUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class V1ServiceWithRawResponse : IV1ServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new V1ServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public V1ServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _customers = new(() => new CustomerServiceWithRawResponse(client));
        _subscriptions = new(() => new SubscriptionServiceWithRawResponse(client));
        _coupons = new(() => new CouponServiceWithRawResponse(client));
    }

    readonly Lazy<ICustomerServiceWithRawResponse> _customers;
    public ICustomerServiceWithRawResponse Customers
    {
        get { return _customers.Value; }
    }

    readonly Lazy<ISubscriptionServiceWithRawResponse> _subscriptions;
    public ISubscriptionServiceWithRawResponse Subscriptions
    {
        get { return _subscriptions.Value; }
    }

    readonly Lazy<ICouponServiceWithRawResponse> _coupons;
    public ICouponServiceWithRawResponse Coupons
    {
        get { return _coupons.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<V1CreateEventResponse>> CreateEvent(
        V1CreateEventParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1CreateEventParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<V1CreateEventResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<V1CreateUsageResponse>> CreateUsage(
        V1CreateUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<V1CreateUsageParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<V1CreateUsageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
