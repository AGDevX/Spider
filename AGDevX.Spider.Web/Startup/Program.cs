using Microsoft.AspNetCore.Builder;

namespace AGDevX.Spider.Web.Startup
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApi = BuildWebApi(args);
            webApi.Run();
        }

        public static WebApplication BuildWebApi(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            var apiConfig = builder.Services.ConfigureServices(configuration);

            var webApi = builder.Build();
            
            webApi.ConfigureMiddlware(apiConfig);

            return webApi;
        }
    }
}