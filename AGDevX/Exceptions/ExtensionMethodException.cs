using System;

namespace AGDevX.Exceptions;

public sealed class ExtensionMethodException : CodedException
{
    public override string Code => "EXTENSION_METHOD_EXCEPTION";

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