using Microsoft.AspNetCore.Http;

namespace AGDevX.Web.Responses
{
    public sealed class OkJsonResponse<T> : JsonResponse<T>
    {
        public OkJsonResponse() : base(StatusCodes.Status200OK)
        {
            Code = ApiResponseCode.Success;
        }
    }
}