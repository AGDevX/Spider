namespace AGDevX.Web.Auth0.ConfidentialClient.Models
{
    public class TokenRequest
    {
        public required string client_id { get; set; }
        public required string client_secret { get; set; }
        public required string audience { get; set; }
        public required string grant_type { get; set; }
    }
}