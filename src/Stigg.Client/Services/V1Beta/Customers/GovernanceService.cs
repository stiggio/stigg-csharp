using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1Beta.Customers.Governance;

namespace Stigg.Client.Services.V1Beta.Customers;

/// <inheritdoc/>
public sealed class GovernanceService : IGovernanceService
{
    readonly Lazy<IGovernanceServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IGovernanceServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IGovernanceService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new GovernanceService(this._client.WithOptions(modifier));
    }

    public GovernanceService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new GovernanceServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<GovernanceListPage> List(
        GovernanceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<GovernanceListPage> List(
        string id,
        GovernanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class GovernanceServiceWithRawResponse : IGovernanceServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IGovernanceServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new GovernanceServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public GovernanceServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<GovernanceListPage>> List(
        GovernanceListParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<GovernanceListParams> request = new()
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
                    .Deserialize<GovernanceListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new GovernanceListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<GovernanceListPage>> List(
        string id,
        GovernanceListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.List(parameters with { ID = id }, cancellationToken);
    }
}
