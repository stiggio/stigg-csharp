using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Subscriptions.FutureUpdate;

namespace Stigg.Services.V1.Subscriptions;

/// <inheritdoc/>
public sealed class FutureUpdateService : IFutureUpdateService
{
    readonly Lazy<IFutureUpdateServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IFutureUpdateServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IFutureUpdateService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new FutureUpdateService(this._client.WithOptions(modifier));
    }

    public FutureUpdateService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new FutureUpdateServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<FutureUpdateCancelPendingPaymentResponse> CancelPendingPayment(
        FutureUpdateCancelPendingPaymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CancelPendingPayment(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FutureUpdateCancelPendingPaymentResponse> CancelPendingPayment(
        string id,
        FutureUpdateCancelPendingPaymentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CancelPendingPayment(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<FutureUpdateCancelScheduleResponse> CancelSchedule(
        FutureUpdateCancelScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CancelSchedule(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<FutureUpdateCancelScheduleResponse> CancelSchedule(
        string id,
        FutureUpdateCancelScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CancelSchedule(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class FutureUpdateServiceWithRawResponse : IFutureUpdateServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IFutureUpdateServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new FutureUpdateServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public FutureUpdateServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FutureUpdateCancelPendingPaymentResponse>> CancelPendingPayment(
        FutureUpdateCancelPendingPaymentParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FutureUpdateCancelPendingPaymentParams> request = new()
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
                    .Deserialize<FutureUpdateCancelPendingPaymentResponse>(token)
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
    public Task<HttpResponse<FutureUpdateCancelPendingPaymentResponse>> CancelPendingPayment(
        string id,
        FutureUpdateCancelPendingPaymentParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CancelPendingPayment(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<FutureUpdateCancelScheduleResponse>> CancelSchedule(
        FutureUpdateCancelScheduleParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<FutureUpdateCancelScheduleParams> request = new()
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
                    .Deserialize<FutureUpdateCancelScheduleResponse>(token)
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
    public Task<HttpResponse<FutureUpdateCancelScheduleResponse>> CancelSchedule(
        string id,
        FutureUpdateCancelScheduleParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CancelSchedule(parameters with { ID = id }, cancellationToken);
    }
}
