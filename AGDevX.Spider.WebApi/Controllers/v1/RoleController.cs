using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.WebApi.AuthZ;
using AGDevX.Spider.WebApi.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1
{
    [ApiController]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public sealed class RoleController : ControllerBase
    {
        private readonly ILogger<RoleController> _logger;
        private readonly IMapper _autoMapper;
        private readonly IRoleService _roleService;

        public RoleController(ILogger<RoleController> logger, IMapper autoMapper, IRoleService roleService)
        {
            _logger = logger;
            _autoMapper = autoMapper;
            _roleService = roleService;
        }

        [HttpGet]
        [AuthorizedScopes(Scopes.ApiAccess)]
        [LogAuthorize(Roles.AGDevXAdmin, Roles.Admin)]
        public async Task<IActionResult> Get()
        {
            var svcRoles = await _roleService.GetRoles();
            var apiRoles = _autoMapper.Map<List<Role>>(svcRoles);
            return Ok(apiRoles);
        }
    }
}