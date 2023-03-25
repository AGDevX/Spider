using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGDevX.Spider.Service.Contracts;
using AGDevX.Spider.WebApi.AuthZ;
using AGDevX.Spider.WebApi.Models;
using AGDevX.Web.Auth.AuthZ.Attributes;
using AGDevX.Web.Responses;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AGDevX.Spider.WebApi.Controllers.v1;

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

    /// <summary>
    /// Creates a new User
    /// </summary>
    /// <param name="user">New User object</param>
    /// <returns>The UserId for the newly created User</returns>
    [HttpPost]
    [AuthorizedScopes(Scopes.ApiAccess)]
    [AuthorizedRoles(Roles.AGDevXAdmin, Roles.Admin, Roles.Normal)]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> AddUser(AddUser user)
    {
        var svcUser = _autoMapper.Map<Service.Models.AddUser>(user);
        var userId = await _userService.AddUser(svcUser);

        return new CreatedResponse<Guid>
        {
            Value = userId
        };
    }

    /// <summary>
    /// Returns a list of Users 
    /// </summary>
    /// <remarks>
    /// Returns a single user in the list if either the userId or email are provided
    /// <br />
    /// Returns all users if the userId and email are both null
    /// <br />
    /// <para><i>If both the userId and email are provided, then userId is used</i></para>
    /// </remarks>
    /// <param name="userId">GUID of the User</param>
    /// <param name="email">Email address for the User</param>
    /// <returns>A list of found Users</returns>
    [HttpGet]
    [AuthorizedScopes(Scopes.ApiAccess)]
    [AuthorizedRoles(AuthorizedRoles.Any)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid? userId = default, string? email = default)
    {
        var svcUsers = await _userService.GetUsers(userId, email);
        var apiUsers = _autoMapper.Map<List<User>>(svcUsers);
        
        if (!apiUsers.Any())
        {
            return new NotFoundResponse<List<User>>
            {
                Code = ApiResponseCode.UsersNotFound,
                Messages = new List<string> { $"Found 0 users" }
            };
        }

        return new OkResponse<List<User>>
        {
            Messages = new List<string> { $"Found { apiUsers.Count } user(s)" },
            Value = apiUsers
        };
    }

    /// <summary>
    /// Returns detailed User information
    /// </summary>
    /// <remarks>
    /// Only one paramter is required
    /// <br />
    /// <para><i>Order of precedence: userId, externalUserId, email</i></para>
    /// </remarks>
    /// <param name="userId">GUID of the User</param>
    /// <param name="externalUserId">Identifier of the User assigned by the Authentication provider</param>
    /// <param name="email">Email address for the User</param>
    [HttpGet, Route("GetUserInfo")]
    [AuthorizedScopes(Scopes.ApiAccess)]
    [AuthorizedRoles(Roles.AGDevXAdmin, Roles.Admin, Roles.Normal)]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> GetUserInfo(Guid? userId = default, string? externalUserId = default, string? email = default)
    {
        var svcUserInfo = await _userService.GetUserInfo(userId, externalUserId, email);
        var apiUserInfo = _autoMapper.Map<UserInfo>(svcUserInfo);

        return new OkResponse<UserInfo>
        {
            Value = apiUserInfo
        };
    }
}