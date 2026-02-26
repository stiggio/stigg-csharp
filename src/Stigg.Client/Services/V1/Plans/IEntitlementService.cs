using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Plans.Entitlements;

namespace Stigg.Client.Services.V1.Plans;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEntitlementService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEntitlementServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates one or more entitlements (feature or credit) on a draft plan.
    /// </summary>
    Task<EntitlementCreateResponse> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(EntitlementCreateParams, CancellationToken)"/>
    Task<EntitlementCreateResponse> Create(
        string planID,
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing entitlement on a draft plan.
    /// </summary>
    Task<PlanEntitlement> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntitlementUpdateParams, CancellationToken)"/>
    Task<PlanEntitlement> Update(
        string id,
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of entitlements for a plan.
    /// </summary>
    Task<EntitlementListResponse> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EntitlementListParams, CancellationToken)"/>
    Task<EntitlementListResponse> List(
        string planID,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an entitlement from a draft plan.
    /// </summary>
    Task<PlanEntitlement> Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EntitlementDeleteParams, CancellationToken)"/>
    Task<PlanEntitlement> Delete(
        string id,
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEntitlementService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEntitlementServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntitlementServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/plans/{planId}/entitlements`, but is otherwise the
    /// same as <see cref="IEntitlementService.Create(EntitlementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementCreateResponse>> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(EntitlementCreateParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementCreateResponse>> Create(
        string planID,
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /api/v1/plans/{planId}/entitlements/{id}`, but is otherwise the
    /// same as <see cref="IEntitlementService.Update(EntitlementUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanEntitlement>> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntitlementUpdateParams, CancellationToken)"/>
    Task<HttpResponse<PlanEntitlement>> Update(
        string id,
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/plans/{planId}/entitlements`, but is otherwise the
    /// same as <see cref="IEntitlementService.List(EntitlementListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementListResponse>> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EntitlementListParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementListResponse>> List(
        string planID,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/plans/{planId}/entitlements/{id}`, but is otherwise the
    /// same as <see cref="IEntitlementService.Delete(EntitlementDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanEntitlement>> Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EntitlementDeleteParams, CancellationToken)"/>
    Task<HttpResponse<PlanEntitlement>> Delete(
        string id,
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
