using System;

namespace AGDevX.Exceptions;

public sealed class AcquireTokenException : CodedException
{
    public override string Code => "ACQUIRE_TOKEN_EXCEPTION";

    public AcquireTokenException()
    {
    }

    public AcquireTokenException(string message) : base(message)
    {
    }

    public AcquireTokenException(string message, Exception innerException) : base(message, innerException)
    {
    }
}