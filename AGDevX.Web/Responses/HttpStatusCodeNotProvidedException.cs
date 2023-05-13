using System;
using AGDevX.Exceptions;

namespace AGDevX.Web.Responses;

public sealed class HttpStatusCodeNotProvidedException : CodedException
{
    public override string Code => "HTTP_STATUS_CODE_NOT_PROVIDED_EXCEPTION";

    public HttpStatusCodeNotProvidedException()
    {
    }

    public HttpStatusCodeNotProvidedException(string message) : base(message)
    {
    }

    public HttpStatusCodeNotProvidedException(string message, Exception innerException) : base(message, innerException)
    {
    }
}