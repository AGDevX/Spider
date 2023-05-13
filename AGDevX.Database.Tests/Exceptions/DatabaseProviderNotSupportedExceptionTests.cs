using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class DatabaseProviderNotSupportedExceptionTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "DATABASE_PROVIDER_NOT_SUPPORTED_EXCEPTION";

        //-- Assert
        Assert.True(new DatabaseProviderNotSupportedException().Code.Equals(code));
    }
}