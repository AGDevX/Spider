using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AGDevX.Web.Responses
{
    /// <summary>
    /// Provides a standard way of returning request state, developer messages, and JSON data from the API. If non-JSON data needs to be returned then another ApiResponse type must be used.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class JsonResponse<T> : IActionResult, IStatusCodeActionResult
    {
        public int? StatusCode { get; }

        public ApiResponseCodes Code { get; set; }
        public List<string> Messages { get; set; } = new();
        public T? Value { get; set; } = default;

        public JsonResponse(int? httpStatusCode = default)
        {
            StatusCode = httpStatusCode;
        }

        //-- https://stackoverflow.com/a/59407866/5372598
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var response = context.HttpContext.Response;

            response.StatusCode = StatusCode ?? throw new HttpStatusCodeNotProvidedException("An HTTP Status Code was not provided to the ApiResponse<T> object");

            await response.WriteAsJsonAsync(new
            {
                Code,
                Messages,
                Value
            });
        }
    }
}