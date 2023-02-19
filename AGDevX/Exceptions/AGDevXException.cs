using System;

namespace AGDevX.Exceptions
{
    public class AGDevXException : ApplicationException
    {
        public virtual int HttpStatusCode => (int)System.Net.HttpStatusCode.InternalServerError;
        public virtual string Code => "AGDX_EXCEPTION";

        public AGDevXException()
        {
        }

        public AGDevXException(string message) : base(message)
        {
        }

        public AGDevXException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}