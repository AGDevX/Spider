using Microsoft.AspNetCore.Http;

namespace AGDevX.Web.Responses;

public sealed class CreatedResponse<T> : JsonResponse<T>
{
    public CreatedResponse() : base(StatusCodes.Status201Created)
    {
    }
}