using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers.PromotionalEntitlements;

namespace Stigg.Client.Services.V1.Customers;

/// <summary>
/// Operations related to promotional entitlements
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Grants promotional entitlements to a customer, providing feature access outside
    /// their subscription. Entitlements can be time-limited or permanent.
    /// </summary>
    Task<PromotionalEntitlementCreateResponse> Create(
        PromotionalEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(PromotionalEntitlementCreateParams, CancellationToken)"/>
    Task<PromotionalEntitlementCreateResponse> Create(
        string id,
        PromotionalEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of a customer's promotional entitlements.
    /// </summary>
    Task<PromotionalEntitlementListPage> List(
        PromotionalEntitlementListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(PromotionalEntitlementListParams, CancellationToken)"/>
    Task<PromotionalEntitlementListPage> List(
        string id,
        PromotionalEntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Revokes a previously granted promotional entitlement from a customer for
    /// a specific feature.
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
    /// Returns a raw HTTP response for `post /api/v1/customers/{id}/promotional-entitlements`, but is otherwise the
    /// same as <see cref="IPromotionalEntitlementService.Create(PromotionalEntitlementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PromotionalEntitlementCreateResponse>> Create(
        PromotionalEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(PromotionalEntitlementCreateParams, CancellationToken)"/>
    Task<HttpResponse<PromotionalEntitlementCreateResponse>> Create(
        string id,
        PromotionalEntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/customers/{id}/promotional-entitlements`, but is otherwise the
    /// same as <see cref="IPromotionalEntitlementService.List(PromotionalEntitlementListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PromotionalEntitlementListPage>> List(
        PromotionalEntitlementListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(PromotionalEntitlementListParams, CancellationToken)"/>
    Task<HttpResponse<PromotionalEntitlementListPage>> List(
        string id,
        PromotionalEntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/customers/{id}/promotional-entitlements/{featureId}`, but is otherwise the
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
