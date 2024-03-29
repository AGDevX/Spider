﻿using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AGDevX.Security;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Strings;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace AGDevX.Spider.WebApi.AuthZ;

public class UserAuthorizationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ApiConfig _apiConfig;

    public UserAuthorizationMiddleware(RequestDelegate next, ApiConfig apiConfig)
    {
        _next = next;
        _apiConfig = apiConfig;
    }

    public async Task Invoke(HttpContext httpContext)
    {
        var ignoreRequest = httpContext.Request.Path.HasValue ? httpContext.Request.Path.Value.ContainsIgnoreCase("swagger") : false;

        if (ignoreRequest)
        {
            await _next(httpContext);
        }
        else
        {
            if (httpContext.User.Identities.Any(i => i.Label?.EqualsIgnoreCase(_apiConfig.Api.Name) ?? false)
                || !httpContext.User.IsActive())
            {
                await _next(httpContext);
            }
            else
            {
                httpContext.Response.Clear();
                httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                await httpContext.Response.WriteAsync("The current user is not authorized to make this call");
                return;
            }
        }
    }
}

public static class UserAuthorizationMiddlewareExtensions
{
    public static IApplicationBuilder UseUserAuthorization(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<UserAuthorizationMiddleware>();
    }
}