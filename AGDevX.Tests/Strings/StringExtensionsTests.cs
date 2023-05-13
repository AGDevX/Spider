using AGDevX.Strings;
using Xunit;

namespace AGDevX.Tests.Strings;

public class StringExtensionsTests
{
    public class When_calling_EqualsIgnoreCase
    {
        [Theory]
        [InlineData("equal", "EQUAL")]
        [InlineData("equal", "equal")]
        public void And_the_string_are_equal_then_return_true(string str1, string str2)
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
        public void And_the_string_are_not_equal_then_return_false(string str1, string str2)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.EqualsIgnoreCase(str2);

            //-- Assert
            Assert.False(result);
        }
    }

    public class When_calling_StartsWithIgnoreCase
    {
        [Theory]
        [InlineData("equal", "EQUAL")]
        [InlineData("equal", "equal")]
        public void And_the_string_starts_with_string_then_return_true(string str1, string str2)
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
        public void And_the_string_does_not_start_with_string_then_return_false(string str1, string str2)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.StartsWithIgnoreCase(str2);

            //-- Assert
            Assert.False(result);
        }
    }

    public class When_calling_ContainsIgnoreCase
    {
        [Theory]
        [InlineData("equal", "EQUAL")]
        [InlineData("equal", "equal")]
        public void And_the_string_contains_the_string_then_return_true(string str1, string str2)
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
        public void And_the_string_does_not_contain_the_string_then_return_false(string str1, string str2)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.ContainsIgnoreCase(str2);

            //-- Assert
            Assert.False(result);
        }
    }

    public class When_calling_IsNullOrWhiteSpace
    {
        [Theory]
        [InlineData(null)]
        [InlineData("   ")]
        public void And_the_string_is_null_or_whitespace_then_return_true(string str1)
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
        public void And_the_string_is_not_null_or_whitespace_then_return_false(string str1)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.IsNullOrWhiteSpace();

            //-- Assert
            Assert.False(result);
        }
    }

    public class When_calling_IsNotNullOrWhiteSpace
    {
        [Theory]
        [InlineData("something")]
        public void And_the_string_is_not_null_or_whitespace_then_return_true(string str1)
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
        public void And_the_string_null_or_whitespace_then_return_false(string str1)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.IsNotNullOrWhiteSpace();

            //-- Assert
            Assert.False(result);
        }
    }

    public class When_calling_IsWhiteSpace
    {
        [Theory]
        [InlineData(" ")]
        [InlineData("        ")]
        public void And_the_string_is_whitespace_then_return_true(string str1)
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
        public void And_the_string_is_not_whitespace_then_return_false(string str1)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.IsWhiteSpace();

            //-- Assert
            Assert.False(result);
        }
    }

    public class When_calling_IsNotWhiteSpace
    {
        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("a")]
        [InlineData(" b")]
        [InlineData("c ")]
        [InlineData(" d ")]
        [InlineData(" . ")]
        public void And_the_string_is_null_or_not_whitespace_then_return_true(string str1)
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
        public void And_the_string_is_whitespace_only_then_return_false(string str1)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.IsNotWhiteSpace();

            //-- Assert
            Assert.False(result);
        }
    }

    public class When_calling_IsEmpty
    {
        [Theory]
        [InlineData("")]
        public void And_the_string_is_empty_only_then_return_true(string str1)
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
        public void And_the_string_is_null_or_whitespace_or_has_non_whitespace_value_then_return_false(string str1)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.IsEmpty();

            //-- Assert
            Assert.False(result);
        }
    }

    public class When_calling_IsNotEmpty
    {
        [Theory]
        [InlineData(null)]
        [InlineData("a")]
        [InlineData(" b")]
        [InlineData("c ")]
        [InlineData(" d ")]
        [InlineData(" . ")]
        [InlineData(" ")]
        [InlineData("      ")]
        public void And_the_string_is_null_or_whitespace_or_has_non_whitespace_value_then_return_true(string str1)
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
        public void And_the_string_is_empty_only_then_return_false(string str1)
        {
            //-- Arrange
            //-- <see InlineData>

            //-- Act
            var result = str1.IsNotEmpty();

            //-- Assert
            Assert.False(result);
        }
    }
}