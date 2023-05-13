using System;

namespace AGDevX.Exceptions;

public sealed class ExtensionMethodParameterNullException : CodedException
{
    public override string Code => "EXTENSION_METHOD_PARAMETER_NULL_EXCEPTION";

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