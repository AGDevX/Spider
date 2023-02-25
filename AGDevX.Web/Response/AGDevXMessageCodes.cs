using System.ComponentModel;
using AGDevX.Enums;

namespace AGDevX.Web.Response
{
    public enum AGDevXMessageCodes
    {
        [EnumStringValue("Information")]
        [Description("An event that occurred during the request")]
        //-- E.g. "A role was not provided for the new user. The ___ role was used by default."
        Information = 1,

        [EnumStringValue("Warning")]
        [Description("An unexpected and recoverable or non-critical event during the request that did not prevent the request from succeeding")]
        //-- E.g. "The user was created, but a notification email could not be sent. Try resending the confirmation email."
        Warning = 2,

        [EnumStringValue("Error")]
        [Description("An unrecoverable or critical event during the request that prevented the request from succeeding")]
        //-- E.g. "Could not remove the role from this user because they need at least one role assigned"
        Error = 3,

        [EnumStringValue("Validation Error")]
        [Description("A validation check that did not pass")]
        //-- E.g. "The provided email address was invalid"
        ValidationError = 4
    }
}