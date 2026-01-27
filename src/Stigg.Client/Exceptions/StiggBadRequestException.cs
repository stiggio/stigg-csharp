using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggBadRequestException : Stigg4xxException
{
    public StiggBadRequestException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
