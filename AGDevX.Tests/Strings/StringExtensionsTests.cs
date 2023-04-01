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

    [Theory]
    [InlineData("something")]
    public void IsNotNullOrWhiteSpace_ReturnsTrue(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsNotNullOrWhiteSpace();

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("   ")]
    public void IsNotNullOrWhiteSpace_ReturnsFalse(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsNotNullOrWhiteSpace();

        //-- Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("        ")]
    public void IsWhiteSpace_ReturnsTrue(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsWhiteSpace();

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("a")]
    [InlineData(" b")]
    [InlineData("c ")]
    [InlineData(" d ")]
    [InlineData(" . ")]
    public void IsWhiteSpace_ReturnsFalse(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsWhiteSpace();

        //-- Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("a")]
    [InlineData(" b")]
    [InlineData("c ")]
    [InlineData(" d ")]
    [InlineData(" . ")]
    public void IsNotWhiteSpace_ReturnsTrue(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsNotWhiteSpace();

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(" ")]
    [InlineData("        ")]
    public void IsNotWhiteSpace_ReturnsFalse(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsNotWhiteSpace();

        //-- Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("")]
    public void IsEmpty_ReturnsTrue(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsEmpty();

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("a")]
    [InlineData(" b")]
    [InlineData("c ")]
    [InlineData(" d ")]
    [InlineData(" . ")]
    [InlineData(" ")]
    [InlineData("      ")]
    public void IsEmpty_ReturnsFalse(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsEmpty();

        //-- Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("a")]
    [InlineData(" b")]
    [InlineData("c ")]
    [InlineData(" d ")]
    [InlineData(" . ")]
    [InlineData(" ")]
    [InlineData("      ")]
    public void IsNotEmpty_ReturnsTrue(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsNotEmpty();

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("")]
    public void IsNotEmpty_ReturnsFalse(string str1)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = str1.IsNotEmpty();

        //-- Assert
        Assert.False(result);
    }
}