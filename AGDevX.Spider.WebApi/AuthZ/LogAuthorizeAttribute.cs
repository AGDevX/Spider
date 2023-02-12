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

namespace AGDevX.Spider.WebApi.AuthZ
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class LogAuthorizeAttribute : AuthorizeAttribute, IFilterFactory
    {
        public bool IsReusable => false;
        private readonly List<string> _authorizedRoles;

        public LogAuthorizeAttribute(params string[] authorizedRoles)
        {
            _authorizedRoles = authorizedRoles.ToList();
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return ActivatorUtilities.CreateInstance<LogAuthorizeAttributeActionFilter>(serviceProvider, _authorizedRoles);
        }
    }

    public class LogAuthorizeAttributeActionFilter : IAsyncActionFilter
    {
        private readonly List<string> _authorizedRoles;
        private readonly ILogger<LogAuthorizeAttributeActionFilter> _logger;

        public LogAuthorizeAttributeActionFilter(ILogger<LogAuthorizeAttributeActionFilter> logger, List<string> authorizedRoles)
        {
            _logger = logger;
            _authorizedRoles = authorizedRoles;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var userRoles = context.HttpContext.User.GetRoles();
            var isAuthorized = _authorizedRoles.HasCommonElement(userRoles);

            _logger.LogInformation($"Authorized Roles: { string.Join(',', _authorizedRoles) }");
            _logger.LogInformation($"User Roles: { string.Join(',', userRoles) }");
            _logger.LogInformation($"IsAuthorized: { isAuthorized }");

            if (!isAuthorized)
            {
                context.Result = new ForbidResult();
                return;
            }

            await next();
        }
    }
}