using System;

namespace AGDevX.Exceptions;

public sealed class ApplicationStartupException : CodedException
{
    public override string Code => "APPLICATION_STARTUP_EXCEPTION";

    public ApplicationStartupException()
    {
    }

    public ApplicationStartupException(string message) : base(message)
    {
    }

    public ApplicationStartupException(string message, Exception innerException) : base(message, innerException)
    {
    }
}