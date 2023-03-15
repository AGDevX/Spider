using System.ComponentModel;
using AGDevX.Attributes;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Tests.Attributes;

public class AttributeExtensionsTests
{
    private enum TestEnum
    {
        [Description("From Cowboy Bebop")]
        Spike,
        [Description("From Ruroni Kenshin")]
        Kenshin,
        Vash
    }

    [Fact]
    public void GetDescription_ReturnsDescription()
    {
        //-- Arrange
        var description = "From Cowboy Bebop";

        //-- Act
        var descriptionFromEnum = TestEnum.Spike.GetDescription();

        //-- Assert
        Assert.Equal(description, descriptionFromEnum);
    }

    [Fact]
    public void GetDescription_ReturnsNull()
    {
        //-- Act
        var descriptionFromEnum = TestEnum.Vash.GetDescription();

        //-- Assert
        Assert.Null(descriptionFromEnum);
    }

    [Fact]
    public void GetDescription_NullSource_ReturnsNull()
    {
        //-- Arrange
        string? source = null;

        //-- Act && Assert
        Assert.Throws<ExtensionMethodParameterNullException>(() => source.GetDescription());
    }
}