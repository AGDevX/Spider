using System;
using AGDevX.Exceptions;

namespace AGDevX.Web.Responses;

public sealed class HttpStatusCodeNotProvidedException : CodedApplicationException
{
    public override string Code { get; set; } = "HTTP_STATUS_CODE_NOT_PROVIDED_EXCEPTION";

    public HttpStatusCodeNotProvidedException()
    {
    }

    public HttpStatusCodeNotProvidedException(string message) : base(message)
    {
    }

    public HttpStatusCodeNotProvidedException(string message, string code) : base(message, code)
    {
        Code = code;
    }

    public HttpStatusCodeNotProvidedException(string message, Exception innerException) : base(message, innerException)
    {
    }

    public HttpStatusCodeNotProvidedException(string message, string code, Exception innerException) : base(message, code, innerException)
    {
        Code = code;
    }
}