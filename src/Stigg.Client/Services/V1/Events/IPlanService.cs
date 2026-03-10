using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Plans;

namespace Stigg.Client.Services.V1.Events;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IPlanService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IPlanServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new plan in draft status.
    /// </summary>
    Task<PlanCreateResponse> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a plan by its unique identifier, including entitlements and pricing details.
    /// </summary>
    Task<PlanRetrieveResponse> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PlanRetrieveParams, CancellationToken)"/>
    Task<PlanRetrieveResponse> Retrieve(
        string id,
        PlanRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of plans in the environment.
    /// </summary>
    Task<PlanListPage> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IPlanService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IPlanServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IPlanServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/plans`, but is otherwise the
    /// same as <see cref="IPlanService.Create(PlanCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanCreateResponse>> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/plans/{id}`, but is otherwise the
    /// same as <see cref="IPlanService.Retrieve(PlanRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanRetrieveResponse>> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(PlanRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<PlanRetrieveResponse>> Retrieve(
        string id,
        PlanRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/plans`, but is otherwise the
    /// same as <see cref="IPlanService.List(PlanListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<PlanListPage>> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
