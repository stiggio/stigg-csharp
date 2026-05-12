using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Models.V1.Credits.AutoRecharge;

namespace Stigg.Client.Services.V1.Credits;

/// <inheritdoc/>
public sealed class AutoRechargeService : IAutoRechargeService
{
    readonly Lazy<IAutoRechargeServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IAutoRechargeServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IAutoRechargeService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new AutoRechargeService(this._client.WithOptions(modifier));
    }

    public AutoRechargeService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new AutoRechargeServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<AutoRechargeGetAutoRechargeResponse> GetAutoRecharge(
        AutoRechargeGetAutoRechargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.GetAutoRecharge(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }
}

/// <inheritdoc/>
public sealed class AutoRechargeServiceWithRawResponse : IAutoRechargeServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IAutoRechargeServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new AutoRechargeServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public AutoRechargeServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<AutoRechargeGetAutoRechargeResponse>> GetAutoRecharge(
        AutoRechargeGetAutoRechargeParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<AutoRechargeGetAutoRechargeParams> request = new()
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
                    .Deserialize<AutoRechargeGetAutoRechargeResponse>(token)
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
