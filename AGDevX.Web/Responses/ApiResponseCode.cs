using System.ComponentModel;
using AGDevX.Enums;

namespace AGDevX.Web.Responses;

public enum ApiResponseCode
{
    [Description("Success")]
    [EnumStringValue("Success")]
    Success = 1,

    [Description("User(s) Not Found")]
    [EnumStringValue("User(s) Not Found")]
    UsersNotFound = 2

    //-- Other codes more specific than "Warning" or "Error" (e.g. "CreateUserFailed")
    //--    This is so callers know exactly what happened and can take programmatic action
}