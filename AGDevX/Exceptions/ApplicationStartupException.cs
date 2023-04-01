using System;

namespace AGDevX.Exceptions;

public sealed class ApplicationStartupException : AGDevXException
{
    public override int HttpStatusCode => (int)System.Net.HttpStatusCode.InternalServerError;
    public override string Code => "AGDX_APPLICATION_STARTUP_EXCEPTION";

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