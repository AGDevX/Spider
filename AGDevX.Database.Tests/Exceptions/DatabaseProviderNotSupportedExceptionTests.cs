using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class DatabaseProviderNotSupportedExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.InternalServerError;

        //-- Assert
        Assert.True(new DatabaseProviderNotSupportedException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_DATABASE_PROVIDER_NOT_SUPPORTED_EXCEPTION";

        //-- Assert
        Assert.True(new DatabaseProviderNotSupportedException().Code.Equals(code));
    }
}