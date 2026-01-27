using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggUnauthorizedException : Stigg4xxException
{
    public StiggUnauthorizedException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
