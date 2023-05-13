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
        public void With_mixed_case_prefix_then_return_true()
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
        public void With_lower_case_prefix_then_return_true()
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
        public void With_upper_case_prefix_then_return_true()
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
        public void With_non_matching_prefix_then_return_false()
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
        public void With_one_matching_prefix_then_return_true()
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
        public void With_non_matching_prefix_then_return_false()
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
        public void With_at_least_one_matching_prefix_then_return_true()
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
        public void With_empty_prefix_list_then_return_false()
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