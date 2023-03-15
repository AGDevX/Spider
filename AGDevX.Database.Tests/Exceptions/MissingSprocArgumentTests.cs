using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingSprocArgumentTests
{
    [Fact]
    public void HasCorrectHttpStatusCode()
    {
        //-- Arrange
        var code = (int)System.Net.HttpStatusCode.InternalServerError;

        //-- Assert
        Assert.True(new MissingSprocArgument().HttpStatusCode.Equals(code));
    }

    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "AGDX_MISSING_SPROC_ARG_EXCEPTION";

        //-- Assert
        Assert.True(new MissingSprocArgument().Code.Equals(code));
    }
}