using System;
using Stigg.Client.Core;
using Stigg.Client.Services.V1;

namespace Stigg.Client.Services;

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
        _events = new(() => new EventService(client));
        _usage = new(() => new UsageService(client));
        _products = new(() => new ProductService(client));
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

    readonly Lazy<IEventService> _events;
    public IEventService Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IUsageService> _usage;
    public IUsageService Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<IProductService> _products;
    public IProductService Products
    {
        get { return _products.Value; }
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
        _events = new(() => new EventServiceWithRawResponse(client));
        _usage = new(() => new UsageServiceWithRawResponse(client));
        _products = new(() => new ProductServiceWithRawResponse(client));
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

    readonly Lazy<IEventServiceWithRawResponse> _events;
    public IEventServiceWithRawResponse Events
    {
        get { return _events.Value; }
    }

    readonly Lazy<IUsageServiceWithRawResponse> _usage;
    public IUsageServiceWithRawResponse Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<IProductServiceWithRawResponse> _products;
    public IProductServiceWithRawResponse Products
    {
        get { return _products.Value; }
    }
}
