using System;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Features;

namespace Stigg.Client.Services.V1.Events;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IFeatureService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IFeatureServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFeatureService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Archives a feature, preventing it from being used in new entitlements.
    /// </summary>
    Task<FeatureArchiveFeatureResponse> ArchiveFeature(
        FeatureArchiveFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ArchiveFeature(FeatureArchiveFeatureParams, CancellationToken)"/>
    Task<FeatureArchiveFeatureResponse> ArchiveFeature(
        string id,
        FeatureArchiveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Creates a new feature with the specified type, metering, and configuration.
    /// </summary>
    Task<FeatureCreateFeatureResponse> CreateFeature(
        FeatureCreateFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a paginated list of features in the environment.
    /// </summary>
    Task<FeatureListFeaturesPage> ListFeatures(
        FeatureListFeaturesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Retrieves a feature by its unique identifier.
    /// </summary>
    Task<FeatureRetrieveFeatureResponse> RetrieveFeature(
        FeatureRetrieveFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFeature(FeatureRetrieveFeatureParams, CancellationToken)"/>
    Task<FeatureRetrieveFeatureResponse> RetrieveFeature(
        string id,
        FeatureRetrieveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Restores an archived feature, allowing it to be used in entitlements again.
    /// </summary>
    Task<FeatureUnarchiveFeatureResponse> UnarchiveFeature(
        FeatureUnarchiveFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UnarchiveFeature(FeatureUnarchiveFeatureParams, CancellationToken)"/>
    Task<FeatureUnarchiveFeatureResponse> UnarchiveFeature(
        string id,
        FeatureUnarchiveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Updates an existing feature's properties such as display name, description,
    /// and configuration.
    /// </summary>
    Task<FeatureUpdateFeatureResponse> UpdateFeature(
        FeatureUpdateFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateFeature(FeatureUpdateFeatureParams, CancellationToken)"/>
    Task<FeatureUpdateFeatureResponse> UpdateFeature(
        string id,
        FeatureUpdateFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}

/// <summary>
/// A view of <see cref="IFeatureService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IFeatureServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IFeatureServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/features/{id}/archive`, but is otherwise the
    /// same as <see cref="IFeatureService.ArchiveFeature(FeatureArchiveFeatureParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureArchiveFeatureResponse>> ArchiveFeature(
        FeatureArchiveFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="ArchiveFeature(FeatureArchiveFeatureParams, CancellationToken)"/>
    Task<HttpResponse<FeatureArchiveFeatureResponse>> ArchiveFeature(
        string id,
        FeatureArchiveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/features`, but is otherwise the
    /// same as <see cref="IFeatureService.CreateFeature(FeatureCreateFeatureParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureCreateFeatureResponse>> CreateFeature(
        FeatureCreateFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/features`, but is otherwise the
    /// same as <see cref="IFeatureService.ListFeatures(FeatureListFeaturesParams?, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureListFeaturesPage>> ListFeatures(
        FeatureListFeaturesParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `get /api/v1/features/{id}`, but is otherwise the
    /// same as <see cref="IFeatureService.RetrieveFeature(FeatureRetrieveFeatureParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureRetrieveFeatureResponse>> RetrieveFeature(
        FeatureRetrieveFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="RetrieveFeature(FeatureRetrieveFeatureParams, CancellationToken)"/>
    Task<HttpResponse<FeatureRetrieveFeatureResponse>> RetrieveFeature(
        string id,
        FeatureRetrieveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `post /api/v1/features/{id}/unarchive`, but is otherwise the
    /// same as <see cref="IFeatureService.UnarchiveFeature(FeatureUnarchiveFeatureParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureUnarchiveFeatureResponse>> UnarchiveFeature(
        FeatureUnarchiveFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UnarchiveFeature(FeatureUnarchiveFeatureParams, CancellationToken)"/>
    Task<HttpResponse<FeatureUnarchiveFeatureResponse>> UnarchiveFeature(
        string id,
        FeatureUnarchiveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    );

    /// <summary>
    /// Returns a raw HTTP response for `patch /api/v1/features/{id}`, but is otherwise the
    /// same as <see cref="IFeatureService.UpdateFeature(FeatureUpdateFeatureParams, CancellationToken)"/>.
    /// </summary>
    Task<HttpResponse<FeatureUpdateFeatureResponse>> UpdateFeature(
        FeatureUpdateFeatureParams parameters,
        CancellationToken cancellationToken = default
    );

    /// <inheritdoc cref="UpdateFeature(FeatureUpdateFeatureParams, CancellationToken)"/>
    Task<HttpResponse<FeatureUpdateFeatureResponse>> UpdateFeature(
        string id,
        FeatureUpdateFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    );
}
