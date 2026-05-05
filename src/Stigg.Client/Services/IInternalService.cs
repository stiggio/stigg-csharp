using System;
using Stigg.Client.Core;
using Stigg.Client.Services.Internal;

namespace Stigg.Client.Services;

/// <summary>
/// NOTE: Do not inherit from this type outside the SDK unless you're okay with breaking
/// changes in non-major versions. We may add new methods in the future that cause
/// existing derived classes to break.
/// </summary>
public interface IInternalService
{
    /// <summary>
    /// Returns a view of this service that provides access to raw HTTP responses
    /// for each method.
    /// </summary>
    IInternalServiceWithRawResponse WithRawResponse { get; }

    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInternalService WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBetaService Beta { get; }
}

/// <summary>
/// A view of <see cref="IInternalService"/> that provides access to raw
/// HTTP responses for each method.
/// </summary>
public interface IInternalServiceWithRawResponse
{
    /// <summary>
    /// Returns a view of this service with the given option modifications applied.
    ///
    /// <para>The original service is not modified.</para>
    /// </summary>
    IInternalServiceWithRawResponse WithOptions(Func<ClientOptions, ClientOptions> modifier);

    IBetaServiceWithRawResponse Beta { get; }
}
