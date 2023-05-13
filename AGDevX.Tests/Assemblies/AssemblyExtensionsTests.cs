using System.Collections.Generic;
using System.Reflection;
using AGDevX.Assemblies;
using Xunit;

namespace AGDevX.Tests.Assemblies;

public class AssemblyExtensionsTests
{
    public class When_calling_FullNameStartsWithPrefix
    {
        [Fact]
        public void And_prefix_is_mixed_case_then_return_true()
        {
            //-- Arrange
            var assembly = Assembly.GetExecutingAssembly();
            var prefix = "AGDevX";

            //-- Act
            var startsWith = assembly.FullNameStartsWithPrefix(prefix);

            //-- Assert
            Assert.True(startsWith);
        }

        [Fact]
        public void And_prefix_is_lower_case_then_return_true()
        {
            //-- Arrange
            var assembly = Assembly.GetExecutingAssembly();
            var prefix = "agdevx";

            //-- Act
            var startsWith = assembly.FullNameStartsWithPrefix(prefix);

            //-- Assert
            Assert.True(startsWith);
        }

        [Fact]
        public void And_prefix_is_uppercase_case_then_return_true()
        {
            //-- Arrange
            var assembly = Assembly.GetExecutingAssembly();
            var prefix = "AGDEVX";

            //-- Act
            var startsWith = assembly.FullNameStartsWithPrefix(prefix);

            //-- Assert
            Assert.True(startsWith);
        }

        [Fact]
        public void And_prefix_does_not_match_anything_then_return_false()
        {
            //-- Arrange
            var assembly = Assembly.GetExecutingAssembly();
            var prefix = "MRSG";

            //-- Act
            var startsWith = assembly.FullNameStartsWithPrefix(prefix);

            //-- Assert
            Assert.False(startsWith);
        }
    }

    public class When_calling_FullNameStartsWithPrefixes
    {
        [Fact]
        public void And_starts_with_one_prefix_return_true()
        {
            //-- Arrange
            var assembly = Assembly.GetExecutingAssembly();
            var prefixes = new List<string>
            {
                "AGDevX"
            };

            //-- Act
            var anyStartsWith = assembly.FullNameStartsWithPrefixes(prefixes);

            //-- Assert
            Assert.True(anyStartsWith);
        }

        [Fact]
        public void And_does_not_start_with_one_prefix_return_false()
        {
            //-- Arrange
            var assembly = Assembly.GetExecutingAssembly();
            var prefixes = new List<string>
            {
                "MRSG"
            };

            //-- Act
            var anyStartsWith = assembly.FullNameStartsWithPrefixes(prefixes);

            //-- Assert
            Assert.False(anyStartsWith);
        }

        [Fact]
        public void And_starts_with_multiple_prefixes_return_false()
        {
            //-- Arrange
            var assembly = Assembly.GetExecutingAssembly();
            var prefixes = new List<string>
            {
                "AGDevX",
                "JDG"
            };

            //-- Act
            var anyStartsWith = assembly.FullNameStartsWithPrefixes(prefixes);

            //-- Assert
            Assert.True(anyStartsWith);
        }

        [Fact]
        public void And_does_not_start_with_any_prefix_return_false()
        {
            //-- Arrange
            var assembly = Assembly.GetExecutingAssembly();
            var prefixes = new List<string>();

            //-- Act
            var anyStartsWith = assembly.FullNameStartsWithPrefixes(prefixes);

            //-- Assert
            Assert.False(anyStartsWith);
        }
    }
}