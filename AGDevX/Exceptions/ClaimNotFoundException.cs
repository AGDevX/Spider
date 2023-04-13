using System;

namespace AGDevX.Exceptions;

public sealed class ClaimNotFoundException : CodedException
{
    public override string Code => "CLAIM_NOT_FOUND_EXCEPTION";

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