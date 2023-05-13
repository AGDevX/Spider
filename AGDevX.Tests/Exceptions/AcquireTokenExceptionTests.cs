using System;
using AGDevX.Exceptions;
using AGDevX.Strings;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class AcquireTokenExceptionTests
{
    public class When_throwing_a_AcquireTokenException
    {
        [Fact]
        public void And_has_correct_code_then_assert_true()
        {
            //-- Arrange
            var code = "ACQUIRE_TOKEN_EXCEPTION";

            //-- Assert
            Assert.True(new AcquireTokenException().Code.EqualsIgnoreCase(code));
        }

        [Fact]
        public void And_has_correct_message_then_assert_true()
        {
            //-- Arrange
            var message = "Test message";

            //-- Assert
            Assert.True(new AcquireTokenException(message).Message.EqualsIgnoreCase(message));
        }

        [Fact]
        public void And_should_have_inner_exception_then_make_sure_it_has_inner_exception()
        {
            //-- Arrange
            var message = "Test message";
            var innerExceptionMessage = "Inner exception message";
            var innerException = new Exception(innerExceptionMessage);

            //-- Assert
            Assert.True(new AcquireTokenException(message, innerException).Message.EqualsIgnoreCase(message));
            Assert.True(new AcquireTokenException(message, innerException).InnerException == innerException);
        }
    }
}