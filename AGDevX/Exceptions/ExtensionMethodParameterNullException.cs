using System;

namespace AGDevX.Exceptions
{
    public sealed class ExtensionMethodParameterNullException : AGDevXException
    {
        public override int HttpStatusCode => (int)System.Net.HttpStatusCode.BadRequest;
        public override string Code => "AGDX_EXTENSION_METHOD_PARAMETER_NULL_EXCEPTION";

        public ExtensionMethodParameterNullException()
        {
        }

        public ExtensionMethodParameterNullException(string message) : base(message)
        {
        }

        public ExtensionMethodParameterNullException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}