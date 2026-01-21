using System.Net.Http;

namespace Stigg.Exceptions;

public class Stigg5xxException : StiggApiException
{
    public Stigg5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
