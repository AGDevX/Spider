using AutoMapper;
using Api = AGDevX.Spider.WebApi.Models;
using Svc = AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.AutoMapperProfiles
{
    public sealed class UserRoleMappings : Profile
    {
        public UserRoleMappings()
        {
            //-- Svc --> Api
            CreateMap<Svc.UserRole, Api.UserRole>().ReverseMap();
        }
    }
}