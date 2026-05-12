using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.AutoRecharge;

namespace Stigg.Client.Services.V1.Credits;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IAutoRechargeService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IAutoRechargeServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutoRechargeService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Retrieves the automatic recharge configuration for a customer and currency.
    /// Returns default settings if no configuration exists.
    /// </summary>
    Task<AutoRechargeGetAutoRechargeResponse> GetAutoRecharge(
        AutoRechargeGetAutoRechargeParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IAutoRechargeService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IAutoRechargeServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IAutoRechargeServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/credits/auto-recharge</c>, but is otherwise the
    /// same as <see cref="IAutoRechargeService.GetAutoRecharge(AutoRechargeGetAutoRechargeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<AutoRechargeGetAutoRechargeResponse>> GetAutoRecharge(
        AutoRechargeGetAutoRechargeParams parameters,
        CancellationToken cancellationToken = default
    );
}
