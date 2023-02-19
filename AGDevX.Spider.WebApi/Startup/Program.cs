using System;
using AGDevX.Spider.WebApi.Startup;
using Microsoft.AspNetCore.Builder;
using Serilog;
using Serilog.Events;

try
{
    //-- Setup Serilog to provide logging while the application starts
    Log.Logger = new LoggerConfiguration()
                    .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
                    .Enrich.FromLogContext()
                    .WriteTo.Console()
                    .CreateBootstrapLogger();

    var builder = WebApplication.CreateBuilder(args);

    var configuration = builder.Configuration;

    var apiConfig = builder.ConfigureServices(configuration);

    var webApi = builder.Build();

    webApi.ConfigureMiddlware(apiConfig);

    webApi.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}