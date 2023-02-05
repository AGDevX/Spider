using System;
using System.Collections.Generic;
using System.Linq;

namespace AGDevX.Strings
{
    public static class DictionaryExtensions
    {
#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
        public static Dictionary<TValue, TKey> ReverseKeysAndValues<TKey, TValue>(this Dictionary<TKey, TValue> dictionary)
        {
            if (dictionary == null)
            {
                throw new ArgumentNullException($"The provided { nameof(dictionary) } argument was null");
            }

            return dictionary.ToDictionary(x => x.Value, x => x.Key);
        }
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
    }
}