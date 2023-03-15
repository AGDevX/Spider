using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class AcquireTokenExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.BadRequest;

        //-- Assert
        Assert.True(new AcquireTokenException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_ACQUIRE_TOKEN_EXCEPTION";

        //-- Assert
        Assert.True(new AcquireTokenException().Code.Equals(code));
    }
}