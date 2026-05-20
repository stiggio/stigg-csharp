using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Events.Credits.Grants;

namespace Stigg.Client.Services.V1.Events.Credits;

/// <inheritdoc/>
public sealed class GrantService : IGrantService
{
    readonly Lazy<IGrantServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGrantServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IGrantService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GrantService(this._client.WithOptions(modifier));
    }

    public GrantService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GrantServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<CreditGrantResponse> Create(
        GrantCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<GrantListPage> List(
        GrantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditGrantResponse> Void(
        GrantVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Void(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CreditGrantResponse> Void(
        string id,
        GrantVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Void(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class GrantServiceWithRawResponse : IGrantServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGrantServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GrantServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GrantServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditGrantResponse>> Create(
        GrantCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GrantCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var creditGrantResponse = await response
                    .Deserialize<CreditGrantResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditGrantResponse.Validate();
                }
                return creditGrantResponse;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GrantListPage>> List(
        GrantListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<GrantListParams> request = new()
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
                    .Deserialize<GrantListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new GrantListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditGrantResponse>> Void(
        GrantVoidParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<GrantVoidParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var creditGrantResponse = await response
                    .Deserialize<CreditGrantResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    creditGrantResponse.Validate();
                }
                return creditGrantResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CreditGrantResponse>> Void(
        string id,
        GrantVoidParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Void(parameters with { ID = id }, cancellationToken);
    }
}
