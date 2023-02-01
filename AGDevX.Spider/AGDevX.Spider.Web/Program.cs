namespace AGDevX.Spider.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var webApp = BuildWebApp(args);
            ConfigureMiddlware(webApp);
            webApp.Run();
        }

        public static WebApplication BuildWebApp(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var webApp = builder.Build();

            return webApp;
        }

        public static WebApplication ConfigureMiddlware(WebApplication webApp)
        {
            if (webApp.Environment.IsDevelopment())
            {
                webApp.UseSwagger();
                webApp.UseSwaggerUI();
            }

            webApp.UseHttpsRedirection();
            webApp.UseAuthorization();
            webApp.MapControllers();

            return webApp;
        }
    }
}