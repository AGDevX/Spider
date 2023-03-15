using AGDevX.Enums;
using AGDevX.Environments;
using AGDevX.Spider.WebApi.AuthZ;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Strings;
using AGDevX.Web.Exceptions;
using AGDevX.Web.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace AGDevX.Spider.WebApi.Startup;

public static class Middlware
{
    public static WebApplication ConfigureMiddlware(this WebApplication webApi, ApiConfig apiConfig)
    {
        if (apiConfig.Environment.IsOneOf(EnvironmentType.Local)
            || webApi.Environment.EnvironmentName.ToString().EqualsIgnoreCase(EnvironmentType.Local.StringValue())
            || webApi.Environment.IsDevelopment())
        {
        }

        webApi.UseSerilogRequestLogging();
        webApi.UseUnhandledExceptionMiddleware(apiConfig.Solution.AssemblyPrefixes);

        webApi.UseHsts();
        webApi.UseHttpsRedirection();

        webApi.UseCors(apiConfig.Security.CorsPolicy);

        webApi.UseAuthentication();
        webApi.UseAuthorization();
        webApi.UseUserAuthorization();

        webApi.UseSwaggerForApi();

        webApi.MapControllers();

        return webApi;
    }
}