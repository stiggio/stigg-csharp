using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events;

namespace Stigg.Client.Services.V1;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEventService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Reports raw usage events for event-based metering. Events are ingested asynchronously
    /// and aggregated into usage totals.
    /// </summary>
    Task<EventReportResponse> Report(
        EventReportParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/events`, but is otherwise the
    /// same as <see cref="IEventService.Report(EventReportParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventReportResponse>> Report(
        EventReportParams parameters,
        CancellationToken cancellationToken = default
    );
}
