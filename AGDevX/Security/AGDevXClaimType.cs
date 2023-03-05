using System.ComponentModel;
using AGDevX.Enums;

namespace AGDevX.Security
{
    public enum AGDevXClaimType
    {
        [Description("request_ip")]
        [EnumStringValue("request_ip")]
        RequestIp = 1,

        [Description("app_metadata")]
        [EnumStringValue("app_metadata")]
        AppMetadata = 2,

        [Description("created_at")]
        [EnumStringValue("created_at")]
        CreatedAt = 3,

        [Description("user_id")]
        [EnumStringValue("user_id")]
        UserId = 4,

        [Description("isActive")]
        [EnumStringValue("isActive")]
        IsActive = 5
    }
}