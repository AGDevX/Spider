using System;
using System.Diagnostics.CodeAnalysis;

namespace AGDevX.Strings;

public static class StringExtensions
{
    public static bool EqualsIgnoreCase(this string? sourceString, string? equals, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
    {
        if (sourceString == null || equals == null)
        {
            return false;
        }

        return sourceString.Equals(equals, stringComparison);
    }

    public static bool StartsWithIgnoreCase(this string? sourceString, string? startsWith, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
    {
        if (sourceString == null || startsWith == null)
        {
            return false;
        }

        return sourceString.StartsWith(startsWith, stringComparison);
    }

    public static bool ContainsIgnoreCase(this string? sourceString, string? contains, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
    {
        if (sourceString == null || contains == null)
        {
            return false;
        }

        return sourceString.Contains(contains, stringComparison);
    }

    public static bool IsNullOrWhiteSpace([NotNullWhen(false)] this string? str)
    {
        return string.IsNullOrWhiteSpace(str);
    }

    public static bool IsNotNullOrWhiteSpace([NotNullWhen(true)] this string? str)
    {
        return !string.IsNullOrWhiteSpace(str);
    }
}