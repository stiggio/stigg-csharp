using System.Net.Http;

namespace Stigg.Exceptions;

public class StiggRateLimitException : Stigg4xxException
{
    public StiggRateLimitException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
