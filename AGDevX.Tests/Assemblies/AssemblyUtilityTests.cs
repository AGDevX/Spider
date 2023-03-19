using System.Collections.Generic;
using System.Reflection;
using AGDevX.Assemblies;
using AGDevX.Strings;
using Xunit;

namespace AGDevX.Tests.Assemblies;

public class AssemblyUtilityTests
{
    //-- TODO: Can't load all assemblies for some reason
    //[Fact]
    //public void GetAssemblies_NullParentNullPrefixes_ReturnsAllAssemblies()
    //{
    //    //-- Arrange
    //    Assembly? parent = null;
    //    List<string>? assemblyPrefixes = null;

    //    //--Act
    //    var assemblies = AssemblyUtility.GetAssemblies(parent, assemblyPrefixes);

    //    //-- Assert
    //    Assert.Contains(assemblies, a => a.FullName.StartsWithIgnoreCase("System"));
    //    Assert.Contains(assemblies, a => a.FullName.StartsWithIgnoreCase("AGDevX"));
    //}

    [Fact]
    public void GetAssemblies_NullParentWithPrefixes_DoesNotReturnSystemAssemblies()
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

    [Fact]
    public void AssemblyNameStartsWithAnyPrefix_ReturnsTrue()
    {
        //-- Arrange
        string assemblyName = "AGDevX";
        List<string> assemblyPrefixes = new List<string>
        {
            "AGDevX"
        };

        //--Act
        var any = AssemblyUtility.AssemblyNameStartsWithAnyPrefix(assemblyName, assemblyPrefixes);

        //-- Assert
        Assert.True(any);
    }

    [Fact]
    public void AssemblyNameStartsWithAnyPrefix_ReturnsFalse()
    {
        //-- Arrange
        string assemblyName = "AGDevX";
        List<string> assemblyPrefixes = new List<string>
        {
            "Spider"
        };

        //--Act
        var any = AssemblyUtility.AssemblyNameStartsWithAnyPrefix(assemblyName, assemblyPrefixes);

        //-- Assert
        Assert.False(any);
    }

    [Fact]
    public void AssemblyNameStartsWithAnyPrefix_NullAssemblyName_ReturnsFalse()
    {
        //-- Arrange
        string? assemblyName = null;
        List<string> assemblyPrefixes = new List<string>
        {
            "AGDevX"
        };

        //--Act
        var any = AssemblyUtility.AssemblyNameStartsWithAnyPrefix(assemblyName, assemblyPrefixes);

        //-- Assert
        Assert.False(any);
    }

    [Fact]
    public void AssemblyNameStartsWithAnyPrefix_NullEnumerable_ReturnsFalse()
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
    public void AssemblyNameStartsWithAnyPrefix_NullAssemblyName_NullEnumerable_ReturnsFalse()
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