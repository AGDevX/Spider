using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Guids;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.WebApi.AuthZ;
using AGDevX.Spider.WebApi.Models;
using AGDevX.Strings;
using AGDevX.Web.AuthZ.Attributes;
using AGDevX.Web.Response;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1
{
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
        public async Task<IActionResult> AddUser(AddUser user)
        {
            var svcUser = _autoMapper.Map<Service.Models.AddUser>(user);
            var userId = await _userService.AddUser(svcUser);
            return new ObjectResult(new { userId });
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid? userId = default, string? email = default)
        {
            if (userId.IsNullOrEmpty() && email.IsNullOrWhiteSpace())
            {
                var svcUsers = await _userService.GetUsers();
                var apiUsers = _autoMapper.Map<List<User>>(svcUsers);
                return new OkObjectResult(new AGDevXWebResponse<List<User>>
                {
                    Code = AGDevXWebResponseCodes.Success,
                    Messages = new List<AGDevXMessage>
                    {
                        new AGDevXMessage
                        {
                            Code = AGDevXMessageCodes.Information,
                            Message = $"Found { apiUsers.Count } users"
                        }
                    },
                    Value = apiUsers
                });
            }

            var svcUser = await _userService.GetUser(userId, email);
            var apiUser = _autoMapper.Map<User>(svcUser);

            return new OkObjectResult(new AGDevXWebResponse<User> {
                Code = AGDevXWebResponseCodes.Success,
                Value = apiUser
            });
        }

        [HttpGet, Route("GetUserInfo")]
        [AuthorizedScopes(Scopes.ApiAccess)]
        [LogAuthorize(Roles.AGDevXAdmin, Roles.Admin, Roles.Normal)]
        public async Task<IActionResult> GetUserInfo(Guid? userId = default, string? externalUserId = default, string? email = default)
        {
            var svcUserInfo = await _userService.GetUserInfo(userId, externalUserId, email);
            var apiUserInfo = _autoMapper.Map<UserInfo>(svcUserInfo);
            return new OkObjectResult(apiUserInfo);
        }
    }
}