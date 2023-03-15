using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ExtensionMethodParameterNullExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.BadRequest;

        //-- Assert
        Assert.True(new ExtensionMethodParameterNullException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_EXTENSION_METHOD_PARAMETER_NULL_EXCEPTION";

        //-- Assert
        Assert.True(new ExtensionMethodParameterNullException().Code.Equals(code));
    }
}