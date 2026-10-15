using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V2.Usage;

namespace Stigg.Client.Services.V2;

/// <summary>
/// Operations related to usage &amp; metering
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
    /// Reports usage measurements for metered features. The reported usage is used to
    /// track, limit, and bill customer consumption. Credit balances are returned once
    /// per wallet in `credits`, not on each measurement.
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
    /// Returns a raw HTTP response for <c>post /api/v2/usage</c>, but is otherwise the
    /// same as <see cref="IUsageService.Report(UsageReportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageReportResponse>> Report(
        UsageReportParams parameters,
        CancellationToken cancellationToken = default
    );
}
