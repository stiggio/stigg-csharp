using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Plans;
using Stigg.Client.Models.V1.Events.Plans.Draft;

namespace Stigg.Client.Services.V1.Events.Plans;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDraftService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDraftServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a draft version of an existing plan for modification before publishing.
    /// </summary>
    Task<Plan> Create(DraftCreateParams parameters, CancellationToken cancellationToken = default);

    /// <inheritdoc cref="Create(DraftCreateParams, CancellationToken)"/>
    Task<Plan> Create(
        string id,
        DraftCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a draft version of a plan.
    /// </summary>
    Task<DraftRemoveResponse> Remove(
        DraftRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(DraftRemoveParams, CancellationToken)"/>
    Task<DraftRemoveResponse> Remove(
        string id,
        DraftRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDraftService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDraftServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/plans/{id}/draft`, but is otherwise the
    /// same as <see cref="IDraftService.Create(DraftCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<Plan>> Create(
        DraftCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Create(DraftCreateParams, CancellationToken)"/>
    Task<HttpResponse<Plan>> Create(
        string id,
        DraftCreateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/plans/{id}/draft`, but is otherwise the
    /// same as <see cref="IDraftService.Remove(DraftRemoveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DraftRemoveResponse>> Remove(
        DraftRemoveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Remove(DraftRemoveParams, CancellationToken)"/>
    Task<HttpResponse<DraftRemoveResponse>> Remove(
        string id,
        DraftRemoveParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
