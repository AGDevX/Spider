using System.Reflection;
using AGDevX.Assemblies;
using Xunit;

namespace AGDevX.Tests.Assemblies;

public class AssemblyExtensionsTests
{
    [Fact]
    public void StartsWithPrefix_DoesStartWithMixedCase_ReturnsTrue()
    {
        //-- Arrange
        var assembly = Assembly.GetExecutingAssembly();
        var prefix = "AGDevX";

        //-- Act
        var startsWith = assembly.StartsWithPrefix(prefix);

        //-- Assert
        Assert.True(startsWith);
    }

    [Fact]
    public void StartsWithPrefix_DoesStartWithLowerCase_ReturnsTrue()
    {
        //-- Arrange
        var assembly = Assembly.GetExecutingAssembly();
        var prefix = "agdevx";

        //-- Act
        var startsWith = assembly.StartsWithPrefix(prefix);

        //-- Assert
        Assert.True(startsWith);
    }

    [Fact]
    public void StartsWithPrefix_DoesStartWithUpperCase_ReturnsTrue()
    {
        //-- Arrange
        var assembly = Assembly.GetExecutingAssembly();
        var prefix = "AGDEVX";

        //-- Act
        var startsWith = assembly.StartsWithPrefix(prefix);

        //-- Assert
        Assert.True(startsWith);
    }

    [Fact]
    public void StartsWithPrefix_DoesNotStartWith_ReturnsFalse()
    {
        //-- Arrange
        var assembly = Assembly.GetExecutingAssembly();
        var prefix = "MRSG";

        //-- Act
        var startsWith = assembly.StartsWithPrefix(prefix);

        //-- Assert
        Assert.False(startsWith);
    }

    [Fact]
    public void StartsWithPrefixes_DoesStartWithOnePrefix_ReturnsTrue()
    {
        //-- Arrange
        var assembly = Assembly.GetExecutingAssembly();
        var prefixes = new List<string>
        {
            "AGDevX"
        };

        //-- Act
        var anyStartsWith = assembly.StartsWithPrefixes(prefixes);

        //-- Assert
        Assert.True(anyStartsWith);
    }

    [Fact]
    public void StartsWithPrefixes_DoesNotStartWithOnePrefix_ReturnsFalse()
    {
        //-- Arrange
        var assembly = Assembly.GetExecutingAssembly();
        var prefixes = new List<string>
        {
            "MRSG"
        };

        //-- Act
        var anyStartsWith = assembly.StartsWithPrefixes(prefixes);

        //-- Assert
        Assert.False(anyStartsWith);
    }

    [Fact]
    public void StartsWithPrefixes_DoesStartWithMultiplePrefixes_ReturnsTrue()
    {
        //-- Arrange
        var assembly = Assembly.GetExecutingAssembly();
        var prefixes = new List<string>
        {
            "AGDevX",
            "MRSG"
        };

        //-- Act
        var anyStartsWith = assembly.StartsWithPrefixes(prefixes);

        //-- Assert
        Assert.True(anyStartsWith);
    }

    [Fact]
    public void StartsWithPrefixes_NoPrefixes_ReturnsFalse()
    {
        //-- Arrange
        var assembly = Assembly.GetExecutingAssembly();
        var prefixes = new List<string>();

        //-- Act
        var anyStartsWith = assembly.StartsWithPrefixes(prefixes);

        //-- Assert
        Assert.False(anyStartsWith);
    }
}