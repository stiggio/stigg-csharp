using System.Net.Http;

namespace Stigg.Exceptions;

public class StiggUnprocessableEntityException : Stigg4xxException
{
    public StiggUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
