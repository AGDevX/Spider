using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AGDevX.Strings;

namespace AGDevX.Assemblies;

public static class AssemblyExtensions
{
    public static bool FullNameStartsWithPrefix(this Assembly assembly, string prefix) => assembly.FullName?.StartsWithIgnoreCase(prefix) ?? throw new ArgumentNullException($"The provided { nameof(assembly) } FullName was null");
    public static bool FullNameStartsWithPrefixes(this Assembly assembly, IEnumerable<string> prefixes) => prefixes.Any(p => FullNameStartsWithPrefix(assembly, p));
}