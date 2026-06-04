using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.DataExport;
using Stigg.Client.Services.V1.Events.DataExport;

namespace Stigg.Client.Services.V1.Events;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDataExportService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDataExportServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataExportService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDestinationService Destinations { get; }

    /// <summary>
    /// Mint a scoped JWT for the FE embedded SDK. Lazy-creates the DATA_EXPORT
    /// integration if needed.
    /// </summary>
    Task<DataExportMintScopedTokenResponse> MintScopedToken(
        DataExportMintScopedTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Trigger a sync for one destination or all destinations under the provider
    /// entity.
    /// </summary>
    Task<DataExportTriggerSyncResponse> TriggerSync(
        DataExportTriggerSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDataExportService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDataExportServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDataExportServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IDestinationServiceWithRawResponse Destinations { get; }

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/data-export/scoped-token</c>, but is otherwise the
    /// same as <see cref="IDataExportService.MintScopedToken(DataExportMintScopedTokenParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DataExportMintScopedTokenResponse>> MintScopedToken(
        DataExportMintScopedTokenParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for <c>post /api/v1/data-export/sync</c>, but is otherwise the
    /// same as <see cref="IDataExportService.TriggerSync(DataExportTriggerSyncParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DataExportTriggerSyncResponse>> TriggerSync(
        DataExportTriggerSyncParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
