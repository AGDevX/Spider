using System;

namespace AGDevX.Strings
{
    public static class StringExtensions
    {
        public static bool EqualsIgnoreCase(this string sourceString, string equals, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (sourceString == null)
            {
                throw new ArgumentNullException($"The { sourceString } parameter was null");
            }

            if (equals == null)
            {
                throw new ArgumentNullException($"The { equals } parameter was null");
            }

            return sourceString.Equals(equals, stringComparison);
        }

        public static bool StartsWithIgnoreCase(this string sourceString, string startsWith, StringComparison stringComparison = StringComparison.OrdinalIgnoreCase)
        {
            if (sourceString == null)
            {
                throw new ArgumentNullException($"The { sourceString } parameter was null");
            }

            if (startsWith == null)
            {
                throw new ArgumentNullException($"The { startsWith } parameter was null");
            }

            return sourceString.StartsWith(startsWith, stringComparison);
        }
    }
}