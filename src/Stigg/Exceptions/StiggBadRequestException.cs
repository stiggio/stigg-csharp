using System.Net.Http;

namespace Stigg.Exceptions;

public class StiggBadRequestException : Stigg4xxException
{
    public StiggBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
