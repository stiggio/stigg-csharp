using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Customers.Assignments;

namespace Stigg.Client.Services.V1Beta.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAssignmentService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAssignmentServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAssignmentService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a cursor-paginated list of capability assignments for the given
    /// customer. An assignment ties an entity to a capability with a usage limit and
    /// reset cadence.
    /// </summary>
    Task<AssignmentListPage> List(
        AssignmentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(AssignmentListParams, CancellationToken)"/>
    Task<AssignmentListPage> List(
        string id,
        AssignmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Batched create-or-update of capability assignments. Existing assignments matched
    /// by (entityId, capabilityId) are updated; new pairs are created. On update,
    /// omitted fields (usageLimit, cadence) are preserved; on create both are required
    /// by the governance service.
    /// </summary>
    Task<AssignmentUpsertResponse> Upsert(
        AssignmentUpsertParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upsert(AssignmentUpsertParams, CancellationToken)"/>
    Task<AssignmentUpsertResponse> Upsert(
        string id,
        AssignmentUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAssignmentService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAssignmentServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAssignmentServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1-beta/customers/{id}/assignments</c>, but is otherwise the
    /// same as <see cref="IAssignmentService.List(AssignmentListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AssignmentListPage>> List(
        AssignmentListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(AssignmentListParams, CancellationToken)"/>
    Task<HttpResponse<AssignmentListPage>> List(
        string id,
        AssignmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>put /api/v1-beta/customers/{id}/assignments</c>, but is otherwise the
    /// same as <see cref="IAssignmentService.Upsert(AssignmentUpsertParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AssignmentUpsertResponse>> Upsert(
        AssignmentUpsertParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Upsert(AssignmentUpsertParams, CancellationToken)"/>
    Task<HttpResponse<AssignmentUpsertResponse>> Upsert(
        string id,
        AssignmentUpsertParams parameters,
        CancellationToken cancellationToken = default
    );
}
