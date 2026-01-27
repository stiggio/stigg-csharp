using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggRateLimitException : Stigg4xxException
{
    public StiggRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
