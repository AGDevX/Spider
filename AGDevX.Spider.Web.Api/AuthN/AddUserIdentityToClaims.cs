using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AGDevX.Enums;
using AGDevX.Security;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Strings;
using Microsoft.AspNetCore.Authentication;

namespace AGDevX.Spider.Web.Api.AuthN
{
    public sealed class AddUserIdentityToClaimsTransformation : IClaimsTransformation
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public AddUserIdentityToClaimsTransformation (
            IUserService userService,
            IRoleService roleService,
            IUserRoleService userRoleService)
        {
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal claimsPrincipal)
        {
            if (!claimsPrincipal.Identities.Any())
            {
                return claimsPrincipal;
            }

            var identity = (ClaimsIdentity)claimsPrincipal.Identity!;

            var email = claimsPrincipal.GetEmail(false);

            if (!email.IsNullOrWhiteSpace())
            {
                //-- TODO: This needs cleaned up REAL bad

                var roles = await _roleService.GetRoles();
                var roleIds = roles.Select(r => r.Id).ToList();
                var user = await _userService.GetUser(null, email);

                if (user != null)
                {
                    var userRoles = await _userRoleService.GetUserRoles(user.Id);

                    var rolesStringBuilder = new StringBuilder();
                    foreach (var userRole in userRoles)
                    {
                        if (roleIds.Contains(userRole.RoleId))
                        {
                            rolesStringBuilder.Append($"{roles.FirstOrDefault(r => r.Id == userRole.RoleId).Code} ");
                        }
                    }

                    var roleString = rolesStringBuilder.ToString().Trim();

                    var claim = new Claim(JwtClaimTypes.Roles.StringValue(), roleString);
                    identity.AddClaim(claim);
                }
            }

            return claimsPrincipal;
        }
    }
}