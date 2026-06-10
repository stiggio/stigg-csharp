using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1Beta.Customers.Assignments;

namespace Stigg.Client.Services.V1Beta.Customers;

/// <inheritdoc/>
public sealed class AssignmentService : IAssignmentService
{
    readonly Lazy<IAssignmentServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAssignmentServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IAssignmentService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AssignmentService(this._client.WithOptions(modifier));
    }

    public AssignmentService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new AssignmentServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<AssignmentListPage> List(
        AssignmentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AssignmentListPage> List(
        string id,
        AssignmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<AssignmentUpsertResponse> Upsert(
        AssignmentUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Upsert(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<AssignmentUpsertResponse> Upsert(
        string id,
        AssignmentUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upsert(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class AssignmentServiceWithRawResponse : IAssignmentServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAssignmentServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AssignmentServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AssignmentServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssignmentListPage>> List(
        AssignmentListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AssignmentListParams> request = new()
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
                    .Deserialize<AssignmentListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new AssignmentListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<AssignmentListPage>> List(
        string id,
        AssignmentListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AssignmentUpsertResponse>> Upsert(
        AssignmentUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<AssignmentUpsertParams> request = new()
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
                    .Deserialize<AssignmentUpsertResponse>(token)
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
    public Task<HttpResponse<AssignmentUpsertResponse>> Upsert(
        string id,
        AssignmentUpsertParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Upsert(parameters with { ID = id }, cancellationToken);
    }
}
