using System;

namespace AGDevX.Strings
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string sourceString, string equals, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (sourceString == null)
            {
                throw new ArgumentNullException($"The provided { nameof(sourceString) } argument was null");
            }

            if (equals == null)
            {
                throw new ArgumentNullException($"The provided { nameof(equals) } argument was null");
            }

            return sourceString.Equals(equals, stringComparison);
        }

        public static bool StartsWithIgnoreCase(this string sourceString, string startsWith, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (sourceString == null)
            {
                throw new ArgumentNullException($"The provided { nameof(sourceString) } argument was null");
            }

            if (startsWith == null)
            {
                throw new ArgumentNullException($"The provided { nameof(startsWith) } argument was null");
            }

            return sourceString.StartsWith(startsWith, stringComparison);
        }

        public static bool ContainsIgnoreCase(this string sourceString, string contains, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (sourceString == null)
            {
                throw new ArgumentNullException($"The provided {nameof(sourceString)} argument was null");
            }

            if (contains == null)
            {
                throw new ArgumentNullException($"The provided {nameof(contains)} argument was null");
            }

            return sourceString.Contains(contains, stringComparison);
        }

        public static bool IsNullOrWhiteSpace(this string? str)
        {
            return string.IsNullOrWhiteSpace(str);
        }
    }
}