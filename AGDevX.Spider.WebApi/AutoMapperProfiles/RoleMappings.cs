using AutoMapper;
using Api = AGDevX.Spider.WebApi.Models;
using Svc = AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.AutoMapperProfiles
{
    public sealed class RoleMappings : Profile
    {
        public RoleMappings()
        {
            //-- Svc --> Api
            CreateMap<Svc.Role, Api.Role>().ReverseMap();
        }
    }
}