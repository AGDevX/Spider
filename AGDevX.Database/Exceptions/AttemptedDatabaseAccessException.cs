using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class AttemptedDatabaseAccessException : CodedApplicationException
{
    public override string Code { get; set; } = "ATTEMPTED_DATABASE_ACCESS_EXCEPTION";

    public AttemptedDatabaseAccessException()
    {
    }

    public AttemptedDatabaseAccessException(string message) : base(message)
    {
    }

    public AttemptedDatabaseAccessException(string message, string code) : base(message, code)
    {
        Code = code;
    }

    public AttemptedDatabaseAccessException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public AttemptedDatabaseAccessException(string message, string code, Exception innerException) : base(message, code, innerException)
    {
        Code = code;
    }
}