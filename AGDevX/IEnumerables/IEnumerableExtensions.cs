using System;
using System.Collections.Generic;
using System.Linq;

namespace AGDevX.IEnumerables
{
    public static class IEnumerableExtensions
    {
        public static bool HasCommonElement(this IEnumerable<string> enumerable1, IEnumerable<string> enumerable2, StringComparer? stringComparer = default)
        {
            if (enumerable1 == null)
            {
                throw new ArgumentNullException($"The provided { nameof(enumerable1) } argument was null");
            }

            if (enumerable2 == null)
            {
                throw new ArgumentNullException($"The provided { nameof(enumerable2) } argument was null");
            }

            stringComparer ??= StringComparer.OrdinalIgnoreCase;

            return enumerable1.Intersect(enumerable2, stringComparer).Any();
        }
    }
}