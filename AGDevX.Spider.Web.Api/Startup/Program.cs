using AGDevX.Spider.Web.Api.Startup;
using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

var apiConfig = builder.Services.ConfigureServices(configuration);

var webApi = builder.Build();

webApi.ConfigureMiddlware(apiConfig);

webApi.Run();