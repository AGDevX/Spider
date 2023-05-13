using AGDevX.IEnumerables;
using Microsoft.Extensions.Hosting;

namespace AGDevX.Hosts;

public static class IHostEnvironmentExtensions
{
    public static bool IsOneOf(this IHostEnvironment? webHostEnvironment, params string[]? environments)
    {
        if (webHostEnvironment == null || environments.IsNullOrEmpty())
        {
            return false;
        }

        return environments!.ContainsIgnoreCase(webHostEnvironment.EnvironmentName);
    }
}