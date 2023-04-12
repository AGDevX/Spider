using System.Linq;
using AGDevX.Enums;
using AGDevX.Environments;
using AGDevX.IEnumerables;
using Microsoft.Extensions.Hosting;

namespace AGDevX.Hosts;

public static class IHostEnvironmentExtensions
{
    public static bool IsOneOf(this IHostEnvironment? webHostEnvironment, params EnvironmentType[]? environments)
    {
        if (webHostEnvironment == null || environments.IsNullOrEmpty())
        {
            return false;
        }

        return environments!.Select(env => env.StringValue()).ContainsIgnoreCase(webHostEnvironment.EnvironmentName);
    }
}