using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.WebApi.AuthZ;
using AGDevX.Spider.WebApi.Models;
using AGDevX.Web.AuthZ.Attributes;
using AGDevX.Web.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1
{
    /// <summary>
    /// Manages Users
    /// </summary>
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public sealed class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IMapper _autoMapper;
        private readonly IUserService _userService;

        public UserController(ILogger<UserController> logger, IMapper autoMapper, IUserService userService)
        {
            _logger = logger;
            _autoMapper = autoMapper;
            _userService = userService;
        }

        [HttpPost]
        [AuthorizedScopes(Scopes.ApiAccess)]
        [AuthorizedRoles(Roles.AGDevXAdmin, Roles.Admin, Roles.Normal)]
        public async Task<IActionResult> AddUser(AddUser user)
        {
            var svcUser = _autoMapper.Map<Service.Models.AddUser>(user);
            var userId = await _userService.AddUser(svcUser);
            return new ObjectResult(new { userId });
        }

        [HttpGet]
        [AuthorizedScopes(Scopes.ApiAccess)]
        [AuthorizedRoles(AuthorizedRoles.Any)]
        public async Task<IActionResult> Get(Guid? userId = default, string? email = default)
        {
            var svcUsers = await _userService.GetUsers(userId, email);
            var apiUsers = _autoMapper.Map<List<User>>(svcUsers);

            return new OkObjectResult(new AGDevXWebResponse<List<User>>
            {
                Code = AGDevXWebResponseCodes.Success,
                Messages = new List<string> { $"Found { apiUsers.Count } user(s)" },
                Value = apiUsers
            });
        }

        [HttpGet, Route("GetUserInfo")]
        [AuthorizedScopes(Scopes.ApiAccess)]
        [AuthorizedRoles(Roles.AGDevXAdmin, Roles.Admin, Roles.Normal)]
        public async Task<IActionResult> GetUserInfo(Guid? userId = default, string? externalUserId = default, string? email = default)
        {
            var svcUserInfo = await _userService.GetUserInfo(userId, externalUserId, email);
            var apiUserInfo = _autoMapper.Map<UserInfo>(svcUserInfo);

            return new OkObjectResult(new AGDevXWebResponse<UserInfo>
            {
                Code = AGDevXWebResponseCodes.Success,
                Value = apiUserInfo
            });
        }
    }
}