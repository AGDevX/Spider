using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AGDevX.Web.AuthZ.OAuth
{
    public static class AddJwtOAuthExtension
    {
        public static IServiceCollection AddJwtOAuth(this IServiceCollection services, JwtOAuthConfig jwtOAuthConfig, JwtBearerEvents? jwtBearerEvents = null)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = jwtOAuthConfig.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Authority = jwtOAuthConfig.Authority;
                options.ClaimsIssuer = jwtOAuthConfig.Issuer;
                options.Audience = jwtOAuthConfig.Audience;
                options.RequireHttpsMetadata = jwtOAuthConfig.RequireHttpsMetadata;
                options.MetadataAddress = jwtOAuthConfig.OpenIDConnectDiscoveryUrl;

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    NameClaimType = jwtOAuthConfig.NameClaimType,
                    RoleClaimType = jwtOAuthConfig.RoleClaimType,
                    ClockSkew = TimeSpan.Zero,
                    ValidateIssuer = true,
                    ValidIssuers = new List<string>
                    {
                        jwtOAuthConfig.Authority,
                        jwtOAuthConfig.Issuer
                    },
                    IgnoreTrailingSlashWhenValidatingAudience = true,
                    ValidateAudience = true,
                    RequireAudience = true
                };

                if (jwtBearerEvents != null)
                {
                    options.Events = jwtBearerEvents;
                }
            });

            return services;
        }
    }
}