using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Addons.Entitlements;

namespace Stigg.Client.Services.V1.Events.Addons;

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
    /// Creates one or more entitlements (feature or credit) on a draft addon.
    /// </summary>
    Task<EntitlementCreateResponse> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(EntitlementCreateParams, CancellationToken)"/>
    Task<EntitlementCreateResponse> Create(
        string addonID,
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing entitlement on a draft addon.
    /// </summary>
    Task<AddonPackageEntitlement> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntitlementUpdateParams, CancellationToken)"/>
    Task<AddonPackageEntitlement> Update(
        string id,
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a list of entitlements for an addon.
    /// </summary>
    Task<EntitlementListResponse> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EntitlementListParams, CancellationToken)"/>
    Task<EntitlementListResponse> List(
        string addonID,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deletes an entitlement from a draft addon.
    /// </summary>
    Task<AddonPackageEntitlement> Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EntitlementDeleteParams, CancellationToken)"/>
    Task<AddonPackageEntitlement> Delete(
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
    /// Returns a raw HTTP response for `post /api/v1/addons/{addonId}/entitlements`, but is otherwise the
    /// same as <see cref="IEntitlementService.Create(EntitlementCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementCreateResponse>> Create(
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(EntitlementCreateParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementCreateResponse>> Create(
        string addonID,
        EntitlementCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /api/v1/addons/{addonId}/entitlements/{id}`, but is otherwise the
    /// same as <see cref="IEntitlementService.Update(EntitlementUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonPackageEntitlement>> Update(
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EntitlementUpdateParams, CancellationToken)"/>
    Task<HttpResponse<AddonPackageEntitlement>> Update(
        string id,
        EntitlementUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/addons/{addonId}/entitlements`, but is otherwise the
    /// same as <see cref="IEntitlementService.List(EntitlementListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementListResponse>> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EntitlementListParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementListResponse>> List(
        string addonID,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/addons/{addonId}/entitlements/{id}`, but is otherwise the
    /// same as <see cref="IEntitlementService.Delete(EntitlementDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AddonPackageEntitlement>> Delete(
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EntitlementDeleteParams, CancellationToken)"/>
    Task<HttpResponse<AddonPackageEntitlement>> Delete(
        string id,
        EntitlementDeleteParams parameters,
        CancellationToken cancellationToken = default
    );
}
