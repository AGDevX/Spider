using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Net;
using System.Threading.Tasks;
using AGDevX.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace AGDevX.Web.Exceptions;

public class UnhandledExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<UnhandledExceptionMiddleware> _logger;
    private readonly IEnumerable<string> _assemblyPrefixes;
    public UnhandledExceptionMiddleware(RequestDelegate next, ILogger<UnhandledExceptionMiddleware> logger, IEnumerable<string>? assemblyPrefixes = default)
    {
        _next = next;
        _logger = logger;
        _assemblyPrefixes = assemblyPrefixes ?? new List<string>();
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        ExceptionDetail exceptionDetail;

        switch (exception)
        {
            case AGDevXException agdxEx:
                _logger.LogError(agdxEx, agdxEx.Message);
                context.Response.StatusCode = agdxEx.HttpStatusCode;
                exceptionDetail = agdxEx.CreateExceptionDetail(context.Response.StatusCode, agdxEx.Code, true, true, _assemblyPrefixes);
                break;
            case SqlException sqlEx:
                _logger.LogError(sqlEx, sqlEx.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                exceptionDetail = sqlEx.CreateExceptionDetail(context.Response.StatusCode, "SQL_EXCEPTION", true, true, _assemblyPrefixes);
                break;
            case Exception ex:
                _logger.LogError(ex, ex.Message);
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                exceptionDetail = ex.CreateExceptionDetail(context.Response.StatusCode, HttpStatusCode.InternalServerError.ToString(), true, true, _assemblyPrefixes);
                break;
            default:
                throw new Exception("Unable to determine exception type");
        }

        await context.Response.WriteAsync(JsonConvert.SerializeObject(exceptionDetail));
    }
}

public static class UnhandledExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseUnhandledExceptionMiddleware(this IApplicationBuilder builder, IEnumerable<string>? assemblyPrefixes = default)
    {
        return builder.UseMiddleware<UnhandledExceptionMiddleware>(assemblyPrefixes);
    }
}