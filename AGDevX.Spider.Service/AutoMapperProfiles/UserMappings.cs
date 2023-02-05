using AutoMapper;
using Db = AGDevX.Spider.Database.Models;
using Svc = AGDevX.Spider.Service.Models;

namespace AGDevX.Spider.Service.AutoMapperProfiles
{
    public sealed class UserMappings : Profile
    {
        public UserMappings()
        {
            //-- Database --> Service
            CreateMap<Db.User, Svc.User>().ReverseMap();
        }
    }
}