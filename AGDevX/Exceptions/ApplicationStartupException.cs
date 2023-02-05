using System;

namespace AGDevX.Exceptions
{
    public sealed class ApplicationStartupException : ApplicationException
    {
        public ApplicationStartupException()
        {
        }

        public ApplicationStartupException(string message) : base(message)
        {
        }

        public ApplicationStartupException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}