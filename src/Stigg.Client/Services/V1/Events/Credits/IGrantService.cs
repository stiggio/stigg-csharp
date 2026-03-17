using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Credits.Grants;

namespace Stigg.Client.Services.V1.Events.Credits;

/// <summary>
/// Operations related to credit grants
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
/// </summary>
public interface IGrantService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IGrantServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGrantService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a new credit grant for a customer with specified amount, type, and
    /// optional billing configuration.
    /// </summary>
    Task<CreditGrantResponse> Create(
        GrantCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of credit grants for a customer.
    /// </summary>
    Task<GrantListPage> List(
        GrantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Voids an existing credit grant, preventing further consumption of the remaining
    /// credits.
    /// </summary>
    Task<CreditGrantResponse> Void(
        GrantVoidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Void(GrantVoidParams, CancellationToken)"/>
    Task<CreditGrantResponse> Void(
        string id,
        GrantVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IGrantService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IGrantServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IGrantServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/credits/grants</c>, but is otherwise the
    /// same as <see cref="IGrantService.Create(GrantCreateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditGrantResponse>> Create(
        GrantCreateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/credits/grants</c>, but is otherwise the
    /// same as <see cref="IGrantService.List(GrantListParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<GrantListPage>> List(
        GrantListParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/credits/grants/{id}/void</c>, but is otherwise the
    /// same as <see cref="IGrantService.Void(GrantVoidParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditGrantResponse>> Void(
        GrantVoidParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Void(GrantVoidParams, CancellationToken)"/>
    Task<HttpResponse<CreditGrantResponse>> Void(
        string id,
        GrantVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
