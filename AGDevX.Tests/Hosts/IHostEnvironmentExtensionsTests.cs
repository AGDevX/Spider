using System;
using AGDevX.Environments;
using AGDevX.Hosts;
using AGDevX.Web.Tests.Extensions;
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
        EnvironmentType[]? environments = null;

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
        EnvironmentType[]? environments = Array.Empty<EnvironmentType>();

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
        EnvironmentType[]? environments = new EnvironmentType[1] { EnvironmentType.Prod };

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
        EnvironmentType[]? environments = new EnvironmentType[2] { EnvironmentType.QA, EnvironmentType.Prod };

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
        EnvironmentType[]? environments = new EnvironmentType[1] { EnvironmentType.Development };

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
        EnvironmentType[]? environments = new EnvironmentType[2] { EnvironmentType.Local, EnvironmentType.Dev };

        //-- Act
        var isNullOrEmpty = hostEnvironment.IsOneOf(environments);

        //-- Assert
        Assert.False(isNullOrEmpty);
    }
}