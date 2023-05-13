using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AGDevX.Enums;
using AGDevX.Exceptions;
using AGDevX.IEnumerables;
using AGDevX.Strings;

namespace AGDevX.Security;

public static class ClaimsPrincipalExtensions
{
    public static string GetIssuer(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Issuer.StringValue())
                    ?? throw new ClaimNotFoundException($"An Issuer claim was not found");
    }

    public static string? GetSubject(this ClaimsPrincipal claimsPrincipal, bool throwExceptionWhenMissing = true)
    {
        var subject = claimsPrincipal.GetClaimValue<string>(JwtClaimType.Subject.StringValue())
                        ?? claimsPrincipal.GetClaimValue<string>(ClaimTypes.NameIdentifier)
                        ?? throw new ClaimNotFoundException($"A Subject claim was not found");

        if (subject.IsNullOrWhiteSpace() && throwExceptionWhenMissing)
        {
            throw new ClaimNotFoundException($"A Subject claim was not found");
        }

        return subject;
    }

    public static List<string> GetAudiences(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValues<string>(JwtClaimType.Audience.StringValue())
                    ?? throw new ClaimNotFoundException($"An Audience claim was not found");
    }

    public static int GetExpiration(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<int>(JwtClaimType.Expiration.StringValue());
    }

    public static int GetNotBefore(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<int>(JwtClaimType.NotBefore.StringValue());
    }

    public static int GetIssuedAt(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<int>(JwtClaimType.IssuedAt.StringValue());
    }

    public static string GetJwtId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.JwtId.StringValue())
                    ?? throw new ClaimNotFoundException($"A JwtId claim was not found");
    }

    public static string GetName(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Name.StringValue())
                    ?? throw new ClaimNotFoundException($"A Name claim was not found");
    }

    public static string GetGivenName(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.GivenName.StringValue())
                    ?? claimsPrincipal.GetClaimValue<string>(ClaimTypes.GivenName)
                    ?? throw new ClaimNotFoundException($"A Given Name claim was not found");
    }

    public static string GetFamilyName(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.FamilyName.StringValue())
                    ?? claimsPrincipal.GetClaimValue<string>(ClaimTypes.Surname)
                    ?? throw new ClaimNotFoundException($"A Family Name claim was not found");
    }

    public static string? GetMiddleName(this ClaimsPrincipal claimsPrincipal, bool throwExceptionWhenMissing = true)
    {
        var middleName = claimsPrincipal.GetClaimValue<string>(JwtClaimType.MiddleName.StringValue());

        if (middleName.IsNullOrWhiteSpace() && throwExceptionWhenMissing)
        {
            throw new ClaimNotFoundException($"A Middle Name claim was not found");
        }

        return middleName;
    }

    public static string GetNickname(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Nickname.StringValue())
                    ?? throw new ClaimNotFoundException($"A Nickname claim was not found");
    }

    public static string GetPreferredUsername(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.PreferredUsername.StringValue())
                    ?? throw new ClaimNotFoundException($"A Preferred Username claim was not found");
    }

    public static string GetProfile(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Profile.StringValue())
                    ?? throw new ClaimNotFoundException($"A Profile claim was not found");
    }

    public static string GetPicture(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Picture.StringValue())
                    ?? throw new ClaimNotFoundException($"A Picture claim was not found");
    }

    public static string GetWebsite(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Website.StringValue())
                    ?? throw new ClaimNotFoundException($"A Website claim was not found");
    }

    public static string? GetEmail(this ClaimsPrincipal claimsPrincipal, bool throwExceptionWhenMissing = true)
    {
        var email = claimsPrincipal.GetClaimValue<string>(JwtClaimType.Email.StringValue())
                    ?? claimsPrincipal.GetClaimValue<string>(ClaimTypes.Email);

        if (email.IsNullOrWhiteSpace() && throwExceptionWhenMissing)
        {
            throw new ClaimNotFoundException($"An Email claim was not found");
        }

        return email;
    }

    public static bool GetEmailVerified(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<bool>(JwtClaimType.EmailVerified.StringValue());
    }

    public static string GetGender(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Gender.StringValue())
                    ?? throw new ClaimNotFoundException($"A Gender claim was not found");
    }

    public static string GetBirthdate(this ClaimsPrincipal claimsPrincipal)
    {
        //-- TODO: Parse into DateTime or return null
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Birthdate.StringValue())
                    ?? throw new ClaimNotFoundException($"A Birthdate claim was not found");
    }

    public static string GetZoneInfo(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.ZoneInfo.StringValue())
                    ?? throw new ClaimNotFoundException($"A ZoneInfo claim was not found");
    }

    public static string GetLocale(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Locale.StringValue())
                    ?? throw new ClaimNotFoundException($"A Locale claim was not found");
    }

    public static string GetPhoneNumber(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.PhoneNumber.StringValue())
                    ?? throw new ClaimNotFoundException($"A PhoneNumber claim was not found");
    }

    public static bool PhoneNumberVerified(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<bool>(JwtClaimType.PhoneNumberVerified.StringValue());
    }

    public static string GetAddress(this ClaimsPrincipal claimsPrincipal)
    {
        //-- TODO: Deserialize into an object from JSON
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Address.StringValue())
                    ?? throw new ClaimNotFoundException($"An Address claim was not found");
    }

    public static int GetUpdatedAt(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<int>(JwtClaimType.UpdatedAt.StringValue());
    }

    public static string GetAuthorizedParty(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.AuthorizedParty.StringValue())
                    ?? throw new ClaimNotFoundException($"An AuthorizedParty claim was not found");
    }

    public static string GetNonce(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.Nonce.StringValue())
                    ?? throw new ClaimNotFoundException($"A Nonce claim was not found");
    }

    public static int GetAuthTime(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<int>(JwtClaimType.AuthTime.StringValue());
    }

    public static string GetAccessTokenHash(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.AccessTokenHash.StringValue())
                    ?? throw new ClaimNotFoundException($"An AccessTokenHash claim was not found");
    }

    public static string GetCodeHash(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.CodeHash.StringValue())
                    ?? throw new ClaimNotFoundException($"A CodeHash claim was not found");
    }

    public static string GetAuthenticationContextClassReference(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.AuthenticationContextClassReference.StringValue())
                    ?? throw new ClaimNotFoundException($"An AuthenticationContextClassReference claim was not found");
    }

    public static string GetAuthenticationMethodsReference(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.AuthenticationMethodsReference.StringValue())
                    ?? throw new ClaimNotFoundException($"An AuthenticationMethodsReference claim was not found");
    }

    public static string GetSessionId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.SessionId.StringValue())
                    ?? throw new ClaimNotFoundException($"A SessionId claim was not found");
    }

    public static List<string> GetScopes(this ClaimsPrincipal claimsPrincipal)
    {
        var scopeStr = claimsPrincipal.GetClaimValue<string>(JwtClaimType.Scope.StringValue())
                            ?? throw new ClaimNotFoundException($"A Scope claim was not found");

        var scopes = scopeStr.Split(' ').ToList();
        return scopes;
    }

    public static string GetClientId(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(JwtClaimType.ClientId.StringValue())
                    ?? throw new ClaimNotFoundException($"A ClientId claim was not found");
    }

    public static List<string> GetRoles(this ClaimsPrincipal claimsPrincipal)
    {
        var rolesStr = claimsPrincipal.GetClaimValue<string>(JwtClaimType.Roles.StringValue())
                            ?? throw new ClaimNotFoundException($"A Roles claim was not found");

        var roles = rolesStr.Split(' ').ToList();
        return roles;
    }

    public static string? GetExternalId(this ClaimsPrincipal claimsPrincipal, bool throwExceptionWhenMissing = true)
    {
        var externalId = claimsPrincipal.GetSubject(false)
                            ?? claimsPrincipal.GetClaimValue<string>(CustomClaimType.UserId.StringValue());

        if (externalId.IsNullOrWhiteSpace() && throwExceptionWhenMissing)
        {
            throw new ClaimNotFoundException($"An External Id claim was not found");
        }

        return externalId;
    }

    public static bool IsActive(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<bool>(CustomClaimType.IsActive.StringValue());
    }

    public static string GetGrantType(this ClaimsPrincipal claimsPrincipal)
    {
        return claimsPrincipal.GetClaimValue<string>(Auth0ClaimType.GrantType.StringValue())
                    ?? throw new ClaimNotFoundException($"A Grant Type claim was not found");
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
        if (claimType.IsNullOrWhiteSpace())
        {
            return default;
        }

        if (!claimsPrincipal.HasClaim(c => c.Type.EqualsIgnoreCase(claimType)))
        {
            return default;
        }

        return claimsPrincipal.FindFirst(claimType)!;
    }

    private static List<T>? GetClaimValues<T>(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        var claims = claimsPrincipal.GetClaims(claimType);

        if (claims!.IsNullOrEmpty())
        {
            return default;
        }

        return claims!.Select(c => (T)Convert.ChangeType(c.Value, typeof(T))).ToList();
    }

    private static List<Claim>? GetClaims(this ClaimsPrincipal claimsPrincipal, string claimType)
    {
        if (claimType.IsNullOrWhiteSpace())
        {
            return default;
        }

        if (!claimsPrincipal.HasClaim(c => c.Type.EqualsIgnoreCase(claimType)))
        {
            return default;
        }

        return claimsPrincipal.FindAll(claimType).ToList()!;
    }
}