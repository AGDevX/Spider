using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingRequiredClaimExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "MISSING_REQUIRED_CLAIM_EXCEPTION";

        //-- Assert
        Assert.True(new MissingRequiredClaimException().Code.Equals(code));
    }

    [Fact]
    public void HasCorrectMessage()
    {
        //-- Arrange
        var message = "Test message";

        //-- Assert
        Assert.True(new MissingRequiredClaimException(message).Message.Equals(message));
    }

    [Fact]
    public void HasInnerException()
    {
        //-- Arrange
        var message = "Test message";
        var innerExceptionMessage = "Inner exception message";
        var innerException = new Exception(innerExceptionMessage);

        //-- Assert
        Assert.True(new MissingRequiredClaimException(message, innerException).Message.Equals(message));
        Assert.True(new MissingRequiredClaimException(message, innerException).InnerException == innerException);
    }
}