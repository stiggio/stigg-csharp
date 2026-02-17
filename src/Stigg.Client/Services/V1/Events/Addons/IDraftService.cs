using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Addons.Draft;

namespace Stigg.Client.Services.V1.Events.Addons;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IDraftService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IDraftServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Creates a draft version of an existing addon for modification before publishing.
    /// </summary>
    Task<DraftCreateAddonDraftResponse> CreateAddonDraft(
        DraftCreateAddonDraftParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateAddonDraft(DraftCreateAddonDraftParams, CancellationToken)"/>
    Task<DraftCreateAddonDraftResponse> CreateAddonDraft(
        string id,
        DraftCreateAddonDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Removes a draft version of an addon.
    /// </summary>
    Task<DraftRemoveAddonDraftResponse> RemoveAddonDraft(
        DraftRemoveAddonDraftParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveAddonDraft(DraftRemoveAddonDraftParams, CancellationToken)"/>
    Task<DraftRemoveAddonDraftResponse> RemoveAddonDraft(
        string id,
        DraftRemoveAddonDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IDraftService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IDraftServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IDraftServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/addons/{id}/draft`, but is otherwise the
    /// same as <see cref="IDraftService.CreateAddonDraft(DraftCreateAddonDraftParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DraftCreateAddonDraftResponse>> CreateAddonDraft(
        DraftCreateAddonDraftParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="CreateAddonDraft(DraftCreateAddonDraftParams, CancellationToken)"/>
    Task<HttpResponse<DraftCreateAddonDraftResponse>> CreateAddonDraft(
        string id,
        DraftCreateAddonDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `delete /api/v1/addons/{id}/draft`, but is otherwise the
    /// same as <see cref="IDraftService.RemoveAddonDraft(DraftRemoveAddonDraftParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<DraftRemoveAddonDraftResponse>> RemoveAddonDraft(
        DraftRemoveAddonDraftParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RemoveAddonDraft(DraftRemoveAddonDraftParams, CancellationToken)"/>
    Task<HttpResponse<DraftRemoveAddonDraftResponse>> RemoveAddonDraft(
        string id,
        DraftRemoveAddonDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
