using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Core;
using Stigg.Exceptions;
using Stigg.Models.V1.Customers;
using Stigg.Models.V1.Customers.PaymentMethod;

namespace Stigg.Services.V1.Customers;

/// <inheritdoc/>
public sealed class PaymentMethodService : IPaymentMethodService
{
    readonly Lazy<IPaymentMethodServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPaymentMethodServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IPaymentMethodService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PaymentMethodService(this._client.WithOptions(modifier));
    }

    public PaymentMethodService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new PaymentMethodServiceWithRawResponse(client.WithRawResponse)
        );
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> Attach(
        PaymentMethodAttachParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Attach(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerResponse> Attach(
        string id,
        PaymentMethodAttachParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Attach(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> Detach(
        PaymentMethodDetachParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Detach(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerResponse> Detach(
        string id,
        PaymentMethodDetachParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Detach(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PaymentMethodServiceWithRawResponse : IPaymentMethodServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPaymentMethodServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new PaymentMethodServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PaymentMethodServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerResponse>> Attach(
        PaymentMethodAttachParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaymentMethodAttachParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerResponse = await response
                    .Deserialize<CustomerResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerResponse.Validate();
                }
                return customerResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerResponse>> Attach(
        string id,
        PaymentMethodAttachParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Attach(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerResponse>> Detach(
        PaymentMethodDetachParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PaymentMethodDetachParams> request = new()
        {
            Method = HttpMethod.Delete,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var customerResponse = await response
                    .Deserialize<CustomerResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    customerResponse.Validate();
                }
                return customerResponse;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<CustomerResponse>> Detach(
        string id,
        PaymentMethodDetachParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Detach(parameters with { ID = id }, cancellationToken);
    }
}
