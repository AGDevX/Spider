using System;
using AGDevX.Hosts;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace AGDevX.Tests.Hosts;
public class IHostEnvironmentExtensionsTests
{
    private IHostEnvironment _hostEnvironment;

    public IHostEnvironmentExtensionsTests()
    {
        _hostEnvironment = new HostEnvironment
        {
            ApplicationName = "AGDevXTests",
            EnvironmentName = "Prod",
            ContentRootPath = "C:\\",
            ContentRootFileProvider = new PhysicalFileProvider("C:\\")
        };
    }

    [Fact]
    public void IsNullOrEmpty_Null_ReturnsFalse()
    {
        //-- Arrange
        IHostEnvironment? hostEnvironment = null;
        string[]? environments = null;

        //-- Act
        var isNullOrEmpty = hostEnvironment.IsOneOf(environments);

        //-- Assert
        Assert.False(isNullOrEmpty);
    }

    [Fact]
    public void IsNullOrEmpty_Empty_ReturnsFalse()
    {
        //-- Arrange
        IHostEnvironment? hostEnvironment = null;
        string[]? environments = Array.Empty<string>();

        //-- Act
        var isNullOrEmpty = hostEnvironment.IsOneOf(environments);

        //-- Assert
        Assert.False(isNullOrEmpty);
    }

    [Fact]
    public void IsOneOf_Prod_ReturnsFalse()
    {
        //-- Arrange
        IHostEnvironment? hostEnvironment = _hostEnvironment;
        string[]? environments = new string[1] { "Prod" };

        //-- Act
        var isNullOrEmpty = hostEnvironment.IsOneOf(environments);

        //-- Assert
        Assert.True(isNullOrEmpty);
    }

    [Fact]
    public void IsOneOfMultiple_Prod_ReturnsFalse()
    {
        //-- Arrange
        IHostEnvironment? hostEnvironment = _hostEnvironment;
        string[]? environments = new string[2] { "QA", "Prod" };

        //-- Act
        var isNullOrEmpty = hostEnvironment.IsOneOf(environments);

        //-- Assert
        Assert.True(isNullOrEmpty);
    }

    [Fact]
    public void IsNotOneOf_Prod_ReturnsFalse()
    {
        //-- Arrange
        IHostEnvironment? hostEnvironment = _hostEnvironment;
        string[]? environments = new string[1] { "Development" };

        //-- Act
        var isNullOrEmpty = hostEnvironment.IsOneOf(environments);

        //-- Assert
        Assert.False(isNullOrEmpty);
    }

    [Fact]
    public void IsNotOneOfMultiple_Prod_ReturnsFalse()
    {
        //-- Arrange
        IHostEnvironment? hostEnvironment = _hostEnvironment;
        string[]? environments = new string[2] { "Local", "Dev" };

        //-- Act
        var isNullOrEmpty = hostEnvironment.IsOneOf(environments);

        //-- Assert
        Assert.False(isNullOrEmpty);
    }

    public class HostEnvironment : IHostEnvironment
    {
        public required string EnvironmentName { get; set; }
        public required string ApplicationName { get; set; }
        public required string ContentRootPath { get; set; }
        public required IFileProvider ContentRootFileProvider { get; set; }
    }
}