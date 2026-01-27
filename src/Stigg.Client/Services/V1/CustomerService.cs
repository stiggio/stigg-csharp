using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Customers;
using Stigg.Client.Services.V1.Customers;

namespace Stigg.Client.Services.V1;

/// <inheritdoc/>
public sealed class CustomerService : ICustomerService
{
    readonly Lazy<ICustomerServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICustomerServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public ICustomerService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerService(this._client.WithOptions(modifier));
    }

    public CustomerService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CustomerServiceWithRawResponse(client.WithRawResponse));
        _paymentMethod = new(() => new PaymentMethodService(client));
        _usage = new(() => new UsageService(client));
    }

    readonly Lazy<IPaymentMethodService> _paymentMethod;
    public IPaymentMethodService PaymentMethod
    {
        get { return _paymentMethod.Value; }
    }

    readonly Lazy<IUsageService> _usage;
    public IUsageService Usage
    {
        get { return _usage.Value; }
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerResponse> Retrieve(
        string id,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerResponse> Update(
        string id,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerListPage> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> Archive(
        CustomerArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerResponse> Archive(
        string id,
        CustomerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CustomerResponse> Unarchive(
        CustomerUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Unarchive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<CustomerResponse> Unarchive(
        string id,
        CustomerUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unarchive(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CustomerServiceWithRawResponse : ICustomerServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICustomerServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CustomerServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CustomerServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _paymentMethod = new(() => new PaymentMethodServiceWithRawResponse(client));
        _usage = new(() => new UsageServiceWithRawResponse(client));
    }

    readonly Lazy<IPaymentMethodServiceWithRawResponse> _paymentMethod;
    public IPaymentMethodServiceWithRawResponse PaymentMethod
    {
        get { return _paymentMethod.Value; }
    }

    readonly Lazy<IUsageServiceWithRawResponse> _usage;
    public IUsageServiceWithRawResponse Usage
    {
        get { return _usage.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerResponse>> Create(
        CustomerCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CustomerCreateParams> request = new()
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
    public async Task<HttpResponse<CustomerResponse>> Retrieve(
        CustomerRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CustomerRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
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
    public Task<HttpResponse<CustomerResponse>> Retrieve(
        string id,
        CustomerRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerResponse>> Update(
        CustomerUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CustomerUpdateParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
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
    public Task<HttpResponse<CustomerResponse>> Update(
        string id,
        CustomerUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerListPage>> List(
        CustomerListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CustomerListParams> request = new()
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
                    .Deserialize<CustomerListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CustomerListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerResponse>> Archive(
        CustomerArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CustomerArchiveParams> request = new()
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
    public Task<HttpResponse<CustomerResponse>> Archive(
        string id,
        CustomerArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CustomerResponse>> Unarchive(
        CustomerUnarchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CustomerUnarchiveParams> request = new()
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
    public Task<HttpResponse<CustomerResponse>> Unarchive(
        string id,
        CustomerUnarchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Unarchive(parameters with { ID = id }, cancellationToken);
    }
}
