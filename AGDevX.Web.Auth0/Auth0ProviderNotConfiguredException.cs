using System;
using AGDevX.Exceptions;

namespace AGDevX.Web.Auth0;

public sealed class Auth0ProviderNotConfiguredException : CodedException
{
    public override string Code => "AUTH0_PROVIDER_NOT_CONFIGURED_EXCEPTION";

    public Auth0ProviderNotConfiguredException()
    {
    }

    public Auth0ProviderNotConfiguredException(string message) : base(message)
    {
    }

    public Auth0ProviderNotConfiguredException(string message, Exception innerException) : base(message, innerException)
    {
    }
}