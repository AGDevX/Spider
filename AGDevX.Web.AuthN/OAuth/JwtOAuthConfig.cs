using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace AGDevX.Web.AuthN.OAuth
{
    public sealed class JwtOAuthConfig
    {
        public string AuthenticationScheme { get; set; } = JwtBearerDefaults.AuthenticationScheme;
        public string Authority { get; set; } = string.Empty;
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public bool RequireHttpsMetadata { get; set; } = true;
        public string OpenIDConnectDiscoveryUrl { get; set; } = string.Empty;
    }
}