using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace AGDevX.Web.Tests.Extensions;
public class HostEnvironment : IHostEnvironment
{
    public required string EnvironmentName { get; set; }
    public required string ApplicationName { get; set; }
    public required string ContentRootPath { get; set; }
    public required IFileProvider ContentRootFileProvider { get; set; }
}