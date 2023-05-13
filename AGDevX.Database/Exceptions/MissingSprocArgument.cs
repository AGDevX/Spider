using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class MissingSprocArgument : CodedException
{
    public override string Code => "MISSING_SPROC_ARG_EXCEPTION";

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