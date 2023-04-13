using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class DatabaseProviderNotSupportedException : CodedException
{
    public override string Code => "DATABASE_PROVIDER_NOT_SUPPORTED_EXCEPTION";

    public DatabaseProviderNotSupportedException()
    {
    }

    public DatabaseProviderNotSupportedException(string message) : base(message)
    {
    }

    public DatabaseProviderNotSupportedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}