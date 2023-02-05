using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AGDevX.Web.AuthN.OAuth
{
    public sealed class JwtOAuthConfig
    {
        public required string AuthenticationScheme { get; set; } = JwtBearerDefaults.AuthenticationScheme;
        public required string Authority { get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
        public required bool RequireHttpsMetadata { get; set; } = true;
        public required string OpenIDConnectDiscoveryUrl { get; set; }
    }
}