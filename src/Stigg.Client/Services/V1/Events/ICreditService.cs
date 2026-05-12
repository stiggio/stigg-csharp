using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Credits;
using Stigg.Client.Services.V1.Events.Credits;

namespace Stigg.Client.Services.V1.Events;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface ICreditService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    ICreditServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGrantService Grants { get; }

    ICustomCurrencyService CustomCurrencies { get; }

    /// <summary>
    /// Retrieves the automatic recharge configuration for a customer and currency.
    /// Returns default settings if no configuration exists.
    /// </summary>
    Task<CreditGetAutoRechargeResponse> GetAutoRecharge(
        CreditGetAutoRechargeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves credit usage time-series data for a customer, grouped by feature, over
    /// a specified time range.
    /// </summary>
    Task<CreditGetUsageResponse> GetUsage(
        CreditGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of credit ledger events for a customer.
    /// </summary>
    Task<CreditListLedgerPage> ListLedger(
        CreditListLedgerParams parameters,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="ICreditService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface ICreditServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    ICreditServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IGrantServiceWithRawResponse Grants { get; }

    ICustomCurrencyServiceWithRawResponse CustomCurrencies { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/credits/auto-recharge</c>, but is otherwise the
    /// same as <see cref="ICreditService.GetAutoRecharge(CreditGetAutoRechargeParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditGetAutoRechargeResponse>> GetAutoRecharge(
        CreditGetAutoRechargeParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/credits/usage</c>, but is otherwise the
    /// same as <see cref="ICreditService.GetUsage(CreditGetUsageParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditGetUsageResponse>> GetUsage(
        CreditGetUsageParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>get /api/v1/credits/ledger</c>, but is otherwise the
    /// same as <see cref="ICreditService.ListLedger(CreditListLedgerParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<CreditListLedgerPage>> ListLedger(
        CreditListLedgerParams parameters,
        CancellationToken cancellationToken = default
    );
}
