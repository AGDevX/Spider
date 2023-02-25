using System.Collections.Generic;

namespace AGDevX.Web.Response
{
    public sealed class AGDevXWebResponse<T>
    {
        public required AGDevXWebResponseCodes Code { get; set; }
        public List<AGDevXMessage> Messages { get; set; } = new List<AGDevXMessage>();
        public T? Value { get; set; } = default;
    }
}