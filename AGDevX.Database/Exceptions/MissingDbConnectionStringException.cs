using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class MissingDbConnectionStringException : CodedException
{
    public override string Code => "MISSING_DATABASE_CONNECTION_STRING_EXCEPTION";

    public MissingDbConnectionStringException()
    {
    }

    public MissingDbConnectionStringException(string message) : base(message)
    {
    }

    public MissingDbConnectionStringException(string message, Exception innerException) : base(message, innerException)
    {
    }
}