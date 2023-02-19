using System;

namespace AGDevX.Exceptions
{
    public sealed class NotAuthorizedException : AGDevXException
    {
        public override int HttpStatusCode => (int)System.Net.HttpStatusCode.Unauthorized;
        public override string Code => "AGDX_NOT_AUTHORIZED_EXCEPTION";

        public NotAuthorizedException()
        {
        }

        public NotAuthorizedException(string message) : base(message)
        {
        }

        public NotAuthorizedException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}