using System;

namespace AGDevX.Exceptions;

public class CodedException : ApplicationException
{
    public virtual string Code => "CODED_EXCEPTION";

    public CodedException()
    {
    }

    public CodedException(string message) : base(message)
    {
    }

    public CodedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}