using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Customers.Usage;

namespace Stigg.Client.Services.V1.Customers;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IUsageService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IUsageServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Perform retrieval on a Usage history
    /// </summary>
    Task<UsageRetrieveResponse> Retrieve(
        UsageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UsageRetrieveParams, CancellationToken)"/>
    Task<UsageRetrieveResponse> Retrieve(
        string featureID,
        UsageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IUsageService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IUsageServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IUsageServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/customers/{customerId}/usage/features/{featureId}`, but is otherwise the
    /// same as <see cref="IUsageService.Retrieve(UsageRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageRetrieveResponse>> Retrieve(
        UsageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(UsageRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<UsageRetrieveResponse>> Retrieve(
        string featureID,
        UsageRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );
}
