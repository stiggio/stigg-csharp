using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers.Entities.Entitlements;

namespace Stigg.Client.Services.V1.Customers.Entities;

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
    /// Returns a cursor-paginated list of entity entitlements for the given customer.
    /// An entity entitlement ties an entity to a feature or currency with a usage limit
    /// and reset cadence.
    /// </summary>
    Task<EntitlementListPage> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EntitlementListParams, CancellationToken)"/>
    Task<EntitlementListPage> List(
        string id,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Batched create-or-update of entity entitlements. Existing entity entitlements
    /// matched by (entityId, featureId or currencyId, scopeEntityIds) are updated; new
    /// ones are created. On update, omitted fields (usageLimit, cadence) are preserved;
    /// on create both are required.
    /// </summary>
    Task<EntitlementUpsertResponse> Upsert(
        EntitlementUpsertParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upsert(EntitlementUpsertParams, CancellationToken)"/>
    Task<EntitlementUpsertResponse> Upsert(
        string id,
        EntitlementUpsertParams parameters,
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
    /// Returns a raw HTTP response for <c>get /api/v1/customers/{id}/entities/entitlements</c>, but is otherwise the
    /// same as <see cref="IEntitlementService.List(EntitlementListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementListPage>> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EntitlementListParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementListPage>> List(
        string id,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/customers/{id}/entities/entitlements</c>, but is otherwise the
    /// same as <see cref="IEntitlementService.Upsert(EntitlementUpsertParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementUpsertResponse>> Upsert(
        EntitlementUpsertParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upsert(EntitlementUpsertParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementUpsertResponse>> Upsert(
        string id,
        EntitlementUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}
