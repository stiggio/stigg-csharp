using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Core;
using Stigg.Models.V1.Customers.Promotional;

namespace Stigg.Services.V1.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPromotionalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPromotionalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPromotionalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a new Promotional Entitlements
    /// </summary>
    Task<PromotionalCreateResponse> Create(
        PromotionalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(PromotionalCreateParams, CancellationToken)"/>
    Task<PromotionalCreateResponse> Create(
        string customerID,
        PromotionalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Perform revocation on a Promotional Entitlement
    /// </summary>
    Task<PromotionalRevokeResponse> Revoke(
        PromotionalRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(PromotionalRevokeParams, CancellationToken)"/>
    Task<PromotionalRevokeResponse> Revoke(
        string featureID,
        PromotionalRevokeParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPromotionalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPromotionalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPromotionalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/customers/{customerId}/promotional`, but is otherwise the
    /// same as <see cref="IPromotionalService.Create(PromotionalCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PromotionalCreateResponse>> Create(
        PromotionalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(PromotionalCreateParams, CancellationToken)"/>
    Task<HttpResponse<PromotionalCreateResponse>> Create(
        string customerID,
        PromotionalCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/customers/{customerId}/promotional/featureId/{featureId}`, but is otherwise the
    /// same as <see cref="IPromotionalService.Revoke(PromotionalRevokeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PromotionalRevokeResponse>> Revoke(
        PromotionalRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(PromotionalRevokeParams, CancellationToken)"/>
    Task<HttpResponse<PromotionalRevokeResponse>> Revoke(
        string featureID,
        PromotionalRevokeParams parameters,
        CancellationToken cancellationToken = default
    );
}
