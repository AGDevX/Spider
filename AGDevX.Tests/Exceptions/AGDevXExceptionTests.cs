using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class AGDevXExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.InternalServerError;

        //-- Assert
        Assert.True(new AGDevXException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_EXCEPTION";

        //-- Assert
        Assert.True(new AGDevXException().Code.Equals(code));
    }
}