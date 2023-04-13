using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class NotAuthorizedExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "NOT_AUTHORIZED_EXCEPTION";

        //-- Assert
        Assert.True(new NotAuthorizedException().Code.Equals(code));
    }

    [Fact]
    public void HasCorrectMessage()
    {
        //-- Arrange
        var message = "Test message";

        //-- Assert
        Assert.True(new NotAuthorizedException(message).Message.Equals(message));
    }

    [Fact]
    public void HasInnerException()
    {
        //-- Arrange
        var message = "Test message";
        var innerExceptionMessage = "Inner exception message";
        var innerException = new Exception(innerExceptionMessage);

        //-- Assert
        Assert.True(new NotAuthorizedException(message, innerException).Message.Equals(message));
        Assert.True(new NotAuthorizedException(message, innerException).InnerException == innerException);
    }
}