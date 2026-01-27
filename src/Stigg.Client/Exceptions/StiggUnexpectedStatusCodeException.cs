using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggUnexpectedStatusCodeException : StiggApiException
{
    public StiggUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
