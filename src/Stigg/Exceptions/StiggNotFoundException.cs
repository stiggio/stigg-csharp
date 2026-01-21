using System.Net.Http;

namespace Stigg.Exceptions;

public class StiggNotFoundException : Stigg4xxException
{
    public StiggNotFoundException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
