using System;

namespace AGDevX.Exceptions
{
    public sealed class ExtensionMethodException : AGDevXException
    {
        public override int HttpStatusCode => (int)System.Net.HttpStatusCode.BadRequest;
        public override string Code => "AGDX_EXTENSION_METHOD_EXCEPTION";

        public ExtensionMethodException()
        {
        }

        public ExtensionMethodException(string message) : base(message)
        {
        }

        public ExtensionMethodException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}