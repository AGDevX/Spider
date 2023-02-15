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
    public class AuthorizedScopesAttribute : AuthorizeAttribute, IFilterFactory
    {
        public bool IsReusable => false;
        private readonly List<string> _authorizedScopes;

        public AuthorizedScopesAttribute(params string[] authorizedScopes)
        {
            _authorizedScopes = authorizedScopes.ToList();
        }

        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider)
        {
            return ActivatorUtilities.CreateInstance<AuthorizedScopesAttributeActionFilter>(serviceProvider, _authorizedScopes);
        }
    }

    public class AuthorizedScopesAttributeActionFilter : IAsyncActionFilter
    {
        private readonly List<string> _authorizedScopes;
        private readonly ILogger<AuthorizedScopesAttributeActionFilter> _logger;

        public AuthorizedScopesAttributeActionFilter(ILogger<AuthorizedScopesAttributeActionFilter> logger, List<string> authorizedScopes)
        {
            _logger = logger;
            _authorizedScopes = authorizedScopes;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!_authorizedScopes.Any())
            {
                throw new ArgumentNullException("No Authorized Scopes were provided to the AuthorizedScopes attribute");
            }

            var scopes = context.HttpContext.User.GetScopes();
            var isAuthorized = _authorizedScopes.HasCommonElement(scopes);

            _logger.LogInformation($"Authorized Scopes: { string.Join(',', _authorizedScopes) }");
            _logger.LogInformation($"User Scopes: { string.Join(',', scopes) }");
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