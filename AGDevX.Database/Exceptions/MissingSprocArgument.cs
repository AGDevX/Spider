using System;

namespace AGDevX.Database.Exceptions
{
    public sealed class MissingSprocArgument : ApplicationException
    {
        public MissingSprocArgument()
        {
        }

        public MissingSprocArgument(string message) : base(message)
        {
        }

        public MissingSprocArgument(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}