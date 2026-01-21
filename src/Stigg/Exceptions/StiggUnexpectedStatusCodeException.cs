using System.Net.Http;

namespace Stigg.Exceptions;

public class StiggUnexpectedStatusCodeException : StiggApiException
{
    public StiggUnexpectedStatusCodeException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
