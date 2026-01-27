using System;
using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggException : Exception
{
    public StiggException(string message, Exception? innerException = null)
        : base(message, innerException) { }

    protected StiggException(HttpRequestException? innerException)
        : base(null, innerException) { }
}
