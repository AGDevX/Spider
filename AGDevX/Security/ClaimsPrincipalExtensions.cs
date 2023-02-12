﻿using System;
using System.Security.Claims;
using AGDevX.Enums;
using AGDevX.Exceptions;
using AGDevX.Strings;

namespace AGDevX.Security
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetIssuer(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Issuer.StringValue())
                        ?? throw new ClaimNotFoundException($"An Issuer claim was not found");
        }

        public static string GetSubject(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Subject.StringValue())
                        ?? claimsPrincipal.GetClaimValue<string>(ClaimTypes.NameIdentifier)
                        ?? throw new ClaimNotFoundException($"A Subject claim was not found");
        }

        public static string GetAudience(this ClaimsPrincipal claimsPrincipal)
        {
            //-- TODO: Could be a string or an array of strings
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Audience.StringValue())
                        ?? throw new ClaimNotFoundException($"An Audience claim was not found");
        }

        public static int GetExpiration(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<int>(JwtClaimTypes.Expiration.StringValue());
        }

        public static int GetNotBefore(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<int>(JwtClaimTypes.NotBefore.StringValue());
        }

        public static int GetIssuedAt(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<int>(JwtClaimTypes.IssuedAt.StringValue());
        }

        public static string GetJwtId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.JwtId.StringValue())
                        ?? throw new ClaimNotFoundException($"A JwtId claim was not found");
        }

        public static string GetName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Name.StringValue())
                        ?? throw new ClaimNotFoundException($"A Name claim was not found");
        }

        public static string GetGivenName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.GivenName.StringValue())
                        ?? throw new ClaimNotFoundException($"A GivenName claim was not found");
        }

        public static string GetFamilyName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.FamilyName.StringValue())
                        ?? throw new ClaimNotFoundException($"A FamilyName claim was not found");
        }

        public static string GetMiddleName(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.MiddleName.StringValue())
                        ?? throw new ClaimNotFoundException($"A MiddleName claim was not found");
        }

        public static string GetNickname(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Nickname.StringValue())
                        ?? throw new ClaimNotFoundException($"A Nickname claim was not found");
        }

        public static string GetPreferredUsername(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.PreferredUsername.StringValue())
                        ?? throw new ClaimNotFoundException($"A PreferredUsername claim was not found");
        }

        public static string GetProfile(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Profile.StringValue())
                        ?? throw new ClaimNotFoundException($"A Profile claim was not found");
        }

        public static string GetPicture(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Picture.StringValue())
                        ?? throw new ClaimNotFoundException($"A Picture claim was not found");
        }

        public static string GetWebsite(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Website.StringValue())
                        ?? throw new ClaimNotFoundException($"A Website claim was not found");
        }

        public static string? GetEmail(this ClaimsPrincipal claimsPrincipal, bool throwExceptionOnNotFound = true)
        {
            var email = claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Email.StringValue())
                        ?? claimsPrincipal.GetClaimValue<string>(ClaimTypes.Email);

            if (email == null && throwExceptionOnNotFound)
            {
                throw new ClaimNotFoundException($"An Email claim was not found");
            }

            return email;
        }

        public static bool GetEmailVerified(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<bool>(JwtClaimTypes.EmailVerified.StringValue());
        }

        public static string GetGender(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Gender.StringValue())
                        ?? throw new ClaimNotFoundException($"A Gender claim was not found");
        }

        public static string GetBirthdate(this ClaimsPrincipal claimsPrincipal)
        {
            //-- TODO: Parse into DateTime or return null
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Birthdate.StringValue())
                        ?? throw new ClaimNotFoundException($"A Birthdate claim was not found");
        }

        public static string GetZoneInfo(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.ZoneInfo.StringValue())
                        ?? throw new ClaimNotFoundException($"A ZoneInfo claim was not found");
        }

        public static string GetLocale(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Locale.StringValue())
                        ?? throw new ClaimNotFoundException($"A Locale claim was not found");
        }

        public static string GetPhoneNumber(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.PhoneNumber.StringValue())
                        ?? throw new ClaimNotFoundException($"A PhoneNumber claim was not found");
        }

        public static bool PhoneNumberVerified(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<bool>(JwtClaimTypes.PhoneNumberVerified.StringValue());
        }

        public static string GetAddress(this ClaimsPrincipal claimsPrincipal)
        {
            //-- TODO: Deserialize into an object from JSON
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Address.StringValue())
                        ?? throw new ClaimNotFoundException($"An Address claim was not found");
        }

        public static int GetUpdatedAt(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<int>(JwtClaimTypes.UpdatedAt.StringValue());
        }

        public static string GetAuthorizedParty(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.AuthorizedParty.StringValue())
                        ?? throw new ClaimNotFoundException($"An AuthorizedParty claim was not found");
        }

        public static string GetNonce(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Nonce.StringValue())
                        ?? throw new ClaimNotFoundException($"A Nonce claim was not found");
        }

        public static int GetAuthTime(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<int>(JwtClaimTypes.AuthTime.StringValue());
        }

        public static string GetAccessTokenHash(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.AccessTokenHash.StringValue())
                        ?? throw new ClaimNotFoundException($"An AccessTokenHash claim was not found");
        }

        public static string GetCodeHash(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.CodeHash.StringValue())
                        ?? throw new ClaimNotFoundException($"A CodeHash claim was not found");
        }

        public static string GetAuthenticationContextClassReference(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.AuthenticationContextClassReference.StringValue())
                        ?? throw new ClaimNotFoundException($"An AuthenticationContextClassReference claim was not found");
        }

        public static string GetAuthenticationMethodsReference(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.AuthenticationMethodsReference.StringValue())
                        ?? throw new ClaimNotFoundException($"An AuthenticationMethodsReference claim was not found");
        }

        public static string GetSessionId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.SessionId.StringValue())
                        ?? throw new ClaimNotFoundException($"A SessionId claim was not found");
        }

        public static string GetScope(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Scope.StringValue())
                        ?? throw new ClaimNotFoundException($"A Scope claim was not found");
        }

        public static string GetClientId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.ClientId.StringValue())
                        ?? throw new ClaimNotFoundException($"A ClientId claim was not found");
        }

        public static string GetRoles(this ClaimsPrincipal claimsPrincipal)
        {
            //-- TODO: Parse into array
            return claimsPrincipal.GetClaimValue<string>(JwtClaimTypes.Roles.StringValue())
                        ?? throw new ClaimNotFoundException($"A Roles claim was not found");
        }

        private static T? GetClaimValue<T>(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            var claim = claimsPrincipal.GetClaim(claimType);

            if (claim == null)
            {
                return default;
            }

            return (T)Convert.ChangeType(claim.Value, typeof(T));
        }

        private static Claim? GetClaim(this ClaimsPrincipal claimsPrincipal, string claimType)
        {
            if (!claimsPrincipal.HasClaim(c => c.Type.EqualsIgnoreCase(claimType)))
            {
                return default;
            }

            return claimsPrincipal.FindFirst(claimType)!;
        }
    }
}