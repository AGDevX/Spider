using AGDevX.Enums;

namespace AGDevX.Security
{
    public enum AGDevXClaimTypes
    {
        [EnumStringValue("request_ip")]
        RequestIp,

        [EnumStringValue("app_metadata")]
        AppMetadata,

        [EnumStringValue("created_at")]
        CreatedAt,

        [EnumStringValue("user_id")]
        UserId,

        [EnumStringValue("isActive")]
        IsActive
    }
}