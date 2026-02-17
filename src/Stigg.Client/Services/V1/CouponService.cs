using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Models.V1.Coupons;

namespace Stigg.Client.Services.V1;

/// <inheritdoc/>
public sealed class CouponService : ICouponService
{
    readonly Lazy<ICouponServiceWithRawResponse> _withRawResponse;

    /// <inheritdoc/>
    public ICouponServiceWithRawResponse WithRawResponse
    {
        get { return _withRawResponse.Value; }
    }

    readonly IStiggClient _client;

    /// <inheritdoc/>
    public ICouponService WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CouponService(this._client.WithOptions(modifier));
    }

    public CouponService(IStiggClient client)
    {
        _client = client;

        _withRawResponse = new(() => new CouponServiceWithRawResponse(client.WithRawResponse));
    }

    /// <inheritdoc/>
    public async Task<Coupon> Create(
        CouponCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Create(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Coupon> Retrieve(
        CouponRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.Retrieve(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Coupon> Retrieve(
        string id,
        CouponRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<CouponListPage> List(
        CouponListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.List(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public async Task<Coupon> ArchiveCoupon(
        CouponArchiveCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.ArchiveCoupon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Coupon> ArchiveCoupon(
        string id,
        CouponArchiveCouponParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveCoupon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<Coupon> UpdateCoupon(
        CouponUpdateCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        using var response = await this
            .WithRawResponse.UpdateCoupon(parameters, cancellationToken)
            .ConfigureAwait(false);
        return await response.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public Task<Coupon> UpdateCoupon(
        string id,
        CouponUpdateCouponParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateCoupon(parameters with { ID = id }, cancellationToken);
    }
}

/// <inheritdoc/>
public sealed class CouponServiceWithRawResponse : ICouponServiceWithRawResponse
{
    readonly IStiggClientWithRawResponse _client;

    /// <inheritdoc/>
    public ICouponServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier)
    {
        return new CouponServiceWithRawResponse(this._client.WithOptions(modifier));
    }

    public CouponServiceWithRawResponse(IStiggClientWithRawResponse client)
    {
        _client = client;
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Coupon>> Create(
        CouponCreateParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        HttpRequest<CouponCreateParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var coupon = await response.Deserialize<Coupon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    coupon.Validate();
                }
                return coupon;
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Coupon>> Retrieve(
        CouponRetrieveParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CouponRetrieveParams> request = new()
        {
            Method = HttpMethod.Get,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var coupon = await response.Deserialize<Coupon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    coupon.Validate();
                }
                return coupon;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Coupon>> Retrieve(
        string id,
        CouponRetrieveParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.Retrieve(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<CouponListPage>> List(
        CouponListParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        HttpRequest<CouponListParams> request = new()
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
                    .Deserialize<CouponListPageResponse>(token)
                    .ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    page.Validate();
                }
                return new CouponListPage(this, parameters, page);
            }
        );
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Coupon>> ArchiveCoupon(
        CouponArchiveCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CouponArchiveCouponParams> request = new()
        {
            Method = HttpMethod.Post,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var coupon = await response.Deserialize<Coupon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    coupon.Validate();
                }
                return coupon;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Coupon>> ArchiveCoupon(
        string id,
        CouponArchiveCouponParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.ArchiveCoupon(parameters with { ID = id }, cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<HttpResponse<Coupon>> UpdateCoupon(
        CouponUpdateCouponParams parameters,
        CancellationToken cancellationToken = default
    )
    {
        if (parameters.ID == null)
        {
            throw new StiggInvalidDataException("'parameters.ID' cannot be null");
        }

        HttpRequest<CouponUpdateCouponParams> request = new()
        {
            Method = StiggClientWithRawResponse.PatchMethod,
            Params = parameters,
        };
        var response = await this._client.Execute(request, cancellationToken).ConfigureAwait(false);
        return new(
            response,
            async (token) =>
            {
                var coupon = await response.Deserialize<Coupon>(token).ConfigureAwait(false);
                if (this._client.ResponseValidation)
                {
                    coupon.Validate();
                }
                return coupon;
            }
        );
    }

    /// <inheritdoc/>
    public Task<HttpResponse<Coupon>> UpdateCoupon(
        string id,
        CouponUpdateCouponParams? parameters = null,
        CancellationToken cancellationToken = default
    )
    {
        parameters ??= new();

        return this.UpdateCoupon(parameters with { ID = id }, cancellationToken);
    }
}
