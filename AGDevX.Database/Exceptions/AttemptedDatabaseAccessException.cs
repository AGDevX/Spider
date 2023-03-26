using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class AttemptedDatabaseAccessException : AGDevXException
{
    public override int HttpStatusCode => (int)System.Net.HttpStatusCode.InternalServerError;
    public override string Code => "AGDX_ATTEMPTED_DATABASE_ACCESS_EXCEPTION";

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