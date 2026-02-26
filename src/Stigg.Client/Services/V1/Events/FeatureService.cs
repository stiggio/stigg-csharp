using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Features;

namespace Stigg.Client.Services.V1.Events;

/// <inheritdoc/>
public sealed class FeatureService : IFeatureService
{
    readonly Lazy<IFeatureServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFeatureServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IFeatureService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FeatureService(this._client.WithOptions(modifier));
    }

    public FeatureService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new FeatureServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Feature> ArchiveFeature(
        FeatureArchiveFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ArchiveFeature(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Feature> ArchiveFeature(
        string id,
        FeatureArchiveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveFeature(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Feature> CreateFeature(
        FeatureCreateFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateFeature(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<FeatureListFeaturesPage> ListFeatures(
        FeatureListFeaturesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListFeatures(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Feature> RetrieveFeature(
        FeatureRetrieveFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveFeature(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Feature> RetrieveFeature(
        string id,
        FeatureRetrieveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFeature(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Feature> UnarchiveFeature(
        FeatureUnarchiveFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UnarchiveFeature(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Feature> UnarchiveFeature(
        string id,
        FeatureUnarchiveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UnarchiveFeature(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Feature> UpdateFeature(
        FeatureUpdateFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateFeature(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Feature> UpdateFeature(
        string id,
        FeatureUpdateFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateFeature(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FeatureServiceWithRawResponse : IFeatureServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFeatureServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FeatureServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FeatureServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Feature>> ArchiveFeature(
        FeatureArchiveFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FeatureArchiveFeatureParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var feature = await response.Deserialize<Feature>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    feature.Validate();
                }
                return feature;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Feature>> ArchiveFeature(
        string id,
        FeatureArchiveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveFeature(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Feature>> CreateFeature(
        FeatureCreateFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<FeatureCreateFeatureParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var feature = await response.Deserialize<Feature>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    feature.Validate();
                }
                return feature;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FeatureListFeaturesPage>> ListFeatures(
        FeatureListFeaturesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<FeatureListFeaturesParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var page = await response
                    .Deserialize<FeatureListFeaturesPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new FeatureListFeaturesPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Feature>> RetrieveFeature(
        FeatureRetrieveFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FeatureRetrieveFeatureParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var feature = await response.Deserialize<Feature>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    feature.Validate();
                }
                return feature;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Feature>> RetrieveFeature(
        string id,
        FeatureRetrieveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveFeature(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Feature>> UnarchiveFeature(
        FeatureUnarchiveFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FeatureUnarchiveFeatureParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var feature = await response.Deserialize<Feature>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    feature.Validate();
                }
                return feature;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Feature>> UnarchiveFeature(
        string id,
        FeatureUnarchiveFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UnarchiveFeature(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Feature>> UpdateFeature(
        FeatureUpdateFeatureParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FeatureUpdateFeatureParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var feature = await response.Deserialize<Feature>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    feature.Validate();
                }
                return feature;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Feature>> UpdateFeature(
        string id,
        FeatureUpdateFeatureParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateFeature(parameters with { ID = id }, cancellationToken);
    }
}
