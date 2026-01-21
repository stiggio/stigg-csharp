using System.Net.Http;

namespace Stigg.Exceptions;

public class StiggUnauthorizedException : Stigg4xxException
{
    public StiggUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
