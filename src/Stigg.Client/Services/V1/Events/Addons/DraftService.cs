using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Addons.Draft;

namespace Stigg.Client.Services.V1.Events.Addons;

/// <inheritdoc/>
public sealed class DraftService : IDraftService
{
    readonly Lazy<IDraftServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IDraftServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IDraftService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DraftService(this._client.WithOptions(modifier));
    }

    public DraftService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new DraftServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<DraftCreateAddonDraftResponse> CreateAddonDraft(
        DraftCreateAddonDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateAddonDraft(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DraftCreateAddonDraftResponse> CreateAddonDraft(
        string id,
        DraftCreateAddonDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateAddonDraft(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<DraftRemoveAddonDraftResponse> RemoveAddonDraft(
        DraftRemoveAddonDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RemoveAddonDraft(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<DraftRemoveAddonDraftResponse> RemoveAddonDraft(
        string id,
        DraftRemoveAddonDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RemoveAddonDraft(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class DraftServiceWithRawResponse : IDraftServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IDraftServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new DraftServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public DraftServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DraftCreateAddonDraftResponse>> CreateAddonDraft(
        DraftCreateAddonDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DraftCreateAddonDraftParams> request = new()
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
                    .Deserialize<DraftCreateAddonDraftResponse>(token)
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
    public Task<HttpResponse<DraftCreateAddonDraftResponse>> CreateAddonDraft(
        string id,
        DraftCreateAddonDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateAddonDraft(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<DraftRemoveAddonDraftResponse>> RemoveAddonDraft(
        DraftRemoveAddonDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<DraftRemoveAddonDraftParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<DraftRemoveAddonDraftResponse>(token)
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
    public Task<HttpResponse<DraftRemoveAddonDraftResponse>> RemoveAddonDraft(
        string id,
        DraftRemoveAddonDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RemoveAddonDraft(parameters with { ID = id }, cancellationToken);
    }
}
