using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ApplicationStartupExceptionTests
{
    public class When_throwing_a_ApplicationStartupException
    {
        [Fact]
        public void And_has_correct_code_then_assert_true()
        {
            //-- Arrange
            var code = "APPLICATION_STARTUP_EXCEPTION";

            //-- Assert
            Assert.True(new ApplicationStartupException().Code.Equals(code));
        }

        [Fact]
        public void And_has_correct_message_then_assert_true()
        {
            //-- Arrange
            var message = "Test message";

            //-- Assert
            Assert.True(new ApplicationStartupException(message).Message.Equals(message));
        }

        [Fact]
        public void And_should_have_inner_exception_then_make_sure_it_has_inner_exception()
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
}