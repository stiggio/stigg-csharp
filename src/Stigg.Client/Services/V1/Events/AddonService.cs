using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons;
using Stigg.Client.Services.V1.Events.Addons;

namespace Stigg.Client.Services.V1.Events;

/// <inheritdoc/>
public sealed class AddonService : IAddonService
{
    readonly Lazy<IAddonServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAddonServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IAddonService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddonService(this._client.WithOptions(modifier));
    }

    public AddonService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AddonServiceWithRawResponse(client.WithRawResponse));
        _draft = new(() => new DraftService(client));
    }

    readonly Lazy<IDraftService> _draft;
    public IDraftService Draft
    {
        get { return _draft.Value; }
    }

    /// <inheritdoc/>
    public async Task<AddonArchiveAddonResponse> ArchiveAddon(
        AddonArchiveAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ArchiveAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonArchiveAddonResponse> ArchiveAddon(
        string id,
        AddonArchiveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonCreateAddonResponse> CreateAddon(
        AddonCreateAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddonListAddonsPage> ListAddons(
        AddonListAddonsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListAddons(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<AddonPublishAddonResponse> PublishAddon(
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.PublishAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonPublishAddonResponse> PublishAddon(
        string id,
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PublishAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonRetrieveAddonResponse> RetrieveAddon(
        AddonRetrieveAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RetrieveAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonRetrieveAddonResponse> RetrieveAddon(
        string id,
        AddonRetrieveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AddonUpdateAddonResponse> UpdateAddon(
        AddonUpdateAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateAddon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AddonUpdateAddonResponse> UpdateAddon(
        string id,
        AddonUpdateAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateAddon(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AddonServiceWithRawResponse : IAddonServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAddonServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AddonServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AddonServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _draft = new(() => new DraftServiceWithRawResponse(client));
    }

    readonly Lazy<IDraftServiceWithRawResponse> _draft;
    public IDraftServiceWithRawResponse Draft
    {
        get { return _draft.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonArchiveAddonResponse>> ArchiveAddon(
        AddonArchiveAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonArchiveAddonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AddonArchiveAddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonArchiveAddonResponse>> ArchiveAddon(
        string id,
        AddonArchiveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonCreateAddonResponse>> CreateAddon(
        AddonCreateAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AddonCreateAddonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AddonCreateAddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonListAddonsPage>> ListAddons(
        AddonListAddonsParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<AddonListAddonsParams> request = new()
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
                    .Deserialize<AddonListAddonsPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AddonListAddonsPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonPublishAddonResponse>> PublishAddon(
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonPublishAddonParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AddonPublishAddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonPublishAddonResponse>> PublishAddon(
        string id,
        AddonPublishAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.PublishAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonRetrieveAddonResponse>> RetrieveAddon(
        AddonRetrieveAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonRetrieveAddonParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AddonRetrieveAddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonRetrieveAddonResponse>> RetrieveAddon(
        string id,
        AddonRetrieveAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RetrieveAddon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AddonUpdateAddonResponse>> UpdateAddon(
        AddonUpdateAddonParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AddonUpdateAddonParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<AddonUpdateAddonResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AddonUpdateAddonResponse>> UpdateAddon(
        string id,
        AddonUpdateAddonParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateAddon(parameters with { ID = id }, cancellationToken);
    }
}
