using AGDevX.Objects;
using Xunit;

namespace AGDevX.Tests.Objects;

public class ObjectExtensionsTests
{
    [Theory]
    [InlineData(null)]
    public void IsNull_ReturnsTrue(object obj)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = obj.IsNull();

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(1)]
    [InlineData(1.0)]
    [InlineData(char.MinValue)]
    [InlineData(' ')]
    [InlineData('`')]
    public void IsNull_ReturnsFalse(object obj)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = obj.IsNull();

        //-- Assert
        Assert.False(result);
    }

    [Theory]
    [InlineData("a")]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(1)]
    [InlineData(1.0)]
    [InlineData(char.MinValue)]
    [InlineData(' ')]
    [InlineData('`')]
    public void IsNotNull_ReturnsTrue(object obj)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = obj.IsNotNull();

        //-- Assert
        Assert.True(result);
    }

    [Theory]
    [InlineData(null)]
    public void IsNotNull_ReturnsFalse(object obj)
    {
        //-- Arrange
        //-- <see InlineData>

        //-- Act
        var result = obj.IsNotNull();

        //-- Assert
        Assert.False(result);
    }
}