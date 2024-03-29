﻿using System;
using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingDbConnectionStringExceptionTests
{
    public class When_throwing_a_MissingDbConnectionStringException
    {
        [Fact]
        public void And_has_correct_default_code_then_assert_true()
        {
            //-- Arrange
            var defaultCode = "MISSING_DATABASE_CONNECTION_STRING_EXCEPTION";

            //-- Assert
            Assert.True(new MissingDbConnectionStringException().Code.Equals(defaultCode));
        }

        [Fact]
        public void And_has_correct_code_then_assert_true()
        {
            //-- Arrange
            var code = "ex";

            //-- Assert
            Assert.True(new MissingDbConnectionStringException("msg", code).Code.Equals(code));
        }

        [Fact]
        public void And_has_correct_message_then_assert_true()
        {
            //-- Arrange
            var message = "Test message";

            //-- Assert
            Assert.True(new MissingDbConnectionStringException(message).Message.Equals(message));
        }

        [Fact]
        public void And_should_have_inner_exception_then_make_sure_it_has_inner_exception()
        {
            //-- Arrange
            var message = "Test message";
            var innerExceptionMessage = "Inner exception message";
            var innerException = new Exception(innerExceptionMessage);

            //-- Assert
            Assert.True(new MissingDbConnectionStringException(message, innerException).Message.Equals(message));
            Assert.True(new MissingDbConnectionStringException(message, innerException).InnerException == innerException);
        }

        [Fact]
        public void And_should_have_inner_exception_then_make_all_properties_are_correct()
        {
            //-- Arrange
            var message = "Test message";
            var code = "ex";
            var innerExceptionMessage = "Inner exception message";
            var innerException = new Exception(innerExceptionMessage);

            //-- Assert
            Assert.True(new MissingDbConnectionStringException(message, code, innerException).Message.Equals(message));
            Assert.True(new MissingDbConnectionStringException(message, code, innerException).Code.Equals(code));
            Assert.True(new MissingDbConnectionStringException(message, code, innerException).InnerException == innerException);
        }
    }
}