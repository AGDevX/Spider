using System.Collections.Generic;
using System.Linq;
using AGDevX.Exceptions;

namespace AGDevX.IEnumerables;

public static class DictionaryExtensions
{
#pragma warning disable CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
    public static Dictionary<TValue, TKey> ReverseKeysAndValues<TKey, TValue>(this Dictionary<TKey, TValue>? dictionary)
    {
        if (dictionary == null)
        {
            throw new ExtensionMethodParameterNullException($"The provided { nameof(dictionary) } argument was null");
        }

        return dictionary.ToDictionary(x => x.Value, x => x.Key);
    }

    public static Dictionary<TKey, TValue> Concatenate<TKey, TValue>(this Dictionary<TKey, TValue>? dictionary1, Dictionary<TKey, TValue>? dictionary2)
    {
        if (dictionary1 == null)
        {
            throw new ExtensionMethodParameterNullException($"The provided { nameof(dictionary1) } argument was null");
        }

        if (dictionary2 == null)
        {
            throw new ExtensionMethodParameterNullException($"The provided { nameof(dictionary2) } argument was null");
        }

        return dictionary1.Concat(dictionary2).ToDictionary(x => x.Key, x => x.Value);
    }
#pragma warning restore CS8714 // The type cannot be used as type parameter in the generic type or method. Nullability of type argument doesn't match 'notnull' constraint.
}