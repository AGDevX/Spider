using AGDevX.Amara.Api.User.Middleware;
using AGDevX.Enums;
using AGDevX.Environments;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Strings;
using AGDevX.Web.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace AGDevX.Spider.WebApi.Startup
{
    public static class Middlware
    {
        public static WebApplication ConfigureMiddlware(this WebApplication webApi, ApiConfig apiConfig)
        {
            if (apiConfig.Environment.IsOneOf(EnvironmentType.Local)
                || webApi.Environment.EnvironmentName.ToString().EqualsIgnoreCase(EnvironmentType.Local.StringValue())
                || webApi.Environment.IsDevelopment())
            {
            }

            webApi.UseHsts();
            webApi.UseHttpsRedirection();

            webApi.UseCors(apiConfig.Security.CorsPolicy);

            webApi.UseAuthentication();
            webApi.UseAuthorization();
            webApi.UseUserAuthentication();

            webApi.UseSwaggerForApi();

            webApi.MapControllers();

            return webApi;
        }
    }
}