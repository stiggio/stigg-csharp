using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.EntityTypes;

namespace Stigg.Client.Services.V1Beta;

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
    /// (e.g. Org, Team, User).
    /// </summary>
    Task<EntityTypeListPage> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Batched create-or-update of entity types. Existing types matched by id are
    /// updated; new ids are created. Idempotent — re-submitting the same payload
    /// converges to the same state.
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
    /// Returns a raw HTTP response for <c>get /api/v1-beta/entity-types</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.List(EntityTypeListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeListPage>> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1-beta/entity-types</c>, but is otherwise the
    /// same as <see cref="IEntityTypeService.Upsert(EntityTypeUpsertParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntityTypeUpsertResponse>> Upsert(
        EntityTypeUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}
