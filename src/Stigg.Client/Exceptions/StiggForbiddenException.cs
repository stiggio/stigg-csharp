using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggForbiddenException : Stigg4xxException
{
    public StiggForbiddenException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
