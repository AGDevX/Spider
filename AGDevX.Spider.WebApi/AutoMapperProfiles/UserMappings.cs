using AutoMapper;
using Api = AGDevX.Spider.WebApi.Models;
using Svc = AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.AutoMapperProfiles
{
    public sealed class UserMappings : Profile
    {
        public UserMappings()
        {
            //-- Svc --> Api
            CreateMap<Svc.User, Api.User>().ReverseMap();
        }
    }
}