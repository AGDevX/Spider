using System;

namespace AGDevX.Exceptions
{
    public sealed class MissingRequiredClaimException : ApplicationException
    {
        public MissingRequiredClaimException()
        {
        }

        public MissingRequiredClaimException(string message) : base(message)
        {
        }

        public MissingRequiredClaimException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}