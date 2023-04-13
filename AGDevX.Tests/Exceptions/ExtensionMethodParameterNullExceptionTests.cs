using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ExtensionMethodParameterNullExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "EXTENSION_METHOD_PARAMETER_NULL_EXCEPTION";

        //-- Assert
        Assert.True(new ExtensionMethodParameterNullException().Code.Equals(code));
    }

    [Fact]
    public void HasCorrectMessage()
    {
        //-- Arrange
        var message = "Test message";

        //-- Assert
        Assert.True(new ExtensionMethodParameterNullException(message).Message.Equals(message));
    }

    [Fact]
    public void HasInnerException()
    {
        //-- Arrange
        var message = "Test message";
        var innerExceptionMessage = "Inner exception message";
        var innerException = new Exception(innerExceptionMessage);

        //-- Assert
        Assert.True(new ExtensionMethodParameterNullException(message, innerException).Message.Equals(message));
        Assert.True(new ExtensionMethodParameterNullException(message, innerException).InnerException == innerException);
    }
}