using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.Web.Api.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.Web.Api.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class UserRoleController : ControllerBase
    {
        private readonly ILogger<UserRoleController> _logger;
        private readonly IMapper _autoMapper;
        private readonly IUserRoleService _userRoleService;

        public UserRoleController(ILogger<UserRoleController> logger, IMapper autoMapper, IUserRoleService userRoleService)
        {
            _logger = logger;
            _autoMapper = autoMapper;
            _userRoleService = userRoleService;
        }

        [HttpGet]
        public async Task<IActionResult> Get(Guid userId)
        {
            var svcUserRoles = await _userRoleService.GetUserRoles(userId);
            var apiUserRoles = _autoMapper.Map<List<UserRole>>(svcUserRoles);
            return Ok(apiUserRoles);
        }
    }
}