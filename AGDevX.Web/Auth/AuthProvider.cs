using System.ComponentModel;
using AGDevX.Enums;

namespace AGDevX.Web.Auth
{
    public enum AuthProvider
    {
        [Description("Auth0")]
        [EnumStringValue("Auth0")]
        Auth0 = 1
    }
}