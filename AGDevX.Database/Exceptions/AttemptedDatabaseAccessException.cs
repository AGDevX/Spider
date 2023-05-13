using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class AttemptedDatabaseAccessException : CodedException
{
    public override string Code => "ATTEMPTED_DATABASE_ACCESS_EXCEPTION";

    public AttemptedDatabaseAccessException()
    {
    }

    public AttemptedDatabaseAccessException(string message) : base(message)
    {
    }

    public AttemptedDatabaseAccessException(string message, Exception innerException) : base(message, innerException)
    {
    }
}