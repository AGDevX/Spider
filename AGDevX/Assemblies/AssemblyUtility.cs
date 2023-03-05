using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AGDevX.Strings;

namespace AGDevX.Assemblies
{
    public static class AssemblyUtility
    {
        public static List<Assembly> GetAssemblies(Assembly? parent, IEnumerable<string>? assemblyPrefixes)
        {
            var referencedAssemblies = parent?.GetReferencedAssemblies().Select(a => Assembly.Load(a));
            var currentDomainAssemblies = AppDomain.CurrentDomain.GetAssemblies();
            assemblyPrefixes ??= Enumerable.Empty<string>();

            return (referencedAssemblies ?? currentDomainAssemblies)
                .Where(a => !assemblyPrefixes.Any() || a.StartsWithPrefixes(assemblyPrefixes))
                .SelectMany(a => GetAssemblies(a, assemblyPrefixes))
                .Concat(parent == null ? Enumerable.Empty<Assembly>() : new[] { parent })
                .Where(a => !assemblyPrefixes.Any() || a.StartsWithPrefixes(assemblyPrefixes))
                .Distinct()
                .ToList();
        }

        public static bool AssemblyNameStartsWithAnyPrefix(string? assemblyName, IEnumerable<string>? assemblyPrefixes)
        {
            assemblyPrefixes ??= Enumerable.Empty<string>();

            return assemblyName.IsNullOrWhiteSpace()
                    ? false
                    : assemblyPrefixes.Any(ap => assemblyName!.StartsWithIgnoreCase(ap));
        }
    }
}