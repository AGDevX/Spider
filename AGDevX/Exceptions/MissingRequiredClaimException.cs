using System;

namespace AGDevX.Exceptions;

public sealed class MissingRequiredClaimException : AGDevXException
{
    public override int HttpStatusCode => (int)System.Net.HttpStatusCode.Unauthorized;
    public override string Code => "AGDX_MISSING_REQUIRED_CLAIM_EXCEPTION";

    public MissingRequiredClaimException()
    {
    }

    public MissingRequiredClaimException(string message) : base(message)
    {
    }

    public MissingRequiredClaimException(string message, Exception innerException) : base(message, innerException)
    {
    }
}