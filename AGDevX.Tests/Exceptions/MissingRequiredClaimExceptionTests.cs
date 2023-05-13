using System;
using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingRequiredClaimExceptionTests
{
    public class When_throwing_a_AcquireTokenException
    {
        [Fact]
        public void And_has_correct_code_then_assert_true()
        {
            //-- Arrange
            var code = "MISSING_REQUIRED_CLAIM_EXCEPTION";

            //-- Assert
            Assert.True(new MissingRequiredClaimException().Code.Equals(code));
        }

        [Fact]
        public void And_has_correct_message_then_assert_true()
        {
            //-- Arrange
            var message = "Test message";

            //-- Assert
            Assert.True(new MissingRequiredClaimException(message).Message.Equals(message));
        }

        [Fact]
        public void And_should_have_inner_exception_then_make_sure_it_has_inner_exception()
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
}