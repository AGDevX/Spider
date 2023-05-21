using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class MissingSprocArgumentException : CodedArgumentNullException   
{
    public override string Code { get; set; } = "MISSING_SPROC_ARG_EXCEPTION";

    public MissingSprocArgumentException() : base()
    {
    }

    public MissingSprocArgumentException(string argumentName) : base(argumentName)
    {
    }

    public MissingSprocArgumentException(string argumentName, string code) : base(argumentName, code)
    {
        Code = code;
    }

    public MissingSprocArgumentException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public MissingSprocArgumentException(string argumentName, string code, Exception innerException) : base(argumentName, code, innerException)
    {
        Code = code;
    }
}