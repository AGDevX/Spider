using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingDbConnectionStringExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "MISSING_DATABASE_CONNECTION_STRING_EXCEPTION";

        //-- Assert
        Assert.True(new MissingDbConnectionStringException().Code.Equals(code));
    }
}