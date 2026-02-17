using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Subscriptions;
using Subscriptions = Stigg.Client.Services.V1.Subscriptions;

namespace Stigg.Client.Services.V1;

/// <inheritdoc/>
public sealed class SubscriptionService : ISubscriptionService
{
    readonly Lazy<ISubscriptionServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public ISubscriptionService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new SubscriptionService(this._client.WithOptions(modifier));
    }

    public SubscriptionService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() =>
            new SubscriptionServiceWithRawResponse(client.WithRawResponse)
        );
        _futureUpdate = new(() => new Subscriptions::FutureUpdateService(client));
        _usage = new(() => new Subscriptions::UsageService(client));
        _invoice = new(() => new Subscriptions::InvoiceService(client));
    }

    readonly Lazy<Subscriptions::IFutureUpdateService> _futureUpdate;
    public Subscriptions::IFutureUpdateService FutureUpdate
    {
        get { return _futureUpdate.Value; }
    }

    readonly Lazy<Subscriptions::IUsageService> _usage;
    public Subscriptions::IUsageService Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<Subscriptions::IInvoiceService> _invoice;
    public Subscriptions::IInvoiceService Invoice
    {
        get { return _invoice.Value; }
    }

    /// <inheritdoc/>
    public async Task<SubscriptionSubscription> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionSubscription> Retrieve(
        string id,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionSubscription> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionSubscription> Update(
        string id,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionListPage> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionSubscription> Cancel(
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Cancel(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionSubscription> Cancel(
        string id,
        SubscriptionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionSubscription> Delegate(
        SubscriptionDelegateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Delegate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionSubscription> Delegate(
        string id,
        SubscriptionDelegateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delegate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionImportResponse> Import(
        SubscriptionImportParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Import(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionSubscription> Migrate(
        SubscriptionMigrateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Migrate(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionSubscription> Migrate(
        string id,
        SubscriptionMigrateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Migrate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionPreviewResponse> Preview(
        SubscriptionPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Preview(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionProvisionResponse> Provision(
        SubscriptionProvisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Provision(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<SubscriptionSubscription> Transfer(
        SubscriptionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Transfer(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<SubscriptionSubscription> Transfer(
        string id,
        SubscriptionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Transfer(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class SubscriptionServiceWithRawResponse : ISubscriptionServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public ISubscriptionServiceWithRawResponse WithOptions(
        Func<ClientOptions, ClientOptions> modifier
    )
    {
        return new SubscriptionServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public SubscriptionServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _futureUpdate = new(() => new Subscriptions::FutureUpdateServiceWithRawResponse(client));
        _usage = new(() => new Subscriptions::UsageServiceWithRawResponse(client));
        _invoice = new(() => new Subscriptions::InvoiceServiceWithRawResponse(client));
    }

    readonly Lazy<Subscriptions::IFutureUpdateServiceWithRawResponse> _futureUpdate;
    public Subscriptions::IFutureUpdateServiceWithRawResponse FutureUpdate
    {
        get { return _futureUpdate.Value; }
    }

    readonly Lazy<Subscriptions::IUsageServiceWithRawResponse> _usage;
    public Subscriptions::IUsageServiceWithRawResponse Usage
    {
        get { return _usage.Value; }
    }

    readonly Lazy<Subscriptions::IInvoiceServiceWithRawResponse> _invoice;
    public Subscriptions::IInvoiceServiceWithRawResponse Invoice
    {
        get { return _invoice.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionSubscription>> Retrieve(
        SubscriptionRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubscriptionRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<SubscriptionSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionSubscription>> Retrieve(
        string id,
        SubscriptionRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionSubscription>> Update(
        SubscriptionUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubscriptionUpdateParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<SubscriptionSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionSubscription>> Update(
        string id,
        SubscriptionUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionListPage>> List(
        SubscriptionListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<SubscriptionListParams> request = new()
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
                    .Deserialize<SubscriptionListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new SubscriptionListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionSubscription>> Cancel(
        SubscriptionCancelParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubscriptionCancelParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<SubscriptionSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionSubscription>> Cancel(
        string id,
        SubscriptionCancelParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Cancel(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionSubscription>> Delegate(
        SubscriptionDelegateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubscriptionDelegateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<SubscriptionSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionSubscription>> Delegate(
        string id,
        SubscriptionDelegateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Delegate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionImportResponse>> Import(
        SubscriptionImportParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionImportParams> request = new()
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
                    .Deserialize<SubscriptionImportResponse>(token)
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
    public async Task<HttpResponse<SubscriptionSubscription>> Migrate(
        SubscriptionMigrateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubscriptionMigrateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<SubscriptionSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionSubscription>> Migrate(
        string id,
        SubscriptionMigrateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Migrate(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<SubscriptionPreviewResponse>> Preview(
        SubscriptionPreviewParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionPreviewParams> request = new()
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
                    .Deserialize<SubscriptionPreviewResponse>(token)
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
    public async Task<HttpResponse<SubscriptionProvisionResponse>> Provision(
        SubscriptionProvisionParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<SubscriptionProvisionParams> request = new()
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
                    .Deserialize<SubscriptionProvisionResponse>(token)
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
    public async Task<HttpResponse<SubscriptionSubscription>> Transfer(
        SubscriptionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<SubscriptionTransferParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var subscription = await response
                    .Deserialize<SubscriptionSubscription>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    subscription.Validate();
                }
                return subscription;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<SubscriptionSubscription>> Transfer(
        string id,
        SubscriptionTransferParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Transfer(parameters with { ID = id }, cancellationToken);
    }
}
