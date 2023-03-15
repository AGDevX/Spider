using AGDevX.DateTimes;
using Xunit;

namespace AGDevX.Tests.DateTimes;

public class DateTimeExtensionsTests
{
    [Fact]
    public void SpecifyKind_IsNotUtc_ReturnsDateTimeNotUtc()
    {
        //-- Arrange
        var originalDateTime = DateTime.Now;

        //-- Act
        var kindSpecifiedDateTime = originalDateTime.SpecifyKind(DateTimeKind.Local);

        //-- Assert
        Assert.False(kindSpecifiedDateTime.Kind == DateTimeKind.Utc);
    }

    [Fact]
    public void SpecifyKind_IsUtc_ReturnsDateTimeUtc()
    {
        //-- Arrange
        var originalDateTime = DateTime.Now;

        //-- Act
        var kindSpecifiedDateTime = originalDateTime.SpecifyKind(DateTimeKind.Utc);

        //-- Assert
        Assert.True(kindSpecifiedDateTime.Kind == DateTimeKind.Utc);
    }
}