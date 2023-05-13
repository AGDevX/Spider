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

    public class When_calling_GetDescription
    {
        [Fact]
        public void And_matches_expected_description_then_return_true()
        {
            //-- Arrange
            var description = "From Cowboy Bebop";

            //-- Act
            var descriptionFromEnum = TestEnum.Spike.GetDescription();

            //-- Assert
            Assert.Equal(description, descriptionFromEnum);
        }

        [Fact]
        public void And_enum_does_not_have_a_description_then_return_null()
        {
            //-- Act
            var descriptionFromEnum = TestEnum.Vash.GetDescription();

            //-- Assert
            Assert.Null(descriptionFromEnum);
        }

        [Fact]
        public void And_has_a_null_source_then_throw_ExtensionMethodParameterNullException()
        {
            //-- Arrange
            string? source = null;

            //-- Act && Assert
            Assert.Throws<ExtensionMethodParameterNullException>(() => source.GetDescription());
        }
    }
}