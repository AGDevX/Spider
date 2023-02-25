using AGDevX.Enums;

namespace AGDevX.Web.Response
{
    public enum AGDevXWebResponseCodes
    {
        [EnumStringValue("Success")]
        Success = 1
        
        //-- Other more specific codes than "Warning" or "Error" like "CreateUserFailed" or "UserNotFound"
    }
}