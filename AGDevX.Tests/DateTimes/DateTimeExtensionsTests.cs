using System;
using AGDevX.DateTimes;
using Xunit;

namespace AGDevX.Tests.DateTimes;

public class DateTimeExtensionsTests
{
    public class When_calling_SpecifyKind
    {
        [Fact]
        public void With_non_utc_datetime_then_return_non_utc_datetime()
        {
            //-- Arrange
            var originalDateTime = DateTime.Now;

            //-- Act
            var kindSpecifiedDateTime = originalDateTime.SpecifyKind(DateTimeKind.Local);

            //-- Assert
            Assert.False(kindSpecifiedDateTime.Kind == DateTimeKind.Utc);
        }

        [Fact]
        public void With_utc_datetime_then_return_utc_datetime()
        {
            //-- Arrange
            var originalDateTime = DateTime.Now;

            //-- Act
            var kindSpecifiedDateTime = originalDateTime.SpecifyKind(DateTimeKind.Utc);

            //-- Assert
            Assert.True(kindSpecifiedDateTime.Kind == DateTimeKind.Utc);
        }
    }
}