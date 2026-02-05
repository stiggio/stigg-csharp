using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICouponService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICouponServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICouponService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new discount coupon with percentage or fixed amount off, applicable
    /// to customer subscriptions.
    /// </summary>
    Task<Coupon> Create(
        CouponCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a coupon by its unique identifier.
    /// </summary>
    Task<Coupon> Retrieve(
        CouponRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CouponRetrieveParams, CancellationToken)"/>
    Task<Coupon> Retrieve(
        string id,
        CouponRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of coupons in the environment.
    /// </summary>
    Task<CouponListPage> List(
        CouponListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICouponService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICouponServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICouponServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/coupons`, but is otherwise the
    /// same as <see cref="ICouponService.Create(CouponCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Coupon>> Create(
        CouponCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/coupons/{id}`, but is otherwise the
    /// same as <see cref="ICouponService.Retrieve(CouponRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Coupon>> Retrieve(
        CouponRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(CouponRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<Coupon>> Retrieve(
        string id,
        CouponRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/coupons`, but is otherwise the
    /// same as <see cref="ICouponService.List(CouponListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CouponListPage>> List(
        CouponListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
