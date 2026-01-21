using System;

namespace Stigg.Exceptions;

public class StiggInvalidDataException : StiggException
{
    public StiggInvalidDataException(string message, Exception? innerException = null)
        : base(message, innerException) { }
}
