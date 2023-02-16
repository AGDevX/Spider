using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AGDevX.Enums;
using AGDevX.Exceptions;
using AGDevX.Security;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.WebApi.Config;
using AGDevX.Strings;
using Microsoft.AspNetCore.Authentication;

namespace AGDevX.Spider.WebApi.AuthN
{
    public sealed class AddUserIdentityToClaimsTransformation : IClaimsTransformation
    {
        private readonly ApiConfig _apiConfig;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public AddUserIdentityToClaimsTransformation(
            ApiConfig apiConfig,
            IUserService userService,
            IRoleService roleService,
            IUserRoleService userRoleService)
        {
            _apiConfig = apiConfig;
            _userService = userService;
            _roleService = roleService;
            _userRoleService = userRoleService;
        }

        public async Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal claimsPrincipal)
        {
            var claims = new List<Claim>();

            var email = claimsPrincipal.GetEmail(false);

            if (email.IsNullOrWhiteSpace())
            {
                throw new MissingRequiredClaimException("The required email claim could not be found");
            }

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
                claims.Add(claim);
            }

            var userIdentity = new ClaimsIdentity(
                claims,
                _apiConfig.AuthN.OAuth.AuthenticationScheme,
                _apiConfig.AuthN.OAuth.NameClaimType,
                _apiConfig.AuthN.OAuth.RoleClaimType
            )
            {
                Label = _apiConfig.Api.Name
            };

            claimsPrincipal.AddIdentity(userIdentity);

            return claimsPrincipal;
        }
    }
}