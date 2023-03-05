using System;

namespace AGDevX.Exceptions;

public sealed class AcquireTokenException : AGDevXException
{
    public override int HttpStatusCode => (int)System.Net.HttpStatusCode.BadRequest;
    public override string Code => "AGDX_ACQUIRE_TOKEN_EXCEPTION";

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