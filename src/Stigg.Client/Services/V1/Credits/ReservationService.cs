using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Credits.Reservations;

namespace Stigg.Client.Services.V1.Credits;

/// <inheritdoc/>
public sealed class ReservationService : IReservationService
{
    readonly Lazy<IReservationServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IReservationServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IReservationService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new ReservationService(this._client.WithOptions(modifier));
    }

    public ReservationService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new ReservationServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<ReservationReleaseResponse> Release(
        ReservationReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Release(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<ReservationReleaseResponse> Release(
        string reservationID,
        ReservationReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Release(parameters with { ReservationID = reservationID }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class ReservationServiceWithRawResponse : IReservationServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IReservationServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new ReservationServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public ReservationServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<ReservationReleaseResponse>> Release(
        ReservationReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ReservationID == null)
        {
            throw new StiggInvalidDataException("'parameters.ReservationID' cannot be null");
        }

        HttpRequest<ReservationReleaseParams> request = new()
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
                    .Deserialize<ReservationReleaseResponse>(token)
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
    public Task<HttpResponse<ReservationReleaseResponse>> Release(
        string reservationID,
        ReservationReleaseParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Release(parameters with { ReservationID = reservationID }, cancellationToken);
    }
}
