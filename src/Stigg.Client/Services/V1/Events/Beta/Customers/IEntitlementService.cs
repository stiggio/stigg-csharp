using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Beta.Customers.Entitlements;

namespace Stigg.Client.Services.V1.Events.Beta.Customers;

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
    /// Experimental — request and response shapes may change without notice. Same
    /// semantics as `Check entitlement`, plus an optional `dimensions` query param that
    /// resolves to per-entity governance limits surfaced as `chains` on the response.
    /// </summary>
    Task<EntitlementCheckResponse> Check(
        EntitlementCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Check(EntitlementCheckParams, CancellationToken)"/>
    Task<EntitlementCheckResponse> Check(
        string id,
        EntitlementCheckParams? parameters = null,
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
    /// Returns a raw HTTP response for <c>get /api/v1-beta/customers/{id}/entitlements/check</c>, but is otherwise the
    /// same as <see cref="IEntitlementService.Check(EntitlementCheckParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EntitlementCheckResponse>> Check(
        EntitlementCheckParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Check(EntitlementCheckParams, CancellationToken)"/>
    Task<HttpResponse<EntitlementCheckResponse>> Check(
        string id,
        EntitlementCheckParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
