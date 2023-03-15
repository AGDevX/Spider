using System;
using AGDevX.Exceptions;

namespace AGDevX.Database.Exceptions;

public sealed class MissingSprocArgument : AGDevXException
{
    public override int HttpStatusCode => (int)System.Net.HttpStatusCode.InternalServerError;
    public override string Code => "AGDX_MISSING_SPROC_ARG_EXCEPTION";

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