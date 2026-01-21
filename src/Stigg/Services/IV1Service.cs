using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Core;
using Stigg.Models.V1;
using Stigg.Services.V1;

namespace Stigg.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IV1Service
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IV1ServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1Service WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomerService Customers { get; }

    ISubscriptionService Subscriptions { get; }

    ICouponService Coupons { get; }

    /// <summary>
    /// Create events
    /// </summary>
    Task<V1CreateEventResponse> CreateEvent(
        V1CreateEventParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Create a new Usage
    /// </summary>
    Task<V1CreateUsageResponse> CreateUsage(
        V1CreateUsageParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IV1Service"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IV1ServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IV1ServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    ICustomerServiceWithRawResponse Customers { get; }

    ISubscriptionServiceWithRawResponse Subscriptions { get; }

    ICouponServiceWithRawResponse Coupons { get; }

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/events`, but is otherwise the
    /// same as <see cref="IV1Service.CreateEvent(V1CreateEventParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1CreateEventResponse>> CreateEvent(
        V1CreateEventParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/usage`, but is otherwise the
    /// same as <see cref="IV1Service.CreateUsage(V1CreateUsageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<V1CreateUsageResponse>> CreateUsage(
        V1CreateUsageParams parameters,
        CancellationToken cancellationToken = default
    );
}
