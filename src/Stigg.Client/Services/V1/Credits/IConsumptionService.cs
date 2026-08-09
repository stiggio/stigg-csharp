using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.Consumption;

namespace Stigg.Client.Services.V1.Credits;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IConsumptionService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IConsumptionServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConsumptionService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Consumes a specified amount of credits directly from a customer wallet, with no
    /// feature mapping. Returns the optimistic balance.
    /// </summary>
    Task<ConsumptionConsumeResponse> Consume(
        ConsumptionConsumeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Consumes credits directly from customer wallets asynchronously. Consumptions are
    /// reconciled asynchronously into the credit balances.
    /// </summary>
    Task<ConsumptionConsumeAsyncResponse> ConsumeAsync(
        ConsumptionConsumeAsyncParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IConsumptionService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IConsumptionServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IConsumptionServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/credits/consumption</c>, but is otherwise the
    /// same as <see cref="IConsumptionService.Consume(ConsumptionConsumeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConsumptionConsumeResponse>> Consume(
        ConsumptionConsumeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/credits/consumption/async</c>, but is otherwise the
    /// same as <see cref="IConsumptionService.ConsumeAsync(ConsumptionConsumeAsyncParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<ConsumptionConsumeAsyncResponse>> ConsumeAsync(
        ConsumptionConsumeAsyncParams parameters,
        CancellationToken cancellationToken = default
    );
}
