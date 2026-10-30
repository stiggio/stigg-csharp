using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Customers.Entities;

namespace Stigg.Client.Services.V1Beta.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEntityService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEntityServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves a single entity for the given customer by its identifier. Deprecated:
    /// use `GET /api/v1/customers/{id}/entities/{entityId}`.
    /// </summary>
    [Obsolete("Use `v1.customers.entities.retrieve` instead.")]
    Task<EntityRetrieveResponse> Retrieve(
        EntityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntityRetrieveParams, CancellationToken)"/>
    [Obsolete("Use `v1.customers.entities.retrieve` instead.")]
    Task<EntityRetrieveResponse> Retrieve(
        string entityID,
        EntityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of entities for the given customer. Deprecated: use
    /// `GET /api/v1/customers/{id}/entities`.
    /// </summary>
    [Obsolete("Use `v1.customers.entities.list` instead.")]
    Task<EntityListPage> List(
        EntityListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EntityListParams, CancellationToken)"/>
    [Obsolete("Use `v1.customers.entities.list` instead.")]
    Task<EntityListPage> List(
        string id,
        EntityListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives entities in bulk for the given customer by id. Upsert an archived
    /// entity to restore it. Deprecated: use `POST
    /// /api/v1/customers/{id}/entities/archive`.
    /// </summary>
    [Obsolete("Use `v1.customers.entities.archive` instead.")]
    Task<EntityArchiveResponse> Archive(
        EntityArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(EntityArchiveParams, CancellationToken)"/>
    [Obsolete("Use `v1.customers.entities.archive` instead.")]
    Task<EntityArchiveResponse> Archive(
        string id,
        EntityArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Deprecated: use `PUT /api/v1/customers/{id}/entities` with the entity id to
    /// restore it. Restores previously archived entities in bulk for the given customer
    /// by id.
    /// </summary>
    [Obsolete(
        "Use `v1.customers.entities.upsert` with the entity id to restore an archived entity."
    )]
    Task<EntityUnarchiveResponse> Unarchive(
        EntityUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(EntityUnarchiveParams, CancellationToken)"/>
    [Obsolete(
        "Use `v1.customers.entities.upsert` with the entity id to restore an archived entity."
    )]
    Task<EntityUnarchiveResponse> Unarchive(
        string id,
        EntityUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates or updates entities in bulk for the given customer. Existing entities
    /// matched by id are updated; new ids are created. An upsert of an archived entity
    /// restores it. An entity on an archived entity type fails with 400. Deprecated:
    /// use `PUT /api/v1/customers/{id}/entities`.
    /// </summary>
    [Obsolete("Use `v1.customers.entities.upsert` instead.")]
    Task<EntityUpsertResponse> Upsert(
        EntityUpsertParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upsert(EntityUpsertParams, CancellationToken)"/>
    [Obsolete("Use `v1.customers.entities.upsert` instead.")]
    Task<EntityUpsertResponse> Upsert(
        string id,
        EntityUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEntityService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEntityServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1-beta/customers/{id}/entities/{entityId}</c>, but is otherwise the
    /// same as <see cref="IEntityService.Retrieve(EntityRetrieveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Use `v1.customers.entities.retrieve` instead.")]
    Task<HttpResponse<EntityRetrieveResponse>> Retrieve(
        EntityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EntityRetrieveParams, CancellationToken)"/>
    [Obsolete("Use `v1.customers.entities.retrieve` instead.")]
    Task<HttpResponse<EntityRetrieveResponse>> Retrieve(
        string entityID,
        EntityRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1-beta/customers/{id}/entities</c>, but is otherwise the
    /// same as <see cref="IEntityService.List(EntityListParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Use `v1.customers.entities.list` instead.")]
    Task<HttpResponse<EntityListPage>> List(
        EntityListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(EntityListParams, CancellationToken)"/>
    [Obsolete("Use `v1.customers.entities.list` instead.")]
    Task<HttpResponse<EntityListPage>> List(
        string id,
        EntityListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1-beta/customers/{id}/entities/archive</c>, but is otherwise the
    /// same as <see cref="IEntityService.Archive(EntityArchiveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Use `v1.customers.entities.archive` instead.")]
    Task<HttpResponse<EntityArchiveResponse>> Archive(
        EntityArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Archive(EntityArchiveParams, CancellationToken)"/>
    [Obsolete("Use `v1.customers.entities.archive` instead.")]
    Task<HttpResponse<EntityArchiveResponse>> Archive(
        string id,
        EntityArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1-beta/customers/{id}/entities/unarchive</c>, but is otherwise the
    /// same as <see cref="IEntityService.Unarchive(EntityUnarchiveParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete(
        "Use `v1.customers.entities.upsert` with the entity id to restore an archived entity."
    )]
    Task<HttpResponse<EntityUnarchiveResponse>> Unarchive(
        EntityUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Unarchive(EntityUnarchiveParams, CancellationToken)"/>
    [Obsolete(
        "Use `v1.customers.entities.upsert` with the entity id to restore an archived entity."
    )]
    Task<HttpResponse<EntityUnarchiveResponse>> Unarchive(
        string id,
        EntityUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1-beta/customers/{id}/entities</c>, but is otherwise the
    /// same as <see cref="IEntityService.Upsert(EntityUpsertParams, CancellationToken)"/>.
    /// </summary>
    [Obsolete("Use `v1.customers.entities.upsert` instead.")]
    Task<HttpResponse<EntityUpsertResponse>> Upsert(
        EntityUpsertParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upsert(EntityUpsertParams, CancellationToken)"/>
    [Obsolete("Use `v1.customers.entities.upsert` instead.")]
    Task<HttpResponse<EntityUpsertResponse>> Upsert(
        string id,
        EntityUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}
