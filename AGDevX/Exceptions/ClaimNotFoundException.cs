using System;

namespace AGDevX.Exceptions
{
    public sealed class ClaimNotFoundException : AGDevXException
    {
        public override int HttpStatusCode => (int)System.Net.HttpStatusCode.Unauthorized;
        public override string Code => "AGDX_CLAIM_NOT_FOUND_EXCEPTION";

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