using AGDevX.Database.Exceptions;
using Xunit;

namespace AGDevX.Database.Tests.Exceptions;

public sealed class MissingSprocArgumentTests
{
    [Fact]
    public void HasCorrectCode()
    {
        //-- Arrange
        var code = "MISSING_SPROC_ARG_EXCEPTION";

        //-- Assert
        Assert.True(new MissingSprocArgument().Code.Equals(code));
    }
}