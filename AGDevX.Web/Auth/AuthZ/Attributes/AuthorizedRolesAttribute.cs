using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AGDevX.IEnumerables;
using AGDevX.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AGDevX.Web.Auth.AuthZ.Attributes;

public static class AuthorizedRoles
{
    public const string Any = "ANY";
}

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
public class AuthorizedRolesAttribute : AuthorizeAttribute, IFilterFactory
{
    public bool IsReusable => false;

    private readonly List<string> _authorizedRoles;

    public AuthorizedRolesAttribute(params string[] authorizedRoles)
    {
        _authorizedRoles = authorizedRoles.ToList();
    }

    public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
    {
        return ActivatorUtilities.CreateInstance<AuthorizedRolesAttributeActionFilter>(serviceProvider, _authorizedRoles);
    }
}

public class AuthorizedRolesAttributeActionFilter : IAsyncActionFilter
{
    private readonly ILogger<AuthorizedRolesAttributeActionFilter> _logger;
    private readonly List<string> _authorizedRoles;

    public AuthorizedRolesAttributeActionFilter(ILogger<AuthorizedRolesAttributeActionFilter> logger, List<string> authorizedRoles)
    {
        _logger = logger;
        _authorizedRoles = authorizedRoles;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!_authorizedRoles.Any())
        {
            throw new ArgumentNullException("No Authorized Roles were provided to the LogAuthorize attribute");
        }

        var userRoles = context.HttpContext.User.GetRoles();
        var isAuthorized = _authorizedRoles.HasCommonStringElement(userRoles)
                            || _authorizedRoles.ContainsStringIgnoreCase(AuthorizedRoles.Any) && userRoles.Any();

        _logger.LogInformation($"Authorized Roles: {string.Join(',', _authorizedRoles)}");
        _logger.LogInformation($"User Roles: {string.Join(',', userRoles)}");
        _logger.LogInformation($"IsAuthorized: {isAuthorized}");

        if (!isAuthorized)
        {
            context.Result = new ForbidResult();
            return;
        }

        await next();
    }
}