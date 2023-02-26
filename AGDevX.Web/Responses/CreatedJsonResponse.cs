using Microsoft.AspNetCore.Http;

namespace AGDevX.Web.Responses
{
    public sealed class CreatedJsonResponse<T> : JsonResponse<T>
    {
        public CreatedJsonResponse() : base(StatusCodes.Status201Created)
        {
        }
    }
}