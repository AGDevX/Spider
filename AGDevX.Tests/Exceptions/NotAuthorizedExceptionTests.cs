using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class NotAuthorizedExceptionTests
{
    public class When_throwing_a_NotAuthorizedException
    {
        [Fact]
        public void And_has_correct_code_then_assert_true()
        {
            //-- Arrange
            var code = "NOT_AUTHORIZED_EXCEPTION";

            //-- Assert
            Assert.True(new NotAuthorizedException().Code.Equals(code));
        }

        [Fact]
        public void And_has_correct_message_then_assert_true()
        {
            //-- Arrange
            var message = "Test message";

            //-- Assert
            Assert.True(new NotAuthorizedException(message).Message.Equals(message));
        }

        [Fact]
        public void And_should_have_inner_exception_then_make_sure_it_has_inner_exception()
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
}