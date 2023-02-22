using System;

namespace AGDevX.Web.Auth0.ConfidentialClient.Models
{
    public class ConfidentialClientOptions
    {
        public required Uri RequestUri { get; set; }
        public required TokenRequest TokenRequest { get; set; }
    }
}