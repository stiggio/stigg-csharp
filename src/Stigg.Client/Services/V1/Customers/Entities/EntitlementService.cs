using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers.Entities.Entitlements;

namespace Stigg.Client.Services.V1.Customers.Entities;

/// <inheritdoc/>
public sealed class EntitlementService : IEntitlementService
{
    readonly Lazy<IEntitlementServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IEntitlementServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IEntitlementService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new EntitlementService(this._client.WithOptions(modifier));
    }

    public EntitlementService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new EntitlementServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<EntitlementListPage> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementListPage> List(
        string id,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<EntitlementUpsertResponse> Upsert(
        EntitlementUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upsert(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<EntitlementUpsertResponse> Upsert(
        string id,
        EntitlementUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upsert(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class EntitlementServiceWithRawResponse : IEntitlementServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IEntitlementServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new EntitlementServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public EntitlementServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementListPage>> List(
        EntitlementListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntitlementListParams> request = new()
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
                    .Deserialize<EntitlementListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new EntitlementListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<EntitlementListPage>> List(
        string id,
        EntitlementListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<EntitlementUpsertResponse>> Upsert(
        EntitlementUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<EntitlementUpsertParams> request = new()
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
                    .Deserialize<EntitlementUpsertResponse>(token)
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
    public Task<HttpResponse<EntitlementUpsertResponse>> Upsert(
        string id,
        EntitlementUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upsert(parameters with { ID = id }, cancellationToken);
    }
}
