using Microsoft.AspNetCore.Http;

namespace AGDevX.Web.Responses;

public sealed class NotFoundResponse<T> : JsonResponse<T>
{
    public NotFoundResponse() : base(StatusCodes.Status404NotFound)
    {
    }
}