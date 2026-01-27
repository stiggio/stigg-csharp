using System;

namespace Stigg.Client.Exceptions;

public class StiggInvalidDataException : StiggException
{
    public StiggInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
