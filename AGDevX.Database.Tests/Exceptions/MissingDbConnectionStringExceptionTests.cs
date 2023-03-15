using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingDbConnectionStringExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.InternalServerError;

        //-- Assert
        Assert.True(new MissingDbConnectionStringException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_MISSING_DATABASE_CONNECTION_STRING_EXCEPTION";

        //-- Assert
        Assert.True(new MissingDbConnectionStringException().Code.Equals(code));
    }
}