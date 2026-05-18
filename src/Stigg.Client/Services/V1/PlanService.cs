using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Plans;
using Stigg.Client.Services.V1.Plans;

namespace Stigg.Client.Services.V1;

/// <inheritdoc/>
public sealed class PlanService : IPlanService
{
    readonly Lazy<IPlanServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public IPlanServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public IPlanService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlanService(this._client.WithOptions(modifier));
    }

    public PlanService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new PlanServiceWithRawResponse(client.WithRawResponse));
        _entitlements = new(() => new EntitlementService(client));
    }

    readonly Lazy<IEntitlementService> _entitlements;
    public IEntitlementService Entitlements
    {
        get { return _entitlements.Value; }
    }

    /// <inheritdoc/>
    public async Task<Plan> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Plan> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Plan> Retrieve(
        string id,
        PlanRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Plan> Update(
        PlanUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Update(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Plan> Update(
        string id,
        PlanUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanListPage> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Plan> Archive(
        PlanArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Archive(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Plan> Archive(
        string id,
        PlanArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Plan> CreateDraft(
        PlanCreateDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.CreateDraft(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Plan> CreateDraft(
        string id,
        PlanCreateDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateDraft(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanListChargesPage> ListCharges(
        PlanListChargesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListCharges(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlanListChargesPage> ListCharges(
        string id,
        PlanListChargesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListCharges(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanListOverageChargesPage> ListOverageCharges(
        PlanListOverageChargesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ListOverageCharges(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlanListOverageChargesPage> ListOverageCharges(
        string id,
        PlanListOverageChargesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListOverageCharges(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanPublishResponse> Publish(
        PlanPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Publish(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlanPublishResponse> Publish(
        string id,
        PlanPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Publish(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<PlanRemoveDraftResponse> RemoveDraft(
        PlanRemoveDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.RemoveDraft(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<PlanRemoveDraftResponse> RemoveDraft(
        string id,
        PlanRemoveDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RemoveDraft(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class PlanServiceWithRawResponse : IPlanServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public IPlanServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new PlanServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public PlanServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;

        _entitlements = new(() => new EntitlementServiceWithRawResponse(client));
    }

    readonly Lazy<IEntitlementServiceWithRawResponse> _entitlements;
    public IEntitlementServiceWithRawResponse Entitlements
    {
        get { return _entitlements.Value; }
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> Create(
        PlanCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<PlanCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var plan = await response.Deserialize<Plan>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    plan.Validate();
                }
                return plan;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> Retrieve(
        PlanRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PlanRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var plan = await response.Deserialize<Plan>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    plan.Validate();
                }
                return plan;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Plan>> Retrieve(
        string id,
        PlanRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> Update(
        PlanUpdateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PlanUpdateParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var plan = await response.Deserialize<Plan>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    plan.Validate();
                }
                return plan;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Plan>> Update(
        string id,
        PlanUpdateParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Update(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanListPage>> List(
        PlanListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<PlanListParams> request = new()
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
                    .Deserialize<PlanListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PlanListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> Archive(
        PlanArchiveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PlanArchiveParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var plan = await response.Deserialize<Plan>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    plan.Validate();
                }
                return plan;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Plan>> Archive(
        string id,
        PlanArchiveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Archive(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Plan>> CreateDraft(
        PlanCreateDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PlanCreateDraftParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var plan = await response.Deserialize<Plan>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    plan.Validate();
                }
                return plan;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Plan>> CreateDraft(
        string id,
        PlanCreateDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.CreateDraft(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanListChargesPage>> ListCharges(
        PlanListChargesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PlanListChargesParams> request = new()
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
                    .Deserialize<PlanListChargesPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PlanListChargesPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PlanListChargesPage>> ListCharges(
        string id,
        PlanListChargesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListCharges(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanListOverageChargesPage>> ListOverageCharges(
        PlanListOverageChargesParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PlanListOverageChargesParams> request = new()
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
                    .Deserialize<PlanListOverageChargesPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new PlanListOverageChargesPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<PlanListOverageChargesPage>> ListOverageCharges(
        string id,
        PlanListOverageChargesParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ListOverageCharges(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanPublishResponse>> Publish(
        PlanPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PlanPublishParams> request = new()
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
                    .Deserialize<PlanPublishResponse>(token)
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
    public Task<HttpResponse<PlanPublishResponse>> Publish(
        string id,
        PlanPublishParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        return this.Publish(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<PlanRemoveDraftResponse>> RemoveDraft(
        PlanRemoveDraftParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<PlanRemoveDraftParams> request = new()
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
                    .Deserialize<PlanRemoveDraftResponse>(token)
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
    public Task<HttpResponse<PlanRemoveDraftResponse>> RemoveDraft(
        string id,
        PlanRemoveDraftParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.RemoveDraft(parameters with { ID = id }, cancellationToken);
    }
}
