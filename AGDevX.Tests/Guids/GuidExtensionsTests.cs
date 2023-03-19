using System;
using AGDevX.Guids;
using Xunit;

namespace AGDevX.Tests.Guids;

public class GuidExtensionsTests
{
    [Fact]
    public void IsEmpty_EmptyGuid_ReturnsTrue()
    {
        //-- Arrange
        var guid = Guid.Empty;

        //-- Act
        var isEmpty = guid.IsEmpty();

        //-- Assert
        Assert.True(isEmpty);
    }

    [Fact]
    public void IsEmpty_NewGuid_ReturnsFalse()
    {
        //-- Arrange
        var guid = Guid.NewGuid();

        //-- Act
        var isEmpty = guid.IsEmpty();

        //-- Assert
        Assert.False(isEmpty);
    }

    [Fact]
    public void IsNullOrEmpty_EmptyGuid_ReturnsTrue()
    {
        //-- Arrange
        Guid? guid = Guid.Empty;

        //-- Act
        var isNullOrEmpty = guid.IsNullOrEmpty();

        //-- Assert
        Assert.True(isNullOrEmpty);
    }

    [Fact]
    public void IsNullOrEmpty_NullGuid_ReturnsTrue()
    {
        //-- Arrange
        Guid? guid = null;

        //-- Act
        var isNullOrEmpty = guid.IsNullOrEmpty();

        //-- Assert
        Assert.True(isNullOrEmpty);
    }
}