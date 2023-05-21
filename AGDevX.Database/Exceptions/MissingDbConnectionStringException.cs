using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class MissingDbConnectionStringException : CodedApplicationException
{
    public override string Code { get; set; } = "MISSING_DATABASE_CONNECTION_STRING_EXCEPTION";

    public MissingDbConnectionStringException()
    {
    }

    public MissingDbConnectionStringException(string message) : base(message)
    {
    }

    public MissingDbConnectionStringException(string message, string code) : base(message, code)
    {
        Code = code;
    }

    public MissingDbConnectionStringException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public MissingDbConnectionStringException(string message, string code, Exception innerException) : base(message, code, innerException)
    {
        Code = code;
    }
}