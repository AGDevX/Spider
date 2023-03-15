using AGDevX.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingRequiredClaimExceptionTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.Unauthorized;

        //-- Assert
        Assert.True(new MissingRequiredClaimException().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_MISSING_REQUIRED_CLAIM_EXCEPTION";

        //-- Assert
        Assert.True(new MissingRequiredClaimException().Code.Equals(code));
    }
}