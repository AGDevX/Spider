using AGDevX.Enums;
using Xunit;

namespace AGDevX.Tests.Enums;

public class EnumExtensionsTests
{
    private enum TestEnum
    {
        [EnumStringValue("From Cowboy Bebop")]
        Spike,
        [EnumStringValue("From Ruroni Kenshin")]
        Kenshin,
        Vash
    }

    [Fact]
    public void EnumStringValue_ReturnsValue()
    {
        //-- Arrange
        var stringValue = "From Cowboy Bebop";

        //-- Act
        var stringValueFromEnum = TestEnum.Spike.StringValue();

        //-- Assert
        Assert.Equal(stringValue, stringValueFromEnum);
    }

    [Fact]
    public void EnumStringValue_NoAttribute_ReturnsValue()
    {
        //-- Arrange
        var stringValue = "Vash";

        //-- Act
        var stringValueFromEnum = TestEnum.Vash.StringValue();

        //-- Assert
        Assert.Equal(stringValue, stringValueFromEnum);
    }

    [Fact]
    public void IsOneOf_ReturnsTrue()
    {
        //-- Arrange
        TestEnum kenshin = TestEnum.Kenshin;

        //-- Act
        var isOneOf = kenshin.IsOneOf(TestEnum.Spike, TestEnum.Kenshin);

        //-- Assert
        Assert.True(isOneOf);
    }

    [Fact]
    public void IsOneOf_ReturnsFalse()
    {
        //-- Arrange
        TestEnum vash = TestEnum.Vash;

        //-- Act
        var isOneOf = vash.IsOneOf(TestEnum.Spike, TestEnum.Kenshin);

        //-- Assert
        Assert.False(isOneOf);
    }
}