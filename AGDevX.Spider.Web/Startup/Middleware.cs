using AGDevX.Enums;
using AGDevX.Environments;
using AGDevX.Strings;
using AGDevX.Web.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Hosting;

namespace AGDevX.Spider.Web.Startup
{
    public static class Middlware
    {
        public static WebApplication ConfigureMiddlware(this WebApplication webApi)
        {
            if (webApi.Environment.EnvironmentName.ToString().EqualsIgnoreCase(EnvironmentType.Local.StringValue()) || webApi.Environment.IsDevelopment())
            {
            }

            webApi.UseSwaggerForApi();
            webApi.UseHttpsRedirection();
            webApi.UseAuthorization();
            webApi.MapControllers();

            return webApi;
        }
    }
}