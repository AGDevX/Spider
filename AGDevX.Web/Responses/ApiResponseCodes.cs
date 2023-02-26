using AGDevX.Enums;

namespace AGDevX.Web.Responses
{
    public enum ApiResponseCodes
    {
        [EnumStringValue("Success")]
        Success = 1,

        [EnumStringValue("User(s) Not Found")]
        UsersNotFound = 2

        //-- Other codes more specific than "Warning" or "Error" (e.g. "CreateUserFailed")
        //--    This is so callers know exactly what happened and can take programmatic action
    }
}