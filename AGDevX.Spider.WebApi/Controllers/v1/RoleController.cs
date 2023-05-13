using System.Collections.Generic;
using System.Threading.Tasks;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.WebApi.Models;
using AGDevX.Web.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1;

/// <summary>
/// Manages Roles
/// </summary>
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

    /// <summary>
    /// Returns all Roles configured for this API
    /// </summary>
    [HttpGet]
    //[AuthorizedScopes(Scopes.ApiAccess)]
    //[AuthorizedRoles(Roles.AGDevXAdmin, Roles.Admin)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> Get()
    {
        var svcRoles = await _roleService.GetRoles();
        var apiRoles = _autoMapper.Map<List<Role>>(svcRoles);

        return new OkResponse<List<Role>>
        {
            Value = apiRoles
        };
    }
}