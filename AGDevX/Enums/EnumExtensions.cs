using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Reflection;

namespace AGDevX.Enums
{
    public static class EnumExtensions
    {
        private static readonly ConcurrentDictionary<string, string> _displayNameCache = new();

        public static string StringValue(this Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException($"The provided { value } was null");
            }

            var key = $"{ value.GetType().FullName }.{ value }";

            var stringValue = _displayNameCache.GetOrAdd(key, x =>
            {
                var stringValues = (EnumStringValueAttribute[])value.GetType()
                                                                   !.GetTypeInfo()
                                                                   !.GetField(value.ToString())
                                                                   !.GetCustomAttributes(typeof(EnumStringValueAttribute), false);

                return stringValues.Length > 0 ? stringValues[0].Value : value.ToString();
            });

            return stringValue;
        }

        public static bool IsOneOf(this Enum enumeration, params Enum[] enums)
        {
            return enums.Contains(enumeration);
        }
    }
}