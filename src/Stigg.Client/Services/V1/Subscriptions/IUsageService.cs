using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Subscriptions.Usage;

namespace Stigg.Client.Services.V1.Subscriptions;

/// <summary>
/// Operations related to subscriptions
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
    /// Immediately charges usage for a subscription via the billing integration.
    /// Calculates usage since the last charge and creates an invoice.
    /// </summary>
    Task<UsageChargeUsageResponse> ChargeUsage(
        UsageChargeUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ChargeUsage(UsageChargeUsageParams, CancellationToken)"/>
    Task<UsageChargeUsageResponse> ChargeUsage(
        string id,
        UsageChargeUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Triggers a usage sync for a subscription, reporting current usage to the
    /// billing provider.
    /// </summary>
    Task<UsageSyncResponse> Sync(
        UsageSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Sync(UsageSyncParams, CancellationToken)"/>
    Task<UsageSyncResponse> Sync(
        string id,
        UsageSyncParams? parameters = null,
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
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/{id}/usage/charge`, but is otherwise the
    /// same as <see cref="IUsageService.ChargeUsage(UsageChargeUsageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageChargeUsageResponse>> ChargeUsage(
        UsageChargeUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ChargeUsage(UsageChargeUsageParams, CancellationToken)"/>
    Task<HttpResponse<UsageChargeUsageResponse>> ChargeUsage(
        string id,
        UsageChargeUsageParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/subscriptions/{id}/usage/sync`, but is otherwise the
    /// same as <see cref="IUsageService.Sync(UsageSyncParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<UsageSyncResponse>> Sync(
        UsageSyncParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="Sync(UsageSyncParams, CancellationToken)"/>
    Task<HttpResponse<UsageSyncResponse>> Sync(
        string id,
        UsageSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
