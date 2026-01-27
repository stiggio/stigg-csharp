using System;
using System.Net.Http;

namespace Stigg.Client.Exceptions;

public class StiggIOException : StiggException
{
    public new HttpRequestException InnerException
    {
        get
        {
            if (base.InnerException == null)
            {
                throw new ArgumentNullException();
            }
            return (HttpRequestException)base.InnerException;
        }
    }

    public StiggIOException(string message, HttpRequestException? innerException = null)
        : base(message, innerException) { }
}
