using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class NotAuthorizedExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.Unauthorized;

        //-- Assert
        Assert.True(new NotAuthorizedException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_NOT_AUTHORIZED_EXCEPTION";

        //-- Assert
        Assert.True(new NotAuthorizedException().Code.Equals(code));
    }
}