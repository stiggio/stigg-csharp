using System.Net.Http;

namespace Stigg.Exceptions;

public class Stigg4xxException : StiggApiException
{
    public Stigg4xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
