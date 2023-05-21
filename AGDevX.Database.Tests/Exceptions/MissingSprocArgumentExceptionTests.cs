using System;
using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingSprocArgumentExceptionTests
{
    public class When_throwing_a_MissingSprocArgumentException
    {
        [Fact]
        public void And_has_correct_default_code_then_assert_true()
        {
            //-- Arrange
            var defaultCode = "MISSING_SPROC_ARG_EXCEPTION";

            //-- Assert
            Assert.True(new MissingSprocArgumentException().Code.Equals(defaultCode));
        }

        [Fact]
        public void And_has_correct_code_then_assert_true()
        {
            //-- Arrange
            var code = "ex";

            //-- Assert
            Assert.True(new MissingSprocArgumentException("msg", code).Code.Equals(code));
        }

        [Fact]
        public void And_has_correct_message_then_assert_true()
        {
            //-- Arrange
            var argumentName = "argumentName";
            var message = "Value cannot be null. (Parameter 'argumentName')";

            //-- Assert
            Assert.True(new MissingSprocArgumentException(argumentName).Message.Equals(message));
        }

        [Fact]
        public void And_should_have_inner_exception_then_make_sure_it_has_inner_exception()
        {
            //-- Arrange
            var message = "Test message";
            var innerExceptionMessage = "Inner exception message";
            var innerException = new Exception(innerExceptionMessage);

            //-- Assert
            Assert.True(new MissingSprocArgumentException(message, innerException).Message.Equals(message));
            Assert.True(new MissingSprocArgumentException(message, innerException).InnerException == innerException);
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
            Assert.True(new MissingSprocArgumentException(message, code, innerException).Message.Equals(message));
            Assert.True(new MissingSprocArgumentException(message, code, innerException).Code.Equals(code));
            Assert.True(new MissingSprocArgumentException(message, code, innerException).InnerException == innerException);
        }
    }
}