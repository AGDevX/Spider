using System;

namespace AGDevX.Exceptions;

public sealed class NotAuthorizedException : CodedException
{
    public override string Code => "NOT_AUTHORIZED_EXCEPTION";

    public NotAuthorizedException()
    {
    }

    public NotAuthorizedException(string message) : base(message)
    {
    }

    public NotAuthorizedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}