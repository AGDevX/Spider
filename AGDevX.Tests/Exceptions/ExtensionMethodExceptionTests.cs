using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ExtensionMethodExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.BadRequest;

        //-- Assert
        Assert.True(new ExtensionMethodException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_EXTENSION_METHOD_EXCEPTION";

        //-- Assert
        Assert.True(new ExtensionMethodException().Code.Equals(code));
    }
}