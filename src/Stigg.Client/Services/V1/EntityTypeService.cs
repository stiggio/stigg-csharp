using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.EntityTypes;

namespace Stigg.Client.Services.V1;

/// <inheritdoc/>
public sealed class EntityTypeService : IEntityTypeService
{
    readonly Lazy<IEntityTypeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEntityTypeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IEntityTypeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntityTypeService(this._client.WithOptions(modifier));
    }

    public EntityTypeService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EntityTypeServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EntityTypeListPage> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityTypeArchiveResponse> Archive(
        EntityTypeArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<EntityTypeCheckActiveEntitiesResponse> CheckActiveEntities(
        EntityTypeCheckActiveEntitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CheckActiveEntities(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntityTypeCheckActiveEntitiesResponse> CheckActiveEntities(
        string id,
        EntityTypeCheckActiveEntitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CheckActiveEntities(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntityTypeUpsertResponse> Upsert(
        EntityTypeUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upsert(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class EntityTypeServiceWithRawResponse : IEntityTypeServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEntityTypeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EntityTypeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EntityTypeServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityTypeListPage>> List(
        EntityTypeListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<EntityTypeListParams> request = new()
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
                    .Deserialize<EntityTypeListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EntityTypeListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityTypeArchiveResponse>> Archive(
        EntityTypeArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EntityTypeArchiveParams> request = new()
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
                    .Deserialize<EntityTypeArchiveResponse>(token)
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
    public async Task<HttpResponse<EntityTypeCheckActiveEntitiesResponse>> CheckActiveEntities(
        EntityTypeCheckActiveEntitiesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntityTypeCheckActiveEntitiesParams> request = new()
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
                    .Deserialize<EntityTypeCheckActiveEntitiesResponse>(token)
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
    public Task<HttpResponse<EntityTypeCheckActiveEntitiesResponse>> CheckActiveEntities(
        string id,
        EntityTypeCheckActiveEntitiesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CheckActiveEntities(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntityTypeUpsertResponse>> Upsert(
        EntityTypeUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<EntityTypeUpsertParams> request = new()
        {
            Method = HttpMethod.Put,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var deserializedResponse = await response
                    .Deserialize<EntityTypeUpsertResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    deserializedResponse.Validate();
                }
                return deserializedResponse;
            }
        );
    }
}
