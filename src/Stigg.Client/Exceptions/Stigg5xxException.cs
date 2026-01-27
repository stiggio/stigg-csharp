using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class Stigg5xxException : StiggApiException
{
    public Stigg5xxException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
