using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Usage;

namespace Stigg.Client.Services.V1;

/// <summary>
/// Operations related to usage & metering
///
/// <para>NOTE: Do not inherit from this type outside the SDK unless you're okay with
/// breaking changes in non-major versions. We may add new methods in the future that
/// cause existing derived classes to break.</para>
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
    /// Retrieves historical usage data for a customer's metered feature over time.
    /// </summary>
    Task<UsageHistoryResponse> History(
        UsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="History(UsageHistoryParams, CancellationToken)"/>
    Task<UsageHistoryResponse> History(
        string featureID,
        UsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Reports usage measurements for metered features. The reported usage is used
    /// to track, limit, and bill customer consumption.
    /// </summary>
    Task<UsageReportResponse> Report(
        UsageReportParams parameters,
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
    /// Returns a raw HTTP response for `get /api/v1/usage/{customerId}/history/{featureId}`, but is otherwise the
    /// same as <see cref="IUsageService.History(UsageHistoryParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageHistoryResponse>> History(
        UsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="History(UsageHistoryParams, CancellationToken)"/>
    Task<HttpResponse<UsageHistoryResponse>> History(
        string featureID,
        UsageHistoryParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/usage`, but is otherwise the
    /// same as <see cref="IUsageService.Report(UsageReportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageReportResponse>> Report(
        UsageReportParams parameters,
        CancellationToken cancellationToken = default
    );
}
