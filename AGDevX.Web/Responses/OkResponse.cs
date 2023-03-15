using Microsoft.AspNetCore.Http;

namespace AGDevX.Web.Responses;

public sealed class OkResponse<T> : JsonResponse<T>
{
    public OkResponse() : base(StatusCodes.Status200OK)
    {
        Code = ApiResponseCode.Success;
    }
}