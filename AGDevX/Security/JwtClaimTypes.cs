using AGDevX.Enums;

//-- https://www.iana.org/assignments/jwt/jwt.xhtml#claims

namespace AGDevX.Security
{
    public enum JwtClaimTypes
    {
        [EnumStringValue("iss")]
        Issuer,

        [EnumStringValue("sub")]
        Subject,

        [EnumStringValue("aud")]
        Audience,

        [EnumStringValue("exp")]
        Expiration,

        [EnumStringValue("nbf")]
        NotBefore,

        [EnumStringValue("iat")]
        IssuedAt,

        [EnumStringValue("jti")]
        JwtId,

        [EnumStringValue("name")]
        Name,

        [EnumStringValue("given_name")]
        GivenName,

        [EnumStringValue("family_name")]
        FamilyName,

        [EnumStringValue("middle_name")]
        MiddleName,

        [EnumStringValue("nickname")]
        Nickname,

        [EnumStringValue("preferred_username")]
        PreferredUsername,

        [EnumStringValue("profile")]
        Profile,

        [EnumStringValue("picture")]
        Picture,

        [EnumStringValue("website")]
        Website,

        [EnumStringValue("email")]
        Email,

        [EnumStringValue("email_verified")]
        EmailVerified,

        [EnumStringValue("gender")]
        Gender,

        [EnumStringValue("birthdate")]
        Birthdate,

        [EnumStringValue("zoneinfo")]
        ZoneInfo,

        [EnumStringValue("locale")]
        Locale,

        [EnumStringValue("phone_number")]
        PhoneNumber,

        [EnumStringValue("phone_number_verified")]
        PhoneNumberVerified,

        [EnumStringValue("address")]
        Address,

        [EnumStringValue("updated_at")]
        UpdatedAt,

        [EnumStringValue("azp")]
        AuthorizedParty,

        [EnumStringValue("nonce")]
        Nonce,

        [EnumStringValue("auth_time")]
        AuthTime,

        [EnumStringValue("at_hash")]
        AccessTokenHash,

        [EnumStringValue("c_hash")]
        CodeHash,

        [EnumStringValue("acr")]
        AuthenticationContextClassReference,

        [EnumStringValue("amr")]
        AuthenticationMethodsReference,

        [EnumStringValue("sid")]
        SessionId,

        [EnumStringValue("scope")]
        Scope,

        [EnumStringValue("client_id")]
        ClientId,

        [EnumStringValue("roles")]
        Roles
    }
}