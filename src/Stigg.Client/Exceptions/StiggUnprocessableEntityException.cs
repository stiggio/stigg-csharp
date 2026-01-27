using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggUnprocessableEntityException : Stigg4xxException
{
    public StiggUnprocessableEntityException(HttpRequestException? innerException = null)
        : base(innerException) { }
}
