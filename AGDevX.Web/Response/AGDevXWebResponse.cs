using System.Collections.Generic;

namespace AGDevX.Web.Response
{
    public sealed class AGDevXWebResponse<T>
    {
        public required AGDevXWebResponseCodes Code { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
        public T? Value { get; set; } = default;
    }
}