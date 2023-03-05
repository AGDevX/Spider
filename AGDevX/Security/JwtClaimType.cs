using System.ComponentModel;
using AGDevX.Enums;

//-- https://www.iana.org/assignments/jwt/jwt.xhtml#claims

namespace AGDevX.Security;

public enum JwtClaimType
{
    [Description("iss")]
    [EnumStringValue("iss")]
    Issuer = 1,

    [Description("sub")]
    [EnumStringValue("sub")]
    Subject = 2,

    [Description("aud")]
    [EnumStringValue("aud")]
    Audience = 3,

    [Description("exp")]
    [EnumStringValue("exp")]
    Expiration = 4,

    [Description("nbf")]
    [EnumStringValue("nbf")]
    NotBefore = 5,

    [Description("iat")]
    [EnumStringValue("iat")]
    IssuedAt = 6,

    [Description("jti")]
    [EnumStringValue("jti")]
    JwtId = 7,

    [Description("name")]
    [EnumStringValue("name")]
    Name = 8,

    [Description("given_name")]
    [EnumStringValue("given_name")]
    GivenName = 9,

    [Description("family_name")]
    [EnumStringValue("family_name")]
    FamilyName = 10,

    [Description("middle_name")]
    [EnumStringValue("middle_name")]
    MiddleName = 11,

    [Description("nickname")]
    [EnumStringValue("nickname")]
    Nickname = 12,

    [Description("preferred_username")]
    [EnumStringValue("preferred_username")]
    PreferredUsername = 13,

    [Description("profile")]
    [EnumStringValue("profile")]
    Profile = 14,

    [Description("picture")]
    [EnumStringValue("picture")]
    Picture = 15,

    [Description("website")]
    [EnumStringValue("website")]
    Website = 16,

    [Description("email")]
    [EnumStringValue("email")]
    Email = 17,

    [Description("email_verified")]
    [EnumStringValue("email_verified")]
    EmailVerified = 18,

    [Description("gender")]
    [EnumStringValue("gender")]
    Gender = 19,

    [Description("birthdate")]
    [EnumStringValue("birthdate")]
    Birthdate = 20,

    [Description("zoneinfo")]
    [EnumStringValue("zoneinfo")]
    ZoneInfo = 21,

    [Description("locale")]
    [EnumStringValue("locale")]
    Locale = 22,

    [Description("phone_number")]
    [EnumStringValue("phone_number")]
    PhoneNumber = 23,

    [Description("phone_number_verified")]
    [EnumStringValue("phone_number_verified")]
    PhoneNumberVerified = 24,

    [Description("address")]
    [EnumStringValue("address")]
    Address = 25,

    [Description("updated_at")]
    [EnumStringValue("updated_at")]
    UpdatedAt = 26,

    [Description("azp")]
    [EnumStringValue("azp")]
    AuthorizedParty = 27,

    [Description("nonce")]
    [EnumStringValue("nonce")]
    Nonce = 28,

    [Description("auth_time")]
    [EnumStringValue("auth_time")]
    AuthTime = 29,

    [Description("at_hash")]
    [EnumStringValue("at_hash")]
    AccessTokenHash = 30,

    [Description("c_hash")]
    [EnumStringValue("c_hash")]
    CodeHash = 31,

    [Description("acr")]
    [EnumStringValue("acr")]
    AuthenticationContextClassReference = 32,

    [Description("amr")]
    [EnumStringValue("amr")]
    AuthenticationMethodsReference = 33,

    [Description("sid")]
    [EnumStringValue("sid")]
    SessionId = 34,

    [Description("scope")]
    [EnumStringValue("scope")]
    Scope = 35,

    [Description("client_id")]
    [EnumStringValue("client_id")]
    ClientId = 36,

    [Description("roles")]
    [EnumStringValue("roles")]
    Roles = 37
}