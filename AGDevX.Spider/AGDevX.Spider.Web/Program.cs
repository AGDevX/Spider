using AGDevX.Web.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AGDevX.Spider.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApi = BuildWebApi(args);

            ConfigureMiddlware(webApi);
            
            webApi.Run();
        }

        public static WebApplication BuildWebApi(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerToApi();

            var webApi = builder.Build();

            return webApi;
        }

        public static WebApplication ConfigureMiddlware(WebApplication webApi)
        {
            if (webApi.Environment.IsDevelopment())
            {
                webApi.UseSwaggerForApi();
            }

            webApi.UseHttpsRedirection();
            webApi.UseAuthorization();
            webApi.MapControllers();

            return webApi;
        }
    }
}