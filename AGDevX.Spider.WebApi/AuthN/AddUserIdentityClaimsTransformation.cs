using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AGDevX.Enums;
using AGDevX.Security;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.Service.Models;
using AGDevX.Spider.WebApi.Config;
using Microsoft.AspNetCore.Authentication;

namespace AGDevX.Spider.WebApi.AuthN
{
    public sealed class AddUserIdentityClaimsTransformation : IClaimsTransformation
    {
        private readonly ApiConfig _apiConfig;
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;
        private readonly IUserRoleService _userRoleService;

        public AddUserIdentityClaimsTransformation(
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
            var email = claimsPrincipal.GetEmail();
            var userInfo = await _userService.GetUserInfo(null, null, email);

            //-- User not found in DB
            if (userInfo == null)
            {
                //-- Create the user
                if (_apiConfig.Api.AutoCreateUsers)
                {
                    var newUserId = await _userService.AddUser(new AddUser
                    {
                        CreatedBy = _apiConfig.Api.SystemUserId,
                        IsActive = _apiConfig.Api.NewUsersActiveByDefault,
                        FirstName = claimsPrincipal.GetGivenName(),
                        MiddleName = claimsPrincipal.GetMiddleName(false),
                        LastName = claimsPrincipal.GetFamilyName(),
                        Email = email!,
                        ExternalId = claimsPrincipal.GetExternalId(false)
                    });

                    //-- Retrieve new user info
                    userInfo = await _userService.GetUserInfo(newUserId, null, null);
                }
            }

            if (userInfo != null)
            {
                var claims = new List<Claim>();

                claims.AddRange(new List<Claim>
                {
                    new Claim(AGDevXClaimTypes.IsActive.StringValue(), userInfo!.User.IsActive.ToString()),
                    new Claim(JwtClaimTypes.Roles.StringValue(), string.Join(' ', userInfo!.Roles.Select(r => r.RoleCode)))
                });

                var userIdentity = new ClaimsIdentity(
                    claims,
                    _apiConfig.AuthN.OAuth.AuthenticationScheme,
                    _apiConfig.AuthN.OAuth.NameClaimType,
                    _apiConfig.AuthN.OAuth.RoleClaimType)
                    {
                        Label = _apiConfig.Api.Name
                    };

                claimsPrincipal.AddIdentity(userIdentity);
            }

            return claimsPrincipal;
        }
    }
}