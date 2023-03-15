using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class ClaimNotFoundExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.Unauthorized;

        //-- Assert
        Assert.True(new ClaimNotFoundException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_CLAIM_NOT_FOUND_EXCEPTION";

        //-- Assert
        Assert.True(new ClaimNotFoundException().Code.Equals(code));
    }
}