using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Events.Credits;
using Stigg.Client.Services.V1.Events.Credits;

namespace Stigg.Client.Services.V1.Events;

/// <inheritdoc/>
public sealed class CreditService : ICreditService
{
    readonly Lazy<ICreditServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICreditServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public ICreditService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditService(this._client.WithOptions(modifier));
    }

    public CreditService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CreditServiceWithRawResponse(client.WithRawResponse));
        _grants = new(() => new GrantService(client));
    }

    readonly Lazy<IGrantService> _grants;
    public IGrantService Grants
    {
        get { return _grants.Value; }
    }

    /// <inheritdoc/>
    public async Task<CreditGetAutoRechargeResponse> GetAutoRecharge(
        CreditGetAutoRechargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetAutoRecharge(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditGetUsageResponse> GetUsage(
        CreditGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetUsage(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CreditListLedgerPage> ListLedger(
        CreditListLedgerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListLedger(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class CreditServiceWithRawResponse : ICreditServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICreditServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CreditServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CreditServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _grants = new(() => new GrantServiceWithRawResponse(client));
    }

    readonly Lazy<IGrantServiceWithRawResponse> _grants;
    public IGrantServiceWithRawResponse Grants
    {
        get { return _grants.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CreditGetAutoRechargeResponse>> GetAutoRecharge(
        CreditGetAutoRechargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditGetAutoRechargeParams> request = new()
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
                    .Deserialize<CreditGetAutoRechargeResponse>(token)
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
    public async Task<HttpResponse<CreditGetUsageResponse>> GetUsage(
        CreditGetUsageParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditGetUsageParams> request = new()
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
                    .Deserialize<CreditGetUsageResponse>(token)
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
    public async Task<HttpResponse<CreditListLedgerPage>> ListLedger(
        CreditListLedgerParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CreditListLedgerParams> request = new()
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
                    .Deserialize<CreditListLedgerPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CreditListLedgerPage(this, parameters, page);
            }
        );
    }
}
