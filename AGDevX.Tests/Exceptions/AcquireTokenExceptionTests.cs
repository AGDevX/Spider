﻿using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class AcquireTokenExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "ACQUIRE_TOKEN_EXCEPTION";

        //-- Assert
        Assert.True(new AcquireTokenException().Code.Equals(code));
    }

    [Fact]
    public void HasCorrectMessage()
    {
        //-- Arrange
        var message = "Test message";

        //-- Assert
        Assert.True(new AcquireTokenException(message).Message.Equals(message));
    }

    [Fact]
    public void HasInnerException()
    {
        //-- Arrange
        var message = "Test message";
        var innerExceptionMessage = "Inner exception message";
        var innerException = new Exception(innerExceptionMessage);

        //-- Assert
        Assert.True(new AcquireTokenException(message, innerException).Message.Equals(message));
        Assert.True(new AcquireTokenException(message, innerException).InnerException == innerException);
    }
}