using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class DatabaseProviderNotSupportedException : CodedApplicationException
{
    public override string Code { get; set; } = "DATABASE_PROVIDER_NOT_SUPPORTED_EXCEPTION";

    public DatabaseProviderNotSupportedException()
    {
    }

    public DatabaseProviderNotSupportedException(string message) : base(message)
    {
    }

    public DatabaseProviderNotSupportedException(string message, string code) : base(message, code)
    {
        Code = code;
    }

    public DatabaseProviderNotSupportedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public DatabaseProviderNotSupportedException(string message, string code, Exception innerException) : base(message, code, innerException)
    {
        Code = code;
    }
}