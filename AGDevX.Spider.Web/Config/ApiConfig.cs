using System;
using AGDevX.Enums;
using AGDevX.Environments;

namespace AGDevX.Spider.Web.Config
{
    public class ApiConfig
    {
        public string Environment { get; set; } = EnvironmentType.Local.StringValue();
        public Api Api { get; set; } = new Api();
        public Solution Solution { get; set; } = new Solution();
        public Security Security { get; set; } = new Security();
    }

    public class Api
    {
        public string Name { get; set; } = "Spider Api";
        public string Description { get; set; } = "RESTful .NET API seed application";
    }

    public class Solution
    {
        public string[] AssemblyPrefixes { get; set; } = Array.Empty<string>();
    }

    public class Security
    {
        public string[] AllowedHosts { get; set; } = Array.Empty<string>();
        public string[] AllowedOrigins { get; set; } = Array.Empty<string>();
        public string[] AllowedMethods { get; set; } = Array.Empty<string>();
    }
}