using AGDevX.Strings;
using Xunit;

namespace AGDevX.Tests.Strings;

public class StringExtensionsTests
{
    [Theory]
    [InlineData("equal", "EQUAL")]
    [InlineData("equal", "equal")]
    public void EqualsIgnoreCase_ReturnsTrue(string str1, string str2)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.EqualsIgnoreCase(str2);

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("equal", "not equal")]
    [InlineData(null, "not equal")]
    [InlineData("equal", null)]
    public void EqualsIgnoreCase_ReturnsFalse(string str1, string str2)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.EqualsIgnoreCase(str2);

        //-- Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("equal", "EQUAL")]
    [InlineData("equal", "equal")]
    public void StartsWithIgnoreCase_ReturnsTrue(string str1, string str2)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.StartsWithIgnoreCase(str2);

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("equal", "not equal")]
    [InlineData(null, "not equal")]
    [InlineData("equal", null)]
    public void StartsWithIgnoreCase_ReturnsFalse(string str1, string str2)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.StartsWithIgnoreCase(str2);

        //-- Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("equal", "EQUAL")]
    [InlineData("equal", "equal")]
    public void ContainsIgnoreCase_ReturnsTrue(string str1, string str2)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.ContainsIgnoreCase(str2);

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("equal", "not equal")]
    [InlineData(null, "not equal")]
    [InlineData("equal", null)]
    public void ContainsIgnoreCase_ReturnsFalse(string str1, string str2)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.ContainsIgnoreCase(str2);

        //-- Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("   ")]
    public void IsNullOrWhiteSpace_ReturnsTrue(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsNullOrWhiteSpace();

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("something")]
    public void IsNullOrWhiteSpace_ReturnsFalse(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsNullOrWhiteSpace();

        //-- Assert
        Assert.False(result);
    }
}