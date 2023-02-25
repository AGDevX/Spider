using System.Collections.Generic;

namespace AGDevX.Web.Response
{
    public sealed class AGDevXMessage
    {
        public required AGDevXMessageCodes Code { get; set; }
        public required string Message { get; set; }
    }
}