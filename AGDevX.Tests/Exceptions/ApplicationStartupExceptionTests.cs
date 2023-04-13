using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ApplicationStartupExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "APPLICATION_STARTUP_EXCEPTION";

        //-- Assert
        Assert.True(new ApplicationStartupException().Code.Equals(code));
    }

    [Fact]
    public void HasCorrectMessage()
    {
        //-- Arrange
        var message = "Test message";

        //-- Assert
        Assert.True(new ApplicationStartupException(message).Message.Equals(message));
    }

    [Fact]
    public void HasInnerException()
    {
        //-- Arrange
        var message = "Test message";
        var innerExceptionMessage = "Inner exception message";
        var innerException = new Exception(innerExceptionMessage);

        //-- Assert
        Assert.True(new ApplicationStartupException(message, innerException).Message.Equals(message));
        Assert.True(new ApplicationStartupException(message, innerException).InnerException == innerException);
    }
}