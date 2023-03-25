using System;

namespace AGDevX.Exceptions;

public sealed class AuthProviderException : AGDevXException
{
    public override int HttpStatusCode => (int)System.Net.HttpStatusCode.InternalServerError;
    public override string Code => "AGDX_AUTH_PROVIDER_EXCEPTION";

    public AuthProviderException()
    {
    }

    public AuthProviderException(string message) : base(message)
    {
    }

    public AuthProviderException(string message, Exception innerException) : base(message, innerException)
    {
    }
}