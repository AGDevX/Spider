using System;

namespace AGDevX.Exceptions
{
    public sealed class ClaimNotFoundException : ApplicationException
    {
        public ClaimNotFoundException()
        {
        }

        public ClaimNotFoundException(string message) : base(message)
        {
        }

        public ClaimNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}