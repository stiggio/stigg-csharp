using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1Beta.Customers.Governance;

namespace Stigg.Client.Services.V1Beta.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IGovernanceService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGovernanceServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGovernanceService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Queries the customer's governance hierarchy tree, returning a cursor-paginated
    /// list of nodes with their usage configuration (limit, cadence, scope) and current
    /// usage, sortable and filterable by usage. Each node carries `parentId` so the
    /// tree can be rebuilt client-side. Usage is read from a periodically-refreshed
    /// read model and never gates access.
    /// </summary>
    Task<GovernanceListPage> List(
        GovernanceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(GovernanceListParams, CancellationToken)"/>
    Task<GovernanceListPage> List(
        string id,
        GovernanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGovernanceService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGovernanceServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGovernanceServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1-beta/customers/{id}/governance</c>, but is otherwise the
    /// same as <see cref="IGovernanceService.List(GovernanceListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GovernanceListPage>> List(
        GovernanceListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="List(GovernanceListParams, CancellationToken)"/>
    Task<HttpResponse<GovernanceListPage>> List(
        string id,
        GovernanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
