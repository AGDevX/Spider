using System.Collections.Generic;
using System.Security.Claims;
using AGDevX.Exceptions;
using AGDevX.Security;
using Xunit;

namespace AGDevX.Tests.Security;

public class ClaimsPrincipalExtensionsTests
{
    public class When_calling_GetEmail
    {
        [Fact]
        public void And_the_claims_principal_has_the_claim_then_return_claim_value()
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
        public void And_the_claims_principal_does_not_have_the_claim_with_do_not_throw_param_then_return_null()
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
        public void And_the_claims_principal_does_not_have_the_claim_without_do_not_throw_param_then_throw_ClaimNotFoundException()
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
}