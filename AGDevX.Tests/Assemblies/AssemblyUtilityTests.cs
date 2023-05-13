using System.Collections.Generic;
using System.Reflection;
using AGDevX.Assemblies;
using AGDevX.Strings;
using Xunit;

namespace AGDevX.Tests.Assemblies;

public class AssemblyUtilityTests
{
    public class When_calling_GetAssemblies
    {
        [Fact]
        public void With_null_parent_and_null_prefix_list_then_return_all_asemblies()
        {
            //-- Arrange
            Assembly? parent = null;
            List<string>? assemblyPrefixes = null;

            //--Act
            var assemblies = AssemblyUtility.GetAssemblies(parent, assemblyPrefixes);

            //-- Assert
            Assert.Contains(assemblies, a => a.FullName.StartsWithIgnoreCase("System"));
            Assert.Contains(assemblies, a => a.FullName.StartsWithIgnoreCase("AGDevX"));
        }

        [Fact]
        public void With_null_parent_without_a_system_prefix_then_do_not_return_system_assemblies()
        {
            //-- Arrange
            Assembly? parent = null;
            var assemblyPrefixes = new List<string>
            {
                "Microsoft",
                "AGDevX"
            };

            //--Act
            var assemblies = AssemblyUtility.GetAssemblies(parent, assemblyPrefixes);

            //-- Assert
            Assert.DoesNotContain(assemblies, a => a.FullName.StartsWithIgnoreCase("System"));
            Assert.Contains(assemblies, a => a.FullName.StartsWithIgnoreCase("Microsoft"));
            Assert.Contains(assemblies, a => a.FullName.StartsWithIgnoreCase("AGDevx"));
        }
    }

    public class When_calling_AssemblyNameStartsWithAnyPrefix
    {
        [Fact]
        public void With_assembly_name_matching_a_prefix_then_return_true()
        {
            //-- Arrange
            string assemblyName = "AGDevX";
            var assemblyPrefixes = new List<string>
            {
                "AGDevX"
            };

            //--Act
            var any = AssemblyUtility.AssemblyNameStartsWithAnyPrefix(assemblyName, assemblyPrefixes);

            //-- Assert
            Assert.True(any);
        }

        [Fact]
        public void With_assembly_name_not_matching_a_prefix_then_return_false()
        {
            //-- Arrange
            string assemblyName = "AGDevX";
            var assemblyPrefixes = new List<string>
            {
                "Spider"
            };

            //--Act
            var any = AssemblyUtility.AssemblyNameStartsWithAnyPrefix(assemblyName, assemblyPrefixes);

            //-- Assert
            Assert.False(any);
        }

        [Fact]
        public void With_a_null_assembly_name_not_matching_a_prefix_then_return_false()
        {
            //-- Arrange
            string? assemblyName = null;
            var assemblyPrefixes = new List<string>
            {
                "AGDevX"
            };

            //--Act
            var any = AssemblyUtility.AssemblyNameStartsWithAnyPrefix(assemblyName, assemblyPrefixes);

            //-- Assert
            Assert.False(any);
        }

        [Fact]
        public void With_a_null_assembly_prefix_list_then_return_false()
        {
            //-- Arrange
            string assemblyName = "AGDevX";
            List<string>? assemblyPrefixes = null;

            //--Act
            var any = AssemblyUtility.AssemblyNameStartsWithAnyPrefix(assemblyName, assemblyPrefixes);

            //-- Assert
            Assert.False(any);
        }

        [Fact]
        public void With_a_null_assembly_name_and_null_assembly_list_then_return_false()
        {
            //-- Arrange
            string? assemblyName = null;
            List<string>? assemblyPrefixes = null;

            //--Act
            var any = AssemblyUtility.AssemblyNameStartsWithAnyPrefix(assemblyName, assemblyPrefixes);

            //-- Assert
            Assert.False(any);
        }
    }
}