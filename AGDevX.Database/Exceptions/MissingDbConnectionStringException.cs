using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions
{
    public sealed class MissingDbConnectionStringException : AGDevXException
    {
        public override int HttpStatusCode => (int)System.Net.HttpStatusCode.InternalServerError;
        public override string Code => "AGDX_MISSING_DATABASE_CONNECTION_STRING_EXCEPTION";

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
}