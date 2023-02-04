namespace AGDevX.Web.Swagger
{
    public sealed class SwaggerConfig
    {
        public bool Enabled { get; set; } = true;
        public string Title { get; set; } = ".NET Web API";
        public string Description { get; set; } = "RESTful .NET Web API";
    }
}