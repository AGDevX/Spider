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

    public class When_calling_EnumStringValue
    {
        [Fact]
        public void And_matches_expected_description_then_return_expected_value()
        {
            //-- Arrange
            var stringValue = "From Cowboy Bebop";

            //-- Act
            var stringValueFromEnum = TestEnum.Spike.StringValue();

            //-- Assert
            Assert.Equal(stringValue, stringValueFromEnum);
        }

        [Fact]
        public void And_enum_does_not_have_attribute_but_itself_matches_the_expected_string_value_then_return_expected_value()
        {
            //-- Arrange
            var stringValue = "Vash";

            //-- Act
            var stringValueFromEnum = TestEnum.Vash.StringValue();

            //-- Assert
            Assert.Equal(stringValue, stringValueFromEnum);
        }
    }

    public class When_calling_IsOneOf
    {
        [Fact]
        public void With_a_value_that_is_one_of_then_return_true()
        {
            //-- Arrange
            TestEnum kenshin = TestEnum.Kenshin;

            //-- Act
            var isOneOf = kenshin.IsOneOf(TestEnum.Spike, TestEnum.Kenshin);

            //-- Assert
            Assert.True(isOneOf);
        }

        [Fact]
        public void With_a_value_that_is_not_one_of_then_return_false()
        {
            //-- Arrange
            TestEnum vash = TestEnum.Vash;

            //-- Act
            var isOneOf = vash.IsOneOf(TestEnum.Spike, TestEnum.Kenshin);

            //-- Assert
            Assert.False(isOneOf);
        }
    }
}