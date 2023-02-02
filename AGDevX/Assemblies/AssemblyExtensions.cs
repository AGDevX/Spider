using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AGDevX.Strings;

namespace AGDevX.Assemblies
{
    public static class AssemblyExtensions
    {
        public static bool StartsWithPrefix(this Assembly assembly, string prefix) => assembly.FullName?.StartsWithIgnoreCase(prefix) ?? throw new ArgumentNullException($"The provided { assembly } FullName was null");
        public static bool StartsWithPrefixes(this Assembly assembly, IEnumerable<string> prefixes) => prefixes.Any(p => StartsWithPrefix(assembly, p));
    }
}