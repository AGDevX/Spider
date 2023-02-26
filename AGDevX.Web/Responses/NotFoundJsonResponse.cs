using Microsoft.AspNetCore.Http;

namespace AGDevX.Web.Responses
{
    public sealed class NotFoundJsonResponse<T> : JsonResponse<T>
    {
        public NotFoundJsonResponse() : base(StatusCodes.Status404NotFound)
        {
        }
    }
}