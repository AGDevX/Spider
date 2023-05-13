using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ClaimNotFoundExceptionTests
{
    public class When_throwing_a_ClaimNotFoundException
    {
        [Fact]
        public void And_has_correct_code_then_assert_true()
        {
            //-- Arrange
            var code = "CLAIM_NOT_FOUND_EXCEPTION";

            //-- Assert
            Assert.True(new ClaimNotFoundException().Code.Equals(code));
        }

        [Fact]
        public void And_has_correct_message_then_assert_true()
        {
            //-- Arrange
            var message = "Test message";

            //-- Assert
            Assert.True(new ClaimNotFoundException(message).Message.Equals(message));
        }

        [Fact]
        public void And_should_have_inner_exception_then_make_sure_it_has_inner_exception()
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
}