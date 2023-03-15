using System.ComponentModel;
using AGDevX.Enums;

namespace AGDevX.Security;

public enum Auth0ClaimType
{
    [Description("gty")]
    [EnumStringValue("gty")]
    GrantType = 1
}