using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.EntityTypes;

namespace Stigg.Client.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEntityTypeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEntityTypeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a cursor-paginated list of entity types defined in the environment.
    /// Entity types are vendor-defined categories of resource that can be governed
    /// (e.g. Org, Team, User). Archived entity types are excluded unless
    /// includeArchived=true.
    /// </summary>
    Task<EntityTypeListPage> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Archives entity types in bulk by id. An entity type with active entities cannot
    /// be archived: archive its entities first, or the whole request fails with 400.
    /// </summary>
    Task<EntityTypeArchiveResponse> Archive(
        EntityTypeArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns whether any active entity of this entity type exists, across every
    /// customer. An entity type can be archived only when this is false. An unknown
    /// entity type returns false.
    /// </summary>
    Task<EntityTypeCheckActiveEntitiesResponse> CheckActiveEntities(
        EntityTypeCheckActiveEntitiesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CheckActiveEntities(EntityTypeCheckActiveEntitiesParams, CancellationToken)"/>
    Task<EntityTypeCheckActiveEntitiesResponse> CheckActiveEntities(
        string id,
        EntityTypeCheckActiveEntitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Batched create-or-update of entity types. Existing types matched by id are
    /// updated; new ids are created. Idempotent — re-submitting the same payload
    /// converges to the same state. An upsert of an archived entity type restores it.
    /// </summary>
    Task<EntityTypeUpsertResponse> Upsert(
        EntityTypeUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEntityTypeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEntityTypeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEntityTypeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/entity-types</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.List(EntityTypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeListPage>> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/entity-types/archive</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.Archive(EntityTypeArchiveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeArchiveResponse>> Archive(
        EntityTypeArchiveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/entity-types/{id}/has-active-entities</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.CheckActiveEntities(EntityTypeCheckActiveEntitiesParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeCheckActiveEntitiesResponse>> CheckActiveEntities(
        EntityTypeCheckActiveEntitiesParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CheckActiveEntities(EntityTypeCheckActiveEntitiesParams, CancellationToken)"/>
    Task<HttpResponse<EntityTypeCheckActiveEntitiesResponse>> CheckActiveEntities(
        string id,
        EntityTypeCheckActiveEntitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1/entity-types</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.Upsert(EntityTypeUpsertParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeUpsertResponse>> Upsert(
        EntityTypeUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}
