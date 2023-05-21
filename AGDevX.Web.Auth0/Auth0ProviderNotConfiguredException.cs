using System;
using AGDevX.Exceptions;

namespace AGDevX.Web.Auth0;

public sealed class Auth0ProviderNotConfiguredException : CodedApplicationException
{
    public override string Code { get; set; } = "AUTH0_PROVIDER_NOT_CONFIGURED_EXCEPTION";

    public Auth0ProviderNotConfiguredException()
    {
    }

    public Auth0ProviderNotConfiguredException(string message) : base(message)
    {
    }

    public Auth0ProviderNotConfiguredException(string message, string code) : base(message, code)
    {
        Code = code;
    }

    public Auth0ProviderNotConfiguredException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public Auth0ProviderNotConfiguredException(string message, string code, Exception innerException) : base(message, code, innerException)
    {
        Code = code;
    }
}