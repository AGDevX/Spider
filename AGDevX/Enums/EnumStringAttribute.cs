using System;

namespace AGDevX.Enums
{
    [AttributeUsage(AttributeTargets.Field)]
    public class EnumStringValueAttribute : Attribute
    {
        public string Value { get; }

        public EnumStringValueAttribute(string value)
        {
            Value = value;
        }
    }
}