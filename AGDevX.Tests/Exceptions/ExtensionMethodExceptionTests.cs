using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ExtensionMethodExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "EXTENSION_METHOD_EXCEPTION";

        //-- Assert
        Assert.True(new ExtensionMethodException().Code.Equals(code));
    }

    [Fact]
    public void HasCorrectMessage()
    {
        //-- Arrange
        var message = "Test message";

        //-- Assert
        Assert.True(new ExtensionMethodException(message).Message.Equals(message));
    }

    [Fact]
    public void HasInnerException()
    {
        //-- Arrange
        var message = "Test message";
        var innerExceptionMessage = "Inner exception message";
        var innerException = new Exception(innerExceptionMessage);

        //-- Assert
        Assert.True(new ExtensionMethodException(message, innerException).Message.Equals(message));
        Assert.True(new ExtensionMethodException(message, innerException).InnerException == innerException);
    }
}