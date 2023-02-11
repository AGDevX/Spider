using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AGDevX.Spider.Web.Api.AuthN
{
    public class UserIdentityMiddleware
    {
        private readonly RequestDelegate _next;

        public UserIdentityMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await _next(context);
        }
    }

    public static class UserIdentityMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserIdentity(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserIdentityMiddleware>();
        }
    }
}