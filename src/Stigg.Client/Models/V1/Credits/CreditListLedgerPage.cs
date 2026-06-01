using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Stigg.Client.Core;
using Stigg.Client.Exceptions;
using Stigg.Client.Services.V1;

namespace Stigg.Client.Models.V1.Credits;

/// <summary>
/// A single page from the paginated endpoint that <see cref="ICreditService.ListLedger(CreditListLedgerParams, CancellationToken)"/> queries.
/// </summary>
public sealed class CreditListLedgerPage(
    ICreditServiceWithRawResponse service,
    CreditListLedgerParams parameters,
    CreditListLedgerPageResponse response
) : IPage<CreditListLedgerResponse>
{
    /// <inheritdoc/>
    public IReadOnlyList<CreditListLedgerResponse> Items
    {
        get { return response.Data; }
    }

    /// <inheritdoc/>
    public bool HasNext()
    {
        try
        {
            return this.Items.Count > 0 && response.Pagination.Next != null;
        }
        catch (StiggInvalidDataException)
        {
            // If accessing the response data to determine if there's a next page failed, then just
            // assume there's no next page.
            return false;
        }
    }

    /// <inheritdoc/>
    async Task<IPage<CreditListLedgerResponse>> IPage<CreditListLedgerResponse>.Next(
        CancellationToken cancellationToken
    ) => await this.Next(cancellationToken).ConfigureAwait(false);

    /// <inheritdoc cref="IPage{T}.Next"/>
    public async Task<CreditListLedgerPage> Next(CancellationToken cancellationToken = default)
    {
        var nextCursor =
            response.Pagination.Next
            ?? throw new InvalidOperationException("Cannot request next page");
        using var nextResponse = await service
            .ListLedger(parameters with { After = nextCursor }, cancellationToken)
            .ConfigureAwait(false);
        return await nextResponse.Deserialize(cancellationToken).ConfigureAwait(false);
    }

    /// <inheritdoc/>
    public void Validate()
    {
        response.Validate();
    }

    public override string ToString() =>
        JsonSerializer.Serialize(
            FriendlyJsonPrinter.PrintValue(JsonSerializer.SerializeToElement(this.Items)),
            ModelBase.ToStringSerializerOptions
        );

    public override bool Equals(object? obj)
    {
        if (obj is not CreditListLedgerPage other)
        {
            return false;
        }

        return Enumerable.SequenceEqual(this.Items, other.Items);
    }

    public override int GetHashCode() => 0;
}
