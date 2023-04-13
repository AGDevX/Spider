using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ClaimNotFoundExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "CLAIM_NOT_FOUND_EXCEPTION";

        //-- Assert
        Assert.True(new ClaimNotFoundException().Code.Equals(code));
    }

    [Fact]
    public void HasCorrectMessage()
    {
        //-- Arrange
        var message = "Test message";

        //-- Assert
        Assert.True(new ClaimNotFoundException(message).Message.Equals(message));
    }

    [Fact]
    public void HasInnerException()
    {
        //-- Arrange
        var message = "Test message";
        var innerExceptionMessage = "Inner exception message";
        var innerException = new Exception(innerExceptionMessage);

        //-- Assert
        Assert.True(new ClaimNotFoundException(message, innerException).Message.Equals(message));
        Assert.True(new ClaimNotFoundException(message, innerException).InnerException == innerException);
    }
}