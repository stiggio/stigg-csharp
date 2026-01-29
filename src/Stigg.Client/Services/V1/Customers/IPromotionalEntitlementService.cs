using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Services.V1.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPromotionalEntitlementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPromotionalEntitlementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPromotionalEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Create a promotional entitlements
    /// </summary>
    Task<PromotionalEntitlementGrantResponse> Grant(
        PromotionalEntitlementGrantParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Grant(PromotionalEntitlementGrantParams, CancellationToken)"/>
    Task<PromotionalEntitlementGrantResponse> Grant(
        string customerID,
        PromotionalEntitlementGrantParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revoke promotional entitlement
    /// </summary>
    Task<PromotionalEntitlementRevokeResponse> Revoke(
        PromotionalEntitlementRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(PromotionalEntitlementRevokeParams, CancellationToken)"/>
    Task<PromotionalEntitlementRevokeResponse> Revoke(
        string featureID,
        PromotionalEntitlementRevokeParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPromotionalEntitlementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPromotionalEntitlementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPromotionalEntitlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/customers/{customerId}/promotional`, but is otherwise the
    /// same as <see cref="IPromotionalEntitlementService.Grant(PromotionalEntitlementGrantParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PromotionalEntitlementGrantResponse>> Grant(
        PromotionalEntitlementGrantParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Grant(PromotionalEntitlementGrantParams, CancellationToken)"/>
    Task<HttpResponse<PromotionalEntitlementGrantResponse>> Grant(
        string customerID,
        PromotionalEntitlementGrantParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/customers/{customerId}/promotional/{featureId}`, but is otherwise the
    /// same as <see cref="IPromotionalEntitlementService.Revoke(PromotionalEntitlementRevokeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PromotionalEntitlementRevokeResponse>> Revoke(
        PromotionalEntitlementRevokeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Revoke(PromotionalEntitlementRevokeParams, CancellationToken)"/>
    Task<HttpResponse<PromotionalEntitlementRevokeResponse>> Revoke(
        string featureID,
        PromotionalEntitlementRevokeParams parameters,
        CancellationToken cancellationToken = default
    );
}
