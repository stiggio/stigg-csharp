using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.Internal.Beta.EventQueues;

namespace Stigg.Client.Services.Internal.Beta;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IEventQueueService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IEventQueueServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventQueueService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Get event queue by queue name
    /// </summary>
    Task<EventQueueResponse> Retrieve(
        EventQueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventQueueRetrieveParams, CancellationToken)"/>
    Task<EventQueueResponse> Retrieve(
        string queueName,
        EventQueueRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Update event queue configuration
    /// </summary>
    Task<EventQueueResponse> Update(
        EventQueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EventQueueUpdateParams, CancellationToken)"/>
    Task<EventQueueResponse> Update(
        string queueName,
        EventQueueUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// List all event queues for the current environment
    /// </summary>
    Task<EventQueueListResponse> List(
        EventQueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Delete an event queue and tear down its infrastructure
    /// </summary>
    Task<EventQueueResponse> Delete(
        EventQueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EventQueueDeleteParams, CancellationToken)"/>
    Task<EventQueueResponse> Delete(
        string queueName,
        EventQueueDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Provision SQS queue, SNS subscriptions, and IAM role for the current environment
    /// </summary>
    Task<EventQueueResponse> Provision(
        EventQueueProvisionParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IEventQueueService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IEventQueueServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IEventQueueServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /internal/beta/event-queues/{queueName}</c>, but is otherwise the
    /// same as <see cref="IEventQueueService.Retrieve(EventQueueRetrieveParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventQueueResponse>> Retrieve(
        EventQueueRetrieveParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Retrieve(EventQueueRetrieveParams, CancellationToken)"/>
    Task<HttpResponse<EventQueueResponse>> Retrieve(
        string queueName,
        EventQueueRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>patch /internal/beta/event-queues/{queueName}</c>, but is otherwise the
    /// same as <see cref="IEventQueueService.Update(EventQueueUpdateParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventQueueResponse>> Update(
        EventQueueUpdateParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Update(EventQueueUpdateParams, CancellationToken)"/>
    Task<HttpResponse<EventQueueResponse>> Update(
        string queueName,
        EventQueueUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /internal/beta/event-queues</c>, but is otherwise the
    /// same as <see cref="IEventQueueService.List(EventQueueListParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventQueueListResponse>> List(
        EventQueueListParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>delete /internal/beta/event-queues/{queueName}</c>, but is otherwise the
    /// same as <see cref="IEventQueueService.Delete(EventQueueDeleteParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventQueueResponse>> Delete(
        EventQueueDeleteParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Delete(EventQueueDeleteParams, CancellationToken)"/>
    Task<HttpResponse<EventQueueResponse>> Delete(
        string queueName,
        EventQueueDeleteParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /internal/beta/event-queues/provision</c>, but is otherwise the
    /// same as <see cref="IEventQueueService.Provision(EventQueueProvisionParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<EventQueueResponse>> Provision(
        EventQueueProvisionParams parameters,
        CancellationToken cancellationToken = default
    );
}
