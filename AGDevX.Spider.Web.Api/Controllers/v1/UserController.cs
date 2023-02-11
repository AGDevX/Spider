using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Guids;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.Web.Api.Models;
using AGDevX.Strings;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Web.Api.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserController : ControllerBase
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

        [HttpGet]
        public async Task<IActionResult> Get(Guid? userId = default, string? email = default)
        {
            if (userId.IsNullOrEmpty() && email.IsNullOrWhiteSpace())
            {
                var svcUsers = await _userService.GetUsers();
                var apiUsers = _autoMapper.Map<List<User>>(svcUsers);
                return Ok(apiUsers);
            }

            var svcUser = await _userService.GetUser(userId, email);
            var apiUser = _autoMapper.Map<User>(svcUser);
            return Ok(apiUser);
        }
    }
}