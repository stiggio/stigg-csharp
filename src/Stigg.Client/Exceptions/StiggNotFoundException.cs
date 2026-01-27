using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggNotFoundException : Stigg4xxException
{
    public StiggNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
