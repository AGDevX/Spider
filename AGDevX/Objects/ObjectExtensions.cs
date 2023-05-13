using System.Diagnostics.CodeAnalysis;

namespace AGDevX.Objects;

public static class ObjectExtensions
{
    public static bool IsNull([NotNullWhen(false)] this object? obj)
    {
        return obj == null;
    }

    public static bool IsNotNull([NotNullWhen(true)] this object? obj)
    {
        return obj != null;
    }
}