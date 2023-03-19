using System.Collections.Generic;
using System.Security.Claims;
using AGDevX.Exceptions;
using AGDevX.Security;
using Xunit;

namespace AGDevX.Tests.Security;

public class ClaimsPrincipalExtensionsTests
{
    [Fact]
    public void GetEmail_ReturnsEmail()
    {
        //-- Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Email, "agdevx@reddwarfjmcagdx.com")
        }, "mock"));

        //-- Act
        var claimValue = user.GetEmail();

        //-- Assert
        Assert.NotNull(claimValue);
    }

    [Fact]
    public void GetEmail_ReturnsNull()
    {
        //-- Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, "August Geier"),
        }, "mock"));

        //-- Act
        var claimValue = user.GetEmail(false);

        //-- Assert
        Assert.Null(claimValue);
    }

    [Fact]
    public void GetEmail_ThrowsException()
    {
        //-- Arrange
        var user = new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
        {
            new Claim(ClaimTypes.Name, "August Geier"),
        }, "mock"));

        //-- Act && Assert
        Assert.Throws<ClaimNotFoundException>(() => user.GetEmail());
    }
}