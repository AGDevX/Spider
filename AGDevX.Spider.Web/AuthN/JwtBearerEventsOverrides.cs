using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AGDevX.Spider.Web.AuthN
{
    public class JwtBearerEventsOverrides : JwtBearerEvents
    {
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public override async Task Challenge(JwtBearerChallengeContext context)
        {
        }

        public override async Task MessageReceived(MessageReceivedContext context)
        {
        }

        public override async Task TokenValidated(TokenValidatedContext context)
        {
        }

        public override async Task Forbidden(ForbiddenContext context)
        {
        }

        public override async Task AuthenticationFailed(AuthenticationFailedContext context)
        {
        }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
    }
}