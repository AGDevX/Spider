using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ApplicationStartupExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.InternalServerError;

        //-- Assert
        Assert.True(new ApplicationStartupException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_STARTUP_EXCEPTION";

        //-- Assert
        Assert.True(new ApplicationStartupException().Code.Equals(code));
    }
}