using System;

namespace AGDevX.Enums;

[AttributeUsage(AttributeTargets.Field)]
public sealed class EnumStringValueAttribute : Attribute
{
    public string Value { get; }

    public EnumStringValueAttribute(string value)
    {
        Value = value;
    }
}